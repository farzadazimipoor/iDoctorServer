using AN.Core.Domain;
using AN.Core.DTO;
using AN.Core.Enums;
using AN.Core.Exceptions;
using AN.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Shared.Settings;
using System.Linq;
using System.Threading.Tasks;

namespace AN.BLL.Services
{
    public class CmsService : ICmsService
    {
        private readonly BanobatDbContext _dbContext;
        private readonly IOptions<AppSettings> _options;
        public CmsService(BanobatDbContext dbContext, IOptions<AppSettings> options)
        {
            _dbContext = dbContext;
            _options = options;
        }

        public async Task<CmsCategoriesResultDTO> GetCmsCategoriesAsync(Lang lang)
        {
            IQueryable<ContentCategory> query = _dbContext.ContentCategories;

            switch (lang)
            {
                case Lang.KU: query = query.Where(x => x.Articles.Any(a => a.IsPublished && !string.IsNullOrEmpty(a.Title_Ku))); break;
                case Lang.AR: query = query.Where(x => x.Articles.Any(a => a.IsPublished && !string.IsNullOrEmpty(a.Title_Ar))); break;
                case Lang.EN: query = query.Where(x => x.Articles.Any(a => a.IsPublished && !string.IsNullOrEmpty(a.Title))); break;
            }

            var categories = await query.OrderBy(x => x.CreatedAt).Select(x => new CmsCategoryDTO
            {
                Id = x.Id,
                Title = lang == Lang.AR ? x.Title_Ar : lang == Lang.KU ? x.Title_Ku : x.Title,
                LayoutStyle = (int)x.LayoutStyle,
                Articles = x.Articles.Where(a => a.IsPublished && (lang == Lang.AR ? !string.IsNullOrEmpty(a.Title_Ar) : lang == Lang.KU ? !string.IsNullOrEmpty(a.Title_Ku) : !string.IsNullOrEmpty(a.Title))).OrderByDescending(a => a.CreatedAt).Take(8).Select(a => new CmsArticleDTO
                {
                    Id = a.Id,
                    CategoryId = a.ContentCategoryId,
                    Title = lang == Lang.AR ? a.Title_Ar : lang == Lang.KU ? a.Title_Ku : a.Title,
                    Summary = lang == Lang.AR ? a.Summary_Ar : lang == Lang.KU ? a.Summary_Ku : a.Summary,
                    ThumbnailUrl = a.ContentCategory.LayoutStyle == ContentLayoutStyle.HORIZONTAL ? lang == Lang.EN ? a.ThumbnailUrl : lang == Lang.AR ? a.ThumbnailUrl_Ar : a.ThumbnailUrl_Ku : lang == Lang.EN ? a.ImageUrl : lang == Lang.AR ? a.ImageUrl_Ar : a.ImageUrl_Ku,
                    ReaderType = a.ReaderType
                }).ToList()
            }).ToListAsync();

            var appConfig = _options.Value.AwroNoreSettings.App;

            var result = new CmsCategoriesResultDTO
            {
                ShowDashboardAction = (lang == Lang.KU && appConfig.Kurdish.ShowDashboardAction) || (lang == Lang.AR && appConfig.Arabic.ShowDashboardAction) || (lang == Lang.EN && appConfig.English.ShowDashboardAction),
                DashboardActionTitle = lang == Lang.KU ? appConfig.Kurdish.DashboardActionTitle : lang == Lang.AR ? appConfig.Arabic.DashboardActionTitle : appConfig.English.DashboardActionTitle,
                DashboardActionUrl = lang == Lang.KU ? appConfig.Kurdish.DashboardActionUrl : lang == Lang.AR ? appConfig.Arabic.DashboardActionUrl : appConfig.English.DashboardActionUrl,
                CmsCategories = categories
            };

            return result;
        }

        public async Task<CmsArticleDetailsDTO> GetCmsArticleDetailsAsync(int articleId, Lang lang)
        {
            var a = await _dbContext.ContentArticles.FindAsync(articleId);

            if (a == null || !a.IsPublished) throw new AwroNoreException("Article not found");

            var details = new CmsArticleDetailsDTO
            {
                Id = a.Id,
                CategoryId = a.ContentCategoryId,
                Title = lang == Lang.AR ? a.Title_Ar : lang == Lang.KU ? a.Title_Ku : a.Title,
                Summary = lang == Lang.AR ? a.Summary_Ar : lang == Lang.KU ? a.Summary_Ku : a.Summary,
                ThumbnailUrl = lang == Lang.EN ? a.ThumbnailUrl : lang == Lang.AR ? a.ThumbnailUrl_Ar : a.ThumbnailUrl_Ku,
                ImageUrl = lang == Lang.EN ? a.ImageUrl : lang == Lang.AR ? a.ImageUrl_Ar : a.ImageUrl_Ku,
                Body = lang == Lang.AR ? a.Body_Ar : lang == Lang.KU ? a.Body_Ku : a.Body,
                Category = lang == Lang.AR ? a.ContentCategory.Title_Ar : lang == Lang.KU ? a.ContentCategory.Title_Ku : a.ContentCategory.Title,
                CreatedAt = a.CreatedAt.ToString("yyyy/MM/dd HH:mm:ss")
            };

            return details;
        }

        public async Task<CmsArticlesListResultDTO> GetArticlesPagingListAsync(int cmsCategoryId, Lang lang, int page = 0, int pageSize = 12)
        {
            var query = _dbContext.ContentArticles.Where(x => x.ContentCategoryId == cmsCategoryId && x.IsPublished);

            switch (lang)
            {
                case Lang.KU: query = query.Where(x => !string.IsNullOrEmpty(x.Title_Ku)); break;
                case Lang.AR: query = query.Where(x => !string.IsNullOrEmpty(x.Title_Ar)); break;
                case Lang.EN: query = query.Where(x => !string.IsNullOrEmpty(x.Title)); break;
            }

            var totalCount = await query.CountAsync();

            query = query.OrderByDescending(x => x.CreatedAt).Skip(pageSize * page).Take(pageSize);

            var offers = await query.Select(x => new CmsArticleDTO
            {
                Id = x.Id,
                Title = lang == Lang.KU ? x.Title_Ku : lang == Lang.AR ? x.Title_Ar : x.Title,
                Summary = lang == Lang.KU ? x.Summary_Ku : lang == Lang.AR ? x.Summary_Ar : x.Summary,
                ThumbnailUrl = lang == Lang.EN ? x.ThumbnailUrl : lang == Lang.AR ? x.ThumbnailUrl_Ar : x.ThumbnailUrl_Ku,
                CategoryId = x.ContentCategoryId,
                ReaderType = x.ReaderType
            }).ToListAsync();

            var result = new CmsArticlesListResultDTO
            {
                TotalCount = totalCount,
                CmsArticles = offers
            };

            return result;
        }
    }
}
