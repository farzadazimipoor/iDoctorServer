using AN.Core;
using AN.Core.Enums;
using System;

namespace AN.Web.Areas.PolyClinicManager.Models.WebAPI
{
    public class MessageApiModel
    {
        /// <summary>
        /// شماره رکورد در جدول نگه داری پیام ها
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// تاریخ و زمان ارسال پیام کوتاه
        /// </summary>
        public DateTime SendingDate { get; set; }

        /// <summary>
        /// نتیجه دریافت شده از وب سرویس هنگام ارسال پیام کوتاه
        /// </summary>
        public long MessageId { get; set; }
        /// <summary>
        /// منیجه دریافت شده از وب سرویس هنگام دریافت وضعیت پیام ارسال شده
        /// </summary>
        public long MessageStatus { get; set; }
        /// <summary>
        /// وضعیت حال حاضر پیام که درون بانک اطلاعاتی ذخیره شده است
        /// </summary>
        public AnnouncementMessageStatus Status { get; set; }
        /// <summary>
        /// نام دریافت کننده پیام
        /// </summary>
        public string ReceiverName { get; set; }
        public string ReceiverMobile { get; set; }
        /// <summary>
        /// پیام در چه موردی ارسال شده است یا بایت چه چیزی ارسال شده است
        /// </summary>
        public string About { get; set; }
        /// <summary>
        /// تعداد تلاشهای انجام شده برای ارسال مجدد پیام ارسال نشده
        /// </summary>
        public int SendingRetryCount { get; set; } = 0;
        /// <summary>
        /// تعداد تلاشهای انجام شده برای دریافت آخرین وضعیت پیام ارسال شده
        /// </summary>
        public int GettingStatusCount { get; set; } = 0;
    }
}