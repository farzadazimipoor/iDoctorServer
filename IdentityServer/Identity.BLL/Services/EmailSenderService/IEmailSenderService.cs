using System.Threading.Tasks;

namespace Identity.BLL.Services.Email
{
    public interface IEmailSenderService
    {
        Task SendEmail(string email, string subject, string message, string toUsername);
    }
}
