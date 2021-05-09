using AN.Core;
using AN.Core.Models;
using AN.Web.App_Code;
using AN.Web.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AN.Web.Areas.PharmacyManager.Controllers
{
    [Area("pharmacymanager")]
    [CheckLoginAs(RequestedAreas = "pharmacymanager")]
    [Authorize(Roles = "pharmacymanager")]
    public class PharmacyManagerController : AwroNoreController
    {
        private readonly IWorkContext _workContext;
        public PharmacyManagerController(IWorkContext workContext)
        {
            _workContext = workContext;
        }
       
        public WorkingAreaModel CurrentPharmacy => _workContext.WorkingArea;

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            if (CurrentPharmacy == null)
            {
                context.Result = new RedirectResult("/Account/Logout");
            }
        }
    }
}