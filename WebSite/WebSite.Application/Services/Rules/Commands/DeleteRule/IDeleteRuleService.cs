using WebSite.Common.Dto;

namespace WebSite.Application.Services.Rules.Commands.DeleteRule
{
    public interface IDeleteRuleService
    {
        ResultDto Execute(DeleteRuleRequest request);
    }
}
