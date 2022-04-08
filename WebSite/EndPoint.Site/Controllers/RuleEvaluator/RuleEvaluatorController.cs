using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using WebSite.Application.Interfaces.FacadPatterns;
using WebSite.Application.Services.Alerts.Commands.AddAlert;
using WebSite.Application.Services.Rules.Queries.GetRule;
using WebSite.Common.Dto;

namespace EndPoint.Site.Controllers.RuleEvaluator
{
    [Route("api/[controller]")]
    [AllowAnonymous]
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

            var dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(addDto.Time).ToLocalTime();

            var request = new AddAlertRequest(addDto.RuleId, addDto.Price, dateTime);
            return alertFacad.AddAlertService.Execute(request);
        }

        [HttpGet]
        public ActionResult<ResultDto<ResultGetRuleListDto>> Get([FromBody] GetRuleDto getDto)
        {
            if (secretkey != getDto.Secretkey)
            {
                return new ResultDto<ResultGetRuleListDto>(false, "Access Denied", null);
            }

            return ruleFacad.GetRuleService.Execute();
        }
    }
}
