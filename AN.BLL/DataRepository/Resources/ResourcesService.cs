using AN.Core.Data;
using AN.Core.Domain;
using AN.Core.Enums;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AN.BLL.DataRepository.Resources
{
    public partial class ResourcesService : IResourcesService
    {
        private readonly IRepository<Resource> _resourceRepository;
        public ResourcesService(IRepository<Resource> resourceRepository)
        {
            _resourceRepository = resourceRepository;
        }

        public Resource GetResourceByKey(ResourceKey? key)
        {
            if (key == null)
                return null;

            return _resourceRepository.Table.Where(x => x.Key == key).FirstOrDefault();
        }

        public virtual async Task<Resource> GetResourceByKeyAsync(ResourceKey? key)
        {
            if (key == null)
                return null;

            return await _resourceRepository.Table.Where(x => x.Key == key).FirstOrDefaultAsync();
        }       


    }
}
