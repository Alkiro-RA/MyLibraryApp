using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyLibraryApp.Data;
using MyLibraryApp.Model;

namespace MyLibraryApp.Pages.Books
{
    [Authorize(Policy = "LoggedInUsersOnly")]
    public class IndexModel : PageModel
    {
        private readonly LibraryDbContext _context;
        public IEnumerable<Book> Books { get; set; }

        public IndexModel(LibraryDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            Books = _context.Book.ToList();
        }
    }
}
