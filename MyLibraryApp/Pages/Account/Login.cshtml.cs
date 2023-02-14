using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyLibraryApp.Data;
using MyLibraryApp.Model;
using MyLibraryApp.MyServices;

namespace MyLibraryApp.Pages.Account
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public User User { get; set; }
        private readonly LibraryDbContext _context;
        private readonly ISecurityContext _security;
        private readonly IPasswordHasher<User> _passwordHasher;

        public LoginModel(LibraryDbContext context, ISecurityContext security, IPasswordHasher<User> passwordHasher)
        {
            _context = context;
            _security = security;
            _passwordHasher = passwordHasher;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = _context
                .User
                .FirstOrDefault(u => u.Email == User.Email);

            if (user == null)
            {
                ModelState.AddModelError(User.Email,
                    "Wrong email or password.");
                return Page();
            }

            var result = _passwordHasher.VerifyHashedPassword(user, user.Password, User.Password);

            if (result == PasswordVerificationResult.Failed)
            {
                ModelState.AddModelError(User.Email,
                    "Wrong email or password.");
                return Page();
            }
            await HttpContext.SignInAsync("CookieAuthentication", _security.CreateSecurityContext(user));
            return RedirectToPage("/Index");
        }
    }
}

