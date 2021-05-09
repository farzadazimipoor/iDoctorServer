using System.ComponentModel;

namespace AN.Core.Enums
{
    /// <summary>
    /// انواع بازه های زمانی مربوط به سرویس های با ارایه ثابت را مشخص می کند
    /// </summary>
    public enum TimePeriodType
    {
        /// <summary>
        /// بازه زمانی خالی
        /// </summary>
        [DisplayName("empty")]
        Empty,

        /// <summary>
        /// An empty time period that can be resrved as offer appointment
        /// </summary>
        [DisplayName("emptyoffer")]
        EmptyOffer,

        /// <summary>
        /// بازه زمانی عدم ارایه سرویس و زمان فراغت
        /// </summary>
        [DisplayName("breaktime")]
        Break,

        /// <summary>
        /// بازه زمانی رزرو شده به عنوان قرارملاقات یا نوبت
        /// </summary>
        [DisplayName("appointment")]
        Appointment,

        /// <summary>
        /// بازه زمانی در حال رزرو که موقتا کنار گذاشته شده است
        /// </summary>
        [DisplayName("inprogressappointment")]
        InProgressAppointment,

        /// <summary>
        /// An appointment that has been reserved based on offer schedule
        /// </summary>
        [DisplayName("offerappointment")]
        OfferAppointment,

        /// <summary>
        /// نوع بازه زمانی هنوز مشخص نیست
        /// </summary>
        [DisplayName("unknown")]
        Unknown
    }
}
