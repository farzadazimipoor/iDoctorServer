using AN.Core.Domain;
using AN.Core.Enums;
using AN.Core.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AN.BLL.DataRepository.Patients
{
    public interface IPatientService
    {
        Task<Patient> GetByIdAsync(int id);

        Task<Patient> FindForServiceSupplyAsync(int serviceSupplyId, int personId);

        Task<Patient> FindForCenterAsync(int centerId, int personId);

        Task InsertNewPatientAsync(Patient patient);

        Task<List<SelectListItem>> GetSelectListItemsAsync(int? shiftCenterId = null, List<int> serviceSupplyIds = null, Lang lng = Lang.KU);

        Task<DataTablesPagedResults<PatientListViewModel>> GetDataTableAsync(int shiftCenterId, DataTablesParameters table, PatientFilterViewModel filters, Lang lng = Lang.KU, bool onlyForCenter = false);
    }
}
