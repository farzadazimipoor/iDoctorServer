using AN.Core.Domain;
using System;

namespace AN.BLL.Core.Appointments.InProgress
{
    public partial class IPAModel
    {

        /// <summary>
        /// مشخص می کند که در چه تاریخ و ساعتی به این لیست اصافه شده است
        /// </summary>
        public DateTime AddedAt { get; set; }


        /// <summary>
        /// تاریخ و زمان شروع نوبت یا قرار ملاقات
        /// </summary>
        public DateTime StartDateTime { get; set; }



        /// <summary>
        /// تاریخ و زمان پایان نوبت و یا قرار ملاقات
        /// </summary>
        public DateTime EndDateTime { get; set; }



        /// <summary>
        /// شماره سرویس ارایه شده که نوبت مربوط به ان می باشد
        /// </summary>
        public int ServiceSupplyId { get; set; }



        /// <summary>
        /// مشخصات عاملی که کلاینت جهت رزرو نوبت استفاده کرده است را نگه داری می کند
        /// </summary>
        public string UserHostAgent { get; set; }

        

        /// <summary>
        /// مشخص می کند که آیا این نوبت برای بیمارستان می باشد یا برای پزشکان جست و جو شده و پزشک انتخاب شده
        /// </summary>
        public bool IsForSelectedDoctor { get; set; } 


        public ShiftCenterService PolyclinicHealthService { get; set; }

        public int? OfferId { get; set; } = null;

    }
}
