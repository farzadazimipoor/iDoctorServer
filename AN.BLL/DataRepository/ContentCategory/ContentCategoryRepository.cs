using AN.Core.Data;
using AN.Core.Domain;
using AN.Core.Enums;
using AN.Core.ViewModels;
using Microsoft.EntityFrameworkCore;
using Shared.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AN.BLL.DataRepository
{
    public class ContentCategoryRepository : IContentCategoryRepository
    {
        private readonly IRepository<ContentCategory> _repository;
        public ContentCategoryRepository(IRepository<ContentCategory> repository)
        {
            _repository = repository;
        }

        public async Task<DataTablesPagedResults<CmsCategoryItemViewModel>> GetDataTableAsync(DataTablesParameters table, CmsCategoryFilterViewModel filters, Lang lng = Lang.KU)
        {
            IQueryable<ContentCategory> query = _repository.Table;

            if (!string.IsNullOrEmpty(filters.FilterString))
            {
                query = query.Where(x => x.Title.Contains(filters.FilterString) || x.Title_Ku.Contains(filters.FilterString) || x.Title_Ar.Contains(filters.FilterString));
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

            if (filters.LayoutStyle != null)
            {
                query = query.Where(x => x.LayoutStyle == filters.LayoutStyle);
            }

            if (table.Order != null && table.Order.Any())
            {
                var orderIndex = table.Order[0].Column;
                var orderDir = table.Order[0].Dir;

                if (orderIndex == 1)
                {
                    query = orderDir == DataTablesOrderDir.DESC ? query.OrderByDescending(x => x.CreatedAt) : query.OrderBy(x => x.CreatedAt);
                }
                else if (orderIndex == 2)
                {
                    query = orderDir == DataTablesOrderDir.DESC ? query.OrderByDescending(x => lng == Lang.EN ? x.Title : lng == Lang.AR ? x.Title_Ar : x.Title_Ku) : query.OrderBy(x => lng == Lang.EN ? x.Title : lng == Lang.AR ? x.Title_Ar : x.Title_Ku);
                }
                else
                {
                    query = orderDir == DataTablesOrderDir.DESC ? query.OrderByDescending(x => x.LayoutStyle) : query.OrderBy(x => x.LayoutStyle);
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
                .Select(x => new CmsCategoryItemViewModel
                {
                    Id = x.Id,
                    Title = lng == Lang.EN ? x.Title : lng == Lang.AR ? x.Title_Ar : x.Title_Ku,
                    CreateDate = x.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss"),
                    LayoutStyle = x.LayoutStyle == ContentLayoutStyle.HORIZONTAL ? "Horizontal" : "Vertical"
                })
                .ToListAsync();

            return new DataTablesPagedResults<CmsCategoryItemViewModel>
            {
                Items = items,
                TotalSize = size
            };
        }
    }
}
