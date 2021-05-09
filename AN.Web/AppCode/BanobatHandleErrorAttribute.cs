//using AN.Core.Exceptions;
//using System;
//using System.Data.SqlClient;
//using System.Web;
//using System.Web.Mvc;

//namespace AN.Web.App_Code
//{
//    public class BanobatHandleErrorAttribute : HandleErrorAttribute
//    {
//        public override void OnException(ExceptionContext filterContext)
//        {
//            if (filterContext.ExceptionHandled) return;

//            var ex = filterContext.Exception;

//            var message = ex.Message;
//            int errorCode = 500;

//            if (ex.GetType() == typeof(BanobatException) || ex.GetType().IsSubclassOf(typeof(BanobatException)))
//            {
//                errorCode = (int)(ex as BanobatException).ErrorCode;
//            }
//            else
//            {
//                if (ex.GetType() == typeof(ArgumentNullException))
//                {
//                    var splitter = "Parameter name: ";
//                    var index = message.IndexOf(splitter);
//                    var parameterName = message.Substring(index + splitter.Length);

//                    message = $"ArgumentNullException: {parameterName}";
//                }
//                else if (ex.GetType() == typeof(NullReferenceException))
//                {

//                }
//                else if (ex.GetType() == typeof(SqlException))
//                {
//                    message = "SqlException";
//                }
//                else if (ex.GetType() == typeof(HttpException))
//                {                   
//                    errorCode = (ex as HttpException).GetHttpCode();
//                }
//            }

//            filterContext.ExceptionHandled = true;

//            #region Logging Error
//            var controllerName = (string)filterContext.RouteData.Values["controller"];
//            var actionName = (string)filterContext.RouteData.Values["action"];
//            var target = string.Format("{0}|{1}", controllerName, actionName);
//            //LoggerSingleton.Instance.LogError(target, message);
//            #endregion

//            #region Setting Response
//            if (filterContext.RequestContext.HttpContext.Request.IsAjaxRequest())
//            {
//                filterContext.HttpContext.Response.Clear();
//                filterContext.HttpContext.Response.Write(message);
//                filterContext.HttpContext.Response.StatusDescription = message;
//                filterContext.HttpContext.Response.StatusCode = errorCode;
//            }
//            else
//            {
//                filterContext.Controller.TempData["UrlReferrer"] = filterContext.RequestContext.HttpContext.Request.UrlReferrer;
//                filterContext.Controller.TempData["Controller"] = controllerName;
//                filterContext.Controller.TempData["Action"] = actionName;
//                filterContext.Controller.TempData["ErrorCode"] = errorCode;
//                filterContext.Controller.TempData["ExceptionMessage"] = message;
//                filterContext.Result = new ViewResult
//                {
//                    ViewName = "UsersError",
//                    ViewData = filterContext.Controller.ViewData,
//                    TempData = filterContext.Controller.TempData,
//                };
//            }
//            #endregion
//        }
//    }
//}