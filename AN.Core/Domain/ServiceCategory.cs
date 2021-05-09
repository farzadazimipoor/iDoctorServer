using AN.Core.Data;
using AN.Core.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AN.Core.Domain
{
    public class ServiceCategory : BaseEntity
    {
        public ServiceCategory()
        {
            Services = new HashSet<Service>();
        }

        public string Name { get; set; }

        public string Name_Ku { get; set; }

        public string Name_Ar { get; set; }     
        
        public ShiftCenterType CenterType { get; set; }

        public string Photo { get; set; }

        [NotMapped]
        public string RealPhoto => !string.IsNullOrEmpty(Photo) ? Photo : "/images/logo.png";

        public virtual ICollection<Service> Services { get; set; }
    }
}
