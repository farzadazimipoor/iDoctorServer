namespace AN.Core.Domain
{
    using AN.Core.Data;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class ServiceSupplyInfo : BaseEntity
    {
        public ServiceSupplyInfo()
        {           
            DoctorScientificCategories = new HashSet<DoctorScientificCategory>();
            AdditionalExpertises = new HashSet<AdditionalExpertise>();            
        }

        [NotMapped]
        public override int Id { get => base.Id; set => base.Id = value; }

        public int ServiceSupplyId { get; set; }        
        
        public string MedicalCouncilNumber { get; set; }
       
        public string Bio { get; set; }      
        public string Bio_Ku { get; set; }      
        public string Bio_Ar { get; set; }

        public string Picture { get; set; }

        public string Website { get; set; }
       
        public string Description { get; set; }     
        public string Description_Ku { get; set; }     
        public string Description_Ar { get; set; }

        public float WorkExperience { get; set; } = 0;

        /// <summary>
        /// This is extra phone like secretary phone (to send reservation sms)
        /// </summary>
        [MaxLength(15), MinLength(10)]
        public string Phone { get; set; }

        /// <summary>
        /// اطلاعات رای گیری یک مطلب به صورت یک خاصیت تو در تو یا پیچیده
        /// Example in dotnettips.info
        /// http://www.dotnettips.info/courses/topic/1/975fbb15-6f32-4ffd-bac6-8554f0ab9df1
        /// </summary>
        //public virtual Rating Rating { set; get; }

        /// <summary>
        /// نگه داری زمان پذیرش تفاهم نامه
        /// </summary>
        public DateTime AcceptionDate { get; set; } = DateTime.Now;

        public virtual ServiceSupply ServiceSupply { get; set; }
       
        public virtual ICollection<DoctorScientificCategory> DoctorScientificCategories { get; set; }
        public virtual ICollection<AdditionalExpertise> AdditionalExpertises { get; set; }       
    }
}
