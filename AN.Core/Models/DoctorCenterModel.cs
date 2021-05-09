using AN.Core.Enums;
using System.Collections.Generic;

namespace AN.Core.Models
{
    public class DoctorCenterModel
    {
        public string CenterName { get; set; }
        public HealthCenterType CenterType { get; set; }
        public string CenterAddress { get; set; }
        public List<WorkingHourModel> WorkingHoures { get; set; }
    }
}
