using AN.Core.DTO;
using AN.Core.Enums;
using AN.DAL;
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

        public async Task<SearchResultDTO> DoSearchAsync(Lang lng, SearchDTO model)
        {
            var result = new SearchResultDTO
            {
                Doctors = new System.Collections.Generic.List<SearchResulItemtDTO>
                {
                    new SearchResulItemtDTO
                    {
                        Id = 1,
                        Title = "Ahmad Karim Ali",
                        Avatar = "https://firebasestorage.googleapis.com/v0/b/ibazzar-7549a.appspot.com/o/avatars%2Fdefault%2Favatar.png?alt=media&token=96b2a643-6894-437f-a510-608ac3a7ba2e"
                    },
                    new SearchResulItemtDTO
                    {
                        Id = 2,
                        Title = "Mohammed Valid Jasem",
                        Avatar = "https://firebasestorage.googleapis.com/v0/b/ibazzar-7549a.appspot.com/o/avatars%2Fdefault%2Favatar.png?alt=media&token=96b2a643-6894-437f-a510-608ac3a7ba2e"
                    }
                },
                HealthTips = new System.Collections.Generic.List<SearchResulItemtDTO>
                {
                    new SearchResulItemtDTO
                    {
                        Id = 1,
                        Title = "Benefits of drinking water",
                        Avatar = "https://firebasestorage.googleapis.com/v0/b/ibazzar-7549a.appspot.com/o/avatars%2Fdefault%2Favatar.png?alt=media&token=96b2a643-6894-437f-a510-608ac3a7ba2e"
                    }
                },
                HealthBank = new System.Collections.Generic.List<SearchResulItemtDTO>
                {
                    new SearchResulItemtDTO
                    {
                        Id = 1,
                        Title = "Arzhin Hospital",
                        Avatar = "https://firebasestorage.googleapis.com/v0/b/ibazzar-7549a.appspot.com/o/avatars%2Fdefault%2Favatar.png?alt=media&token=96b2a643-6894-437f-a510-608ac3a7ba2e"
                    },
                   new SearchResulItemtDTO
                   {
                       Id = 2,
                       Title = "CMS Eye Center",
                       Avatar = "https://firebasestorage.googleapis.com/v0/b/ibazzar-7549a.appspot.com/o/avatars%2Fdefault%2Favatar.png?alt=media&token=96b2a643-6894-437f-a510-608ac3a7ba2e"
                   }
                }
            };

            return result;
        }
    }
}
