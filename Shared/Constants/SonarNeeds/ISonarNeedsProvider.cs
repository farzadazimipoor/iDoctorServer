using Shared.Models;
using System.Collections.Generic;

namespace Shared.Constants.SonarNeeds
{
    public interface ISonarNeedsProvider
    {
        IEnumerable<SonarNeedModel> GetAll();

        SonarNeedModel GetById(int id);
    }
}
