//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Filters;
//using Microsoft.AspNetCore.Routing;
//using System;

//namespace AN.Web.App_Code.Security
//{
//    /// <summary>
//    /// how to restrict access to action methods that you would not want users to directly request in the browser's address bar.
//    /// In ASP.NET MVC, you can use the [ChildActionOnly] attribute to indicate that an action method should be called only
//    /// as a child action from within a view. Typically, child actions are associated with partial views.
//    ///Suppose you need to create an action method for remote validation.Creating it as a child action wil not work
//    ///in this case if you don't want users to request the method directly in the browser's address bar.
//    ///In order to apply this restriction to any action method you can create a custom action filter.
//    ///Below is the code for the NoDirectAccessAttribute method to restrict direct access to any class or action method
//    ///that applies the NoDirectAccess attribute
//    /// </summary>
//    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
//    public class NoDirectAccessAttribute : ActionFilterAttribute
//    {
//        public override void OnActionExecuting(ActionExecutingContext filterContext)
//        {
//            if (filterContext.HttpContext.Request.UrlReferrer == null || filterContext.HttpContext.Request.Url.Host != filterContext.HttpContext.Request.UrlReferrer.Host)
//            {
//                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = "Index", area = "Public" }));
//            }
//        }
//    }
//}