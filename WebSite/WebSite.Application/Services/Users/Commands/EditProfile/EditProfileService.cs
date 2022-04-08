using Microsoft.AspNetCore.Identity;
using WebSite.Common.Dto;
using WebSite.Domain.Entities.Users;
using System.Linq;

namespace WebSite.Application.Services.Users.Commands.EditProfile
{
    public class EditProfileService : IEditProfileService
    {
        private readonly UserManager<User> userManager;

        public EditProfileService(UserManager<User> userManager) =>
            this.userManager = userManager;

        public ResultDto Execute(EditProfileRequest request)
        {
            var user = userManager.FindByNameAsync(request.Email).Result;

            if (user == null)
            {
                return new ResultDto(false, "کاربری با این ایمیل موجود نیست");
            }

            user.Name = request.Name;
            user.PhoneNumber = request.PhoneNumber;

            var result = userManager.UpdateAsync(user).Result;

            if (result.Succeeded)
            {
                return new ResultDto(true, "Profile edited successfully.");
            }

            var errorMessage = string.Join("\n", result.Errors.Select(x => x.Description));
            return new ResultDto(false, errorMessage);
        }
    }
}
