using AN.BLL.DataRepository.Clinics;
using AN.Core.Domain;
using AN.Web.App_Code;
using AN.Web.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AN.Web.Areas.ClinicManager.Controllers
{
    [Area("clinicmanager")]
    [CheckLoginAs(RequestedAreas = "clinicmanager")]
    [Authorize(Roles = "clinicmanager")]   
    public class ClinicManagerController : AwroNoreController
    {       
        private readonly IClinicService _clinicService;
        public ClinicManagerController(IClinicService clinicService)
        {
            _clinicService = clinicService;
        }

        private Clinic _currentClinic;
        public Clinic CurrentClinic => _currentClinic ?? (_currentClinic = _clinicService.GetCurrentClinic());
    }
}