using AN.Core.Domain;
using AN.Core.Enums;
using AN.Core.ViewModels;
using Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AN.BLL.DataRepository.TreatmentHistories
{
    public interface ITreatmentHistoryService
    {
        Task<TreatmentHistory> GetByIdAsync(int id);

        Task InsertNewTreatmentAsync(TreatmentHistory treatment);

        Task<List<TreatmentHistory>> GetByPatientAsync(int patientId, int centerId);

        Task<DataTablesPagedResults<TreatmentHistoryListItemViewModel>> GetDataTableAsync(int shiftCenterId, DataTablesParameters table, TreatmentHistoryFilterViewModel filters, Lang lng = Lang.KU);
    }
}
