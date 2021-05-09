using AN.Core.Domain;
using AN.Core.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AN.BLL.DataRepository.ServiceSupplies
{
    public partial interface IServiceSupplyService
    {
        IQueryable<ServiceSupply> Table { get; }

        Task<long> GetAllCountForHospitalAsync(int hospitalId);

        ServiceSupply GetServiceSupplyById(int id);

        Task<ServiceSupply> GetServiceSupplyByIdAsync(int id);

        Task<IList<SelectListItem>> GetSelectListAsync(int? polyclinicId = null, List<int> serviceSupplyIds = null, bool? isConsultancyEnabled = null);

        IQueryable<ServiceSupply> GetAll(int? polyclinicId = null);       

        IQueryable<ServiceSupply> GetAllAvailableServiceSuppliesForClinic(int clinicId);

        ServiceSupply GetServiceSupplyByIdForClinic(int clinicId, int id);

        ServiceSupply GetServiceSupplyByIdForPolyClinic(int polyclinicId, int id);

        Task<ServiceSupply> GetForShiftCenterAsync(int id, int centerId);

        ServiceSupply GetServiceSupplyForArea(int id);

        Task<ServiceSupply> GetServiceSupplyForAreaAsync(int id);

        void UpdateServiceSupply(ServiceSupply serviceSupply);
    }
}
