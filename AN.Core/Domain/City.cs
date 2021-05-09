
namespace AN.Core.Domain
{
    using AN.Core.Data;
    using System.Collections.Generic;

    public partial class City : BaseEntity
    {        
        public City()
        {
            Clinics = new HashSet<Clinic>();
            Hospitals = new HashSet<Hospital>();
            ShiftCenters = new HashSet<ShiftCenter>();
            InsuranceBranches = new HashSet<InsuranceBranch>();
        }          
              
        public string Name { get; set; }
        public string Name_Ku { get; set; }       
        public string Name_Ar { get; set; }
       
        public int ProvinceId { get; set; }       
       
        public virtual Province Province { get; set; }

        public virtual ICollection<Clinic> Clinics { get; set; }
        public virtual ICollection<Hospital> Hospitals { get; set; }
        public virtual ICollection<ShiftCenter> ShiftCenters { get; set; }
        public virtual ICollection<Pharmacy> Pharmacies { get; set; }
        public virtual ICollection<InsuranceBranch> InsuranceBranches { get; set; }
    }
}
