using AN.Core.Data;
using AN.Core.Domain;
using AN.Core.Enums;
using AN.Core.Resources.Global;
using AN.Core.ViewModels;
using Microsoft.EntityFrameworkCore;
using Shared.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AN.BLL.DataRepository
{
    public class ContentArticleRepository : IContentArticleRepository
    {
        private readonly IRepository<ContentArticle> _repository;
        public ContentArticleRepository(IRepository<ContentArticle> repository)
        {
            _repository = repository;
        }

        public async Task<DataTablesPagedResults<CmsArticleItemViewModel>> GetDataTableAsync(DataTablesParameters table, CmsArticleFilterViewModel filters, Lang lng = Lang.KU)
        {
            IQueryable<ContentArticle> query = _repository.Table;

            query = query.Where(x => x.IsPublished == filters.IsPublished);

            if(filters.CategoryId != null)
            {
                query = query.Where(x => x.ContentCategoryId == filters.CategoryId);
            }

            if (filters.FromDate != null)
            {
                query = query.Where(a => a.CreatedAt >= filters.FromDate);
            }

            if (filters.ToDate != null)
            {
                filters.ToDate = DateTime.Parse($"{filters.ToDate.Value.ToShortDateString()} 23:59:59");

                query = query.Where(a => a.CreatedAt <= filters.ToDate);
            }

            if (!string.IsNullOrEmpty(filters.FilterString))
            {                
                query = query.Where(x => x.Title.Contains(filters.FilterString) || x.Title_Ku.Contains(filters.FilterString) || x.Title_Ar.Contains(filters.FilterString) ||
                                         x.Summary.Contains(filters.FilterString) || x.Summary_Ku.Contains(filters.FilterString) || x.Summary_Ar.Contains(filters.FilterString) ||
                                         x.Body.Contains(filters.FilterString) || x.Body_Ku.Contains(filters.FilterString) || x.Body_Ar.Contains(filters.FilterString));
            }             

            if (table.Order != null && table.Order.Any())
            {
                var orderIndex = table.Order[0].Column;
                var orderDir = table.Order[0].Dir;

                if (orderIndex == 2)
                {
                    query = orderDir == DataTablesOrderDir.DESC ? query.OrderByDescending(x => x.CreatedAt) : query.OrderBy(x => x.CreatedAt);
                }
                else if (orderIndex == 3)
                {
                    query = orderDir == DataTablesOrderDir.DESC ? query.OrderByDescending(x => lng == Lang.EN ? x.Title : lng == Lang.AR ? x.Title_Ar : x.Title_Ku) : query.OrderBy(x => lng == Lang.EN ? x.Title : lng == Lang.AR ? x.Title_Ar : x.Title_Ku);
                }
                else if (orderIndex == 4)
                {
                    query = orderDir == DataTablesOrderDir.DESC ? query.OrderByDescending(x => lng == Lang.EN ? x.Summary : lng == Lang.AR ? x.Summary_Ar : x.Summary_Ku) : query.OrderBy(x => lng == Lang.EN ? x.Summary : lng == Lang.AR ? x.Summary_Ar : x.Summary_Ku);
                }
                else if (orderIndex == 5)
                {
                    query = orderDir == DataTablesOrderDir.DESC ? query.OrderByDescending(x => x.ContentCategoryId) : query.OrderBy(x => x.ContentCategoryId);
                }
                else if (orderIndex == 6)
                {
                    query = orderDir == DataTablesOrderDir.DESC ? query.OrderByDescending(x => x.IsPublished) : query.OrderBy(x => x.IsPublished);
                }
            }
            else
            {
                query = query.OrderByDescending(x => x.CreatedAt);
            }

            var size = await query.CountAsync();

            var items = await query
                .AsNoTracking()
                .Skip((table.Start / table.Length) * table.Length)
                .Take(table.Length)
                .Select(x => new CmsArticleItemViewModel
                {
                    Id = x.Id,
                    Title = lng == Lang.EN ? x.Title : lng == Lang.AR ? x.Title_Ar : x.Title_Ku,
                    CreateDate = x.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss"),
                    Category = lng == Lang.EN ? x.ContentCategory.Title : lng == Lang.AR ? x.ContentCategory.Title_Ar : x.ContentCategory.Title_Ku,
                    IsPublished = x.IsPublished ? Global.Yes : Global.No,
                    Summary = lng == Lang.EN ? x.Summary : lng == Lang.AR ? x.Summary_Ar : x.Summary_Ku,
                    ImageUrl = x.ThumbnailUrl
                })
                .ToListAsync();

            return new DataTablesPagedResults<CmsArticleItemViewModel>
            {
                Items = items,
                TotalSize = size
            };
        }
    }
}
