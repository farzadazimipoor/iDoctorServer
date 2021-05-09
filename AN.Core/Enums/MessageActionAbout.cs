namespace AN.Core.Enums
{
    /// <summary>
    /// مشخص می کند که پیام بابت چه عملی برای مخاطب ارسال شده است
    /// </summary>
    public enum MessageActionAbout
    {
        Normal = 0,

        /// <summary>
        /// جهت اعلام انجام نوبت
        /// </summary>
        DoneAppointment = 1,

        /// <summary>
        /// جهت اعلام اینکه نوبت لغو شده است
        /// </summary>
        CancelAppointment = 2,

        /// <summary>
        /// جهت اعلام اینکه نوبت به زمان دیگری انتقال یافته است
        /// </summary>
        MoveAppointment = 3
    }
}
