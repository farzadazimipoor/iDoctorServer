using AN.BLL.DataRepository.Insurances;
using AN.Core.DTO;
using AN.Core.Enums;
using AN.Core.ViewModels;
using Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AN.BLL.Services
{
    public interface IInsuranceServiceService
    {
        Task<List<InsuranceServiceItemDTO>> GetInsuranceServicesAsync(int insuranceId, Lang lng, string hostAddress);

        Task<DataTablesPagedResults<InsuranceServiceListItemViewModel>> GetDataTableAsync(DataTablesParameters table, InsuranceServiceFilterViewModel filters, Lang lng = Lang.KU);

        Task<AN.Core.Domain.InsuranceService> GetByIdAsync(int id);

        Task<int> CreateUpdateInsuranceServiceAsync(InsuranceServiceCRUDViewModel model);

        Task DeleteInsuranceServiceAsync(int id);
    }
}
