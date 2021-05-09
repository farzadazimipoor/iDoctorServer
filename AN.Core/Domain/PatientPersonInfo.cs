
namespace AN.Core.Domain
{
    using AN.Core.Data;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    public partial class PatientPersonInfo : BaseEntity
    {
        public PatientPersonInfo()
        {
            this.PatientInsurances = new HashSet<PatientInsurance>();
        }

        [NotMapped]
        public override int Id { get => base.Id; set => base.Id = value; }
      
        public int PersonId { get; set; }

        public int FreeTurnsCount { get; set; } = 0;       

        public virtual Person Person { get; set; }

        public virtual ICollection<PatientInsurance> PatientInsurances { get; set; }        
    }
}
