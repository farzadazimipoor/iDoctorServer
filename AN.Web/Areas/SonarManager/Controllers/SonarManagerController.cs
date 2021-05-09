using AN.Core;
using AN.Core.Models;
using AN.Web.App_Code;
using AN.Web.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AN.Web.Areas.SonarManager.Controllers
{
    [Area("sonarmanager")]
    [CheckLoginAs(RequestedAreas = "sonarmanager")]
    [Authorize(Roles = "sonarmanager")]
    public class SonarManagerController : AwroNoreController
    {
        private readonly IWorkContext _workContext;
        public SonarManagerController(IWorkContext workContext)
        {
            _workContext = workContext;
        }

        public WorkingAreaModel CurrentSonar => _workContext.WorkingArea;

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            if (CurrentSonar == null)
            {
                context.Result = new RedirectResult("/Account/Logout");
            }
        }
    }
}