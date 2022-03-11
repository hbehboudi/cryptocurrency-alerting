using System.Collections.Generic;

namespace WebSite.Application.Services.Rules.Queries.GetRule
{
    public class ResultGetRuleDto
    {
        public List<GetRuleDto> GetRuleDtos { get; }

        public int RowsCount { get; }

        public ResultGetRuleDto(int rowsCount, List<GetRuleDto> getRuleDtos)
        {
            RowsCount = rowsCount;
            GetRuleDtos = getRuleDtos;
        }
    }
}
