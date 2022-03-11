using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            if (!string.IsNullOrEmpty(request.SearchValue))
            {
                rules = rules.Where(x =>
                    x.Name.ToLower().Contains(request.SearchValue) ||
                    x.Description.ToLower().Contains(request.SearchValue) ||
                    x.Owner.ToLower().Contains(request.SearchValue));
            }

            var getRuleDtos = rules
                .Where(x => string.IsNullOrEmpty(request.SearchValue) ||
                    x.Name.ToLower().Contains(request.SearchValue) ||
                    x.Description.ToLower().Contains(request.SearchValue) ||
                    x.Symbol.ToLower().Contains(request.SearchValue) ||
                    x.Indicator.ToLower().Contains(request.SearchValue))
                .ToPaged(request.Page, request.Size, out var rowsCount)
                .Select(x => new GetRuleDto(x.Id, x.Owner, x.Name, x.Symbol, x.Description, x.Indicator,
                    x.MorePriceType, x.LessPriceType, x.MorePeriod, x.LessPeriod))
                .ToList();

            var result = new ResultGetRuleDto(rowsCount, getRuleDtos);

            return new ResultDto<ResultGetRuleDto>(true, "List returned successfully.", result);
        }
    }
}
