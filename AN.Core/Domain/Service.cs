using AN.Core.Data;
using System.Collections.Generic;

namespace AN.Core.Domain
{
    public partial class Service : BaseEntity
    {
        public Service()
        {
            ShiftCenterServices = new HashSet<ShiftCenterService>();
        }
            
        public string Name { get; set; }

        public string Name_Ku { get; set; }      

        public string Name_Ar { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string Description_Ku { get; set; }

        public string Description_Ar { get; set; }

        /// <summary>
        /// Format: 00:00
        /// </summary>
        public string Time { get; set; }

        public int ServiceCategoryId { get; set; }

        public virtual ServiceCategory ServiceCategory { get; set; }

        public virtual ICollection<ShiftCenterService> ShiftCenterServices { get; set; }

    }
}
