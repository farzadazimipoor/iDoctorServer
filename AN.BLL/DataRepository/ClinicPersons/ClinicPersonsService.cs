using AN.Core.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AN.BLL.DataRepository
{
    public class ClinicPersonsService : IClinicPersonsService
    {
        private readonly IRepository<AN.Core.Domain.ClinicPersons> _clinicUsersRepository;

        public ClinicPersonsService(IRepository<AN.Core.Domain.ClinicPersons> clinicUsersRepository)
        {
            _clinicUsersRepository = clinicUsersRepository;
        }

        public async Task<AN.Core.Domain.ClinicPersons> GetClinicUsersAsync(int clinicId, int userId)
        {
            if (clinicId == 0) return null;

            var result = await _clinicUsersRepository.Table.FirstOrDefaultAsync(x => x.Clinic_Id == clinicId && x.PersonId == userId);

            return result;
        }

        public virtual IList<AN.Core.Domain.ClinicPersons> GetAllClinicUsers()
        {
            return _clinicUsersRepository.Table.ToList();
        }

        public void InsertClinicUser(AN.Core.Domain.ClinicPersons clinicUser)
        {
            _clinicUsersRepository.Insert(clinicUser);
        }

        public async Task InsertClinicUserAsync(AN.Core.Domain.ClinicPersons clinicUser)
        {
            if (clinicUser == null) throw new ArgumentNullException(nameof(clinicUser));

            await _clinicUsersRepository.InsertAsync(clinicUser);
        }

        public async Task UpdateClinicUserAsync(AN.Core.Domain.ClinicPersons clinicUser)
        {
            if (clinicUser == null) throw new ArgumentNullException(nameof(clinicUser));

            _clinicUsersRepository.Update(clinicUser);
        }

        public async Task DeleteClinicUserAsync(int clinicId, int userId)
        {
            if (clinicId == 0) throw new ArgumentNullException(nameof(clinicId));            

            var clinicUser = await _clinicUsersRepository.Table.FirstOrDefaultAsync(x => x.Clinic_Id == clinicId && x.PersonId == userId);

            if(clinicUser != null)
            {
                await _clinicUsersRepository.DeleteAsync(clinicUser);
            }
        }
    }
}
