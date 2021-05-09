using AN.Core;
using AN.Core.Domain;
using AN.Core.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AN.BLL.DataRepository.Clinics
{
    public interface IClinicService
    {
        IQueryable<Clinic> Table { get; }
        Task<long> GetAllCountForHospitalAsync(int hospitalId);
        IEnumerable<Clinic> DynamicQuery(QueryModel<Clinic> model);
        List<Clinic> GetAllClinics(string filter);
        List<Clinic> GetAll(bool isIndependent = false);
        int GetAllIndepententClinicsCount();
        Task<int> GetAllClinicsCountAsync(bool? isIndependent = null);
        Clinic GetClinicById(int id);
        Clinic GetCurrentClinic();
        Clinic GetClinicForArea(int id);
        Task<Clinic> GetClinicForAreaAsync(int id);
        Clinic GetClinicForHospital(int hospitalId, int clinicId);
        Task<Clinic> GetClinicForHospitalAsync(int hospitalId, int clinicId);
        void InsertClinic(Clinic entity);
        void DeleteClinic(Clinic entity);
    }
}
