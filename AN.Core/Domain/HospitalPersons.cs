using AN.Core.Data;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AN.Core.Domain
{
    public class HospitalPersons : BaseEntity
    {
        [NotMapped]
        public override int Id { get => base.Id; set => base.Id = value; }

        [Key, Column(Order = 0)]
        public int HospitalId { get; set; }

        [Key, Column(Order = 1)]
        public int PersonId { get; set; } 

        public bool IsManager { get; set; }

        //داده های این فیلد موقتی است و بعد از تایید مطب توسط مدیر سیستم پاک می شود
        public string TempGeneratedPassword { get; set; }      
       
        public virtual Hospital Hospital { get; set; }
       
        public virtual Person Person { get; set; }
    }
}
