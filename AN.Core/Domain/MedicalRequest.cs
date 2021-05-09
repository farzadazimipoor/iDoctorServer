using AN.Core.Data;
using System;

namespace AN.Core.Domain
{
    public class MedicalRequest : BaseEntity
    {
        public DateTime Date { get; set; }

        public string Note { get; set; }

        /// <summary>
        /// Medical request is for which country
        /// </summary>
        public int RequestedCountryId { get; set; }

        /// <summary>
        /// Which user has created this medical request
        /// </summary>
        public int RequesterPersonId { get; set; }

        public virtual Country RequestedCountry { get; set; }

        public virtual Person RequesterPerson { get; set; }
    }
}
