using AN.Core.Data;
using System.Collections.Generic;

namespace AN.Core.Domain
{
    /// <summary>
    /// Specifies what insurance each doctor has a contract with
    /// </summary>
    public class ServiceSupplyInsurance : BaseEntity
    {
        public ServiceSupplyInsurance()
        {
            UsualSchedules = new HashSet<UsualScheduleInsurances>();
            Schedules = new HashSet<ScheduleInsurance>();
            Patients = new HashSet<PatientInsurance>();
        }

        public int ServiceSupplyId { get; set; }

        public int InsuranceId { get; set; }

        public virtual ServiceSupply ServiceSupply { get; set; }

        public virtual Insurance Insurance { get; set; }

        public virtual ICollection<UsualScheduleInsurances> UsualSchedules { get; set; }
        public virtual ICollection<ScheduleInsurance> Schedules { get; set; }
        public virtual ICollection<PatientInsurance> Patients { get; set; }
    }
}
