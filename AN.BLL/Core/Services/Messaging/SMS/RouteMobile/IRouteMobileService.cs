using System.Threading.Tasks;

namespace AN.BLL.Core.Services.Messaging.SMS.RouteMobile
{
    public interface IRouteMobileService
    {
        Task SendSmsAsync(string mobile, string message);
    }
}
