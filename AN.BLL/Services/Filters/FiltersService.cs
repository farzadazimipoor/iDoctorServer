using AN.Core.DTO;
using AN.Core.DTO.Location;
using AN.Core.Enums;
using AN.Core.Extensions;
using AN.DAL;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AN.BLL.Services.Filters
{
    public class FiltersService : IFiltersService
    {
        private readonly BanobatDbContext _dbContext;
        public FiltersService(BanobatDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<FilterDTO> GetFilterDataAsync(Lang lng)
        {
            var countries = await _dbContext.Countries.Select(x => new CountryDTO
            {
                Id = x.Id,
                Name = lng == Lang.KU ? x.Name_Ku : lng == Lang.AR ? x.Name_Ar : x.Name,
                HomeCareDescription = lng == Lang.KU ? x.HomeCareDescription_Ku : lng == Lang.AR ? x.HomeCareDescription_Ar : x.HomeCareDescription,
                Type = x.Type,
                TypeTitle = x.Type.GetLocalizedDisplayName()
            }).ToListAsync();

            var cities = await _dbContext.Cities.Select(x => new CityDTO
            {
                Id = x.Id,
                Name = lng == Lang.KU ? x.Name_Ku : lng == Lang.AR ? x.Name_Ar : x.Name,
                ProvinceId = x.ProvinceId
            }).ToListAsync();

            var hospitals = await _dbContext.Hospitals.Select(x => new HospitalDTO
            {
                Id = x.Id,
                Name = lng == Lang.KU ? x.Name_Ku : lng == Lang.AR ? x.Name_Ar : x.Name,
                CityId = x.CityId

            }).ToListAsync();

            var clinics = await _dbContext.Clinics.Select(x => new ClinicDTO
            {
                Id = x.Id,
                CityId = x.CityId,
                HospitalId = x.HospitalId,
                Name = lng == Lang.KU ? x.Name_Ku : lng == Lang.AR ? x.Name_Ar : x.Name,
            }).ToListAsync();

            var expertiseCats = await _dbContext.ExpertiseCategories.Select(x => new ExpertiseCategoryDTO
            {
                Id = x.Id,
                Name = lng == Lang.KU ? x.Name_Ku : lng == Lang.AR ? x.Name_Ar : x.Name,
            }).ToListAsync();

            var expertises = await _dbContext.Expertises.Select(x => new ExpertiseDTO
            {
                Id = x.Id,
                Name = lng == Lang.KU ? x.Name_Ku : lng == Lang.AR ? x.Name_Ar : x.Name,
                CategoryId = x.ExpertiseCategoryId
            }).ToListAsync();

            var insurances = await _dbContext.Insurances.Select(x => new InsuranceItemDTO
            {
                Id = x.Id,
                Name = lng == Lang.KU ? x.Name_Ku : lng == Lang.AR ? x.Name_Ar : x.Name,
                Logo = x.Logo
            }).ToListAsync();

            var result = new FilterDTO
            {
                Countries = countries,
                Cities = cities,
                Hospitals = hospitals,
                Clinics = clinics,
                ExpertiseCategories = expertiseCats,
                Expertises = expertises,
                Insurances = insurances
            };

            return result;
        }

        public async Task<ServicesFilterDTO> GetServicesFilterDataAsync(Lang lang)
        {
            var serviceCategories = await _dbContext.ServiceCategories.Select(x => new ServiceCategoryDTO
            {
                Id = x.Id,
                Name = lang == Lang.KU ? x.Name_Ku : lang == Lang.AR ? x.Name_Ar : x.Name,
                CenterType = x.CenterType
            }).ToListAsync();

            var services = await _dbContext.Services.Select(x => new ServiceDTO
            {
                Id = x.Id,
                Name = lang == Lang.KU ? x.Name_Ku : lang == Lang.AR ? x.Name_Ar : x.Name,
                CategoryId = x.ServiceCategoryId,
                Price = x.Price.ToString(),
                CategoryCenterType = x.ServiceCategory.CenterType,                
            }).ToListAsync();

            var result = new ServicesFilterDTO
            {
                ServiceCategories = serviceCategories,
                Services = services
            };

            var homecareCenterTypes = await _dbContext.CenterServices.Where(x => x.Service.ServiceCategory.CenterType == ShiftCenterType.HomeCare).ToListAsync();

            return result;
        }

        public async Task<List<CenterServiceDTO>> GetServicesFilterDataAsync(Lang lang, ShiftCenterType centerType)
        {
            var services = await _dbContext.CenterServices.Where(x => x.Service.ServiceCategory.CenterType == centerType).Select(x => new CenterServiceDTO
            {
                Id = x.Id,
                Name = lang == Lang.KU ? x.Service.Name_Ku : lang == Lang.AR ? x.Service.Name_Ar : x.Service.Name,
                CategoryId = x.Service.ServiceCategoryId,
                Price = x.Price ?? x.Service.Price.ToString(),
                CenterId = x.ShiftCenterId,
                CenterServiceId = x.Id,
                CurrencyType = x.CurrencyType.ToString(),
                CategoryCenterType = x.Service.ServiceCategory.CenterType
            }).ToListAsync();

            return services;
        }
    }
}
