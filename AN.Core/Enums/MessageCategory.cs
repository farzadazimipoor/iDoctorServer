namespace AN.Core.Enums
{
    public enum MessageCategory
    {
        /// <summary>
        /// پیام یاد آوری
        /// </summary>
        Reminder = 0,

        /// <summary>
        /// پیام اطلاع رسانی برای زمانی که اتفاقی برای نوبت می افتد. مثل لغو
        /// </summary>
        Announcement = 1,

        /// <summary>
        /// پیام تایید. بیشتر زمان رزرو نوبت برای بیمار ارسال می شود
        /// </summary>
        Verification = 2
    }
}
