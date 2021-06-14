using AN.Core.Data;
using System.Collections.Generic;

namespace AN.Core.Domain
{
    public class Country : BaseEntity
    {
        public Country()
        {
            Provinces = new HashSet<Province>();
            MedicalRequests = new HashSet<MedicalRequest>();
        }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Name_Ku { get; set; }

        public string Name_Ar { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public string HomeCareDescription { get; set; }

        public string HomeCareDescription_Ku { get; set; }

        public string HomeCareDescription_Ar { get; set; }
       
        public virtual ICollection<Province> Provinces { get; set; }

        public virtual ICollection<MedicalRequest> MedicalRequests { get; set; }
    }
}
