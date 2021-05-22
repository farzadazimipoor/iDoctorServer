using AN.Core.DTO;
using AN.Core.Enums;
using System.Threading.Tasks;

namespace AN.BLL.Services.Search
{
    public interface ISearchService
    {
        Task<SearchResultDTO> DoSearchAsync(Lang lng, SearchDTO model);
    }
}
