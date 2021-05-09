using System;
using System.Collections.Generic;
using System.Text;

namespace AN.Core.DTO.Profile
{
    public class DiseaseRecordsFormDTO
    {
        public long Age { get; set; }

        public bool HasLongTermDisease { get; set; }

        public string LongTermDiseasesDescription { get; set; }

        public string DrugsYouUsed { get; set; }

        public string MedicalAllergies { get; set; }

        public bool DoYouSmoke { get; set; }

        public bool HadSurgery { get; set; }

        public string SurgeriesDescription { get; set; }

        public int PersonId { get; set; }
    }
}
