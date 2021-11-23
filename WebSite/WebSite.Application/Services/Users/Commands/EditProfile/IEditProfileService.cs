using WebSite.Common.Dto;

namespace WebSite.Application.Services.Users.Commands.EditProfile
{
    public interface IEditProfileService
    {
        ResultDto Execute(EditProfileRequest request);
    }
}
