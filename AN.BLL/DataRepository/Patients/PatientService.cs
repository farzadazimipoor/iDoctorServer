using AN.Core.Data;
using AN.Core.Domain;
using AN.Core.Enums;
using AN.Core.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace AN.BLL.DataRepository.Patients
{
    public class PatientService : IPatientService
    {
        private readonly IRepository<Patient> _patientRepository;
        public PatientService(IRepository<Patient> patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<Patient> GetByIdAsync(int id)
        {
            return await _patientRepository.GetByIdAsync(id);
        }

        public async Task<Patient> FindForServiceSupplyAsync(int serviceSupplyId, int personId)
        {
            var patient = await _patientRepository.Table.FirstOrDefaultAsync(x => x.ServiceSupplyId == serviceSupplyId && x.PersonId == personId);

            return patient;
        }

        public async Task<Patient> FindForCenterAsync(int centerId, int personId)
        {
            var patient = await _patientRepository.Table.FirstOrDefaultAsync(x => x.CenterId == centerId && x.PersonId == personId);

            return patient;
        }

        public async Task InsertNewPatientAsync(Patient patient)
        {
            await _patientRepository.InsertAsync(patient);
        }

        public async Task<List<SelectListItem>> GetSelectListItemsAsync(int? shiftCenterId = null, List<int> serviceSupplyIds = null, Lang lng = Lang.KU)
        {
            IQueryable<Patient> query = _patientRepository.Table;

            if(shiftCenterId != null)
            {
                query = query.Where(x => x.ServiceSupply.ShiftCenterId == shiftCenterId);
            }

            if (serviceSupplyIds != null && serviceSupplyIds.Any())
            {
                query = query.Where(x => x.ServiceSupplyId != null && serviceSupplyIds.Contains(x.ServiceSupplyId.Value));
            }

            var result = await query.OrderBy(x => lng == Lang.KU ? x.Person.FullName_Ku : lng == Lang.AR ? x.Person.FullName_Ar : x.Person.FullName).Select(x => new SelectListItem
            {
                Text = lng == Lang.KU ? x.Person.FullName_Ku : lng == Lang.AR ? x.Person.FullName_Ar : x.Person.FullName,
                Value = x.Id.ToString()

            }).ToListAsync();

            return result;
        }

        public async Task<DataTablesPagedResults<PatientListViewModel>> GetDataTableAsync(int shiftCenterId, DataTablesParameters table, PatientFilterViewModel filters, Lang lng = Lang.KU, bool onlyForCenter = false)
        {
            IQueryable<Patient> query = _patientRepository.Table;

            if (onlyForCenter)
            {
                query = query.Where(x => x.CenterId == shiftCenterId);
            }
            else
            {
                query = query.Where(x => x.ServiceSupply != null && x.ServiceSupply.ShiftCenterId == shiftCenterId);
            }
           
            if (filters.ServiceSupplyIds != null && filters.ServiceSupplyIds.Any())
            {
                query = query.Where(x => x.ServiceSupplyId != null && filters.ServiceSupplyIds.Contains(x.ServiceSupplyId.Value));
            }

            if (!string.IsNullOrEmpty(filters.FilterString))
            {
                query = query.Where(x => x.Person.FullName.Contains(filters.FilterString) ||
                                         x.Person.FullName_Ar.Contains(filters.FilterString) ||
                                         x.Person.FullName_Ku.Contains(filters.FilterString) ||
                                         x.Person.Mobile.Contains(filters.FilterString) ||
                                         x.Person.UniqueId != null && x.Person.UniqueId.Contains(filters.FilterString));
            }

            if (!string.IsNullOrEmpty(filters.UniqueId))
            {
                query = query.Where(x => x.Person.UniqueId.Contains(filters.UniqueId));
            }

            if (filters.ServiceSupplyId != null)
            {
                query = query.Where(a => a.ServiceSupplyId == filters.ServiceSupplyId);
            }

            if (filters.FromDate != null)
            {
                query = query.Where(a => a.CreatedAt >= filters.FromDate);
            }
            if (filters.ToDate != null)
            {
                filters.ToDate = DateTime.Parse($"{filters.ToDate.Value.ToShortDateString()} 23:59:59");

                query = query.Where(a => a.CreatedAt <= filters.ToDate);
            }

            // Do Filters & Ordering Here

            if (table.Order != null && table.Order.Any())
            {
                var orderIndex = table.Order[0].Column;
                var orderDir = table.Order[0].Dir;

                if (orderIndex == 2)
                {
                    if (orderDir == DataTablesOrderDir.DESC)
                    {
                        query = query.OrderByDescending(x => lng == Lang.KU ? x.Person.FullName_Ku : lng == Lang.AR ? x.Person.FullName_Ar : x.Person.FullName);
                    }
                    else
                    {
                        query = query.OrderBy(x => lng == Lang.KU ? x.Person.FullName_Ku : lng == Lang.AR ? x.Person.FullName_Ar : x.Person.FullName);
                    }
                }
                else if (orderIndex == 3)
                {
                    query = orderDir == DataTablesOrderDir.DESC ? query.OrderByDescending(x => x.Person.Mobile) : query.OrderBy(x => x.Person.Mobile);
                }
                else if (orderIndex == 4)
                {
                    query = orderDir == DataTablesOrderDir.DESC ? query.OrderByDescending(x => x.Person.Gender) : query.OrderBy(x => x.Person.Gender);
                }
                else if (orderIndex == 5)
                {
                    query = orderDir == DataTablesOrderDir.DESC ? query.OrderByDescending(x => x.Person.Age) : query.OrderBy(x => x.Person.Age);
                }
                else if (orderIndex == 6)
                {
                    query = orderDir == DataTablesOrderDir.DESC ? query.OrderByDescending(x => x.Person.UniqueId) : query.OrderBy(x => x.Person.UniqueId);
                }
                else if (orderIndex == 7)
                {
                    if (orderDir == DataTablesOrderDir.DESC)
                    {
                        query = query.OrderByDescending(x => lng == Lang.KU ? x.ServiceSupply.Person.FullName_Ku : lng == Lang.AR ? x.ServiceSupply.Person.FullName_Ar : x.ServiceSupply.Person.FullName);
                    }
                    else
                    {
                        query = query.OrderBy(x => lng == Lang.KU ? x.ServiceSupply.Person.FullName_Ku : lng == Lang.AR ? x.ServiceSupply.Person.FullName_Ar : x.ServiceSupply.Person.FullName);
                    }
                }
                else
                {
                    query = orderDir == DataTablesOrderDir.DESC ? query.OrderByDescending(x => x.CreatedAt) : query.OrderBy(x => x.CreatedAt);
                }
            }

            var size = await query.CountAsync();

            var items = await query
                .AsNoTracking()
                .Skip((table.Start / table.Length) * table.Length)
                .Take(table.Length)
                .Select(x => new PatientListViewModel
                {
                    Id = x.Id,
                    ServiceSupplyId = x.ServiceSupplyId,
                    PersonId = x.PersonId,
                    Name = lng == Lang.KU ? x.Person.FullName_Ku : lng == Lang.AR ? x.Person.FullName_Ar : x.Person.FullName,
                    Mobile = x.Person.Mobile,
                    Gender = x.Person.Gender == Gender.Male ? AN.Core.Resources.Global.Global.Male : AN.Core.Resources.Global.Global.FeMale,
                    Age = x.Person.Age ?? 0,
                    IdNumber = x.Person.IdNumber,
                    UniqueId = x.Person.UniqueId,
                    Doctor = lng == Lang.KU ? x.ServiceSupply.Person.FullName_Ku : lng == Lang.AR ? x.ServiceSupply.Person.FullName_Ar : x.ServiceSupply.Person.FullName,
                    Avatar = x.Person.RealAvatar
                }).ToListAsync();

            return new DataTablesPagedResults<PatientListViewModel>
            {
                Items = items,
                TotalSize = size
            };
        }
    }
}
