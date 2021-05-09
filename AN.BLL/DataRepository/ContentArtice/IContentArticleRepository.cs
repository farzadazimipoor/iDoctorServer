using AN.Core.Enums;
using AN.Core.ViewModels;
using Shared.Models;
using System.Threading.Tasks;

namespace AN.BLL.DataRepository
{
    public interface IContentArticleRepository
    {
        Task<DataTablesPagedResults<CmsArticleItemViewModel>> GetDataTableAsync(DataTablesParameters table, CmsArticleFilterViewModel filters, Lang lng = Lang.KU);
    }
}
