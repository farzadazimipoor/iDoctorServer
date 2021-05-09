using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AN.Core.Resources.Global;

namespace AN.Web.Areas.PolyClinicManager.Models.WebAPI
{
    public class PolyclinicApiModel
    {
        [Display(Name = "Name", ResourceType = typeof(Global))]
        [Required(ErrorMessage = "نام مطب الزامی می باشد")]
        public string Name { get; set; }

        [Display(Name = "Description", ResourceType = typeof(Core.Resources.Global.Global))]
        public string Description { get; set; }

        [Display(Name = "Address", ResourceType = typeof(Global))]
        public string Address { get; set; }

        [Display(Name = "تلفن یک")]
        [Required(ErrorMessage = "شماره تلفن الزامی می باشد")]
        public string Phone1 { get; set; }

        [Display(Name = "تلفن دو")]
        public string Phone2 { get; set; }

        [Display(Name = "تلفن سه")]
        public string Phone3 { get; set; }

        [Display(Name = "عرض جغرافیایی")]
        public string GoogleMap_lat { get; set; }
        [Display(Name = "طول جغرافیایی")]
        public string GoogleMap_lng { get; set; }
        [Display(Name = "محدودیت رزرو تا چند ساعت قبل از شروع ویزیت")]
        public int BookingRestriction { get; set; } = 24; //default value is 24

        [Display(Name ="تعداد روزهای فعال پیش روی مطب")]
        public int ActiveDaysAhead { get; set; } = 15;

        [Display(Name = "اطلاعیه")]
        public string Notification { get; set; }

        [Display(Name = "جهت رزرو")]
        public bool Phone1IsForReserve { get; set; }
        [Display(Name = "جهت رزرو")]
        public bool Phone2IsForReserve { get; set; }
        [Display(Name = "جهت رزرو")]
        public bool Phone3IsForReserve { get; set; }
    }


    public class PolyClinicsToManageModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsIndependent { get; set; }
    }


    public class DashboardDataModel
    {
        public int TodayAppoints { get; set; }
        public int NewAppoints { get; set; }        
        public int AllAppoints { get; set; }
        public TodayQueueDashboard TodayQueue { get; set; }
        public int ActiveDaysAhead { get; set; }
        public int BookingRestrictionHour { get; set; }
    }

    public class TodayQueueDashboard
    {
        public int Count { get; set; }
        public List<DashboardQueuePatient> Patients { get; set; }
    }


    public class DashboardQueuePatient
    {
        public string Name { get; set; }
        public string StartTime { get; set; }
    }



    public class UsualSchedulePlanModel
    {
        public IEnumerable<UsualSchedulePlanSericeSupply> ServiceSupplies { get; set; }
        public UsualSchedulePlanDay Saturday { get; set; }
        public UsualSchedulePlanDay Sunday { get; set; }
        public UsualSchedulePlanDay Monday { get; set; }
        public UsualSchedulePlanDay Tuesday { get; set; }
        public UsualSchedulePlanDay Wednesday { get; set; }
        public UsualSchedulePlanDay Thursday { get; set; }
        public UsualSchedulePlanDay Friday { get; set; }
    }

    public class UpdateUsualSchedulePlanModel
    {
        public UsualSchedulePlanDay Saturday { get; set; }
        public UsualSchedulePlanDay Sunday { get; set; }
        public UsualSchedulePlanDay Monday { get; set; }
        public UsualSchedulePlanDay Tuesday { get; set; }
        public UsualSchedulePlanDay Wednesday { get; set; }
        public UsualSchedulePlanDay Thursday { get; set; }
        public UsualSchedulePlanDay Friday { get; set; }
    }

    public class NewUpdateUsualSchedulePlanModel
    {
        public bool Saturday_IsMorningActive { get; set; }
        public string Saturday_MorningFrom { get; set; }
        public string Saturday_MorningTo { get; set; }
        public int? Saturday_MorningServiceSupplyId { get; set; }
        public bool Saturday_IsEveningActive { get; set; }
        public string Saturday_EveningFrom { get; set; }
        public string Saturday_EveningTo { get; set; }
        public int? Saturday_EveningServiceSupplyId { get; set; }

        public bool Sunday_IsMorningActive { get; set; }
        public string Sunday_MorningFrom { get; set; }
        public string Sunday_MorningTo { get; set; }
        public int? Sunday_MorningServiceSupplyId { get; set; }
        public bool Sunday_IsEveningActive { get; set; }
        public string Sunday_EveningFrom { get; set; }
        public string Sunday_EveningTo { get; set; }
        public int? Sunday_EveningServiceSupplyId { get; set; }

        public bool Monday_IsMorningActive { get; set; }
        public string Monday_MorningFrom { get; set; }
        public string Monday_MorningTo { get; set; }
        public int? Monday_MorningServiceSupplyId { get; set; }
        public bool Monday_IsEveningActive { get; set; }
        public string Monday_EveningFrom { get; set; }
        public string Monday_EveningTo { get; set; }
        public int? Monday_EveningServiceSupplyId { get; set; }

        public bool Tuesday_IsMorningActive { get; set; }
        public string Tuesday_MorningFrom { get; set; }
        public string Tuesday_MorningTo { get; set; }
        public int? Tuesday_MorningServiceSupplyId { get; set; }
        public bool Tuesday_IsEveningActive { get; set; }
        public string Tuesday_EveningFrom { get; set; }
        public string Tuesday_EveningTo { get; set; }
        public int? Tuesday_EveningServiceSupplyId { get; set; }

        public bool Wednesday_IsMorningActive { get; set; }
        public string Wednesday_MorningFrom { get; set; }
        public string Wednesday_MorningTo { get; set; }
        public int? Wednesday_MorningServiceSupplyId { get; set; }
        public bool Wednesday_IsEveningActive { get; set; }
        public string Wednesday_EveningFrom { get; set; }
        public string Wednesday_EveningTo { get; set; }
        public int? Wednesday_EveningServiceSupplyId { get; set; }

        public bool Thursday_IsMorningActive { get; set; }
        public string Thursday_MorningFrom { get; set; }
        public string Thursday_MorningTo { get; set; }
        public int? Thursday_MorningServiceSupplyId { get; set; }
        public bool Thursday_IsEveningActive { get; set; }
        public string Thursday_EveningFrom { get; set; }
        public string Thursday_EveningTo { get; set; }
        public int? Thursday_EveningServiceSupplyId { get; set; }

        public bool Friday_IsMorningActive { get; set; }
        public string Friday_MorningFrom { get; set; }
        public string Friday_MorningTo { get; set; }
        public int? Friday_MorningServiceSupplyId { get; set; }
        public bool Friday_IsEveningActive { get; set; }
        public string Friday_EveningFrom { get; set; }
        public string Friday_EveningTo { get; set; }
        public int? Friday_EveningServiceSupplyId { get; set; }
    }

    public class UpdateUsualSchedulePlanResultModel
    {
        public String Status { get; set; }
        public String Message { get; set; }
    }

    public class UsualSchedulePlanSericeSupply
    {
        public int? ServiceSupplyId { get; set; }
        public string DoctorName { get; set; }
    }

    public class UsualSchedulePlanDay
    {
        public bool IsMorningActive { get; set; }
        public string MorningFrom { get; set; }
        public string MorningTo { get; set; }
        public int? MorningServiceSupplyId { get; set; }
        public bool IsEveningActive { get; set; }
        public string EveningFrom { get; set; }
        public string EveningTo { get; set; }
        public int? EveningServiceSupplyId { get; set; }
    }
}