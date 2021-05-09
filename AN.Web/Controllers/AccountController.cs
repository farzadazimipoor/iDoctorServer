using AN.BLL.Services.IdentityServer;
using AN.Core.ViewModels;
using IdentityModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.DTO;
using System.Linq;
using System.Threading.Tasks;

namespace AN.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IHttpContextAccessor _httpContext;
        private readonly IIdentityService _identityService;
        public AccountController(IHttpContextAccessor httpContext, IIdentityService identityService)
        {
            _httpContext = httpContext;
            _identityService = identityService;
        }

        public IActionResult Login()
        {
            return Challenge(new AuthenticationProperties
            {
                RedirectUri = "/admin/home/"
            }, "oidc");           
        }

        public IActionResult Logout()
        {
            // Clear Sessions
            _httpContext.HttpContext.Session.Clear();

            // Clear Cookies
            foreach (var cookie in Request.Cookies.Keys)
            {
                Response.Cookies.Delete(cookie);
            }

            // SignOut From Identity-Server
            return SignOut(new AuthenticationProperties
            {
                RedirectUri = "/Account/Login"
            }, CookieAuthenticationDefaults.AuthenticationScheme, "oidc");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public IActionResult ChangePassword()
        {
            var userName = User.Claims.Where(x => x.Type == JwtClaimTypes.PreferredUserName).Select(x => x.Value).FirstOrDefault();

            if (string.IsNullOrEmpty(userName)) return RedirectToAction("Logout");

            return PartialView(new ChangePasswordViewModel
            {
                Username = userName
            });
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            var changePassDTO = new ChangePasswordDTO
            {
                Username = model.Username,
                OldPassword = model.OldPassword,
                NewPassword = model.Password
            };

            var (isSucceeded, message) = await _identityService.PutChangePasswordAsync("user", changePassDTO);

            message = isSucceeded ? Core.Resources.EntitiesResources.Messages.ActionDoneSuccesfully : message;

            return Json(new { success = isSucceeded, message });
        }
    }
}
