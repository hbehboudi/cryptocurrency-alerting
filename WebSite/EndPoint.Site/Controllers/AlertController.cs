using Microsoft.AspNetCore.Mvc;
using WebSite.Application.Interfaces.FacadPatterns;
using WebSite.Application.Services.Alerts.Queries.GetAlert;
using WebSite.Common.Dto;

namespace EndPoint.Site.Controllers
{
    public class AlertController : Controller
    {
        private readonly IAlertFacad alertFacad;

        public AlertController(IAlertFacad alertFacad) =>
            this.alertFacad = alertFacad;

        [HttpGet]
        public IActionResult Index()
        {
            var owner = User.Identity.Name;

            if (owner == null)
            {
                return Json(new ResultDto(false, "No user available."));
            }

            var getAlertListRequest = new GetAlertListRequest(owner, 0, int.MaxValue);

            var resultDto = alertFacad.GetAlertService.Execute(getAlertListRequest);

            return View(resultDto.Data);
        }
    }
}
