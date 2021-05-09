using AN.Core.Data;
using AN.Core.Enums;
using System;

namespace AN.Core.Domain
{
    public class ShiftCenterMessage : BaseEntity
    {       
        /// <summary>
        /// اگر بیشتر از صفر باشد شناسه پیام ارسال شده می باشد که 
        /// می توان با استفاده از آن از وصعیت پیام آگاه شد که 
        /// آیا به دست مخاطب رسیده است یا نه؟
        /// </summary>
        public long? MessageId { get; set; }
        /// <summary>
        /// وشعیت پیام بعد از ارسال موفق را نشان می دهد
        /// ممکن است بعد از ارسال موفق هنوز پیام به دست مخاطب نرسیده باشد
        /// </summary>
        public long? MessageStatus { get; set; }

        public DateTime SendingDate { get; set; }
        /// <summary>
        /// نوع پیام را نشان می دهد که می تواند پیام کوتاه باشد و یا ایمیل
        /// </summary>
        public MessageType Type { get; set; }


        /// <summary>
        /// دسته بندی پیام را نشان می دهد که می تواند یادآور باشد و یا اعلان دهنده
        /// </summary>
        public MessageCategory Category { get; set; }

        /// <summary>
        /// در چه باره ای پیام ارسال شده است؟
        /// </summary>
        public MessageActionAbout About { get; set; } = MessageActionAbout.Normal;
       
        public string MessageBody { get; set; }
       
        public string Recipient { get; set; }

        /// <summary>
        /// مشخص می کند که بعد از ارسال ناموفق تا حالا چند بار تلاش دوباره برای ارسال صورت گرفته است
        /// </summary>
        public int SendingRetryCount { get; set; } = 0;

        /// <summary>
        /// مشخص می کند که بعد از ارسال موفق تا حالا چند بار تلاش برای دریافت وضعیت آن صورت گرفته است
        /// </summary>
        public int GettingStatusCount { get; set; } = 0;     
       
        public int ShiftCenterId { get; set; }
             
        public string SenderUserName { get; set; }
        
        public int ReceiverPersonId { get; set; }

        public int AppointmentId { get; set; }
       
        public virtual ShiftCenter ShiftCenter { get; set; }
        
        public virtual Person ReceiverPerson { get; set; }
       
        public virtual Appointment Appointment { get; set; }


    }
}
