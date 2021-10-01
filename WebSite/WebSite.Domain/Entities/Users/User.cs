using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WebSite.Domain.Entities.Users
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required]
        public bool IsPublisher { get; set; }

        [Required]
        public bool IsPremium { get; set; } = false;
    }
}
