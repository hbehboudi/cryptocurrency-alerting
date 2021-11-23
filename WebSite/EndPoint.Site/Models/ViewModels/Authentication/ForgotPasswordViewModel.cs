using System.ComponentModel.DataAnnotations;

namespace EndPoint.Site.Models.ViewModels.Authentication
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

    }
}
