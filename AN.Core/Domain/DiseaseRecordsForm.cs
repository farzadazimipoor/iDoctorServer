using AN.Core.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace AN.Core.Domain
{
    public class DiseaseRecordsForm : BaseEntity
    {
        [NotMapped]
        public override int Id { get => base.Id; set => base.Id = value; }

        public long Age { get; set; }

        public bool HasLongTermDisease { get; set; }

        public string LongTermDiseasesDescription { get; set; }

        public string DrugsYouUsed { get; set; }

        public string MedicalAllergies { get; set; }

        public bool DoYouSmoke { get; set; }

        public bool HadSurgery { get; set; }

        public string SurgeriesDescription { get; set; }

        public int PersonId { get; set; }

        public virtual Person Person { get; set; }
    }
}
