using AN.Core;
using AN.Core.Data;
using AN.Core.Domain;
using AN.Core.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AN.BLL.DataRepository.ServiceSupplies
{
    public partial class ServiceSupplyService : IServiceSupplyService
    {
        private readonly IRepository<ServiceSupply> _serviceSupplyRepository;
        private readonly IWorkContext _workContext;
        public ServiceSupplyService(IRepository<ServiceSupply> serviceSupplyRepository,
                                    IWorkContext workContext)
        {
            _serviceSupplyRepository = serviceSupplyRepository;
            _workContext = workContext;
        }

        private Lang Lng => _workContext.Lang;

        public IQueryable<ServiceSupply> Table => _serviceSupplyRepository.Table;

        public async Task<long> GetAllCountForHospitalAsync(int hospitalId)
        {
            var count = await _serviceSupplyRepository.Table.LongCountAsync(x => x.ShiftCenter.Clinic.HospitalId == hospitalId);

            return count;
        }       

        public async Task<IList<SelectListItem>> GetSelectListAsync(int? polyclinicId = null, List<int> serviceSupplyIds = null, bool? isConsultancyEnabled = null)
        {
            var query = _serviceSupplyRepository.Table;

            if (polyclinicId != null)
            {
                query = query.Where(x => x.ShiftCenterId == polyclinicId);
            }

            if(serviceSupplyIds != null && serviceSupplyIds.Any())
            {
                query = query.Where(x => serviceSupplyIds.Contains(x.Id));
            }

            if(isConsultancyEnabled != null)
            {
                query = query.Where(x => x.ConsultancyEnabled == isConsultancyEnabled);
            }

            var doctors = await (from s in query
                                 select new SelectListItem
                                 {
                                     Text = Lng == Lang.KU ? s.Person.FullName_Ku : Lng == Lang.AR ? s.Person.FullName_Ar : s.Person.FullName,
                                     Value = s.Id.ToString(),
                                 }).ToListAsync();

            return doctors;
        }

        public IQueryable<ServiceSupply> GetAll(int? polyclinicId = null)
        {
            var query = _serviceSupplyRepository.Table;

            if (polyclinicId != null)
            {
                query = query.Where(x => x.ShiftCenterId == polyclinicId);
            }

            return query;
        }

        public virtual IQueryable<ServiceSupply> GetAllAvailableServiceSuppliesForClinic(int clinicId)
        {
            if (clinicId == 0)
                throw new ArgumentNullException("clinicId");

            var query = from s in _serviceSupplyRepository.Table
                        where s.ShiftCenter.ClinicId == clinicId && s.IsAvailable
                        select s;

            return query;
        }

        public virtual ServiceSupply GetServiceSupplyById(int id)
        {
            if (id == 0)
                return null;

            return _serviceSupplyRepository.GetById(id);
        }

        public virtual async Task<ServiceSupply> GetServiceSupplyByIdAsync(int id)
        {
            if (id == 0) return null;

            return await _serviceSupplyRepository.Table.FirstOrDefaultAsync(x => x.Id == id);
        }

        public virtual ServiceSupply GetServiceSupplyByIdForClinic(int clinicId, int id)
        {
            if (id == 0 || clinicId == 0)
                return null;

            var query = from s in _serviceSupplyRepository.Table
                        where s.Id == id && s.ShiftCenter.ClinicId == clinicId
                        select s;
            return query.FirstOrDefault();
        }

        public ServiceSupply GetServiceSupplyByIdForPolyClinic(int polyclinicId, int id)
        {
            if (id == 0 || polyclinicId == 0)
                return null;

            var query = from s in _serviceSupplyRepository.Table
                        where s.Id == id && s.ShiftCenterId == polyclinicId
                        select s;
            return query.FirstOrDefault();
        }

        public async Task<ServiceSupply> GetForShiftCenterAsync(int id, int centerId)
        {
            var result = await _serviceSupplyRepository.Table.FirstOrDefaultAsync(x => x.Id == id && x.ShiftCenterId == centerId);

            return result;
        }

        public ServiceSupply GetServiceSupplyForArea(int id)
        {
            if (id == 0) return null;

            ServiceSupply serviceSupply = null;

            switch (_workContext.LoginAs)
            {
                case LoginAs.ADMIN:
                    serviceSupply = GetServiceSupplyById(id);
                    break;
                case LoginAs.CLINICMANAGER:
                    serviceSupply = GetServiceSupplyByIdForClinic(_workContext.WorkingArea.Id, id);
                    break;
                case LoginAs.POLYCLINICMANAGER:
                case LoginAs.BEAUTYCENTERMANAGER:
                    serviceSupply = GetServiceSupplyByIdForPolyClinic(_workContext.WorkingArea.Id, id);
                    break;
                default:
                    break;
            }
            return serviceSupply;
        }

        public async Task<ServiceSupply> GetServiceSupplyForAreaAsync(int id)
        {
            if (id == 0) return null;

            ServiceSupply serviceSupply = null;

            switch (_workContext.LoginAs)
            {
                case LoginAs.ADMIN:
                    serviceSupply = await GetServiceSupplyByIdAsync(id);
                    break;
                case LoginAs.CLINICMANAGER:
                    serviceSupply = GetServiceSupplyByIdForClinic(_workContext.WorkingArea.Id, id);
                    break;
                case LoginAs.POLYCLINICMANAGER:
                case LoginAs.BEAUTYCENTERMANAGER:
                    serviceSupply = GetServiceSupplyByIdForPolyClinic(_workContext.WorkingArea.Id, id);
                    break;
                default:
                    break;
            }

            return serviceSupply;
        }

        public virtual void UpdateServiceSupply(ServiceSupply serviceSupply)
        {
            if (serviceSupply == null)
                throw new ArgumentNullException("serviceSupply");

            _serviceSupplyRepository.Update(serviceSupply);
        }
    }
}
