using AN.Core;
using AN.Core.Models;
using AN.Web.App_Code;
using AN.Web.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AN.Web.Areas.LabManager.Controllers
{
    [Area("labmanager")]
    [CheckLoginAs(RequestedAreas = "labmanager")]
    [Authorize(Roles = "labmanager")]
    public class LabManagerController : AwroNoreController
    {
        private readonly IWorkContext _workContext;
        public LabManagerController(IWorkContext workContext)
        {
            _workContext = workContext;
        }

        public WorkingAreaModel CurrentLab => _workContext.WorkingArea;

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            if (CurrentLab == null)
            {
                context.Result = new RedirectResult("/Account/Logout");
            }
        }
    }
}