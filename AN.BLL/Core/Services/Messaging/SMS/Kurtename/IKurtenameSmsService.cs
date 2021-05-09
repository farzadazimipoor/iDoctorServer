using System.Threading.Tasks;

namespace AN.BLL.Core.Services.Messaging.SMS.Kurtename
{
    public interface IKurtenameSmsService
    {
        Task SendSmsAsync(string mobile, string message);
    }
}
