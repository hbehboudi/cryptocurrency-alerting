using WebSite.Application.Services.Rules.Commands.AddRule;
using WebSite.Application.Services.Rules.Commands.DeleteRule;
using WebSite.Application.Services.Rules.Queries.GetRule;

namespace WebSite.Application.Interfaces.FacadPatterns
{
    public interface IRuleFacad
    {
        IAddRuleService AddRuleService { get; }

        IDeleteRuleService DeleteRuleService { get; }

        IGetRuleService GetRuleService { get; }
    }
}
