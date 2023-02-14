using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyLibraryApp.Data;
using MyLibraryApp.Model;

namespace MyLibraryApp.Pages.Account
{
    [Authorize(Policy = "AdminOnly")]
    public class RegisterAdminModel : PageModel
    {
        [BindProperty]
        public User User { get; set; }
        private readonly LibraryDbContext _context;

        public RegisterAdminModel(LibraryDbContext context)
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
                User.RoleId = 2;
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
