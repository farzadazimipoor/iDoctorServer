using AN.Core.Domain;
using AN.Core.DTO.Location;
using AN.Core.Enums;
using AN.Core.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AN.BLL.DataRepository.Places
{
    public partial interface IPlaceService
    {
        Task<City> GetCityByIdAsync(int id);

        IQueryable<City> GetAllCities();

        void InsertCity(City city);

        void UpdateCity(City city);

        Task DeleteCityAsync(int id);

        IList<CommonEntity> GetCitiesForProvince(int provinceId, Lang lng);

        IQueryable<Province> GetAllProvinces();

        Task<List<ProvinceDTO>> GetProvincesListAsync(Lang lng);

        Task<List<CountryDTO>> GetCountriesListAsync(Lang lng);
    }
}
