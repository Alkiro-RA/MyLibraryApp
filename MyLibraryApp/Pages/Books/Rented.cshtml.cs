using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyLibraryApp.Data;
using MyLibraryApp.Model;

namespace MyLibraryApp.Pages.Books
{
    [Authorize(Policy = "LoggedInUsersOnly")]
    public class RentedModel : PageModel
    {
        [BindProperty]
        public IEnumerable<Book> Books { get; set; }
        private readonly LibraryDbContext _context;

        public RentedModel(LibraryDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            Books = _context.Book.ToList();
        }
    }
}
