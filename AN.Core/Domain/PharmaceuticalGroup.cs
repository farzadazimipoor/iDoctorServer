using AN.Core.Data;
using System.Collections.Generic;

namespace AN.Core.Domain
{
    public class PharmaceuticalGroup : BaseEntity
    {
        public PharmaceuticalGroup()
        {
            DrugGroups = new HashSet<DrugGroups>();
        }
      
        public string Name { get; set; }
    
        public string Name_Ku { get; set; }
     
        public string Name_Ar { get; set; }

        public virtual ICollection<DrugGroups> DrugGroups { get; set; }
    }
}
