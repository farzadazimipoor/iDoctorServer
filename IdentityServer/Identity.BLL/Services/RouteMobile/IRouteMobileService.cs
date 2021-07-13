using System.Threading.Tasks;

namespace Identity.BLL.Services.RouteMobile
{
    public interface IRouteMobileService
    {
        Task SendSmsAsync(string mobile, string message);
    }
}
