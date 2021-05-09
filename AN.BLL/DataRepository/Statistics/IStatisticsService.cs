using System.Threading.Tasks;

namespace AN.BLL.DataRepository.StatisticsRepo
{
    public partial interface IStatisticsService
    {
        Task<int> GetTotalVisitsCountAsync();
        int GetTotalVisitsCount();
        Task<int> GetTodayVisitsCountAsync();
        int GetTodayVisitsCount();
        Task<int> GetUniqueVisitsCountAsync();
        int GetUniqueVisitsCount();
    }
}
