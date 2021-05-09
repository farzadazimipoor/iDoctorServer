namespace AN.Core.Domain
{
    using AN.Core.Data;
    using System.Collections.Generic;

    /// <summary>
    /// Specifies which patients have used this insurance to take turns
    /// </summary>
    public partial class PatientInsurance : BaseEntity
    {
        public PatientInsurance()
        {
            Appointments = new HashSet<Appointment>();
        }
       
        public int ServiceSupplyInsuranceId { get; set; }

        public int UserPatientId { get; set; }

        public string InsuranceNumber { get; set; }       

        public virtual ServiceSupplyInsurance Insurance { get; set; }

        public virtual PatientPersonInfo UserPatientInfo { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }       

    }
}
