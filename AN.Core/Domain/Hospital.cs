namespace AN.Core.Domain
{
    using AN.Core.Data;
    using AN.Core.Enums;
    using AN.Core.Models;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using NetTopologySuite.Geometries;
    public partial class Hospital : BaseEntity
    {
        public Hospital()
        {
            this.Clinics = new HashSet<Clinic>();            
            this.HospitalUsers = new HashSet<HospitalPersons>();              
        }
        
        public string Name { get; set; }
        public string Name_Ku { get; set; }       
        public string Name_Ar { get; set; }
                
        public string Description { get; set; }
        public string Description_Ku { get; set; }       
        public string Description_Ar { get; set; }

        public int CityId { get; set; }
       
        public string Address { get; set; }      
        public string Address_Ku { get; set; }      
        public string Address_Ar { get; set; }

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
     
        public bool IsGovernmental { get; set; } = false;
       
        public HospitalType Type { get; set; }
        
        public Point Location { get; set; }

        public bool IsApproved { get; set; } = false;
      
        public string Notification { get; set; }       
        public string Notification_Ku { get; set; }       
        public string Notification_Ar { get; set; }

        /// <summary>
        /// Save Phone Numbers As JSON Object in database
        /// </summary>
        public string _PhoneNumbers { get; set; }
        [NotMapped]
        public List<ShiftCenterPhoneModel> PhoneNumbers
        {
            get { return _PhoneNumbers == null ? null : JsonConvert.DeserializeObject<List<ShiftCenterPhoneModel>>(_PhoneNumbers); }
            set { _PhoneNumbers = JsonConvert.SerializeObject(value); }
        }

        public string Logo { get; set; }

        [NotMapped]
        public string RealLogo => !string.IsNullOrEmpty(Logo) ? Logo : "/images/logo.png";

        public virtual City City { get; set; }

        public virtual ICollection<Clinic> Clinics { get; set; }                       
        public virtual ICollection<HospitalPersons> HospitalUsers { get; set; }      
    }
}
