using AN.Core.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AN.BLL.Services.Reports
{
    public interface IDashboardReportsService
    {
        Task<CenterAppointmentsDashboardModel> GetShiftCenterDashboardDataAsync(int centerId, List<int> serviceSupplyIds = null);
    }
}
