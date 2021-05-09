using AN.Core.DTO;
using AN.Core.Enums;
using System.Threading.Tasks;

namespace AN.BLL.Services.Filters
{
    public interface IFiltersService
    {
        Task<FilterDTO> GetFilterDataAsync(Lang lng);

        Task<ServicesFilterDTO> GetServicesFilterDataAsync(Lang lang);
    }
}
