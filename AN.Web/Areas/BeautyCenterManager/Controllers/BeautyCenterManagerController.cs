using AN.Core;
using AN.Core.Models;
using AN.Web.App_Code;
using AN.Web.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AN.Web.Areas.BeautyCenterManager.Controllers
{    
    [Area("BeautyCenterManager")]
    [Authorize(Roles = "beautycentermanager")]
    [CheckLoginAs(RequestedAreas = "beautycentermanager")]
    public class BeautyCenterManagerController : AwroNoreController
    {
        private readonly IWorkContext _workContext;
        public BeautyCenterManagerController(IWorkContext workContext)
        {
            _workContext = workContext;
        }

        public WorkingAreaModel CurrentBeautyCenter => _workContext.WorkingArea;

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            if (CurrentBeautyCenter == null)
            {
                context.Result = new RedirectResult("/Account/Logout");
            }
        }
    }
}