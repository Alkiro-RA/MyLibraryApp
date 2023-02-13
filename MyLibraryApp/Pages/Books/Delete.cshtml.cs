using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyLibraryApp.Data;
using MyLibraryApp.Model;

namespace MyLibraryApp.Pages.Books
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public Book Book { get; set; }
        private readonly LibraryDbContext _context;

        public DeleteModel(LibraryDbContext dbContext)
        {
            _context = dbContext;
        }
        public void OnGet(int id)
        {
            Book = _context.Book.Find(id);
        }
        public async Task<IActionResult> OnPost()
        {
            _context.Book.Remove(Book);
            await _context.SaveChangesAsync();
            return RedirectToPage("/Books/Index");
        }
    }
}
