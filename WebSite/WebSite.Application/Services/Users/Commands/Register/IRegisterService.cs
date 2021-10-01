using WebSite.Common.Dto;

namespace WebSite.Application.Services.Users.Commands.Register
{
    public interface IRegisterService
    {
        ResultDto Execute(RegisterRequest request);
    }
}
