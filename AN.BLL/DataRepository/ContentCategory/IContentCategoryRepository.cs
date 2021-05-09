using AN.Core.Enums;
using AN.Core.ViewModels;
using Shared.Models;
using System.Threading.Tasks;

namespace AN.BLL.DataRepository
{
    public interface IContentCategoryRepository
    {
        Task<DataTablesPagedResults<CmsCategoryItemViewModel>> GetDataTableAsync(DataTablesParameters table, CmsCategoryFilterViewModel filters, Lang lng = Lang.KU);
    }
}
