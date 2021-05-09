namespace AN.Core.Enums
{
    public enum PayamResanMessageStatus
    {
        /// <summary>
        /// دریافت شده توسط پیام رسان - در صف ارسال
        /// </summary>
        InPayamResanSendingQueue = 0,

        /// <summary>
        /// ارسال شده - هنوز وضعیتی از مخابرات اعلام نشده است 
        /// </summary>
        SendedFromPayamResanNotResponseFromTCT = 1,

        /// <summary>
        /// در صف ارسال مخابرات
        /// </summary>
        InTCTSendingQueue = 2,

        /// <summary>
        /// رسیده به مخابرات
        /// </summary>
        DeliveredToTCT = 3,

        /// <summary>
        /// رسیده به گوشی - موفق
        /// </summary>
        DeliveredToMobilePhone = 4,

        /// <summary>
        /// نرسیده به گوشی
        /// </summary>
        NotDeliveredToMobilePhone = 5,

        /// <summary>
        /// نرسیده به مخابرات
        /// </summary>
        NotDeliveredToTCT = 6,

        /// <summary>
        /// نرسیده به مخابرات - گیرنده دریافت پیامک تبلیغاتی را غیرفعال کرده است
        /// </summary>
        NotDeliveredToTCTReceiverDisabledGettingAdsMessages = 7,

        /// <summary>
        /// پیامک یافت نشد - شناسه اشتباه است و یا اینکه پیامک بیش از 7 روز گذشته ارسال شده است
        /// </summary>
        MessageNotFound = 8,

        /// <summary>
        /// منقضی شده است
        /// </summary>
        Expired = 9,

        /// <summary>
        /// نامشخص
        /// </summary>
        Unknown = 10


    }
}
