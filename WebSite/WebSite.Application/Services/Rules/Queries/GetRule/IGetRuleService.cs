using WebSite.Common.Dto;

namespace WebSite.Application.Services.Rules.Queries.GetRule
{
    public interface IGetRuleService
    {
        ResultDto<ResultGetRuleListDto> Execute(GetRuleListRequest request);

        ResultDto<ResultGetRuleListDto> Execute();

        ResultDto<ResultGetRuleDto> Execute(GetRuleRequest request);
    }
}
