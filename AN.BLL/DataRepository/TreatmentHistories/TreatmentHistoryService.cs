using AN.Core.Data;
using AN.Core.Domain;
using AN.Core.Enums;
using AN.Core.Extensions;
using AN.Core.ViewModels;
using Microsoft.EntityFrameworkCore;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AN.BLL.DataRepository.TreatmentHistories
{
    public class TreatmentHistoryService : ITreatmentHistoryService
    {
        private readonly IRepository<TreatmentHistory> _treatmentHistoryRepository;
        public TreatmentHistoryService(IRepository<TreatmentHistory> treatmentHistoryRepository)
        {
            _treatmentHistoryRepository = treatmentHistoryRepository;
        }

        public async Task<TreatmentHistory> GetByIdAsync(int id)
        {
            var result = await _treatmentHistoryRepository.Table.FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        public async Task InsertNewTreatmentAsync(TreatmentHistory treatment)
        {
            if (treatment == null) throw new ArgumentNullException(nameof(treatment));

            await _treatmentHistoryRepository.InsertAsync(treatment);
        }

        public async Task<List<TreatmentHistory>> GetByPatientAsync(int patientId, int centerId)
        {
            if (patientId <= 0) return new List<TreatmentHistory>();

            var result = await _treatmentHistoryRepository.Table.Where(x => x.Patient.ServiceSupply.ShiftCenterId == centerId && x.PatientId == patientId).ToListAsync();

            return result;
        }

        public async Task<DataTablesPagedResults<TreatmentHistoryListItemViewModel>> GetDataTableAsync(int shiftCenterId, DataTablesParameters table, TreatmentHistoryFilterViewModel filters, Lang lng = Lang.KU)
        {
            IQueryable<TreatmentHistory> query = _treatmentHistoryRepository.Table.Where(a => a.Patient.ServiceSupply.ShiftCenterId == shiftCenterId);

            query = query.Where(x => !x.Prescriptions.Any());

            if (!string.IsNullOrEmpty(filters.FilterString))
            {
                query = query.Where(a => a.Patient.Person.FullName.Contains(filters.FilterString) ||
                                         a.Patient.Person.FullName_Ar.Contains(filters.FilterString) ||
                                         a.Patient.Person.FullName_Ku.Contains(filters.FilterString) ||
                                         a.Patient.ServiceSupply.Person.FullName.Contains(filters.FilterString) ||
                                         a.Patient.ServiceSupply.Person.FullName_Ar.Contains(filters.FilterString) ||
                                         a.Patient.ServiceSupply.Person.FullName_Ku.Contains(filters.FilterString));
            }

            if (filters.ServiceSupplyIds != null && filters.ServiceSupplyIds.Any())
            {
                query = query.Where(a => a.Patient.ServiceSupplyId != null && filters.ServiceSupplyIds.Contains(a.Patient.ServiceSupplyId.Value));
            }

            if (filters.DoctorId != null)
            {
                query = query.Where(a => a.Patient.ServiceSupplyId == filters.DoctorId);
            }

            if (filters.PatientId != null)
            {
                query = query.Where(a => a.PatientId == filters.PatientId);
            }

            if (filters.VisitFrom != null)
            {
                query = query.Where(a => a.VisitDate >= filters.VisitFrom);
            }

            if (filters.VisitTo != null)
            {
                filters.VisitTo = DateTime.Parse($"{filters.VisitTo.Value.ToShortDateString()} 23:59:59");

                query = query.Where(a => a.VisitDate <= filters.VisitTo);
            }

            if (table.Order != null && table.Order.Any())
            {
                var orderIndex = table.Order[0].Column;
                var orderDir = table.Order[0].Dir;

                if (orderIndex == 1)
                {
                    query = orderDir == DataTablesOrderDir.DESC ? query.OrderByDescending(x => x.VisitDate) : query.OrderBy(x => x.VisitDate);
                }
                else if (orderIndex == 2)
                {
                    query = orderDir == DataTablesOrderDir.DESC ? query.OrderByDescending(x => x.Patient.ServiceSupplyId) : query.OrderBy(x => x.Patient.ServiceSupplyId);
                }
                else if (orderIndex == 3)
                {
                    query = orderDir == DataTablesOrderDir.DESC ? query.OrderByDescending(x => x.Patient.PersonId) : query.OrderBy(x => x.Patient.PersonId);
                }
                else if (orderIndex == 4)
                {
                    query = orderDir == DataTablesOrderDir.DESC ? query.OrderByDescending(x => x.Patient.Person.Gender) : query.OrderBy(x => x.Patient.Person.Gender);
                }
            }

            var size = await query.CountAsync();

            var items = await query
                .AsNoTracking()
                .Skip((table.Start / table.Length) * table.Length)
                .Take(table.Length)
                .Select(x => new TreatmentHistoryListItemViewModel
                {
                    Id = x.Id,
                    VisitDate = x.VisitDate.ToString("yyyy/MM/dd"),
                    Patient = lng == Lang.KU ? x.Patient.Person.FullName_Ku : lng == Lang.AR ? x.Patient.Person.FullName_Ar : x.Patient.Person.FullName,
                    Doctor = lng == Lang.KU ? x.Patient.ServiceSupply.Person.FullName_Ku : lng == Lang.AR ? x.Patient.ServiceSupply.Person.FullName_Ar : x.Patient.ServiceSupply.Person.FullName,
                    Gender = x.Patient.Person.Gender.GetLocalizedDisplayName(),
                    Pharmacy = x.PharmacyPrescriptions.Any() ? lng == Lang.KU ? x.PharmacyPrescriptions.FirstOrDefault().Pharmacy.Name_Ku : lng == Lang.AR ? x.PharmacyPrescriptions.FirstOrDefault().Pharmacy.Name_Ar : x.PharmacyPrescriptions.FirstOrDefault().Pharmacy.Name : "",
                    Avatar = x.Patient.Person.RealAvatar,
                    IsDoneByPharmacy = x.PharmacyPrescriptions.Any(p => p.Status == PrescriptionStatus.DONE)
                })
                .ToListAsync();

            return new DataTablesPagedResults<TreatmentHistoryListItemViewModel>
            {
                Items = items,
                TotalSize = size
            };
        }
    }
}
