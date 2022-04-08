using WebSite.Common.Dto;

namespace WebSite.Application.Services.Rules.Commands.EditRule
{
    public interface IEditRuleService
    {
        ResultDto Execute(EditRuleRequest request);
    }
}
