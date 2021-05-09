namespace AN.Core.Enums
{
    public enum AnnouncementMessageStatus
    {
        /// <summary>
        /// پیام اصلا ارسال نشده است. 
        /// MessageId < 0
        /// </summary>
        MessageNotSent = -1,


        /// <summary>
        /// پیام ارسال شده اما وضعیت آن هنوز نامشخص است
        /// MessageId > 0 && MessageStatus = 10
        /// </summary>
        WaitingForStatus = 0,


        /// <summary>
        /// پیام ارسال شده و وضعیت آن نیز مشخص می باشد
        /// MessageId > 0 && MessageStatus = 0 ... 9
        /// </summary>
        WaitingForDelivery = 1,



    }


    public enum AnnouncementMessageAction
    {
        /// <summary>
        /// امکان تلاش دوباره برای ارسال خودکار پیامک وجود دارد
        /// </summary>
        Retry = 0,

        /// <summary>
        /// اصلا امکان ارسال پیامک وجود ندارد و باید دستی اطلاع رسانی شود
        /// </summary>
        ManualAnnounce = 1

    }
}
