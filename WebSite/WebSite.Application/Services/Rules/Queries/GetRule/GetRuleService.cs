using System;
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

        public ResultDto<ResultGetRuleListDto> Execute(GetRuleListRequest request)
        {
            var rules = dataBaseContext.Rules.AsQueryable();

            var user = dataBaseContext.Users.FirstOrDefault(x => x.UserName == request.Owner);

            if (user == null)
            {
                return new ResultDto<ResultGetRuleListDto>(false, "No user available.", null);
            }

            var resultGetRuleDtos = rules
                .Where(x => x.Owner.Equals(user.UserName))
                .ToPaged(request.Page, request.Size, out var rowsCount)
                .Select(x => new ResultGetRuleDto(x.Id, x.Owner, x.Name, x.Symbol, x.Description, x.Indicator,
                    x.MorePriceType, x.LessPriceType, x.MorePeriod, x.LessPeriod, ConvertTimeFrame(x.TimeFrame), ConvertCondition(x.Condition)))
                .ToList();

            var result = new ResultGetRuleListDto(rowsCount, resultGetRuleDtos);

            return new ResultDto<ResultGetRuleListDto>(true, "List returned successfully.", result);
        }

        public ResultDto<ResultGetRuleListDto> Execute()
        {
            var rules = dataBaseContext.Rules.AsQueryable();

            var resultGetRuleDtos = rules
                .Select(x => new ResultGetRuleDto(x.Id, x.Owner, x.Name, x.Symbol, x.Description, x.Indicator,
                    x.MorePriceType, x.LessPriceType, x.MorePeriod, x.LessPeriod, x.TimeFrame, x.Condition))
                .ToList();

            var result = new ResultGetRuleListDto(resultGetRuleDtos);

            return new ResultDto<ResultGetRuleListDto>(true, "List returned successfully.", result);
        }

        public ResultDto<ResultGetRuleDto> Execute(GetRuleRequest request)
        {
            var user = dataBaseContext.Users.FirstOrDefault(x => x.UserName == request.Owner);

            if (user == null)
            {
                return new ResultDto<ResultGetRuleDto>(false, "No user available.", null);
            }

            var rule = dataBaseContext.Rules.AsQueryable()
                .FirstOrDefault(x => x.Id == request.Id && x.Owner == request.Owner);

            if (rule == null)
            {
                return new ResultDto<ResultGetRuleDto>(false, "Rule is not available.", null);
            }

            var resultGetRuleDto = new ResultGetRuleDto(rule.Id, rule.Owner, rule.Name, rule.Symbol,
                rule.Description, rule.Indicator, rule.MorePriceType, rule.LessPriceType, rule.MorePeriod,
                rule.LessPeriod, rule.TimeFrame, rule.Condition);

            return new ResultDto<ResultGetRuleDto>(true, "Rule returned successfully.", resultGetRuleDto);
        }

        private static string ConvertTimeFrame(string timeFrame)
        {
            if (timeFrame == "1m")
            {
                return "۱ دقیقه‌ای";
            }

            if (timeFrame == "3m")
            {
                return "۳ دقیقه‌ای";
            }

            if (timeFrame == "5m")
            {
                return "۵ دقیقه‌ای";
            }

            if (timeFrame == "15m")
            {
                return "۱۵ دقیقه‌ای";
            }

            if (timeFrame == "30m")
            {
                return "۳۰ دقیقه‌ای";
            }

            if (timeFrame == "45m")
            {
                return "۴۵ دقیقه‌ای";
            }

            if (timeFrame == "1h")
            {
                return "۱ ساعته";
            }

            if (timeFrame == "2h")
            {
                return "۲ ساعته";
            }

            if (timeFrame == "3h")
            {
                return "۳ ساعته";
            }

            if (timeFrame == "4h")
            {
                return "۴ ساعته";
            }

            if (timeFrame == "1d")
            {
                return "۱ روزه";
            }

            if (timeFrame == "1w")
            {
                return "۱ هفته‌ای";
            }

            if (timeFrame == "1M")
            {
                return "۱ ماهه";
            }

            throw new InvalidOperationException();
        }

        private static string ConvertCondition(string condition)
        {
            if (condition == "Cross up")
            {
                return "اندیکاتور ۱ اندیکاتور ۲ را به سمت بالا قطع کند.";
            }

            if (condition == "Cross down")
            {
                return "اندیکاتور ۱ اندیکاتور ۲ را به سمت پایین قطع کند.";
            }

            throw new InvalidOperationException();
        }
    }
}
