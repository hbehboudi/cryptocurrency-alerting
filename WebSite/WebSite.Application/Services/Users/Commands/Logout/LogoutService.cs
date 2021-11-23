using Microsoft.AspNetCore.Identity;
using WebSite.Common.Dto;
using WebSite.Domain.Entities.Users;

namespace WebSite.Application.Services.Users.Commands.Logout
{
    public class LogoutService : ILogoutService
    {
        private readonly SignInManager<User> signInManager;

        public LogoutService(SignInManager<User> signInManager) =>
            this.signInManager = signInManager;

        public ResultDto Execute()
        {
            signInManager.SignOutAsync();
            return new ResultDto(true, "Logout Successful.");
        }
    }
}
