using AN.BLL.DataRepository;
using AN.Core;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AN.Web.Areas.PharmacyManager.Controllers
{
    public class HomeController : PharmacyManagerController
    {
        private readonly IPharmacyPrescriptionRepository _prescriptionRepository;
        public HomeController(IWorkContext workContext, IPharmacyPrescriptionRepository prescriptionRepository) : base(workContext)
        {
            _prescriptionRepository = prescriptionRepository;
        }
        
        public async Task<IActionResult> Index()
        {
            ViewBag.CurrentPharmacy = CurrentPharmacy;

            var model = await _prescriptionRepository.PharmacyDashboardDataAsync(CurrentPharmacy.Id);

            return View(model);
        }
    }
}