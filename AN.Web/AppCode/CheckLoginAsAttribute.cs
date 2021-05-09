using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.Linq;

namespace AN.Web.App_Code
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CheckLoginAsAttribute : ActionFilterAttribute
    {
        public string RequestedAreas { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // var loginAs = filterContext.HttpContext.Session.GetString("LoginAs");

            var loginAs = filterContext.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "LoginAs")?.Value;

            if (loginAs == "rootadmin") loginAs = "admin";

            if (!string.IsNullOrEmpty(loginAs))
            {
                var allowedAreas = RequestedAreas.Split(',').ToList();

                if (!allowedAreas.Contains(loginAs))
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                    {
                        controller = "Home",
                        action = "Index",
                        area = loginAs
                    }));
                }
            }
            else
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    controller = "Account",
                    action = "LogOut",
                    area = ""
                }));
            }
        }
    }
}