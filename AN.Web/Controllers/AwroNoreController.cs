using AN.Core.Enums;
using AN.Web.Helper;
using IdentityModel;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AN.Web.Controllers
{
    public class AwroNoreController : Controller
    {
        public Lang Lng => CultureHelper.Lang;

        private string _userName;
        public string CurrentUserName => _userName ?? (_userName = User.Claims.Where(x => x.Type == JwtClaimTypes.PreferredUserName).Select(x => x.Value).FirstOrDefault());

        private string _hostAddress;
        public string HostAddress => _hostAddress ?? (_hostAddress = $"{Request.Scheme}://{Request.Host}{Request.PathBase}");
    }
}