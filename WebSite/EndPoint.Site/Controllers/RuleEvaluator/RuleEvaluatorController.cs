using Microsoft.AspNetCore.Mvc;
using System;
using WebSite.Application.Interfaces.FacadPatterns;
using WebSite.Application.Services.Alerts.Commands.AddAlert;
using WebSite.Application.Services.Rules.Queries.GetRule;
using WebSite.Common.Dto;

namespace EndPoint.Site.Controllers.RuleEvaluator
{
    [Route("api/[controller]")]
    [ApiController]
    public class RuleEvaluatorController : ControllerBase
    {
        private readonly IAlertFacad alertFacad;

        private readonly IRuleFacad ruleFacad;

        private readonly string secretkey = "SyXzAxDTso";

        public RuleEvaluatorController(IAlertFacad alertFacad, IRuleFacad ruleFacad)
        {
            this.alertFacad = alertFacad;
            this.ruleFacad = ruleFacad;
        }

        [HttpPost]
        public ActionResult<ResultDto> Post([FromBody] AddAlertDto addDto)
        {
            if (secretkey != addDto.Secretkey)
            {
                return new ResultDto(false, "Access Denied");
            }

            var request = new AddAlertRequest(addDto.RuleId, addDto.Price, new DateTime(addDto.Time));
            return alertFacad.AddAlertService.Execute(request);
        }

        [HttpGet]
        public ActionResult<ResultDto<ResultGetRuleListDto>> Get([FromBody] GetRuleDto getDto)
        {
            if (secretkey != getDto.Secretkey)
            {
                return new ResultDto<ResultGetRuleListDto>(false, "Access Denied", null);
            }

            var request = new GetRuleListRequest(getDto.Owner, 0, int.MaxValue);
            return ruleFacad.GetRuleService.Execute(request);
        }
    }
}
