using AN.Core.Data;
using AN.Core.Domain;
using System;

namespace AN.BLL.DataRepository.ActivityLog
{
    public partial class ActivityLogService : IActivityLogService
    {
        private readonly IRepository<DoctorActivityLog> _doctorActivityLogRepository;
        public ActivityLogService(IRepository<DoctorActivityLog> doctorActivityLogRepository)
        {
            _doctorActivityLogRepository = doctorActivityLogRepository;
        }

        public void InsertActivityLog(DoctorActivityLog activityLog)
        {
            if (activityLog == null)
                throw new ArgumentNullException(nameof(activityLog));

            _doctorActivityLogRepository.Insert(activityLog);
        }
    }
}
