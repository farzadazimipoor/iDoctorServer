using AN.Core.Domain;
using AN.Core.DTO;
using AN.Core.Enums;
using AN.Core.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AN.BLL.DataRepository.Insurances
{
    public interface IInsuranceService
    {
        Task<List<InsuranceItemDTO>> GetInsurancesAsync(Lang lng, string hostAddress, int? cityId = null);
        Task<DataTablesPagedResults<InsuranceListItemViewModel>> GetDataTableAsync(DataTablesParameters table, InsuranceFilterViewModel filters, Lang lng = Lang.KU);
        Task<Insurance> GetByIdAsync(int id);
        Task<List<Insurance>> GetAllInsurancesAsync();
        Task<List<SelectListItem>> GetSelectListItemsAsync(Lang lang);
        Task<int> CreateUpdateInsuranceAsync(InsuranceCRUDViewModel model);
        Task DeleteInsuranceAsync(int id);
    }
}
