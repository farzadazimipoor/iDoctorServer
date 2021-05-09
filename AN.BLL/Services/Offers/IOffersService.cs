using AN.Core.DTO;
using AN.Core.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AN.BLL.Services.Offers
{
    public interface IOffersService
    {
        Task<OffersDataDTO> GetOffersDataAsync(Lang lang, string hostAddress, int? cityId = null);

        Task<List<OfferItemDTO>> GetOffersByCategoryAsync(Lang lang, string hostAddress, OffersFilterDTO filters);

        Task<(long totalCount, int totalPages, List<OfferItemDTO>)> GetOffersListAsync(Lang lang, string hostAddress, int page = 0, int pageSize = 12, bool supportBasicOffers = false);

        Task<OfferTimePeriodsDTO> GetOfferTimePeriodsAsync(int id);
    }
}
