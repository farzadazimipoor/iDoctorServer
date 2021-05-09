namespace AN.Core.Domain
{
    using AN.Core.Data;
    using AN.Core.Enums;
    using AN.Core.Models;
    using NetTopologySuite.Geometries;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Any center that we can make appointments for it like polyclinic, beauty center, ...
    /// </summary>
    public partial class ShiftCenter : BaseEntity
    {
        public ShiftCenter()
        {
            this.ServiceSupplies = new HashSet<ServiceSupply>();
            this.ShiftCenterUsers = new HashSet<ShiftCenterPersons>();
            this.PoliclinicMessages = new HashSet<ShiftCenterMessage>();
            this.PolyclinicHealthServices = new HashSet<ShiftCenterService>();
            this.BlockedMobiles = new HashSet<BlockedMobiles>();
            this.Prescriptions = new HashSet<CenterPrescription>();
            this.Patients = new HashSet<Patient>();
        }
        
        public string Name { get; set; }        
        public string Name_Ku { get; set; }        
        public string Name_Ar { get; set; }

        public bool IsIndependent { get; set; }

        public int? CityId { get; set; }
        
        public string Address { get; set; }        
        public string Address_Ku { get; set; }        
        public string Address_Ar { get; set; }
       
        public string Description { get; set; }        
        public string Description_Ku { get; set; }        
        public string Description_Ar { get; set; }

        public bool KnownAsDoctorName { get; set; }

        [Range(0, 24)]
        public int BookingRestrictionHours { get; set; }

        public ShiftCenterType Type { get; set; } = ShiftCenterType.Polyclinic;

        public int? ClinicId { get; set; }

        /// <summary>
        /// پیام اطلاع رسانی بعد از رزرو نوبت روی اپ و سایت
        /// </summary>       
        public string FinalBookMessage { get; set; }       
        public string FinalBookMessage_Ku { get; set; }       
        public string FinalBookMessage_Ar { get; set; }

        /// <summary>
        /// متن پیامک اطلاع رسانی بعد از رزرو نوبت
        /// </summary>        
        public string FinalBookSMSMessage { get; set; }          
        public string FinalBookSMSMessage_Ku { get; set; }          
        public string FinalBookSMSMessage_Ar { get; set; }              

        public Point Location { get; set; }

        public bool IsApproved { get; set; } = true;       
       
        public string Notification { get; set; }        
        public string Notification_Ku { get; set; }        
        public string Notification_Ar { get; set; }

        public bool AutomaticScheduleEnabled { get; set; } = false;

        /// <summary>
        /// چند روز فعال آینده
        /// مشخص می کند که بر اساس زمانبندی همیشگی مطب از امروز تا چند روز آینده مطب
        /// جهت رزرو نوبت فعال می باشد
        /// برای مثال اگر 30 روز باشد
        /// سیستم فقط تا 30 روز آینده به بیماران نوبت می دهد
        /// </summary>
        [Range(1, 365)]
        public int ActiveDaysAhead { get; set; } = 30;

        public string _FcmInstanceIds { get; set; }
        [NotMapped]
        public List<PolyclinicFcmInstanceIdEntityModel> FcmInstanceIds
        {
            get { return _FcmInstanceIds == null ? null : JsonConvert.DeserializeObject<List<PolyclinicFcmInstanceIdEntityModel>>(_FcmInstanceIds); }
            set { _FcmInstanceIds = JsonConvert.SerializeObject(value); }
        }

        public string _PhoneNumbers { get; set; }
        [NotMapped]
        public List<ShiftCenterPhoneModel> PhoneNumbers
        {
            get { return _PhoneNumbers == null ? null : JsonConvert.DeserializeObject<List<ShiftCenterPhoneModel>>(_PhoneNumbers); }
            set { _PhoneNumbers = JsonConvert.SerializeObject(value); }
        }

        public string _Images { get; set; }
        [NotMapped]
        public List<HealthCenterImageEntityModel> Images
        {
            get { return _Images == null ? null : JsonConvert.DeserializeObject<List<HealthCenterImageEntityModel>>(_Images); }
            set { _Images = JsonConvert.SerializeObject(value); }
        }

        public string _Vocations { get; set; }
        [NotMapped]
        public List<VocationModel> Vocations
        {
            get { return _Vocations == null ? null : JsonConvert.DeserializeObject<List<VocationModel>>(_Vocations); }
            set { _Vocations = JsonConvert.SerializeObject(value); }
        }

        public string Logo { get; set; }

        [NotMapped]
        public string RealLogo => !string.IsNullOrEmpty(Logo) ? Logo : "/images/logo.png";

        public string PrescriptionPath { get; set; }

        public bool SupportAppointments { get; set; } = false;

        public bool ShowInHealthBank { get; set; } = false;

        public virtual Clinic Clinic { get; set; }
       
        public virtual City City { get; set; }

        public virtual ICollection<ServiceSupply> ServiceSupplies { get; set; }
        public virtual ICollection<ShiftCenterPersons> ShiftCenterUsers { get; set; }
        public virtual ICollection<ShiftCenterMessage> PoliclinicMessages { get; set; }
        public virtual ICollection<BlockedMobiles> BlockedMobiles { get; set; }
        public virtual ICollection<ShiftCenterService> PolyclinicHealthServices { get; set; }
        public virtual ICollection<CenterPrescription> Prescriptions { get; set; }
        public virtual ICollection<Patient> Patients { get; set; }
    }
}
