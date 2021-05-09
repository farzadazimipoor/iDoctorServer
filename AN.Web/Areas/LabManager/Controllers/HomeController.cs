using AN.BLL.DataRepository;
using AN.Core;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AN.Web.Areas.LabManager.Controllers
{
    public class HomeController : LabManagerController
    {
        private readonly IPrescriptionRepository _prescriptionRepository;
        public HomeController(IWorkContext workContext, IPrescriptionRepository prescriptionRepository) : base(workContext)
        {
            _prescriptionRepository = prescriptionRepository;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.CurrentLab = CurrentLab;

            var model = await _prescriptionRepository.CenterDashboardDataAsync(CurrentLab.Id);

            return View(model);
        }
    }
}