using Microsoft.AspNetCore.Identity;
using PasswordGenerator;
using WebSite.Application.Services.Email;
using WebSite.Common.Dto;
using WebSite.Domain.Entities.Users;
using System.Linq;

namespace WebSite.Application.Services.Users.Commands.ForgotPassword
{
    public class ForgotPasswordService : IForgotPasswordService
    {
        private readonly UserManager<User> userManager;
        private readonly IEmailService emailService;

        public ForgotPasswordService(UserManager<User> userManager, IEmailService emailService)
        {
            this.userManager = userManager;
            this.emailService = emailService;
        }

        public ResultDto Execute(ForgotPasswordRequest request)
        {
            var user = userManager.FindByNameAsync(request.Email).Result;

            if (user == null)
            {
                return new ResultDto(false, "کاربری با این ایمیل موجود نیست");
            }

            var newPassword = new Password(8).Next();

            var title = "Forgot Password Email";
            var body = $"Your new password: {newPassword}";

            emailService.Execute(request.Email, title, body);

            return ChangePassword(user, newPassword);
        }

        private ResultDto ChangePassword(User user, string newPassword)
        {
            var token = userManager.GeneratePasswordResetTokenAsync(user).Result;
            var result = userManager.ResetPasswordAsync(user, token, newPassword).Result;

            if (result.Succeeded)
            {
                return new ResultDto(true, "رمز عبور جدید برای شما ارسال شد");
            }

            var errorMessage = string.Join("\n", result.Errors.Select(x => x.Description));
            return new ResultDto(false, errorMessage);
        }
    }
}
