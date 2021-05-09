using AN.Core.Domain;
using AN.Core.Enums;
using AN.Core.ViewModels;
using Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AN.BLL.DataRepository
{
    public interface IOfferRepository
    {
        Task<Offer> GetByIdAsync(int id);

        Task InsertOfferAsync(Offer offer);

        void UpdateOffer(Offer offer);

        Task<DataTablesPagedResults<OfferListViewModel>> GetDataAsync(DataTablesParameters table, int? centerId = null, List<int> serviceSupplyIds = null, bool isForAdmin = false);

        Task<Offer> SetNewStatusAsync(int id, OfferStatus newStatus);

        Task<bool> IsExistCodeAsync(string code);

        Task<string> GenerateUniqueCodeAsync();

        Task DeleteAsync(int id);
    }
}
