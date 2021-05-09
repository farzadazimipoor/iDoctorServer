using AN.Web.App_Code;
using AN.Web.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AN.Web.Areas.Admin.Controllers
{
    [Area("admin")]
    [CheckLoginAs(RequestedAreas = "admin")]
    [Authorize(Roles = "admin,rootadmin")]      
    public class AdminController : AwroNoreController
    {

    }
}