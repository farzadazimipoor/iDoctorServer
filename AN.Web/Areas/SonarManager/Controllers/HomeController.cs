using AN.BLL.DataRepository;
using AN.Core;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AN.Web.Areas.SonarManager.Controllers
{
    public class HomeController : SonarManagerController
    {
        private readonly IPrescriptionRepository _prescriptionRepository;       
        public HomeController(IWorkContext workContext, IPrescriptionRepository prescriptionRepository) : base(workContext)
        {
            _prescriptionRepository = prescriptionRepository;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.CurrentSonar = CurrentSonar;

            var model = await _prescriptionRepository.CenterDashboardDataAsync(CurrentSonar.Id);

            return View(model);
        }
    }
}