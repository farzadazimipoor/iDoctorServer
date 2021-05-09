using AN.Core.Domain;
using AN.Core.Enums;
using AN.Core.Models;
using AN.Core.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AN.BLL.DataRepository.HealthServices
{
    public partial interface IServicesService
    {
      
        Service GetServiceById(int id);
       
        IList<Service> GetAll();

        Task<List<ServiceListItemViewModel>> GetServicePagingDataAsync(Lang lang);

        ShiftCenterService GetShiftCenterServiceById(int shiftCenterServiceId);

        Task<ShiftCenterService> GetShiftCenterServiceByIdAsync(int polyclinicHealthServiceId);

        List<MySelectListItem> GetShiftCenterServicesListItems(int polyclinicId, Lang Lang);

        Task<List<SelectListItem>> GetSelectListItemsAsync(int centerId, Lang Lang);

        Task DeleteShiftCenterServiceAsync(int polyclinicId);

        Task<List<SelectListItem>> GetServiceCategoriesSelectListAsync(Lang lang);

        Task<ServiceCategoryViewModel> GetServiceCategoryForCRUD(int id);

        Task<ServiceViewModel> GetServiceForCRUD(int id);
    }
}
