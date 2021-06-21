using AN.Core.DTO;
using AN.Core.DTO.Turn;
using AN.Core.Enums;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AN.BLL.Core.Services.Messaging.Notifications
{
    public class NotificationService : INotificationService
    {
        #region Ctor
        private readonly string _serverKey;
        private readonly string _senderId;
        public NotificationService()
        {
            _serverKey = "";
            _senderId = "";
        } 
        #endregion

        #region Helper Methods
        public virtual async Task SendConsultancyMessageDeliveryNotificationAsync(string instanceId, string title, string text, ConsultancyMessageNotificationPayload payload)
        {
            var data = new
            {
                click_action = "FLUTTER_NOTIFICATION_CLICK",
                sound = "default",
                status = "done",
                screen = payload?.Sender == ConsultancyMessageSender.CUSTOMER ? "OPEN_DOCTOR_CHAT" : "OPEN_CHAT",
                payload?.NotificationType,
                payload?.ChatId,
                payload?.ServiceSupplyId,
                payload?.PersonId,
                payload?.MessageId,
                payload?.Sender,
                payload?.Content,
                payload?.Type,
                payload?.PersonName,
                payload?.PersonAvatar
            };
            await SendFcmToSingleDeviceAsync(instanceId, title, text, data);
        }

        public virtual async Task SendDoneAppointmentNotificationAsync(string instanceId, BaseNotificationPayload payload, DoneAppointmentNotificationPayload dataJson = null)
        {
            var data = new
            {
                click_action = "FLUTTER_NOTIFICATION_CLICK",
                sound = "default",
                status = "done",
                screen = "APPOINTMENT_DONE",
                dataJson?.AppointmentId,
                dataJson?.NotificationType,
                dataJson?.UserTurnItem,
                title = payload.Title,
                titleKu = payload.TitleKu,
                titleAr = payload.TitleAr,
                body = payload.Body,
                bodyKu = payload.BodyKu,
                bodyAr = payload.BodyAr
            };

            await SendFcmToSingleDeviceAsync(instanceId, payload.Title, payload.Body, data);
        }

        public virtual async Task SendPublishArticleNotificationAsync(BaseNotificationPayload payload, CmsArticleDTO article)
        {
            var data = new
            {
                click_action = "FLUTTER_NOTIFICATION_CLICK",
                sound = "default",
                status = "done",
                screen = "READ_ARTICLE",
                article,
                title = payload.Title,
                titleKu = payload.TitleKu,
                titleAr = payload.TitleAr,
                body = payload.Body,
                bodyKu = payload.BodyKu,
                bodyAr = payload.BodyAr
            };           

            await SendFcmToTopicAsync("Public", payload.Title, payload.Body, data);
        }

        public virtual async Task SendInboxNotificationAsync(BaseNotificationPayload payload, NotificationListItemDTO notification)
        {
            var data = new
            {
                click_action = "FLUTTER_NOTIFICATION_CLICK",
                sound = "default",
                status = "done",
                screen = "READ_NOTIFICATION",
                notification,
                title = payload.Title,
                titleKu = payload.TitleKu,
                titleAr = payload.TitleAr,
                body = payload.Body,
                bodyKu = payload.BodyKu,
                bodyAr = payload.BodyAr
            };           

            await SendFcmToTopicAsync("Public", payload.Title, payload.Body, data);
        }

        public virtual async Task SendInboxOfferNotificationAsync(BaseNotificationPayload payload)
        {
            var data = new
            {
                click_action = "FLUTTER_NOTIFICATION_CLICK",
                sound = "default",
                status = "done",
                screen = "OFFERS_INBOX_LIST",
                title = payload.Title,
                titleKu = payload.TitleKu,
                titleAr = payload.TitleAr,
                body = payload.Body,
                bodyKu = payload.BodyKu,
                bodyAr = payload.BodyAr
            };           

            await SendFcmToTopicAsync("Public", payload.Title, payload.Body, data);
        } 
        #endregion

        #region Base Methods
        public virtual async Task<FCMResponse> SendFcmToSingleDeviceAsync(string instanceId, string title, string text, object data = null)
        {
            if (data == null)
            {
                data = new
                {
                    ShortDesc = "",
                    IncidentNo = "",
                    Description = ""
                };
            }

            var objNotification = new
            {
                to = instanceId,
                data,
                notification = new
                {
                    click_action = "FLUTTER_NOTIFICATION_CLICK",
                    title,
                    text,
                    sound = "default"
                }
            };
            var jsonNotificationFormat = JsonConvert.SerializeObject(objNotification);
            var byteArray = Encoding.UTF8.GetBytes(jsonNotificationFormat);

            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://fcm.googleapis.com/fcm/send");
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Headers.Add(string.Format("Authorization: key={0}", _serverKey));
            httpWebRequest.Headers.Add(string.Format("Sender: id={0}", _senderId));
            httpWebRequest.ContentLength = byteArray.Length;

            using (var dataStream = httpWebRequest.GetRequestStream())
            {
                await dataStream.WriteAsync(byteArray, 0, byteArray.Length);

                using (var tResponse = await httpWebRequest.GetResponseAsync())
                {
                    using (var dataStreamResponse = tResponse.GetResponseStream())
                    {
                        using (var tReader = new StreamReader(dataStreamResponse))
                        {
                            var responseFromFirebaseServer = await tReader.ReadToEndAsync();

                            var response = JsonConvert.DeserializeObject<FCMResponse>(responseFromFirebaseServer);
                            return response;
                        }
                    }

                }
            }
        }

        public virtual async Task<FCMResponse> SendFcmToTopicAsync(string topic, string title, string text, object data = null)
        {
            if (data == null)
            {
                data = new
                {
                    ShortDesc = "",
                    IncidentNo = "",
                    Description = ""
                };
            }

            var objNotification = new
            {
                to = $"/topics/{topic}",
                data,
                notification = new
                {
                    click_action = "FLUTTER_NOTIFICATION_CLICK",
                    title,
                    text,
                    sound = "default"
                }
            };

            var jsonNotificationFormat = JsonConvert.SerializeObject(objNotification);

            var byteArray = Encoding.UTF8.GetBytes(jsonNotificationFormat);

            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://fcm.googleapis.com/fcm/send");
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Headers.Add(string.Format("Authorization: key={0}", _serverKey));
            httpWebRequest.Headers.Add(string.Format("Sender: id={0}", _senderId));
            httpWebRequest.ContentLength = byteArray.Length;

            using (var dataStream = await httpWebRequest.GetRequestStreamAsync())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);

                using (var tResponse = await httpWebRequest.GetResponseAsync())
                {
                    using (var dataStreamResponse = tResponse.GetResponseStream())
                    {
                        using (var tReader = new StreamReader(dataStreamResponse))
                        {
                            var responseFromFirebaseServer = await tReader.ReadToEndAsync();

                            var response = JsonConvert.DeserializeObject<FCMResponse>(responseFromFirebaseServer);
                            return response;
                        }
                    }

                }
            }
        } 
        #endregion
    }

    #region Payload Models
    public class BaseNotificationPayload
    {
        public string Title { get; set; }
        public string TitleKu { get; set; }
        public string TitleAr { get; set; }
        public string Body { get; set; }
        public string BodyKu { get; set; }
        public string BodyAr { get; set; }
    }
    public class ConsultancyMessageNotificationPayload
    {
        public NotificationType NotificationType { get; set; } = NotificationType.ConsultancyMessage;
        public int ChatId { get; set; }
        public int ServiceSupplyId { get; set; }
        public int PersonId { get; set; }
        public string PersonName { get; set; }
        public string PersonAvatar { get; set; }
        public int MessageId { get; set; }
        public string Content { get; set; }
        public ConsultancyMessageSender Sender { get; set; }
        public ConsultancyMessageType Type { get; set; }
    }

    public class DoneAppointmentNotificationPayload : BaseNotificationPayload
    {
        public int AppointmentId { get; set; }
        public NotificationType NotificationType { get; set; }
        public UserTurnItemDTO UserTurnItem { get; set; }
    }

    public class FCMResponse
    {
        public long multicast_id { get; set; }
        public int success { get; set; }
        public int failure { get; set; }
        public int canonical_ids { get; set; }
        public List<FCMResult> results { get; set; }
    }
    public class FCMResult
    {
        public string message_id { get; set; }
    } 
    #endregion
}
