using AN.Core;
using AN.Core.Data;
using AN.Core.Domain;
using System.Linq;

namespace AN.BLL.DataRepository.Drugs
{
    public class DrugsService : IDrugsService
    {
        private readonly IRepository<Drug> _drugsRepository;
        public DrugsService(IRepository<Drug> drugsRepository)
        {
            _drugsRepository = drugsRepository;
        }

        public IQueryable<Drug> GetAll()
        {
            return _drugsRepository.Table;
        }
    }
}
