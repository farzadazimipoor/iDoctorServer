using AN.Core.Domain;
using System.Linq;
using System.Threading.Tasks;

namespace AN.BLL.DataRepository.Rating
{
    public interface IRatingService
    {
        IQueryable<ServiceSupplyRating> Table { get; }

        Task InsertRatingAsync(ServiceSupplyRating rating);
    }
}
