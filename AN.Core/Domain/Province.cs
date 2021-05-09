using AN.Core.Data;
using System.Collections.Generic;

namespace AN.Core.Domain
{
    public partial class Province : BaseEntity
    {
        public Province()
        {
            Cities = new HashSet<City>();
        }       
     
        public string Name { get; set; }

        public string Name_Ku { get; set; }      

        public string Name_Ar { get; set; }

        public int? CountryId { get; set; }

        public virtual Country Country { get; set; }
        
        public virtual ICollection<City> Cities { get; set; }
    }
}
