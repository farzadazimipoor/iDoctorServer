
namespace AN.Core.Domain
{
    using AN.Core.Data;
    using AN.Core.Enums;
    using AN.Core.Models;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public partial class ServiceSupply : BaseEntity
    {
        public ServiceSupply()
        {
            DoctorExpertises = new HashSet<DoctorExpertise>();
            Appointments = new HashSet<Appointment>();
            Schedules = new HashSet<Schedule>();
            ActivityLogs = new HashSet<DoctorActivityLog>();
            UsualSchedulePlans = new HashSet<UsualSchedulePlan>();
            Rates = new HashSet<ServiceSupplyRating>();
            Offers = new HashSet<Offer>();
            Patients = new HashSet<Patient>();
            Consultancies = new HashSet<Consultancy>();
            ConsultancyMessages = new HashSet<ConsultancyMessage>();
            Insurances = new HashSet<ServiceSupplyInsurance>();
        }
              
        public long VisitPrice { get; set; }

        [Range(0,100)]
        public int PrePaymentPercent { get; set; } = 0;

        public PaymentType PaymentType { get; set; } = PaymentType.Free;
       
        public int Duration { get; set; }
       
        public int OnlineReservationPercent { get; set; } = 100;

        public bool IsAvailable { get; set; } = true;

        /// <summary>
        /// تاریخ شروع نوبت دهی را مشخص می کند.
        /// این مقدار فقط برای اولین بار و تنها یک بار تنظیم می شود
        /// برای مثال زمانی که سیستم برای/ مطبی فعال می شود مطب اعلام میکند که تا دو ماه دیگر
        /// نوبت ها همه بصورت دستی گرفته شده اند. لذا تاریخ شروع ما برای نوبت دهی از دو ماه دیگر خواهد بود
        /// 
        /// این تاریخ بصورت کلی می باشد
        /// </summary>
        public DateTime StartReservationDate { get; set; } = DateTime.Now;
       
        /// <summary>
        /// محدوده نوبت دهی برای یک روز خاص را مشخص می کند
        /// </summary>
        /// Reservation Range
        public int ReservationRangeStartPoint { get; set; } = -1;
        public Position ReservationRangeEndPointPosition { get; set; } = Position.AFTER;
        public int ReservationRangeEndPointDiffMinutes { get; set; } = -1;
        
        public int ShiftCenterId { get; set; }
                
        public string Notification { get; set; }
        public string Notification_Ku { get; set; }        
        public string Notification_Ar { get; set; }

        /// <summary>
        /// مشخص می کند که نحوه رزرو نوبت برای این سرویس (دکتر) چگونه باشد
        /// بصورت تکی و فقط اولین نوبت خالی را نمایش دهد و یا اینکه
        /// همه نوبت ها را نمایش دهد و بیمار خودش نوبت را انتخاب کند
        /// </summary>
        public ReservationType ReservationType { get; set; }

        public string PrescriptionPath { get; set; }

        public string _Vocations { get; set; }
        [NotMapped]
        public List<VocationModel> Vocations
        {
            get { return _Vocations == null ? null : JsonConvert.DeserializeObject<List<VocationModel>>(_Vocations); }
            set { _Vocations = JsonConvert.SerializeObject(value); }
        }

        // This is only for manual order doctors
        public long RankScore { get; set; }

        public double? TotalRating { get; set; }

        public int? TotalRaters { get; set; }

        public double? AverageRating { get; set; }

        public bool ConsultancyEnabled { get; set; } = false;

        public int PersonId { get; set; }
      
        public virtual ShiftCenter ShiftCenter { get; set; }
       
        public virtual Person Person { get; set; }

        public virtual ServiceSupplyInfo ServiceSupplyInfo { get; set; }

        public virtual ICollection<DoctorExpertise> DoctorExpertises { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
        public virtual ICollection<DoctorActivityLog> ActivityLogs { get; set; }
        public virtual ICollection<UsualSchedulePlan> UsualSchedulePlans { get; set; }
        public virtual ICollection<ServiceSupplyRating> Rates { get; set; }
        public virtual ICollection<Offer>  Offers{ get; set; }
        public virtual ICollection<Patient> Patients { get; set; }
        public virtual ICollection<Consultancy> Consultancies { get; set; }
        public virtual ICollection<ConsultancyMessage> ConsultancyMessages { get; set; }
        public virtual ICollection<ServiceSupplyInsurance> Insurances { get; set; }
    }
}
