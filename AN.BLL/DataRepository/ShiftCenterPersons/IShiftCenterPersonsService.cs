using AN.Core.Domain;
using System.Collections.Generic;

namespace AN.BLL.DataRepository.PolyclinicUsersRepo
{
    public partial interface IShiftCenterPersonsService
    {
        IList<ShiftCenterPersons> GetAll();
    }
}
