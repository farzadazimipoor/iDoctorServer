using AN.Core.Data;
using AN.Core.Domain;
using AN.Core.Enums;
using AN.Core.Exceptions;
using AN.Core.Models;
using AN.Core.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AN.BLL.DataRepository.HealthServices
{
    public partial class ServicesService : IServicesService
    {
        private readonly IRepository<Service> _serviceRepository;
        private readonly IRepository<ServiceCategory> _serviceCategoryRepository;
        private readonly IRepository<ShiftCenterService> _shiftCenterServiceRepository;
        public ServicesService(IRepository<Service> serviceRepository,
                               IRepository<ServiceCategory> serviceCategoryRepository,
                               IRepository<ShiftCenterService> shiftCenterServiceRepository)
        {
            _serviceRepository = serviceRepository;
            _serviceCategoryRepository = serviceCategoryRepository;
            _shiftCenterServiceRepository = shiftCenterServiceRepository;
        }


        public virtual IList<Service> GetAll()
        {
            var result = _serviceRepository.Table.ToList();

            return result;
        }


        public virtual Service GetServiceById(int id)
        {
            if (id == 0)
                return null;

            return _serviceRepository.GetById(id);
        }

        public async Task<List<ServiceListItemViewModel>> GetServicePagingDataAsync(Lang lang)
        {
            var result = new List<ServiceListItemViewModel>();

            var categories = await _serviceCategoryRepository.Table.ToListAsync();

            foreach (var category in categories)
            {
                result.Add(new ServiceListItemViewModel
                {
                    Order = result.Any() ? result.OrderByDescending(r => r.Order).FirstOrDefault().Order + 1 : 1,
                    Id = category.Id,
                    CategoryId = category.Id,
                    Category = lang == Lang.KU ? category.Name_Ku : lang == Lang.AR ? category.Name_Ar : category.Name,
                    ParentOrChild = ParentOrChild.PARENT,
                    Name = "",
                    Description = "",
                    Price = 0,
                    Time = ""
                });

                foreach (var x in category.Services)
                {
                    result.Add(new ServiceListItemViewModel
                    {
                        Order = result.OrderByDescending(r => r.Order).FirstOrDefault().Order + 1,
                        Id = x.Id,
                        CategoryId = x.ServiceCategoryId,
                        Category = "",
                        ParentOrChild = ParentOrChild.CHILD,
                        Name = lang == Lang.KU ? x.Name_Ku : lang == Lang.AR ? x.Name_Ar : x.Name,
                        Description = lang == Lang.KU ? x.Description_Ku : lang == Lang.AR ? x.Description_Ar : x.Description,
                        Time = x.Time,
                        Price = x.Price
                    });
                }
            }

            return result;
        }

        public async Task<List<SelectListItem>> GetServiceCategoriesSelectListAsync(Lang lang)
        {
            var query = _serviceCategoryRepository.Table;

            var result = await query.Select(c => new SelectListItem
            {
                Text = lang == Lang.KU ? c.Name_Ku : lang == Lang.AR ? c.Name_Ar : c.Name,
                Value = c.Id.ToString()
            }).ToListAsync();

            return result;
        }

        public async Task<ServiceCategoryViewModel> GetServiceCategoryForCRUD(int id)
        {
            var category = await _serviceCategoryRepository.GetByIdAsync(id);

            if (category == null) throw new AwroNoreException("Category not found");

            return new ServiceCategoryViewModel
            {
                Id = category.Id,
                CenterType = category.CenterType,
                Name = category.Name,
                Name_Ar = category.Name_Ar,
                Name_Ku = category.Name_Ku,
                Photo = category.Photo
            };
        }

        public async Task<ServiceViewModel> GetServiceForCRUD(int id)
        {
            var service = await _serviceRepository.GetByIdAsync(id);

            if (service == null) throw new AwroNoreException("Service not found");

            return new ServiceViewModel
            {
                Id = service.Id,
                Name = service.Name,
                Name_Ar = service.Name_Ar,
                Name_Ku = service.Name_Ku,
                Description = service.Description,
                Description_Ar = service.Description_Ar,
                Description_Ku = service.Description_Ku,
                ServiceCategoryId = service.ServiceCategoryId,
                Price = service.Price.ToString(),
                Time = service.Time
            };
        }

        #region PolyclinicHealthServices
        public ShiftCenterService GetShiftCenterServiceById(int polyclinicHealthServiceId)
        {
            if (polyclinicHealthServiceId == 0) return null;

            return _shiftCenterServiceRepository.GetById(polyclinicHealthServiceId);
        }

        public async Task<ShiftCenterService> GetShiftCenterServiceByIdAsync(int polyclinicHealthServiceId)
        {
            return await _shiftCenterServiceRepository.GetByIdAsync(polyclinicHealthServiceId);
        }

        public List<MySelectListItem> GetShiftCenterServicesListItems(int polyclinicId, Lang Lang)
        {
            if (polyclinicId == 0) return new List<MySelectListItem>();

            var query = _shiftCenterServiceRepository.Table.Where(x => x.ShiftCenterId == polyclinicId).Select(x => new MySelectListItem
            {
                Value = x.Id.ToString(),
                Text = Lang == Lang.KU ? x.Service.Name_Ku : Lang == Lang.AR ? x.Service.Name_Ar : x.Service.Name
            });

            return query.ToList();
        }

        public async Task<List<SelectListItem>> GetSelectListItemsAsync(int centerId, Lang Lang)
        {
            var result = await _shiftCenterServiceRepository.Table.Where(x => x.ShiftCenterId == centerId).Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = Lang == Lang.KU ? x.Service.Name_Ku : Lang == Lang.AR ? x.Service.Name_Ar : x.Service.Name
            }).ToListAsync();

            return result;
        }

        public async Task DeleteShiftCenterServiceAsync(int polyclinicId)
        {
            var healthServices = await _shiftCenterServiceRepository.Table.Where(x => x.ShiftCenterId == polyclinicId).ToListAsync();

            foreach (var item in healthServices)
            {
                await _shiftCenterServiceRepository.DeleteAsync(item);
            }
        }
        #endregion
    }
}
