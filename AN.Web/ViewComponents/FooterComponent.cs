using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AN.Web.ViewComponents
{
    [Area("")]
    public class FooterComponent : ViewComponent
    {       
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}