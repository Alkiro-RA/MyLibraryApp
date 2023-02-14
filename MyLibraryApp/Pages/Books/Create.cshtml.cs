using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyLibraryApp.Data;
using MyLibraryApp.Model;

namespace MyLibraryApp.Pages.Books
{
    [Authorize(Policy ="AdminOnly")]
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Book Book { get; set; }
        private readonly LibraryDbContext _context;

        public CreateModel(LibraryDbContext context)
        {
            _context = context;
        }
        public void OnGet()
        {}

        public async Task<IActionResult> OnPost()
        {
            bool anyNumbers = CheckForNumbers(Book.Author);
            if (anyNumbers)
            {
                ModelState.AddModelError(string.Empty,
                    "Author field must consist of letters only.");
            }
            if (ModelState.IsValid)
            {
                if (Book.MemberId == 0)
                    Book.MemberId = 1;

                await _context.Book.AddAsync(Book);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Book added successfuly";
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
