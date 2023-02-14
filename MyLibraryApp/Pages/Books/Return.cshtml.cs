using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyLibraryApp.Data;
using MyLibraryApp.Model;

namespace MyLibraryApp.Pages.Books
{
    [Authorize(Policy = "LoggedInUsersOnly")]
    public class ReturnModel : PageModel
    {
        public Book Book { get; set; }
        private readonly LibraryDbContext _context;

        public ReturnModel(LibraryDbContext context)
        {
            _context = context;
        }

        public void OnGet(int id)
        {
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            Book = _context.Book.Find(id);

            Book.MemberId = 1;

            _context.Book.Update(Book);
            await _context.SaveChangesAsync();

            TempData["Success"] = "You've returned book successfuly.";

            return RedirectToPage("/Books/Rented");
        }
    }
}
