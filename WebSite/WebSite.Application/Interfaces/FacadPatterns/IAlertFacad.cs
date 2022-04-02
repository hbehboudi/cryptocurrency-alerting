using WebSite.Application.Services.Alerts.Queries.GetAlert;

namespace WebSite.Application.Interfaces.FacadPatterns
{
    public interface IAlertFacad
    {
        IGetAlertService GetAlertService { get; }
    }
}
