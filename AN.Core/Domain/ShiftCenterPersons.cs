using AN.Core.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AN.Core.Domain
{
    public class ShiftCenterPersons : BaseEntity
    {
        [NotMapped]
        public override int Id { get => base.Id; set => base.Id = value; }

        [Key, Column(Order = 0)]
        public int ShiftCenterId { get; set; }

        [Key, Column(Order = 1)]
        public int PersonId { get; set; }

        public bool IsManager { get; set; }

        public bool IsPatient { get; set; } = true;

        //داده های این فیلد موقتی است و بعد از تایید مطب توسط مدیر سیستم پاک می شود
        public string TempGeneratedPassword { get; set; }     
        
        public virtual ShiftCenter ShiftCenter { get; set; }
      
        public virtual Person Person { get; set; }
    }
}
