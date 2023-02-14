using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyLibraryApp.Data;
using MyLibraryApp.Model;

namespace MyLibraryApp.Pages.Account
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public User User { get; set; }
        private readonly LibraryDbContext _context;
        private readonly IPasswordHasher<User> _passwordHasher;

        public RegisterModel(LibraryDbContext context, IPasswordHasher<User> passwordHasher)
        {
            _context = context;
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

            try
            {
                var hashedPassword = _passwordHasher.HashPassword(User, User.Password);
                User.Password = hashedPassword;
                User.RoleId = 3;    // member
                await _context.User.AddAsync(User);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                ModelState.AddModelError(User.Email,
                    "Given email is already registered.");
                return Page();
            }

            TempData["Success"] = "Registration successful.";
            return Page();
        }
    }
}
