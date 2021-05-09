using AN.Core;
using AN.Core.Domain;
using AN.Core.Enums;
using System.Threading.Tasks;

namespace AN.BLL.DataRepository.Resources
{
    public partial interface IResourcesService
    {
        Task<Resource> GetResourceByKeyAsync(ResourceKey? key);

        Resource GetResourceByKey(ResourceKey? key);
    }
}
