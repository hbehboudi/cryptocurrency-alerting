using System.Collections.Generic;

namespace WebSite.Application.Services.Rules.Queries.GetRule
{
    public class ResultGetRuleListDto
    {
        public List<ResultGetRuleDto> ResultGetRuleDtos { get; }

        public int RowsCount { get; }

        public ResultGetRuleListDto(int rowsCount, List<ResultGetRuleDto> resultGetRuleDtos)
        {
            RowsCount = rowsCount;
            ResultGetRuleDtos = resultGetRuleDtos;
        }
    }
}
