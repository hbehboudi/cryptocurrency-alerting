using WebSite.Application.Interfaces.Contexts;
using WebSite.Common.Dto;
using WebSite.Domain.Entities.Rules;

namespace WebSite.Application.Services.Rules.Commands.AddRule
{
    public class AddRuleService : IAddRuleService
    {
        private readonly IDataBaseContext dataBaseContext;

        public AddRuleService(IDataBaseContext dataBaseContext) =>
            this.dataBaseContext = dataBaseContext;

        public ResultDto Execute(AddRuleRequest request)
        {
            var rule = new Rule
            {
                Name = request.Name,
                Symbol = request.Symbol,
                Description = request.Description,
                Owner = request.Owner,
                Indicator = request.Indicator,
                MorePriceType = request.MorePriceType,
                LessPriceType = request.LessPriceType,
                MorePeriod = request.MorePeriod,
                LessPeriod = request.LessPeriod
            };

            dataBaseContext.Rules.Add(rule);
            dataBaseContext.SaveChanges();

            return new ResultDto(true, "Rule added successfully.");
        }
    }
}
