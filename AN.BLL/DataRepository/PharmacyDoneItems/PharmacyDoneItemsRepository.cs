using AN.Core.Data;
using AN.Core.Domain;

namespace AN.BLL.DataRepository
{
    public class PharmacyDoneItemsRepository : IPharmacyDoneItemsRepository
    {
        private readonly IRepository<PharmacyDoneTreatments> _repository;
        public PharmacyDoneItemsRepository(IRepository<PharmacyDoneTreatments> repository)
        {
            _repository = repository;
        }
    }
}
