using WebSite.Application.Interfaces.Contexts;
using WebSite.Application.Interfaces.FacadPatterns;
using WebSite.Application.Services.Rules.Commands.AddRule;
using WebSite.Application.Services.Rules.Commands.DeleteRule;
using WebSite.Application.Services.Rules.Commands.EditRule;
using WebSite.Application.Services.Rules.Queries.GetRule;

namespace WebSite.Application.Services.Rules.FacadPattern
{
    public class RuleFacad : IRuleFacad
    {
        private readonly IDataBaseContext dataBaseContext;

        private IAddRuleService addRuleService;

        private IDeleteRuleService deleteRuleService;

        private IEditRuleService editRuleService;

        private IGetRuleService getRuleService;

        public RuleFacad(IDataBaseContext dataBaseContext) =>
            this.dataBaseContext = dataBaseContext;

        public IAddRuleService AddRuleService
        {
            get
            {
                return addRuleService ??= new AddRuleService(dataBaseContext);
            }
        }

        public IDeleteRuleService DeleteRuleService
        {
            get
            {
                return deleteRuleService ??= new DeleteRuleService(dataBaseContext);
            }
        }

        public IEditRuleService EditRuleService
        {
            get
            {
                return editRuleService ??= new EditRuleService(dataBaseContext);
            }
        }

        public IGetRuleService GetRuleService
        {
            get
            {
                return getRuleService ??= new GetRuleService(dataBaseContext);
            }
        }
    }
}
