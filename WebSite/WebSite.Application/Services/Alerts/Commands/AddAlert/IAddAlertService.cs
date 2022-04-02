using WebSite.Common.Dto;

namespace WebSite.Application.Services.Alerts.Commands.AddAlert
{
    public interface IAddAlertService
    {
        ResultDto Execute(AddAlertRequest request);
    }
}
