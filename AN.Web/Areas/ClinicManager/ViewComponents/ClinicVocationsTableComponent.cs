using AN.BLL.DataRepository.Clinics;
using AN.Core.Domain;
using AN.Web.Areas.ClinicManager.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AN.Web.Areas.ClinicManager.ViewComponents
{
    [Area("ClinicManager")]
    public class ClinicVocationsTableComponent : ViewComponent
    {
        private readonly IClinicService _clinicService;
        public ClinicVocationsTableComponent(IClinicService clinicService)
        {
            _clinicService = clinicService;
        }

        private Clinic _currentClinic;
        public Clinic CurrentClinic => _currentClinic ?? (_currentClinic = _clinicService.GetCurrentClinic());

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var currentClinic = CurrentClinic;

            var vocations = new List<CMVocationViewModel>();

            if (currentClinic.Vocations != null)
            {
                vocations = currentClinic.Vocations.Select(v => new CMVocationViewModel
                {
                    FromDate = v.F.ToShortDateString(),
                    ToDate = v.T.ToShortDateString(),
                }).ToList();
            }

            return View(vocations);
        }
    }
}