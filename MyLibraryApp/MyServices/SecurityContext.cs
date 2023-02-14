using MyLibraryApp.Model;
using System.Security.Claims;

namespace MyLibraryApp.MyServices
{
    public interface ISecurityContext
    {
        ClaimsPrincipal CreateSecurityContext(User user);
    }

    public class SecurityContext : ISecurityContext
    {
        public ClaimsPrincipal CreateSecurityContext(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Id.ToString()),
                new Claim("Role", user.RoleId.ToString()) // 2 - Admin // 3 - Member
            };

            var identity = new ClaimsIdentity(claims, "CookieAuthentication");

            return new ClaimsPrincipal(identity);
        }
    }
}
