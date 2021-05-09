using AN.Core.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace AN.Core.Models
{
    /// <summary>
    /// اعمال محدودیت رزرو نوبت به نسبت شروع ویزیت (ساعت کاری) پزشک برای یک روز خاص
    /// </summary>
    [ComplexType]
    public class ReservationRange
    {
        /// <summary>
        /// تعداد دقایقی قبل از شروع ویزیت پزشک که باید نوبت دهی شروع شود
        /// منفی: یعنی محدودیتی ندارد از همین الان به بعد نوبت دهی شروع میشود
        /// صفر : همزمان با شروع ساعت ویزیت نوبت دهی هم شروع می شود
        /// بزرگتر از صفر: تعداد دقایق اختلاف کمتر از ساعت ویزیت
        /// </summary>
        public int StartPoint { get; set; } = -1;

        /// <summary>
        /// نقطه پایان نوبت دهی که میتواند کمتر از زمان ویزیت و یا بیشتر از آن نیز باشد
        /// </summary>
        public EndPoint EndPoint { get; set; }
    }




    /// <summary>
    /// نقطه پایان رزرو نوبت بر اساس شروع ویزیت برای یک روز
    /// </summary>
    public class EndPoint
    {
        /// <summary>
        /// موفقیت نقطه : قبل یا بعد از شروع ویزیت
        /// </summary>
        public Position Position { get; set; } = Position.AFTER;

        /// <summary>
        /// دقایق اختلاف نقطه پایان رزرو نسبت به زمان شروع ویزیت
        /// </summary>
        public int DiffMinutes { get; set; } = 0;
    }
}
