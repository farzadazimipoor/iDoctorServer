using AN.Core.Data;
using AN.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AN.BLL.DataRepository.StatisticsRepo
{
    public partial class StatisticsService : IStatisticsService
    {
        private readonly IRepository<Statistics> _statisticsRepository;

        public StatisticsService(IRepository<Statistics> statisticsRepository)
        {
            _statisticsRepository = statisticsRepository;
        }

        public virtual async Task<int> GetTodayVisitsCountAsync()
        {
            var count = await (from s in _statisticsRepository.Table                               
                         where s.DateStamp.Date == DateTime.Now.Date
                         select s).CountAsync();
            return count;
        }

        public virtual int GetTodayVisitsCount()
        {
            return _statisticsRepository.Table.Count(s => s.DateStamp.Date == DateTime.Now.Date);
                            
        }

        public virtual async Task<int> GetTotalVisitsCountAsync()
        {
            return await _statisticsRepository.Table.CountAsync();
        }


        public virtual int GetTotalVisitsCount()
        {
            return _statisticsRepository.Table.Count();
        }

        public virtual async Task<int> GetUniqueVisitsCountAsync()
        {
            return await _statisticsRepository.Table.GroupBy(ta => ta.IpAddress).Select(ta => ta.Key).CountAsync();            
        }


        public virtual int GetUniqueVisitsCount()
        {
            return _statisticsRepository.Table.GroupBy(ta => ta.IpAddress).Select(ta => ta.Key).Count();
        }
    }
}
