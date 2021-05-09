using AN.Core.DTO;
using AN.Core.Enums;
using System.Threading.Tasks;

namespace AN.BLL.Services
{
    public interface ICmsService
    {
        Task<CmsCategoriesResultDTO> GetCmsCategoriesAsync(Lang lang);

        Task<CmsArticleDetailsDTO> GetCmsArticleDetailsAsync(int articleId, Lang lang);

        Task<CmsArticlesListResultDTO> GetArticlesPagingListAsync(int cmsCategoryId, Lang lang, int page = 0, int pageSize = 12);
    }
}
