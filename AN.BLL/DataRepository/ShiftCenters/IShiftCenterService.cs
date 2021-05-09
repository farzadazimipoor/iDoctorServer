using AN.Core.Domain;
using AN.Core.Enums;
using AN.Core.Models;
using AN.Core.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AN.BLL.DataRepository.Polyclinics
{
    public partial interface IShiftCenterService
    {
        Task<ShiftCenter> GetByIdAsync(int id);

        Task<List<SelectListItem>> GetSelectListAsync(Lang lang, List<ShiftCenterType> types = null);

        Task<long> GetAllCountForHospitalAsync(int hospitalId);

        IEnumerable<ShiftCenter> DynamicQuery(QueryModel<ShiftCenter> model);

        int GetAllApprovedIndependentShiftCenterCount();

        Task<int> GetAllApprovedShiftCentersCountAsync(bool? isIndependent = null);

        IQueryable<ShiftCenter> GetAllApprovedIndependentShiftCenters();

        IQueryable<ShiftCenter> GetAllUnApprovedIndependentShiftCenters();

        IList<ShiftCenter> GetAllShiftCentersForHospital(int hospitalId);

        IList<ShiftCenter> GetAllShiftCentersForClinic(int clinicId);

        Task<int> GetAllUnApprovedIndependentShiftCentersCountAsync();

        ShiftCenter GetShiftCenterById(int id);

        ShiftCenter GetIndependentShiftCenterById(int id);

        ShiftCenter GetShiftCenterForArea(int id);

        ShiftCenter GetCurrentShiftCenter();

        void DeleteShiftCenter(ShiftCenter poliClinic);

        void InsertShiftCenter(ShiftCenter poliClinic);

        IQueryable<ShiftCenter> GetPoliclinicsForUser(int userId);

        Task<DataTablesPagedResults<RegisterRequestsListViewModel>> GetRegistrationRequestsDataTableAsync(DataTablesParameters table, RegisterRequestsFilterViewModel filters, Lang lng = Lang.KU);

        Task ApproveRegistrationRequestAsync(int id);

        Task DeleteRegistrationRequestAsync(int id);
    }
}
