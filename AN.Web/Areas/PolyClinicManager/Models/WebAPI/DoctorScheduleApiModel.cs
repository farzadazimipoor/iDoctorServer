using System.Collections.Generic;

namespace AN.Web.Areas.PolyClinicManager.Models.WebAPI
{
    public class DoctorDayScheduleApiModel
    {
        /// <summary>
        /// آیا امروز تعطیل است
        /// </summary>
        public bool IsVocationDay { get; set; }
        /// <summary>
        /// آیا در برنامه همیشگی پزشک برای امروز فعال است
        /// </summary>
        public bool IsActiveInUsualSchedule { get; set; }
        /// <summary>
        /// آیا برای پزشک برای امروز ساعات کاری دستی تعریف شده است
        /// </summary>
        public bool HaveManualSchedule { get; set; }
        /// <summary>
        /// آیا پزشک امروز فعال است
        /// </summary>
        public bool IsDoctorAvailableToday { get; set; }
        /// <summary>
        /// آیا پزشک در کل فعال است.؟
        /// این مورد در جدول سرویس ها مشخص میشود
        /// </summary>
        public bool IsDoctorActive { get; set; }
        /// <summary>
        /// شماره سرویس
        /// </summary>
        public int ServiceSupplyId { get; set; }
        /// <summary>
        /// لیست ساعات کاری دستی
        /// </summary>

        public List<ManualScheduleModel> Schedules { get; set; }
        
    }  
    
    
    public class ManualScheduleModel
    {
        /// <summary>
        /// مشخص می کند که در این ساعت کاری چند نوبت رزرو شده اند
        /// </summary>
        public int ReservedAppointsCount { get; set; }
        /// <summary>
        /// مشخص می کند که آیا این ساعت کاری زمان استراحت و فراغت است یا نه؟
        /// </summary>
        public bool IsBreak { get; set; }
        /// <summary>
        /// ساعت شروع
        /// </summary>
        public string StartTime { get; set; }
        /// <summary>
        /// ساعت پایان
        /// </summary>
        public string EndTime { get; set; }
        /// <summary>
        /// مشخص می کند که این ساعت کاری در چه شیفتی قرار دارد؟ صبح یا عصر؟
        /// </summary>
        public string Shift { get; set; }
    }
    
    

    public class SetDoctorAvailabilityModel
    {
        public int? PolyClinicId { get; set; }
        public int? ServiceSupplyId { get; set; }
        public string Date { get; set; }
        public bool? IsAvailable { get; set; }
        public bool? CancelAllAndDisableDoctor { get; set; }
        public bool? OnlyDisableDoctor { get; set; }
    }


    public class SetDoctorAvailabilityResultModel
    {
        public bool HavePendingAppointments { get; set; }
        public int PendingAppointmentsCount { get; set; }
        public bool AvailabilityDone { get; set; }
    }
}