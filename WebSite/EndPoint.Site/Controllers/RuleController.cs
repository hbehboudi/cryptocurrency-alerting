using EndPoint.Site.Models.ViewModels.Rule;
using Microsoft.AspNetCore.Mvc;
using WebSite.Application.Interfaces.FacadPatterns;
using WebSite.Application.Services.Rules.Commands.AddRule;
using WebSite.Application.Services.Rules.Commands.DeleteRule;
using WebSite.Application.Services.Rules.Queries.GetRule;
using WebSite.Common.Dto;

namespace EndPoint.Site.Controllers
{
    public class RuleController : Controller
    {
        private readonly IRuleFacad ruleFacad;

        public RuleController(IRuleFacad ruleFacad) =>
            this.ruleFacad = ruleFacad;

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddRuleViewModel addRuleViewModel)
        {
            var owner = User.Identity.Name;

            if (owner == null)
            {
                return Json(new ResultDto(false, "No user available."));
            }

            var error = Validate(addRuleViewModel);

            if (!string.IsNullOrEmpty(error))
            {
                return Json(new ResultDto(false, error));
            }

            var addRuleRequest = new AddRuleRequest(addRuleViewModel.Name, addRuleViewModel.Symbol,
                addRuleViewModel.Description, owner, addRuleViewModel.Indicator, addRuleViewModel.MorePriceType,
                addRuleViewModel.LessPriceType, addRuleViewModel.MorePeriod, addRuleViewModel.LessPeriod,
                addRuleViewModel.TimeFrame, addRuleViewModel.Condition);
            var resultDto = ruleFacad.AddRuleService.Execute(addRuleRequest);

            return Json(resultDto);
        }

        [HttpGet]
        public IActionResult Index()
        {
            var owner = User.Identity.Name;

            if (owner == null)
            {
                return Json(new ResultDto(false, "No user available."));
            }

            var getRuleListRequest = new GetRuleListRequest(owner, 0, int.MaxValue);

            var resultDto = ruleFacad.GetRuleService.Execute(getRuleListRequest);

            return View(resultDto.Data);
        }

        [HttpPost]
        public IActionResult Delete(long id)
        {
            var owner = User.Identity.Name;

            if (owner == null)
            {
                return Json(new ResultDto(false, "No user available."));
            }

            var deleteRuleRequest = new DeleteRuleRequest(id, owner);

            var resultDto = ruleFacad.DeleteRuleService.Execute(deleteRuleRequest);

            return Json(resultDto);
        }

        public string Validate(AddRuleViewModel request)
        {
            if (string.IsNullOrWhiteSpace(request.Name) ||
                string.IsNullOrWhiteSpace(request.Symbol) ||
                string.IsNullOrWhiteSpace(request.Indicator) ||
                string.IsNullOrWhiteSpace(request.MorePriceType) ||
                string.IsNullOrWhiteSpace(request.LessPriceType))
            {
                return "لطفا تمامی موارد را ارسال نمایید.";
            }

            if (request.MorePeriod < 1 || request.LessPeriod < 1)
            {
                return "مقادیر دوره‌تناوب‌ها باید عددی مثبت و صحیح باشند.";
            }

            return null;
        }

        public string Validate(EditRuleViewModel request)
        {
            if (string.IsNullOrWhiteSpace(request.Name) ||
                string.IsNullOrWhiteSpace(request.Symbol) ||
                string.IsNullOrWhiteSpace(request.Indicator) ||
                string.IsNullOrWhiteSpace(request.MorePriceType) ||
                string.IsNullOrWhiteSpace(request.LessPriceType))
            {
                return "لطفا تمامی موارد را ارسال نمایید.";
            }

            if (request.MorePeriod < 1 || request.LessPeriod < 1)
            {
                return "مقادیر دوره‌تناوب‌ها باید عددی مثبت و صحیح باشند.";
            }

            return null;
        }
    }
}
