//using System;
//using System.Web;
//using System.Web.Helpers;
//using System.Web.Mvc;

//namespace AN.Web.App_Code.Security
//{

//    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
//    public class ValidateCustomAntiForgeryTokenAttribute : FilterAttribute, IAuthorizationFilter
//    {
//        private void ValidateRequestHeader(HttpRequestBase request)
//        {
//            var cookieToken = String.Empty;
//            var formToken = String.Empty;
//            var tokenValue = request.Headers["RequestVerificationToken"];
//            if (!String.IsNullOrEmpty(tokenValue))
//            {
//                var tokens = tokenValue.Split(':');
//                if (tokens.Length == 2)
//                {
//                    cookieToken = tokens[0].Trim();
//                    formToken = tokens[1].Trim();
//                }
//            }
//            AntiForgery.Validate(cookieToken, formToken);
//        }
//        public void OnAuthorization(AuthorizationContext filterContext)
//        {
//            try
//            {
//                ValidateRequestHeader(filterContext.HttpContext.Request);
//            }
//            catch (HttpAntiForgeryException)
//            {
//                throw new HttpAntiForgeryException("Anti forgery token cookie not found");
//            }
//            catch (Exception ex)
//            {
//                throw new Exception(ex.Message);
//            }            

//            /*
//            try
//            {
//                if (filterContext.HttpContext.Request.IsAjaxRequest())
//                {
//                    ValidateRequestHeader(filterContext.HttpContext.Request);
//                }
//                else
//                {
//                    AntiForgery.Validate();
//                }
//            }
//            catch (HttpAntiForgeryException)
//            {
//                throw new HttpAntiForgeryException("Anti forgery token cookie not found");
//            }*/
//        }
//    }
   
//}