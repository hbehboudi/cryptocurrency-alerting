using Microsoft.AspNetCore.Identity;
using WebSite.Common.Dto;
using WebSite.Domain.Entities.Users;
using System.Linq;

namespace WebSite.Application.Services.Users.Commands.Register
{
    public class RegisterService : IRegisterService
    {
        private readonly UserManager<User> userManager;

        private readonly SignInManager<User> signInManager;

        public RegisterService(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public ResultDto Execute(RegisterRequest request)
        {
            var oldUser = userManager.FindByNameAsync(request.Email).Result;

            if (oldUser != null)
            {
                return new ResultDto(false, "کاربری با این ایمیل موجود است.");
            }

            var user = new User
            {
                Name = request.Name,
                Email = request.Email,
                UserName = request.Email,
            };

            var result = userManager.CreateAsync(user, request.Password).Result;

            if (result.Succeeded)
            {
                signInManager.SignOutAsync();
                return new ResultDto(true, "ثبت‌نام با موفقیت انجام شد");
            }

            var errorMessage = string.Join("\n", result.Errors.Select(x => x.Description));
            return new ResultDto(false, errorMessage);
        }
    }
}
