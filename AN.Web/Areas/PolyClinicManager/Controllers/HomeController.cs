using AN.BLL.Services.Reports;
using AN.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AN.Web.Areas.PolyClinicManager.Controllers
{
    public class HomeController : PolyclinicManagerController
    {
        #region Fields
        private readonly IDashboardReportsService _dashboardReportsService;
        #endregion

        #region Ctor
        public HomeController(IDashboardReportsService dashboardReportsService, IWorkContext workContext) : base(workContext)
        {
            _dashboardReportsService = dashboardReportsService;
        }
        #endregion

        [HttpGet]
        [Authorize(Roles = "polyclinicmanager,doctor,secretary")]
        public async Task<IActionResult> Index()
        {
            ViewBag.Lang = Lng;

            ViewBag.CenterId = CurrentPolyclinic.Id;

            var model = await _dashboardReportsService.GetShiftCenterDashboardDataAsync(CurrentPolyclinic.Id, CurrentPolyclinic.ServiceSupplyIds);

            return View(model);
        }

        public IActionResult Guide()
        {
            return View();
        }
    }
}