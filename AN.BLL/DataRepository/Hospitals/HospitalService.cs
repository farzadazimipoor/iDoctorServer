using AN.Core;
using AN.Core.Data;
using AN.Core.Domain;
using AN.Core.Enums;
using AN.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AN.BLL.DataRepository.Hospitals
{
    public class HospitalService : IHospitalService
    {
        private readonly IRepository<Hospital> _hospitalRepository;
        private readonly IWorkContext _workContext;
        public HospitalService(IRepository<Hospital> hospitalRepository, IWorkContext workContext)
        {
            _hospitalRepository = hospitalRepository;
            _workContext = workContext;
        }

        public IQueryable<Hospital> Table => _hospitalRepository.Table;

        public virtual Hospital GetHospitalById(int id)
        {
            if (id == 0) return null;

            return _hospitalRepository.GetById(id);
        }

        public virtual async Task<Hospital> GetHospitalByIdAsync(int id)
        {
            if (id == 0) return null;

            return await _hospitalRepository.Table.FirstOrDefaultAsync(x => x.Id == id);
        }

        public virtual Hospital GetCurrentHospital()
        {
            if (_workContext.WorkingArea.LoginAs == Shared.Enums.LoginAs.HOSPITALMANAGER)
            {
                return GetHospitalById(_workContext.WorkingArea.Id);
            }

            return null;
        }

        public virtual IQueryable<Hospital> GetAll()
        {
            return _hospitalRepository.Table;
        }

        public virtual async Task<IList<Hospital>> GetAllAsync()
        {
            return await _hospitalRepository.Table.ToListAsync();
        }

        public virtual async Task<int> GetHospitalsCountAsync()
        {
            return await _hospitalRepository.Table.CountAsync();
        }

        public int GetHospitalsCount()
        {
            return _hospitalRepository.Table.Count();
        }

        public virtual void InsertHospital(Hospital hospital)
        {
            if (hospital == null)
                throw new ArgumentNullException(nameof(hospital));

            _hospitalRepository.Insert(hospital);
        }

        public virtual async Task InsertHospitalAsync(Hospital hospital)
        {
            if (hospital == null) throw new ArgumentNullException(nameof(hospital));

            await _hospitalRepository.InsertAsync(hospital);
        }

        public virtual void UpdateHospital(Hospital hospital)
        {
            if (hospital == null)
                throw new ArgumentNullException(nameof(hospital));

            _hospitalRepository.Update(hospital);
        }

        public virtual void DeleteHospital(Hospital hospital)
        {
            if (hospital == null)
                throw new ArgumentNullException(nameof(hospital));

            _hospitalRepository.Delete(hospital);
        }

        public virtual async Task<IList<CommonEntity>> GetAllHospitalsCommonEntityAsync()
        {
            var lng = _workContext.Lang;

            return await _hospitalRepository.Table.Select(x => new CommonEntity
            {
                Id = x.Id,
                Name = lng == Lang.AR ? x.Name_Ar : x.Name_Ku
            }).ToListAsync();
        }

        public IList<CommonEntity> GetAllHospitalsCommonEntity()
        {
            var lng = _workContext.Lang;

            return _hospitalRepository.Table.Select(x => new CommonEntity
            {
                Id = x.Id,
                Name = lng == Lang.AR ? x.Name_Ar : x.Name_Ku
            }).ToList();
        }
    }
}
