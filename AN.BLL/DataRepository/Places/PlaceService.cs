using AN.Core.Data;
using AN.Core.Domain;
using AN.Core.DTO.Location;
using AN.Core.Enums;
using AN.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AN.BLL.DataRepository.Places
{
    public partial class PlaceService : IPlaceService
    {
        private readonly IRepository<Country> _countryRepository;
        private readonly IRepository<Province> _provinceRepository;
        private readonly IRepository<City> _cityRepository;
        public PlaceService(IRepository<Country> countryRepository, IRepository<Province> provinceRepository, IRepository<City> cityRepository)
        {
            _countryRepository = countryRepository;
            _cityRepository = cityRepository;
            _provinceRepository = provinceRepository;
        }


        public virtual IQueryable<City> GetAllCities()
        {
            return _cityRepository.Table;
        }

        public IQueryable<Province> GetAllProvinces()
        {
            return _provinceRepository.Table;
        }

        public virtual IList<CommonEntity> GetCitiesForProvince(int provinceId, Lang lng)
        {
            if (provinceId == 0) return null;

            var query = from c in _cityRepository.Table
                        where c.ProvinceId == provinceId
                        select new CommonEntity { Id = c.Id, Name = lng == Lang.AR ? c.Name_Ar : c.Name_Ku };

            return query.ToList();
        }

        public async Task<City> GetCityByIdAsync(int id)
        {
            var result = await _cityRepository.GetByIdAsync(id);

            return result;
        }

        public virtual void InsertCity(City city)
        {
            _cityRepository.Insert(city);
        }

        public void UpdateCity(City city)
        {
            _cityRepository.Update(city);
        }

        public async Task DeleteCityAsync(int id)
        {
            var city = await _cityRepository.GetByIdAsync(id);

            if(city != null)
            {
                await _cityRepository.DeleteAsync(city);
            }
        }

        public async Task<List<ProvinceDTO>> GetProvincesListAsync(Lang lng)
        {
            var result = await _provinceRepository.Table.Select(x => new ProvinceDTO
            {
                Id = x.Id,
                Name = lng == Lang.AR ? x.Name_Ar : x.Name_Ku,
                Cities = x.Cities.Select(c => new CityDTO
                {
                    Id = c.Id,
                    Name = lng == Lang.AR ? c.Name_Ar : c.Name_Ku,
                    ProvinceId = x.Id
                }).ToList()
            }).ToListAsync();

            return result;
        }

        public async Task<List<CountryDTO>> GetCountriesListAsync(Lang lng)
        {
            var result = await _countryRepository.Table.Select(x => new CountryDTO
            {
                Id = x.Id,
                Name = lng == Lang.AR ? x.Name_Ar : lng == Lang.KU ? x.Name_Ku : x.Name
            }).ToListAsync();

            return result;
        }
    }
}
