using AN.Core;
using AN.Core.Data;
using AN.Core.Domain;
using AN.Core.Enums;
using AN.Core.Exceptions;
using AN.Core.Extensions;
using AN.Core.Models;
using AN.Core.ViewModels;
using AN.DAL;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AN.BLL.DataRepository.Polyclinics
{
    public partial class ShiftCenterService : IShiftCenterService
    {
        private readonly IRepository<ShiftCenter> _shiftCenterRepository;
        private readonly IWorkContext _workContext;        
        private readonly BanobatDbContext _dbContext;        
        public ShiftCenterService(IRepository<ShiftCenter> shiftCenterRepository, IWorkContext workContext, BanobatDbContext dbContext)
        {
            _shiftCenterRepository = shiftCenterRepository;
            _workContext = workContext;
            _dbContext = dbContext;
        }

        public async Task<ShiftCenter> GetByIdAsync(int id)
        {
            return await _shiftCenterRepository.GetByIdAsync(id);
        }

        public async Task<List<SelectListItem>> GetSelectListAsync(Lang lang, List<ShiftCenterType> types = null)
        {
            var query = _shiftCenterRepository.Table;

            if (types != null && types.Any())
            {
                query = query.Where(x => types.Any(t => x.Type.HasFlag(t)));
            }

            var result = await query.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = lang == Lang.KU ? x.Name_Ku : lang == Lang.AR ? x.Name_Ar : x.Name
            }).ToListAsync();

            return result;
        }

        public async Task<long> GetAllCountForHospitalAsync(int hospitalId)
        {
            var count = await _shiftCenterRepository.Table.LongCountAsync(x => x.Clinic != null && x.Clinic.HospitalId == hospitalId);

            return count;
        }

        public IEnumerable<ShiftCenter> DynamicQuery(QueryModel<ShiftCenter> model)
        {
            var policlinis = _shiftCenterRepository.GenericQuery(model);

            return policlinis;
        }

        public ShiftCenter GetShiftCenterById(int id)
        {
            if (id == 0)
                throw new ArgumentNullException("id");

            return _shiftCenterRepository.Table.FirstOrDefault(p => p.Id == id);
        }

        public virtual void DeleteShiftCenter(ShiftCenter poliClinic)
        {
            if (poliClinic == null)
                throw new ArgumentNullException("poliClinic");

            _shiftCenterRepository.Delete(poliClinic);
        }

        public virtual IQueryable<ShiftCenter> GetAllApprovedIndependentShiftCenters()
        {
            var query = from p in _shiftCenterRepository.Table
                        where (p.ClinicId == null || p.ClinicId == 0) && (bool)p.IsIndependent && (bool)p.IsApproved && (bool)!p.IsDeleted
                        select p;

            return query;
        }

        public virtual IQueryable<ShiftCenter> GetAllUnApprovedIndependentShiftCenters()
        {
            var query = from p in _shiftCenterRepository.Table
                        where p.ClinicId == null && (bool)p.IsIndependent && (bool)!p.IsApproved && (bool)!p.IsDeleted
                        select p;

            return query;
        }

        public ShiftCenter GetIndependentShiftCenterById(int id)
        {
            if (id == 0)
                throw new ArgumentNullException("id");

            return _shiftCenterRepository.Table.FirstOrDefault(p => p.ClinicId == null && (bool)p.IsIndependent && p.Id == id);
        }

        public IList<ShiftCenter> GetAllShiftCentersForHospital(int hospitalId)
        {
            if (hospitalId == 0)
                throw new ArgumentNullException("hospitalId");

            var query = from p in _shiftCenterRepository.Table
                        where p.Clinic.HospitalId == hospitalId
                        select p;

            return query.ToList();
        }

        public IList<ShiftCenter> GetAllShiftCentersForClinic(int clinicId)
        {
            if (clinicId == 0)
                throw new ArgumentNullException("clinicId");

            var query = from p in _shiftCenterRepository.Table
                        where p.ClinicId == clinicId
                        select p;

            return query.ToList();
        }

        public void InsertShiftCenter(ShiftCenter poliClinic)
        {
            if (poliClinic == null)
                throw new ArgumentNullException("poliClinic");

            _shiftCenterRepository.Insert(poliClinic);
        }

        public int GetAllApprovedIndependentShiftCenterCount()
        {
            return _shiftCenterRepository.Table.Where(p => (bool)p.IsIndependent && (bool)p.IsApproved && !(bool)p.IsDeleted).Count();
        }

        public virtual async Task<int> GetAllApprovedShiftCentersCountAsync(bool? isIndependent = null)
        {
            var query = _shiftCenterRepository.Table;
            if (isIndependent != null)
            {
                query = query.Where(p => (bool)p.IsIndependent && (bool)p.IsApproved && !(bool)p.IsDeleted);
            }
            return await query.CountAsync();
        }

        public virtual async Task<int> GetAllUnApprovedIndependentShiftCentersCountAsync()
        {
            return await _shiftCenterRepository.Table.Where(p => (bool)p.IsIndependent && !(bool)p.IsApproved && !(bool)p.IsDeleted).CountAsync();
        }

        public ShiftCenter GetShiftCenterForArea(int id)
        {
            if (id == 0) return null;

            ShiftCenter poliClinic = null;

            switch (_workContext.LoginAs)
            {
                case Shared.Enums.LoginAs.ADMIN:
                    poliClinic = GetShiftCenterById(id);
                    break;
                case Shared.Enums.LoginAs.HOSPITALMANAGER:
                    poliClinic = _shiftCenterRepository.Table.FirstOrDefault(x => x.Id == id && !x.IsIndependent && !x.Clinic.IsIndependent && x.Clinic.HospitalId == _workContext.WorkingArea.Id);
                    break;
                case Shared.Enums.LoginAs.CLINICMANAGER:
                    poliClinic = _shiftCenterRepository.Table.FirstOrDefault(x => x.Id == id && !(bool)x.IsIndependent && x.ClinicId == _workContext.WorkingArea.Id);
                    break;
                case Shared.Enums.LoginAs.POLYCLINICMANAGER:
                case Shared.Enums.LoginAs.BEAUTYCENTERMANAGER:
                    poliClinic = GetShiftCenterById(_workContext.WorkingArea.Id);
                    break;
            }

            return poliClinic;
        }

        public virtual ShiftCenter GetCurrentShiftCenter()
        {
            if (_workContext.WorkingArea.LoginAs == Shared.Enums.LoginAs.POLYCLINICMANAGER || _workContext.WorkingArea.LoginAs == Shared.Enums.LoginAs.BEAUTYCENTERMANAGER)
            {
                return GetShiftCenterById(_workContext.WorkingArea.Id);
            }              
            return null;
        }

        public IQueryable<ShiftCenter> GetPoliclinicsForUser(int userId)
        {
            var query = from pcu in _shiftCenterRepository.Table
                        where pcu.ShiftCenterUsers.Any(x => x.PersonId == userId)
                        select pcu;

            return query;
        }

        public async Task<DataTablesPagedResults<RegisterRequestsListViewModel>> GetRegistrationRequestsDataTableAsync(DataTablesParameters table, RegisterRequestsFilterViewModel filters, Lang lng = Lang.KU)
        {
            IQueryable<ShiftCenter> query = _shiftCenterRepository.Table;

            query = query.Where(x => x.IsApproved == false);

            if (!string.IsNullOrEmpty(filters.FilterString))
            {
                query = query.Where(x => x.Name.Contains(filters.FilterString) || x.Name_Ar.Contains(filters.FilterString) || x.Name_Ku.Contains(filters.FilterString));
            }

            if (filters.From != null)
            {
                query = query.Where(a => a.CreatedAt >= filters.From);
            }
            if (filters.To != null)
            {
                filters.To = DateTime.Parse($"{filters.To.Value.ToShortDateString()} 23:59:59");

                query = query.Where(a => a.CreatedAt <= filters.To);
            }

            if (table.Order != null && table.Order.Any())
            {
                var orderIndex = table.Order[0].Column;
                var orderDir = table.Order[0].Dir;

                switch (orderIndex)
                {
                    case 0:
                    case 2:
                        {
                            query = orderDir == DataTablesOrderDir.ASC ? query.OrderBy(x => x.CreatedAt) : query.OrderByDescending(x => x.CreatedAt); 
                        }
                        break;
                    case 6:
                        {
                            if (lng == Lang.KU)
                                query = orderDir == DataTablesOrderDir.ASC ? query.OrderBy(x => x.Name_Ku) : query.OrderByDescending(x => x.Name_Ku); 
                            else if (lng == Lang.AR)
                                query = orderDir == DataTablesOrderDir.ASC ? query.OrderBy(x => x.Name_Ar) : query.OrderByDescending(x => x.Name_Ar); 
                            else
                                query = orderDir == DataTablesOrderDir.ASC ? query.OrderBy(x => x.Name) : query.OrderByDescending(x => x.Name);                            
                        }
                        break;
                    case 7:
                        {
                            query = orderDir == DataTablesOrderDir.ASC ? query.OrderBy(x => x.PhoneNumbers.FirstOrDefault().PhoneNumber) : query.OrderByDescending(x => x.CreatedAt); 
                        }
                        break;
                    case 8:
                        {
                            query = orderDir == DataTablesOrderDir.ASC ? query.OrderBy(x => x.CityId) : query.OrderByDescending(x => x.CityId);
                        }
                        break;
                    case 9:
                        {
                            query = orderDir == DataTablesOrderDir.ASC ? query.OrderBy(x => x.Type) : query.OrderByDescending(x => x.Type);
                        }
                        break;
                }               
            }

            var size = await query.CountAsync();

            var items = await query
                .AsNoTracking()
                .Skip((table.Start / table.Length) * table.Length)
                .Take(table.Length)
                .Select(x => new RegisterRequestsListViewModel
                {
                    Id = x.Id,
                    CreateDate = x.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss"),
                    Name = x.ShiftCenterUsers.FirstOrDefault().Person != null ? lng == Lang.KU ? x.ShiftCenterUsers.FirstOrDefault().Person.FullName_Ku : lng == Lang.AR ? x.ShiftCenterUsers.FirstOrDefault().Person.FullName_Ar : x.ShiftCenterUsers.FirstOrDefault().Person.FullName : "",
                    Mobile = x.ShiftCenterUsers.FirstOrDefault().Person != null ? x.ShiftCenterUsers.FirstOrDefault().Person.Mobile : "",
                    Gender = x.ShiftCenterUsers.FirstOrDefault().Person != null ? x.ShiftCenterUsers.FirstOrDefault().Person.Gender == Gender.Male ? AN.Core.Resources.Global.Global.Male : AN.Core.Resources.Global.Global.FeMale : "",
                    CenterName = lng == Lang.KU ? x.Name_Ku : lng == Lang.AR ? x.Name_Ar : x.Name,
                    CenterPhone = x.PhoneNumbers.FirstOrDefault() != null ? x.PhoneNumbers.FirstOrDefault().PhoneNumber : "",
                    CenterCity = lng == Lang.KU ? x.City.Name_Ku : lng == Lang.AR ? x.City.Name_Ar : x.City.Name,
                    CenterType = x.Type.GetDisplayName(),
                    Avatar = x.ShiftCenterUsers.FirstOrDefault().Person != null ? x.ShiftCenterUsers.FirstOrDefault().Person.RealAvatar : ""
                })
                .ToListAsync();

            return new DataTablesPagedResults<RegisterRequestsListViewModel>
            {
                Items = items,
                TotalSize = size
            };
        }

        public async Task ApproveRegistrationRequestAsync(int id)
        {
            var center = await _dbContext.ShiftCenters.FirstOrDefaultAsync(x => x.Id == id && !x.IsApproved);

            if (center == null) throw new AwroNoreException("Shift center not found");

            center.IsApproved = true;

            _dbContext.Entry(center).State = EntityState.Modified;

            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteRegistrationRequestAsync(int id)
        {
            var center = await _dbContext.ShiftCenters.FirstOrDefaultAsync(x => x.Id == id && !x.IsApproved);

            if(center != null)
            {
                var centerPersons = center.ShiftCenterUsers.ToList();

                if (centerPersons.Any())
                {
                    _dbContext.ShiftCenterPersons.RemoveRange(centerPersons);
                }

                var centerServices = center.PolyclinicHealthServices.ToList();

                if (centerServices.Any())
                {
                    _dbContext.CenterServices.RemoveRange(centerServices);
                }

                _dbContext.ShiftCenters.Remove(center);

                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
