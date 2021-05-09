using AN.Core.Data;
using System.Collections.Generic;

namespace AN.Core.Domain
{
    public class ScientificCategory : BaseEntity
    {
        public ScientificCategory()
        {
            DoctorExpertises = new HashSet<DoctorExpertise>();
            DoctorScientificCategories = new HashSet<DoctorScientificCategory>();
        }
         
        public string Name { get; set; }
        public string Name_Ku { get; set; }        
        public string Name_Ar { get; set; }
      
        public string Description { get; set; }       
        public string Description_Ku { get; set; }       
        public string Description_Ar { get; set; }

        public virtual ICollection<DoctorExpertise> DoctorExpertises { get; set; }
        public virtual ICollection<DoctorScientificCategory> DoctorScientificCategories { get; set; }
    }
}
