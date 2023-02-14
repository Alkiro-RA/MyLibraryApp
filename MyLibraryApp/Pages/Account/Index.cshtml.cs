using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyLibraryApp.Model;

namespace MyLibraryApp.Pages.Account
{
    [Authorize(Policy = "LoggedInUsersOnly")]
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
