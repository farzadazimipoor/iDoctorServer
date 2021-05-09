using AN.Core.Domain;
using AN.Core.DTO;
using AN.Core.Enums;
using AN.Core.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AN.BLL.DataRepository
{
    public interface IPharmacyRepository
    {
        Task<Pharmacy> GetByIdAsync(int id);

        Task InsertPharmacyAsync(Pharmacy pharmacy);

        void UpdatePharmacy(Pharmacy pharmacy);

        Task<DataTablesPagedResults<PharmacyListViewModel>> GetDataAsync(DataTablesParameters table, Lang lng = Lang.KU);

        Task<(long totalCount, int totalPages, List<PharmacyItemDTO>)> GetPharmaciesListAsync(Lang lang, int page = 0, int pageSize = 12);

        Task<List<SelectListItem>> GetSelectListItemsAsync(Lang lang = Lang.KU, int? cityId = null);
    }
}
