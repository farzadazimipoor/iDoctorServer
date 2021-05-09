using AN.Core.Data;

namespace AN.Core.Domain
{
    public class AdditionalExpertise : BaseEntity
    {       
        public string Name { get; set; }
        public string Name_Ku { get; set; }        
        public string Name_Ar { get; set; }
       
        public string Description { get; set; }
        public string Description_Ku { get; set; }       
        public string Description_Ar { get; set; }

        public int UserDoctorId { get; set; }
        
        public virtual ServiceSupplyInfo UserDoctorInfo { get; set; }       
    }
}
