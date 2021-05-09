using AN.Core.Models;
using System;
using System.Net.Mail;
using System.Threading.Tasks;

namespace AN.BLL.Core.Services.Messaging.Email
{
    public class EmailService : IEmailService
    {
        public async Task SendEmailAsync(EmailModel model)
        {
            try
            {
                var mail = new MailMessage(model.From, model.To)
                {
                    Subject = model.Subject,
                    Body = model.Body,
                    IsBodyHtml = true,                    
                };
               
                mail.ReplyToList.Add(model.From);
                mail.DeliveryNotificationOptions = DeliveryNotificationOptions.Delay |
                                                   DeliveryNotificationOptions.OnFailure |
                                                   DeliveryNotificationOptions.OnSuccess;

                var client = new SmtpClient();

                await client.SendMailAsync(mail);                
            }
            catch (Exception)
            {
                throw;
            }            
        }


        public Task SendEmail(EmailModel model)
        {
            try
            {
                using (var mailMessage = new MailMessage(model.From, model.To))
                {
                    mailMessage.Subject = model.Subject;
                    mailMessage.Body = model.Body;
                    mailMessage.IsBodyHtml = true;

                    //mail.ReplyToList.Add(new MailAddress(replyto, "My Email"));
                    mailMessage.ReplyToList.Add(model.From);
                    mailMessage.DeliveryNotificationOptions = DeliveryNotificationOptions.Delay |
                                                       DeliveryNotificationOptions.OnFailure |
                                                       DeliveryNotificationOptions.OnSuccess;

                    using (var client = new SmtpClient())
                    {
                        return client.SendMailAsync(mailMessage);
                    }
                }               
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
