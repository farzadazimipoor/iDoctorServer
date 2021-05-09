using AN.Core.Domain;
using AN.Core.Enums;
using AN.Core.ViewModels;
using Shared.Models;
using System.Threading.Tasks;

namespace AN.BLL.DataRepository
{
    public interface IPharmacyPrescriptionRepository
    {
        Task<PharmacyPrescription> GetByIdAsync(int id);

        Task<PharmacyPrescription> GetPharmacyPrescriptionAsync(int pharmacyId, int treatmentId);

        Task<PharmacyDashboardViewModel> PharmacyDashboardDataAsync(int pharmacyId);

        Task<DataTablesPagedResults<PharmacyPrescriptionListViewModel>> GetDataTableAsync(DataTablesParameters table, PharmacyPrescriptionFilterViewModel filters, Lang lng = Lang.KU);

        Task SetStatusAsync(int pharmacyId, int treatmentId, PrescriptionStatus status);

        Task DeletePrescriptionAsync(int pharmacyId, int treatmentId);
    }
}
