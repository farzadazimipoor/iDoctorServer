using AN.Core.DTO;
using AN.Core.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AN.BLL.Services
{
    public interface IHealthBankService
    {
        Task<List<HealthBankCategoryDTO>> GetHealthBankCategoriesAsync(Lang lang, string hostAddress, int? cityId = null);

        Task<HealthBankItemsPagingResultDTO> GetHelathBankItemsAsync(HealthBankCategoryType type, Lang lang, string hostAddress, ShiftCenterType? centerType = null, int? cityId = null, string filterString = "", int page = 0, int pageSize = 12);

        Task<HealthBankItemDetailDTO> GetHealthBankItemDetailAsync(HealthBankCategoryType type, Lang lang, string hostAddress, int id);
    }
}
