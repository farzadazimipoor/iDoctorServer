using AN.Core.Resources.Global;
using System.ComponentModel.DataAnnotations;

namespace AN.Core.Enums
{
    public enum AppointmentStatus
    {

        /// <summary>
        /// قرار ملاقات منتظر انجام
        /// </summary>
        [Display(Name = "Pending", ResourceType = typeof(Global))]
        Pending,



        /// <summary>
        /// قرار ملاقات انجام شده
        /// </summary>
        [Display(Name = "Done", ResourceType = typeof(Global))]
        Done,



        /// <summary>
        /// قرار ملاقات لغو شده
        /// </summary>
        [Display(Name = "Canceled", ResourceType = typeof(Global))]
        Canceled,


        /// <summary>
        /// مشخص نشده. برای همه نوبت ها
        /// </summary>
        [Display(Name = "Unknown", ResourceType = typeof(Global))]
        Unknown

    }
}
