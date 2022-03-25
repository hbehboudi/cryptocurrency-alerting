using System.ComponentModel.DataAnnotations;

namespace EndPoint.Site.Models.ViewModels.Account
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

    }
}
