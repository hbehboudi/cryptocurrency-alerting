using Microsoft.AspNetCore.Identity;

namespace WebSite.Domain.Entities.Users
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
    }
}
