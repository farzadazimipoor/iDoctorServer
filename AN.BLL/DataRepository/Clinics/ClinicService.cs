using AN.Core;
using AN.Core.Data;
using AN.Core.Domain;
using AN.Core.Enums;
using AN.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AN.BLL.DataRepository.Clinics
{
    public class ClinicService : IClinicService
    {
        private readonly IRepository<Clinic> _clinicRepository;
        private readonly IWorkContext _workContext;
        public ClinicService(IRepository<Clinic> clinicRepository, IWorkContext workContext)
        {
            _clinicRepository = clinicRepository;
            _workContext = workContext;
        }

        private Lang Lng => _workContext.Lang;

        public IQueryable<Clinic> Table => _clinicRepository.Table;

        public async Task<long> GetAllCountForHospitalAsync(int hospitalId)
        {
            var count = await _clinicRepository.Table.LongCountAsync(x => x.HospitalId == hospitalId);

            return count;
        }

        public IEnumerable<Clinic> DynamicQuery(QueryModel<Clinic> model)
        {
            var clinis = _clinicRepository.GenericQuery(model);

            return clinis;
        }

        public List<Clinic> GetAllClinics(string filter)
        {
            var experssions = new List<Expression<Func<Clinic, string>>> { n => Lng == Lang.KU ? n.Name_Ku : n.Name_Ar };

            var query = _clinicRepository.Match(_clinicRepository.Table, filter, experssions);

            var result = query.ToList();

            return result;
        }

        public List<Clinic> GetAll(bool isIndependent = false)
        {
            var query = _clinicRepository.Table;

            if (isIndependent) query = query.Where(x => (x.HospitalId == null || x.HospitalId == 0) && x.IsIndependent);

            return query.ToList();
        }

        public int GetAllIndepententClinicsCount()
        {
            return _clinicRepository.Table.Count(c => c.IsIndependent);
        }

        public async Task<int> GetAllClinicsCountAsync(bool? isIndependent = null)
        {
            var query = _clinicRepository.Table;
            if (isIndependent != null)
            {
                query = query.Where(x => x.IsIndependent && x.HospitalId == null);
            }
            return await query.CountAsync();
        }

        public Clinic GetClinicById(int id)
        {
            return _clinicRepository.GetById(id);
        }

        public virtual Clinic GetCurrentClinic()
        {
            if (_workContext.WorkingArea.LoginAs == Shared.Enums.LoginAs.CLINICMANAGER)
                return GetClinicById(_workContext.WorkingArea.Id);

            return null;
        }

        public Clinic GetClinicForArea(int id)
        {
            if (id == 0) return null;

            Clinic clinic = null;

            switch (_workContext.WorkingArea.LoginAs)
            {
                case Shared.Enums.LoginAs.ADMIN:
                    clinic = GetClinicById(id);
                    break;
                case Shared.Enums.LoginAs.HOSPITALMANAGER:
                    clinic = GetClinicForHospital(_workContext.WorkingArea.Id, id);
                    break;
                case Shared.Enums.LoginAs.CLINICMANAGER:
                    clinic = GetCurrentClinic();
                    break;
            }

            return clinic;
        }

        public async Task<Clinic> GetClinicForAreaAsync(int id)
        {
            if (id == 0) return null;

            Clinic clinic = null;

            switch (_workContext.WorkingArea.LoginAs)
            {
                case Shared.Enums.LoginAs.ADMIN:
                    clinic = GetClinicById(id);
                    break;
                case Shared.Enums.LoginAs.HOSPITALMANAGER:
                    clinic = await GetClinicForHospitalAsync(_workContext.WorkingArea.Id, id);
                    break;
                case Shared.Enums.LoginAs.CLINICMANAGER:
                    clinic = GetCurrentClinic();
                    break;
            }

            return clinic;
        }

        public Clinic GetClinicForHospital(int hospitalId, int clinicId)
        {
            if (hospitalId == 0 || clinicId == 0) return null;

            var result = _clinicRepository.Table.FirstOrDefault(x => x.Id == clinicId && x.HospitalId == hospitalId);

            return result;
        }

        public async Task<Clinic> GetClinicForHospitalAsync(int hospitalId, int clinicId)
        {
            if (hospitalId == 0 || clinicId == 0) return null;

            var result = await _clinicRepository.Table.FirstOrDefaultAsync(x => x.Id == clinicId && x.HospitalId == hospitalId);

            return result;
        }

        public void InsertClinic(Clinic clinic)
        {
            if (clinic == null)
                throw new ArgumentNullException(nameof(clinic));

            _clinicRepository.Insert(clinic);
        }

        public void DeleteClinic(Clinic clinic)
        {
            if (clinic == null)
                throw new ArgumentNullException(nameof(clinic));

            _clinicRepository.Delete(clinic);
        }
    }
}
