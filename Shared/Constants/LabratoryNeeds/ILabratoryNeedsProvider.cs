using Shared.Models;
using System.Collections.Generic;

namespace Shared.Constants.LabratoryNeeds
{
    public interface ILabratoryNeedsProvider
    {
        IEnumerable<LabratoryNeedModel> GetAll();

        LabratoryNeedModel GetById(int id);
    }
}
