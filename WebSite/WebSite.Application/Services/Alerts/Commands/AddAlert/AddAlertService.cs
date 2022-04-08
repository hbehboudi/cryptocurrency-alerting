using WebSite.Application.Interfaces.Contexts;
using WebSite.Common.Dto;
using WebSite.Domain.Entities.Alert;

namespace WebSite.Application.Services.Alerts.Commands.AddAlert
{
    public class AddAlertService : IAddAlertService
    {
        private readonly IDataBaseContext dataBaseContext;

        public AddAlertService(IDataBaseContext dataBaseContext) =>
            this.dataBaseContext = dataBaseContext;

        public ResultDto Execute(AddAlertRequest request)
        {
            var alert = new Alert
            {
                RuleId = request.RuleId,
                Price = request.Price,
                Time = request.Time
            };

            dataBaseContext.Alerts.Add(alert);
            dataBaseContext.SaveChanges();

            return new ResultDto(true, "Alert added successfully.");
        }
    }
}
