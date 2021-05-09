using AN.Core;
using AN.Core.MyExceptions;
using AN.Web.Models;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;

namespace AN.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWorkContext _workContext;
        public HomeController(IWorkContext workContext)
        {
            _workContext = workContext;
        }

        [Route("")]
        public IActionResult Index()
        {
            if (_workContext.LoginAs != Shared.Enums.LoginAs.UNKNOWN)
            {
                return RedirectToAction("Index", "Home", new { area = _workContext.LoginAs.ToString().ToLower() });
            }
            else
            {
                return RedirectToAction("Login", "Account", new { area = "" });
            }
        }

        public virtual IActionResult SetCulture(string culture, string returnUrl = "/")
        {
            HttpContext.Session.Remove("CurrentUserPerson");
            HttpContext.Session.Remove("CurrentShiftCenter");
            HttpContext.Session.Remove("CurrentPharmacy");
           
            SetCookie("_culture", culture, DateTime.Now.AddYears(1));

            string referer = Request.Headers["Referer"].ToString();

            return Redirect(referer);
        }

        public IActionResult StatusCode(string code)
        {
            if (code == "404")
            {
                return View("~/Views/Shared/Error404.cshtml");
            }

            if(code == "403" || code == "401")
            {
                throw new AccessDeniedException();
            }

            return View();
        }

        public IActionResult Error()
        {
            var exceptionHandlerPathFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            var model = new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                Message = exceptionHandlerPathFeature?.Error?.Message
            };

            return View("~/Views/Shared/Error.cshtml", model);
        }

        private void SetCookie(string key, string value, DateTime? expireTime)
        {
            var options = new CookieOptions
            {
                IsEssential = true,
                Expires = expireTime.HasValue ? expireTime : DateTime.MaxValue
            };

            HttpContext.Response.Cookies.Append(key, value, options);
        }
    }
}