using WebSite.Common.Dto;

namespace WebSite.Application.Services.Users.Commands.ForgotPassword
{
    public interface IForgotPasswordService
    {
        ResultDto Execute(ForgotPasswordRequest request);
    }
}
