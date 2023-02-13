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

        public RegisterModel(LibraryDbContext context)
        {
            _context = context;
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
                User.RoleId = 3;
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
