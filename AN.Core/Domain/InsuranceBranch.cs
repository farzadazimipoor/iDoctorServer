using AN.Core.Data;
using NetTopologySuite.Geometries;

namespace AN.Core.Domain
{
    public class InsuranceBranch : BaseEntity
    {
        public string Address { get; set; }
        public string Address_Ku { get; set; }
        public string Address_Ar { get; set; }

        public Point Location { get; set; }

        public int CityId { get; set; }

        public int InsuranceId { get; set; }

        public virtual City City { get; set; }

        public virtual Insurance Insurance { get; set; }
    }
}
