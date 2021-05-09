using AN.Core.Data;
using AN.Core.Models;
using NetTopologySuite.Geometries;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AN.Core.Domain
{
    public class Pharmacy : BaseEntity
    {
        public Pharmacy()
        {
            Prescriptions = new HashSet<PharmacyPrescription>();
        }

        public string Name { get; set; }
        public string Name_Ku { get; set; }
        public string Name_Ar { get; set; }

        public string Address { get; set; }
        public string Address_Ku { get; set; }
        public string Address_Ar { get; set; }

        public Point Location { get; set; }

        public string Description { get; set; }
        public string Description_Ku { get; set; }
        public string Description_Ar { get; set; }

        public string Avatar { get; set; }

        public string _Images { get; set; }
        [NotMapped]
        public List<HealthCenterImageEntityModel> Images
        {
            get { return _Images == null ? null : JsonConvert.DeserializeObject<List<HealthCenterImageEntityModel>>(_Images); }
            set { _Images = JsonConvert.SerializeObject(value); }
        }

        public int CityId { get; set; }

        public virtual City City { get; set; }

        public virtual ICollection<PharmacyPrescription> Prescriptions { get; set; }
    }
}
