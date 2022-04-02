using WebSite.Application.Interfaces.Contexts;
using WebSite.Application.Interfaces.FacadPatterns;
using WebSite.Application.Services.Alerts.Queries.GetAlert;

namespace WebSite.Application.Services.Alerts.FacadPattern
{
    public class AlertFacad : IAlertFacad
    {
        private readonly IDataBaseContext dataBaseContext;

        private IGetAlertService getAlertService;

        public AlertFacad(IDataBaseContext dataBaseContext) =>
            this.dataBaseContext = dataBaseContext;

        public IGetAlertService GetAlertService
        {
            get
            {
                return getAlertService ??= new GetAlertService(dataBaseContext);
            }
        }
    }
}
