using System.Collections.Generic;
using System.Threading.Tasks;

namespace AN.BLL.DataRepository
{
    public interface IClinicPersonsService
    {
        Task<AN.Core.Domain.ClinicPersons> GetClinicUsersAsync(int clinicId, int userId);

        IList<AN.Core.Domain.ClinicPersons> GetAllClinicUsers();

        void InsertClinicUser(AN.Core.Domain.ClinicPersons clinicUser);

        Task InsertClinicUserAsync(AN.Core.Domain.ClinicPersons clinicUser);

        Task UpdateClinicUserAsync(AN.Core.Domain.ClinicPersons clinicUser);

        Task DeleteClinicUserAsync(int clinicId, int userId);
    }
}
