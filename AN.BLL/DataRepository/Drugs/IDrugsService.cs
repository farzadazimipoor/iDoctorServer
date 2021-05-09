using AN.Core.Domain;
using System.Linq;

namespace AN.BLL.DataRepository.Drugs
{
    public interface IDrugsService
    {
        IQueryable<Drug> GetAll();
    }
}
