using WebSite.Common.Dto;

namespace WebSite.Application.Services.Alerts.Queries.GetAlert
{
    public interface IGetAlertService
    {
        ResultDto<ResultGetAlertListDto> Execute(GetAlertListRequest request);
    }
}
