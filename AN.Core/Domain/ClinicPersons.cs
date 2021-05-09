using AN.Core.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AN.Core.Domain
{
    public class ClinicPersons : BaseEntity
    {
        [NotMapped]
        public override int Id { get => base.Id; set => base.Id = value; }

        [Key, Column(Order = 0)]
        public int Clinic_Id { get; set; }

        [Key, Column(Order = 1)]
        public int PersonId { get; set; }

        public bool IsManager { get; set; } = false;

        public string TempGeneratedPassword { get; set; }       
        
        public virtual Clinic Clinic { get; set; }
       
        public virtual Person Person { get; set; }
    }
}
