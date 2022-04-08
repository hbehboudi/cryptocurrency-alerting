using System.ComponentModel.DataAnnotations;

namespace EndPoint.Site.Models.ViewModels.Account
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool IsPersistent { get; } = false;
    }
}
