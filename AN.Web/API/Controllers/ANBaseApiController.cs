using AN.Core;
using AN.Core.Enums;
using IdentityModel;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Linq;

namespace AN.Web.API.Controllers
{
    public class ANBaseApiController : ControllerBase
    {
        private IRequestCultureFeature _requestCultureFeature;
        public IRequestCultureFeature RequestCultureFeature =>
            _requestCultureFeature ?? (_requestCultureFeature = Request.HttpContext.Features.Get<IRequestCultureFeature>());

        public CultureInfo Culture => RequestCultureFeature.RequestCulture.Culture;

        public string AcceptLanguage => Request.Headers["Accept-Language"];

        public Lang RequestLang
        {
            get
            {
                if (Culture.Name == SupportedLangs.EN)
                    return Lang.EN;
                else if (Culture.Name == SupportedLangs.AR)
                    return Lang.AR;
                else
                    return Lang.KU;
            }
        }

        private string _hostAddress;
        public string HostAddress => _hostAddress ?? (_hostAddress = $"{Request.Scheme}://{Request.Host}{Request.PathBase}");

        private string _userName;
        public string CurrentUserName => _userName ?? (_userName = User.Claims.Where(x => x.Type == JwtClaimTypes.PreferredUserName).Select(x => x.Value).FirstOrDefault());

        private string _identityUserId;
        public string IdentityUserId => _identityUserId ?? (_identityUserId = User.Claims.Where(x => x.Type == JwtClaimTypes.Subject).Select(x => x.Value).FirstOrDefault());
    }
}