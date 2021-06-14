using AN.Core.DTO;
using AN.Core.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AN.BLL.Services.Filters
{
    public interface IFiltersService
    {
        Task<FilterDTO> GetFilterDataAsync(Lang lng);

        Task<ServicesFilterDTO> GetServicesFilterDataAsync(Lang lang);

        Task<List<CenterServiceDTO>> GetServicesFilterDataAsync(Lang lang, ShiftCenterType centerType);
    }
}
