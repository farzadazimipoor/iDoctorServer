using AN.Core.Domain;
using AN.Core.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AN.BLL.DataRepository.Hospitals
{
    public partial interface IHospitalService
    {
        IQueryable<Hospital> Table { get; }

        int GetHospitalsCount();

        Task<int> GetHospitalsCountAsync();

        Hospital GetHospitalById(int id);

        Task<Hospital> GetHospitalByIdAsync(int id);

        Hospital GetCurrentHospital();

        IQueryable<Hospital> GetAll();

        Task<IList<Hospital>> GetAllAsync();

        IList<CommonEntity> GetAllHospitalsCommonEntity();

        Task<IList<CommonEntity>> GetAllHospitalsCommonEntityAsync();

        void InsertHospital(Hospital expertise);

        Task InsertHospitalAsync(Hospital hospital);

        void UpdateHospital(Hospital expertise);

        void DeleteHospital(Hospital expertise);
    }
}
