using AN.Core.DTO;
using System.Threading.Tasks;

namespace AN.BLL.Core.Services.Messaging.Notifications
{
    public interface INotificationService
    {
        Task SendConsultancyMessageDeliveryNotificationAsync(string instanceId, string title, string text, ConsultancyMessageNotificationPayload payload);

        Task SendDoneAppointmentNotificationAsync(string instanceId, BaseNotificationPayload payload, DoneAppointmentNotificationPayload dataJson = null);

        Task SendPublishArticleNotificationAsync(BaseNotificationPayload payload, CmsArticleDTO article);

        Task SendInboxNotificationAsync(BaseNotificationPayload payload, NotificationListItemDTO notification);

        Task SendInboxOfferNotificationAsync(BaseNotificationPayload payload);

        Task<FCMResponse> SendFcmToSingleDeviceAsync(string instanceId, string title, string text, object data = null);

        Task<FCMResponse> SendFcmToTopicAsync(string topic, string title, string text, object data = null);
    }
}
