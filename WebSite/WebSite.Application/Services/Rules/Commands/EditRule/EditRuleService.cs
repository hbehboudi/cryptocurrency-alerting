using System.Linq;
using WebSite.Application.Interfaces.Contexts;
using WebSite.Common.Dto;

namespace WebSite.Application.Services.Rules.Commands.EditRule
{
    public class EditRuleService : IEditRuleService
    {
        private readonly IDataBaseContext dataBaseContext;

        public EditRuleService(IDataBaseContext dataBaseContext) =>
            this.dataBaseContext = dataBaseContext;

        public ResultDto Execute(EditRuleRequest request)
        {
            var rule = dataBaseContext.Rules.FirstOrDefault(x => x.Id == request.Id);

            if (rule == null)
            {
                return new ResultDto(false, "Rule is not available.");
            }

            if (rule.Owner != request.Owner)
            {
                return new ResultDto(false, "User access is not allowed.");
            }

            rule.Name = request.Name;
            rule.Symbol = request.Symbol;
            rule.Description = request.Description;
            rule.Indicator = request.Indicator;
            rule.MorePriceType = request.MorePriceType;
            rule.LessPriceType = request.LessPriceType;
            rule.MorePeriod = request.MorePeriod;
            rule.LessPeriod = request.LessPeriod;

            dataBaseContext.SaveChanges();

            return new ResultDto(true, "Rule edited successfully.");
        }
    }
}
