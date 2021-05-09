using AN.BLL.Services.Reports;
using AN.Core;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AN.Web.Areas.BeautyCenterManager.Controllers
{
    public class HomeController : BeautyCenterManagerController
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
        public async Task<IActionResult> Index()
        {
            ViewBag.Lang = Lng;

            ViewBag.CenterId = CurrentBeautyCenter.Id;

            var model = await _dashboardReportsService.GetShiftCenterDashboardDataAsync(CurrentBeautyCenter.Id, CurrentBeautyCenter.ServiceSupplyIds);

            return View(model);
        }
    }
}