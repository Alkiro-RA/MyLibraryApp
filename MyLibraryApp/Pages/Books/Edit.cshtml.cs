using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyLibraryApp.Data;
using MyLibraryApp.Model;

namespace MyLibraryApp.Pages.Books
{
    [Authorize(Policy = "AdminOnly")]
    public class EditModel : PageModel
    {
        [BindProperty]
        public Book Book { get; set; }
        private readonly LibraryDbContext _context;

        public EditModel(LibraryDbContext dbContext)
        {
            _context = dbContext;
        }
        public void OnGet(int id)
        {
            Book = _context.Book.Find(id);
        }
        public async Task<IActionResult> OnPost()
        {
            bool anyNumbers = CheckForNumbers(Book.Author);
            if (anyNumbers)
            {
                ModelState.AddModelError(Book.Author,
                    "Author field must consist of letters only.");
            }
            if (ModelState.IsValid)
            {
                _context.Book.Update(Book);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Book updated successfuly";
                return RedirectToPage("Index");
            }
            return Page();
        }
        private bool CheckForNumbers(string str)
        {
            if (str == null)
            {
                return false;

            }
            foreach (char c in str)
            {
                if (c <= '9' && c != ' ')
                    return true;
            }

            return false;
        }
    }
}
