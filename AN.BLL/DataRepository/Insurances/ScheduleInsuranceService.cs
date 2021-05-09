using AN.Core.Data;
using AN.Core.Domain;
using AN.Core.MyExceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AN.BLL.DataRepository.Insurances
{
    public class ScheduleInsuranceService : IScheduleInsuranceService
    {
        private readonly IRepository<UsualScheduleInsurances> _usualScheduleInsuranceRepository;
        public ScheduleInsuranceService(IRepository<UsualScheduleInsurances> usualScheduleInsuranceRepository)
        {
            _usualScheduleInsuranceRepository = usualScheduleInsuranceRepository;
        }

        public async Task<List<UsualScheduleInsurances>> GetAllAsync(int usualScheduleId)
        {
            if (usualScheduleId == 0)
                return new List<UsualScheduleInsurances>();

            return await _usualScheduleInsuranceRepository.Table.Where(x => x.ScheduleId == usualScheduleId).ToListAsync();
        }

        public async Task<bool> IsExistsAsync(int scheduleId, int insuranceId)
        {
            var result = await _usualScheduleInsuranceRepository.Table.AnyAsync(x =>x.ServiceSupplyInsuranceId == insuranceId && x.ScheduleId == scheduleId);

            return result;
        }

        public async Task InsertUsualScheduleInsuranceAsync(UsualScheduleInsurances usualScheduleInsurance)
        {
            if (usualScheduleInsurance == null)
            {
                throw new ArgumentNullException(nameof(usualScheduleInsurance));
            }

            await _usualScheduleInsuranceRepository.InsertAsync(usualScheduleInsurance);
        }

        public async Task DeleteUsualScheduleInsuranceAsync(int id)
        {
            var entity = await _usualScheduleInsuranceRepository.Table.FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null)
                throw new EntityNotFoundException();

            _usualScheduleInsuranceRepository.Delete(entity);
        }
        
    }
}
