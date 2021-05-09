using System.Threading.Tasks;

namespace Identity.BLL.Services.Kurtename
{
    public interface IKurtenameSmsService
    {
        Task SendSmsAsync(string mobile, string message);
    }
}
