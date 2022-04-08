using WebSite.Common.Dto;

namespace WebSite.Application.Services.Users.Commands.Login
{
    public interface ILoginService
    {
        ResultDto Execute(LoginRequest request);
    }
}
