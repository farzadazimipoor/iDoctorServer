using AN.Core.Domain;
using AN.Core.DTO;
using AN.Core.Enums;
using AN.DAL;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AN.BLL.Services.Search
{
    public class SearchService : ISearchService
    {
        private readonly BanobatDbContext _dbContext;
        public SearchService(BanobatDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<SearchResultDTO> DoSearchAsync(Lang lng, SearchDTO model, string hostAddress)
        {
            var result = new SearchResultDTO();

            #region Doctors
            IQueryable<ServiceSupply> doctorsQuery = _dbContext.ServiceSupplies;

            if (lng == Lang.KU)
            {
                doctorsQuery = doctorsQuery.Where(x => x.Person.FullName_Ku.Contains(model.SearchTerm));
            }
            else if (lng == Lang.AR)
            {
                doctorsQuery = doctorsQuery.Where(x => x.Person.FullName_Ar.Contains(model.SearchTerm));
            }
            else
            {
                doctorsQuery = doctorsQuery.Where(x => x.Person.FullName.Contains(model.SearchTerm));
            }

            result.Doctors = await doctorsQuery.Select(x => new SearchResulItemtDTO
            {
                Id = x.Id,
                Title = lng == Lang.KU ? x.Person.FullName_Ku : lng == Lang.AR ? x.Person.FullName_Ar : x.Person.FullName,
                Avatar = $"{hostAddress}{x.Person.RealAvatar}"
            }).ToListAsync();
            #endregion

            #region Health Tips
            IQueryable<ContentArticle> articlesQuery = _dbContext.ContentArticles;

            if (lng == Lang.KU)
            {
                articlesQuery = articlesQuery.Where(x => x.Title_Ku.Contains(model.SearchTerm));
            }
            else if (lng == Lang.AR)
            {
                articlesQuery = articlesQuery.Where(x => x.Title_Ar.Contains(model.SearchTerm));
            }
            else
            {
                articlesQuery = articlesQuery.Where(x => x.Title.Contains(model.SearchTerm));
            }

            result.HealthTips = await articlesQuery.Select(x => new SearchResulItemtDTO
            {
                Id = x.Id,
                Title = lng == Lang.KU ? x.Title_Ku : lng == Lang.AR ? x.Title_Ar : x.Title,
                Avatar = hostAddress + (lng == Lang.KU ? x.ImageUrl_Ku : lng == Lang.AR ? x.ImageUrl_Ar : x.ImageUrl)
            }).ToListAsync();
            #endregion

            #region Health Bank
            IQueryable<ShiftCenter> healthBankQuery = _dbContext.ShiftCenters.Where(x => x.ShowInHealthBank);

            if (lng == Lang.KU)
            {
                healthBankQuery = healthBankQuery.Where(x => x.Name_Ku.Contains(model.SearchTerm));
            }
            else if (lng == Lang.AR)
            {
                healthBankQuery = healthBankQuery.Where(x => x.Name_Ar.Contains(model.SearchTerm));
            }
            else
            {
                healthBankQuery = healthBankQuery.Where(x => x.Name.Contains(model.SearchTerm));
            }

            result.HealthBank = await healthBankQuery.Select(x => new SearchResulItemtDTO
            {
                Id = x.Id,
                Title = lng == Lang.KU ? x.Name_Ku : lng == Lang.AR ? x.Name_Ar : x.Name,
                Avatar = hostAddress + x.RealLogo
            }).ToListAsync();
            #endregion

            return result;
        }
    }
}
