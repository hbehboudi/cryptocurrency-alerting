using WebSite.Common.Dto;

namespace WebSite.Application.Services.Rules.Commands.AddRule
{
    public interface IAddRuleService
    {
        ResultDto Execute(AddRuleRequest request);
    }
}
