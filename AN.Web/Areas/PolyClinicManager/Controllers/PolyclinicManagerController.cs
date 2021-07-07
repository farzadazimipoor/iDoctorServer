using AN.Core;
using AN.Core.Models;
using AN.Core.MyExceptions;
using AN.Web.App_Code;
using AN.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;
using System.Linq;

namespace AN.Web.Areas.PolyClinicManager.Controllers
{
    [Area("polyclinicmanager")]
    [CheckLoginAs(RequestedAreas = "polyclinicmanager, homecaremanager")]    
    public class PolyclinicManagerController : AwroNoreController
    {       
        private readonly IWorkContext _workContext;
        public PolyclinicManagerController(IWorkContext workContext)
        {
            _workContext = workContext;
        }

        public WorkingAreaModel CurrentPolyclinic => _workContext.WorkingArea;     

        public void EnsureAllowAccess(int serviceSupplyId)
        {
            if ((CurrentPolyclinic.ServiceSupplyIds != null && CurrentPolyclinic.ServiceSupplyIds.Any()))
            {
                if (!CurrentPolyclinic.ServiceSupplyIds.Contains(serviceSupplyId)) throw new AccessDeniedException();
            }
        }

        public void EnsureAllowAccess(List<int> serviceSupplyIds)
        {
            if ((CurrentPolyclinic.ServiceSupplyIds != null && CurrentPolyclinic.ServiceSupplyIds.Any()))
            {
                if (serviceSupplyIds.Any(s => !CurrentPolyclinic.ServiceSupplyIds.Contains(s)))
                {
                    throw new AccessDeniedException();
                }
            }
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            if (CurrentPolyclinic == null)
            {
                context.Result = new RedirectResult("/Account/Logout");
            }
        }
    }
}