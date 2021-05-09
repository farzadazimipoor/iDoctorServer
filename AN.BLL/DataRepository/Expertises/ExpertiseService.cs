using AN.Core.Data;
using AN.Core.Domain;
using AN.Core.Enums;
using AN.Core.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AN.BLL.DataRepository.Expertises
{
    public partial class ExpertiseService : IExpertiseService
    {
        private readonly IRepository<ExpertiseCategory> _expertiseCategoryRepository;
        private readonly IRepository<Expertise> _expertiseRepository;
        public ExpertiseService(IRepository<ExpertiseCategory> expertiseCategoryRepository,
                                IRepository<Expertise> expertiseRepository)
        {
            _expertiseCategoryRepository = expertiseCategoryRepository;
            _expertiseRepository = expertiseRepository;
        }

        public async Task<DataTablesPagedResults<ExpertiseListViewModel>> GetDataTableAsync(DataTablesParameters table, ExpertiseFilterViewModel filters, Lang lng = Lang.KU)
        {
            IQueryable<Expertise> query = _expertiseRepository.Table;

            if (!string.IsNullOrEmpty(filters.FilterString))
            {
                query = query.Where(x => lng == Lang.KU ? x.Name_Ku.Contains(filters.FilterString) : lng == Lang.AR ? x.Name_Ar.Contains(filters.FilterString) : x.Name.Contains(filters.FilterString));
            }

            if (filters.CategoryId != null)
            {
                query = query.Where(x => x.ExpertiseCategoryId == filters.CategoryId);
            }

            if (table.Order != null && table.Order.Any())
            {
                var orderIndex = table.Order[0].Column;
                var orderDir = table.Order[0].Dir;

                if (orderIndex == 0)
                {
                    if (orderDir == DataTablesOrderDir.DESC)
                    {
                        query = query.OrderByDescending(x => lng == Lang.KU ? x.Name_Ku : lng == Lang.AR ? x.Name_Ar : x.Name);
                    }
                    else
                    {
                        query = query.OrderBy(x => lng == Lang.KU ? x.Name_Ku : lng == Lang.AR ? x.Name_Ar : x.Name);
                    }
                }
                else if (orderIndex == 1)
                {
                    if (orderDir == DataTablesOrderDir.DESC)
                    {
                        query = query.OrderByDescending(x => x.ExpertiseCategoryId);
                    }
                    else
                    {
                        query = query.OrderBy(x => x.ExpertiseCategoryId);
                    }
                }
                else if (orderIndex == 2)
                {
                    if (orderDir == DataTablesOrderDir.DESC)
                    {
                        query = query.OrderByDescending(x => lng == Lang.KU ? x.Description_Ku : lng == Lang.AR ? x.Description_Ar : x.Description);
                    }
                    else
                    {
                        query = query.OrderBy(x => lng == Lang.KU ? x.Description_Ku : lng == Lang.AR ? x.Description_Ar : x.Description);
                    }
                }               
            }           

            var size = await query.CountAsync();

            var items = await query
                .AsNoTracking()
                .Skip((table.Start / table.Length) * table.Length)
                .Take(table.Length)
                .Select(x => new ExpertiseListViewModel
                {
                    Id = x.Id,
                    CategoryId = x.ExpertiseCategoryId,
                    Name = lng == Lang.KU ? x.Name_Ku : lng == Lang.AR ? x.Name_Ar : x.Name, 
                    Category = lng == Lang.KU ? x.ExpertiseCategory.Name_Ku : lng == Lang.AR ? x.ExpertiseCategory.Name_Ar : x.ExpertiseCategory.Name,
                    Description = lng == Lang.KU ? x.Description_Ku : lng == Lang.AR ? x.Description_Ar : x.Description                   
                }).ToListAsync();

            return new DataTablesPagedResults<ExpertiseListViewModel>
            {
                Items = items,
                TotalSize = size
            };
        }

        public async Task<List<SelectListItem>> GetCatrgoriesSelectListAsync(Lang lang = Lang.KU)
        {
            var result = await _expertiseCategoryRepository.Table.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = lang == Lang.KU ? x.Name_Ku : lang == Lang.AR ? x.Name_Ar : x.Name
            }).ToListAsync();

            return result;
        }

        public virtual ExpertiseCategory GetExpertiseCategoryById(int id)
        {
            if (id == 0) return null;

            return _expertiseCategoryRepository.GetById(id);
        }

        public async Task<Expertise> GetByIdAsync(int id)
        {
            return await _expertiseRepository.GetByIdAsync(id);
        }

        public virtual Expertise GetExpertiseById(int id)
        {
            if (id == 0) return null;

            return _expertiseRepository.GetById(id);
        }


        public virtual IEnumerable<ExpertiseCategory> GetAllExpertiseCategories()
        {
            return _expertiseCategoryRepository.Table;
        }

        public virtual IQueryable<Expertise> AllExpertisesTable()
        {
            return _expertiseRepository.Table;
        }


        public virtual IEnumerable<Expertise> GetAllExpertises()
        {
            return _expertiseRepository.Table;
        }


        public virtual void InsertExpertiseCategory(ExpertiseCategory expertiseCategory)
        {
            if (expertiseCategory == null)
                throw new ArgumentNullException("expertiseCategory");

            _expertiseCategoryRepository.Insert(expertiseCategory);
        }


        public virtual void UpdateExpertiseCategory(ExpertiseCategory expertiseCategory)
        {
            if (expertiseCategory == null)
                throw new ArgumentNullException("expertiseCategory");

            _expertiseCategoryRepository.Update(expertiseCategory);
        }


        public virtual void DeleteExpertiseCategory(ExpertiseCategory expertiseCategory)
        {
            if (expertiseCategory == null) throw new ArgumentNullException("expertiseCategory");

            _expertiseCategoryRepository.Delete(expertiseCategory);
        }


        public virtual void InsertExpertise(Expertise expertise)
        {
            if (expertise == null)  throw new ArgumentNullException("expertise");

            _expertiseRepository.Insert(expertise);
        }       


        public virtual void UpdateExpertise(Expertise expertise)
        {
            if (expertise == null) throw new ArgumentNullException("expertise");

            _expertiseRepository.Update(expertise);
        }

        public virtual void DeleteExpertise(Expertise expertise)
        {
            if (expertise == null) throw new ArgumentNullException("expertise");

            _expertiseRepository.Delete(expertise);
        }

        public virtual IList<Expertise> GetExpertisesForCategory(int categoryId)
        {
            if (categoryId == 0) return null;

            var query = from e in _expertiseRepository.Table
                        where e.ExpertiseCategoryId == categoryId
                        select e;

            return query.ToList();
        }
    }
}
