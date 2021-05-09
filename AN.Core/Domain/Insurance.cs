using AN.Core.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AN.Core.Domain
{
    public partial class Insurance : BaseEntity
    {
        public Insurance()
        {
            ServiceSupplies = new HashSet<ServiceSupplyInsurance>();
            Documents = new HashSet<InsuranceService>();
            CityBranches = new HashSet<InsuranceBranch>();
        }

        public string Name { get; set; }
        public string Name_Ku { get; set; }
        public string Name_Ar { get; set; }

        public string Description { get; set; }
        public string Description_Ku { get; set; }
        public string Description_Ar { get; set; }

        public string Logo { get; set; }

        [NotMapped]
        public string RealLogo => !string.IsNullOrEmpty(Logo) ? Logo : $"/images/logo.png";

        public string FullLogoUrl(string hostAddress) => $"{hostAddress}{RealLogo}";

        public virtual ICollection<ServiceSupplyInsurance> ServiceSupplies { get; set; }
        public virtual ICollection<InsuranceService> Documents { get; set; }
        public virtual ICollection<InsuranceBranch> CityBranches { get; set; }
    }
}
