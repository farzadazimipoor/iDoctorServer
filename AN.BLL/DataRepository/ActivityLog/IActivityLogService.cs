using AN.Core.Domain;

namespace AN.BLL.DataRepository.ActivityLog
{
    public partial interface IActivityLogService
    {
        void InsertActivityLog(DoctorActivityLog activityLog);
    }
}
