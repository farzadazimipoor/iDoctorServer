using AN.BLL.DataRepository.Hospitals;
using AN.Core.Domain;
using AN.Web.App_Code;
using AN.Web.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AN.Web.Areas.HospitalManager.Controllers
{
    [Area("hospitalmanager")]
    [CheckLoginAs(RequestedAreas = "hospitalmanager")]
    [Authorize(Roles = "hospitalmanager")]   
    public class HospitalManagerController : AwroNoreController
    {
        private readonly IHospitalService _hospitalService;
        public HospitalManagerController(IHospitalService hospitalService)
        {
            _hospitalService = hospitalService;
        }


        private Hospital _currentHospital;
        public Hospital CurrentHospital => _currentHospital ?? (_currentHospital = _hospitalService.GetCurrentHospital());
    }
}