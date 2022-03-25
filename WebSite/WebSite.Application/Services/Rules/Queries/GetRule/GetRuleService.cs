using System.Linq;
using WebSite.Application.Interfaces.Contexts;
using WebSite.Common.Dto;
using WebSite.Common.Util;

namespace WebSite.Application.Services.Rules.Queries.GetRule
{
    public class GetRuleService : IGetRuleService
    {
        private readonly IDataBaseContext dataBaseContext;

        public GetRuleService(IDataBaseContext dataBaseContext) =>
            this.dataBaseContext = dataBaseContext;

        public ResultDto<ResultGetRuleDto> Execute(GetRuleRequest request)
        {
            var rules = dataBaseContext.Rules.AsQueryable();

            var user = dataBaseContext.Users.FirstOrDefault(x => x.UserName == request.Owner);

            if (user == null)
            {
                return new ResultDto<ResultGetRuleDto>(false, "No user available.", null);
            }

            var getRuleDtos = rules
                .Where(x => x.Owner.Equals(user.UserName))
                .ToPaged(request.Page, request.Size, out var rowsCount)
                .Select(x => new GetRuleDto(x.Id, x.Owner, x.Name, x.Symbol, x.Description, x.Indicator,
                    x.MorePriceType, x.LessPriceType, x.MorePeriod, x.LessPeriod))
                .ToList();

            var result = new ResultGetRuleDto(rowsCount, getRuleDtos);

            return new ResultDto<ResultGetRuleDto>(true, "List returned successfully.", result);
        }

        public ResultDto<GetRuleDto> Execute(GetItemRequest request)
        {
            var user = dataBaseContext.Users.FirstOrDefault(x => x.UserName == request.Owner);

            if (user == null)
            {
                return new ResultDto<GetRuleDto>(false, "No user available.", null);
            }

            var rule = dataBaseContext.Rules.AsQueryable()
                .FirstOrDefault(x => x.Id == request.Id && x.Owner == request.Owner);

            if (rule == null)
            {
                return new ResultDto<GetRuleDto>(false, "Rule is not available.", null);
            }

            var getRuleDto = new GetRuleDto(rule.Id, rule.Owner, rule.Name, rule.Symbol, rule.Description,
                rule.Indicator, rule.MorePriceType, rule.LessPriceType, rule.MorePeriod, rule.LessPeriod);

            return new ResultDto<GetRuleDto>(true, "Rule returned successfully.", getRuleDto);
        }
    }
}
