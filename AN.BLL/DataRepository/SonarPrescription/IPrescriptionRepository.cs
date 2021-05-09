using AN.Core.Domain;
using AN.Core.Enums;
using AN.Core.ViewModels;
using Shared.Models;
using System.Threading.Tasks;

namespace AN.BLL.DataRepository
{
    public interface IPrescriptionRepository
    {
        Task<CenterPrescription> GetByIdAsync(int id);

        Task<SonarDashboardViewModel> CenterDashboardDataAsync(int sonarId);

        Task<DataTablesPagedResults<SonarPrescriptionListViewModel>> GetDataTableAsync(DataTablesParameters table, PrescriptionFilterViewModel filters, Lang lng = Lang.KU);

        Task SetStatusAsync(int id, int centerId, int treatmentId, PrescriptionStatus status);

        Task DeletePrescriptionAsync(int id, int centerId, int treatmentId);
    }
}
