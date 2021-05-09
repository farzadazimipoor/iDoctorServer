using AN.Core.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AN.BLL.DataRepository.Insurances
{
    public interface IScheduleInsuranceService
    {
        Task<List<UsualScheduleInsurances>> GetAllAsync(int usualScheduleId);
        Task InsertUsualScheduleInsuranceAsync(UsualScheduleInsurances usualScheduleInsurance);
        Task<bool> IsExistsAsync(int scheduleId, int insuranceId);
        Task DeleteUsualScheduleInsuranceAsync(int id);
    }
}
