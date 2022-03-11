using WebSite.Application.Services.Rules.Commands.AddRule;
using WebSite.Application.Services.Rules.Commands.DeleteRule;
using WebSite.Application.Services.Rules.Commands.EditRule;
using WebSite.Application.Services.Rules.Queries.GetRule;

namespace WebSite.Application.Interfaces.FacadPatterns
{
    public interface IRuleFacad
    {
        IAddRuleService AddRuleService { get; }

        IDeleteRuleService DeleteRuleService { get; }

        IEditRuleService EditRuleService { get; }

        IGetRuleService GetRuleService { get; }
    }
}
