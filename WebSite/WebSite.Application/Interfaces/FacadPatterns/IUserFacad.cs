using WebSite.Application.Services.Users.Commands.EditProfile;
using WebSite.Application.Services.Users.Commands.ForgotPassword;
using WebSite.Application.Services.Users.Commands.Login;
using WebSite.Application.Services.Users.Commands.Logout;
using WebSite.Application.Services.Users.Commands.Register;
using WebSite.Application.Services.Users.Queries.GetProfile;

namespace WebSite.Application.Interfaces.FacadPatterns
{
    public interface IUserFacad
    {
        IRegisterService RegisterService { get; }

        ILoginService LoginService { get; }

        ILogoutService LogoutService { get; }

        IForgotPasswordService ForgotPasswordService { get; }

        IEditProfileService EditProfileService { get; }

        IGetProfileService GetProfileService { get; }
    }
}
