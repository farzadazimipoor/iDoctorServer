using AN.Core.Data;
using System.Collections.Generic;
namespace AN.Core.Domain
{
    public class ExpertiseCategory : BaseEntity
    {
        public ExpertiseCategory()
        {
            Expertises = new HashSet<Expertise>();
        }
       
        public string Name { get; set; }
        public string Name_Ku { get; set; }        
        public string Name_Ar { get; set; }
              
        public string Description { get; set; }        
        public string Description_Ku { get; set; }        
        public string Description_Ar { get; set; }

        public virtual ICollection<Expertise> Expertises { get; set; }
    }
}
