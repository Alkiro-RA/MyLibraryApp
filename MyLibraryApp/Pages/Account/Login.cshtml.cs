using Microsoft.AspNetCore.Authentication;
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
        private readonly LibraryDbContext _dbContext;
        private readonly ISecurityContext _security;

        public LoginModel(LibraryDbContext dbContext, ISecurityContext security)
        {
            _dbContext = dbContext;
            _security = security;
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

            var user = _dbContext
                .User
                .FirstOrDefault(u => u.Email == User.Email);

            if (user == null)
            {
                ViewData["Fail"] = "Wrong email or password.";
                return Page();
            }

            if (user.Email == User.Email && user.Password == User.Password)
            {
                await HttpContext.SignInAsync("CookieAuthentication", _security.CreateSecurityContext(user));
                return RedirectToPage("/Index");
            }
            else
            {
                ViewData["Fail"] = "Wrong email or password.";
                return Page();
            }
        }
    }
}

