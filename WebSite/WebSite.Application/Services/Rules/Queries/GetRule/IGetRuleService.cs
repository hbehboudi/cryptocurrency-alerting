using WebSite.Common.Dto;

namespace WebSite.Application.Services.Rules.Queries.GetRule
{
    public interface IGetRuleService
    {
        ResultDto<ResultGetRuleDto> Execute(GetRuleRequest request);

        ResultDto<GetRuleDto> Execute(GetItemRequest request);
    }
}
