using AN.Core.Data;
using AN.Core.Domain;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AN.BLL.DataRepository.Rating
{
    public class RatingService : IRatingService
    {
        private readonly IRepository<ServiceSupplyRating> _ratingRepository;
        public RatingService(IRepository<ServiceSupplyRating> ratingRepository)
        {
            _ratingRepository = ratingRepository;
        }

        public IQueryable<ServiceSupplyRating> Table => _ratingRepository.Table;

        public async Task InsertRatingAsync(ServiceSupplyRating rating)
        {
            if (rating == null) throw new ArgumentNullException(nameof(rating));

            await _ratingRepository.InsertAsync(rating);
        }       
    }
}
