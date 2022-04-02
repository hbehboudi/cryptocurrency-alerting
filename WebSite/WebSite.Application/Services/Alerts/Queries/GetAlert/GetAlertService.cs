using System;
using System.Linq;
using WebSite.Application.Interfaces.Contexts;
using WebSite.Common.Dto;
using WebSite.Common.Util;
using WebSite.Domain.Entities.Alert;

namespace WebSite.Application.Services.Alerts.Queries.GetAlert
{
    public class GetAlertService : IGetAlertService
    {
        private readonly IDataBaseContext dataBaseContext;

        public GetAlertService(IDataBaseContext dataBaseContext) =>
            this.dataBaseContext = dataBaseContext;

        public ResultDto<ResultGetAlertListDto> Execute(GetAlertListRequest request)
        {
            var alerts = dataBaseContext.Alerts.AsQueryable();

            var user = dataBaseContext.Users.FirstOrDefault(x => x.UserName == request.Owner);

            if (user == null)
            {
                return new ResultDto<ResultGetAlertListDto>(false, "No user available.", null);
            }

            var rules = dataBaseContext.Rules.AsQueryable().Where(x => x.Owner == user.UserName).ToDictionary(x => x.Id);
            var ruleIds = rules.Keys.ToList();

            var resultGetAlertDtos = alerts
                .Where(x => ruleIds.Contains(x.RuleId))
                .ToPaged(request.Page, request.Size, out var rowsCount)
                .Select(x => new ResultGetAlertDto(x.Id, rules[x.RuleId].Name, rules[x.RuleId].Symbol, x.Price, x.Time))
                .ToList();

            var result = new ResultGetAlertListDto(rowsCount, resultGetAlertDtos);

            var alert = new Alert
            {
                RuleId = 2,
                Price = 1,
                Time = DateTime.Now
            };

            dataBaseContext.Alerts.Add(alert);
            dataBaseContext.SaveChanges();

            return new ResultDto<ResultGetAlertListDto>(true, "List returned successfully.", result);
        }
    }
}
