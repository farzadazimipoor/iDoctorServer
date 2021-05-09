using AN.Core;
using AN.Core.Models;
using System.Threading.Tasks;

namespace AN.BLL.Core.Services.Messaging.Email
{
    public interface IEmailService
    {
        Task SendEmailAsync(EmailModel model);

        Task SendEmail(EmailModel model);
    }
}
