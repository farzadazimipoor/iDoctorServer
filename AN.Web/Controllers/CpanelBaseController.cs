using AN.Core;
using Shared.Enums;

namespace AN.Web.Controllers
{
    public class CpanelBaseController : AwroNoreController
    {
        private readonly IWorkContext _workContext;
        public CpanelBaseController(IWorkContext workContext)
        {
            _workContext = workContext;
        }

        public LoginAs LoginAs => _workContext.LoginAs;
    }
}