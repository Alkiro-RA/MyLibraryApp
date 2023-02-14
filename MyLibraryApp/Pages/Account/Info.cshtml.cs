using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyLibraryApp.Data;
using MyLibraryApp.Model;

namespace MyLibraryApp.Pages.Account
{
    [Authorize(Policy = "LoggedInUsersOnly")]
    public class InfoModel : PageModel
    {
        [BindProperty]
        public User User { get; set; }
        private readonly LibraryDbContext _context;

        public InfoModel(LibraryDbContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            try
            {
                int id = int.Parse(HttpContext.User.Identity.Name);
                User = _context.User.Find(id);
            }
            catch(Exception)
            {
                
            }
        }
    }
}
