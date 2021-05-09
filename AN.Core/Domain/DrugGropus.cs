using AN.Core.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AN.Core.Domain
{
    public class DrugGroups : BaseEntity
    {
        [NotMapped]
        public override int Id { get => base.Id; set => base.Id = value; }       

        [Key, Column(Order = 0)]
        public int PharmaceuticalGroupId { get; set; }
     
        [Key, Column(Order = 1)]
        public int DrugId { get; set; }
       
        public virtual PharmaceuticalGroup PharmaceuticalGroup { get; set; }
       
        public virtual Drug Drug { get; set; }
    }
}
