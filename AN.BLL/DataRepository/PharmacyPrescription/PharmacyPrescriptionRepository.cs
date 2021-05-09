using AN.Core.Data;
using AN.Core.Domain;
using AN.Core.Enums;
using AN.Core.Exceptions;
using AN.Core.Extensions;
using AN.Core.ViewModels;
using Microsoft.EntityFrameworkCore;
using Shared.Models;
using System.Linq;
using System.Threading.Tasks;

namespace AN.BLL.DataRepository
{
    public class PharmacyPrescriptionRepository : IPharmacyPrescriptionRepository
    {
        private readonly IRepository<PharmacyPrescription> _prescriptionRepository;
        public PharmacyPrescriptionRepository(IRepository<PharmacyPrescription> prescriptionRepository)
        {
            _prescriptionRepository = prescriptionRepository;
        }

        public async Task<PharmacyPrescription> GetByIdAsync(int id)
        {
            var prescript = await _prescriptionRepository.Table.FirstOrDefaultAsync(x => x.Id == id);

            return prescript;
        }

        public async Task<PharmacyPrescription> GetPharmacyPrescriptionAsync(int pharmacyId, int treatmentId)
        {
            var prescript = await _prescriptionRepository.Table.FirstOrDefaultAsync(x => x.PharmacyId == pharmacyId && x.TreatmentHistoryId == treatmentId);

            return prescript;
        }

        public async Task<PharmacyDashboardViewModel> PharmacyDashboardDataAsync(int pharmacyId)
        {
            var query = _prescriptionRepository.Table;

            query = query.Where(x => x.PharmacyId == pharmacyId);

            var allCount = await query.CountAsync();

            var newCount = await query.CountAsync(x => x.Status == PrescriptionStatus.PENDING);

            var doneCount = await query.CountAsync(x => x.Status == PrescriptionStatus.DONE);

            var result = new PharmacyDashboardViewModel
            {
                AllPrescriptionCount = allCount,
                NewPrescriptionCount = newCount,
                DonePrescriptionCount = doneCount
            };

            return result;
        }

        public async Task<DataTablesPagedResults<PharmacyPrescriptionListViewModel>> GetDataTableAsync(DataTablesParameters table, PharmacyPrescriptionFilterViewModel filters, Lang lng = Lang.KU)
        {
            IQueryable<PharmacyPrescription> query = _prescriptionRepository.Table;

            query = query.Where(x => x.PharmacyId == filters.PharmacyId);

            if (!string.IsNullOrEmpty(filters.FilterString))
            {
                query = query.Where(x => x.TreatmentHistory.Patient.Person.FullName.Contains(filters.FilterString));
            }

            if (filters.Status != null)
            {
                query = query.Where(x => x.Status == filters.Status);
            }

            if (filters.FromDate != null)
            {
                query = query.Where(x => x.CreatedAt >= filters.FromDate);
            }

            if (filters.ToDate != null)
            {
                query = query.Where(x => x.CreatedAt <= filters.ToDate);
            }

            if (table.Order != null && table.Order.Any())
            {
                var orderIndex = table.Order[0].Column;
                var orderDir = table.Order[0].Dir;

                if (orderIndex == 0)
                {
                    query = orderDir == DataTablesOrderDir.DESC ? query.OrderByDescending(x => lng == Lang.KU ? x.Pharmacy.Name_Ku : lng == Lang.AR ? x.Pharmacy.Name_Ar : x.Pharmacy.Name) : query.OrderBy(x => lng == Lang.KU ? x.Pharmacy.Name_Ku : lng == Lang.AR ? x.Pharmacy.Name_Ar : x.Pharmacy.Name);
                }
                else if (orderIndex == 1)
                {
                    query = orderDir == DataTablesOrderDir.DESC ? query.OrderByDescending(x => lng == Lang.KU ? x.TreatmentHistory.Patient.ServiceSupply.Person.FullName_Ku : lng == Lang.AR ? x.TreatmentHistory.Patient.ServiceSupply.Person.FullName_Ar : x.TreatmentHistory.Patient.ServiceSupply.Person.FullName) : query.OrderBy(x => lng == Lang.KU ? x.TreatmentHistory.Patient.ServiceSupply.Person.FullName_Ku : lng == Lang.AR ? x.TreatmentHistory.Patient.ServiceSupply.Person.FullName_Ar : x.TreatmentHistory.Patient.ServiceSupply.Person.FullName);
                }
                else if (orderIndex == 2)
                {
                    query = orderDir == DataTablesOrderDir.DESC ? query.OrderByDescending(x => lng == Lang.KU ? x.TreatmentHistory.Patient.Person.FullName_Ku : lng == Lang.AR ? x.TreatmentHistory.Patient.Person.FullName_Ar : x.TreatmentHistory.Patient.Person.FullName) : query.OrderBy(x => lng == Lang.KU ? x.TreatmentHistory.Patient.Person.FullName_Ku : lng == Lang.AR ? x.TreatmentHistory.Patient.Person.FullName_Ar : x.TreatmentHistory.Patient.Person.FullName);
                }
                else if (orderIndex == 3)
                {
                    query = orderDir == DataTablesOrderDir.DESC ? query.OrderByDescending(x => x.CreatedAt) : query.OrderBy(x => x.CreatedAt);
                }
                else if (orderIndex == 4)
                {
                    query = orderDir == DataTablesOrderDir.DESC ? query.OrderByDescending(x => x.Status) : query.OrderBy(x => x.Status);
                }
            }
            else
            {
                query = query.OrderByDescending(x => x.CreatedAt);
            }

            var size = await query.CountAsync();

            var items = await query
                .AsNoTracking()
                .Skip((table.Start / table.Length) * table.Length)
                .Take(table.Length)
                .Select(x => new PharmacyPrescriptionListViewModel
                {
                    Id = x.Id,
                    PharmacyId = x.PharmacyId,
                    TreatmentHistoryId = x.TreatmentHistoryId,
                    Status = x.Status,
                    Pharmacy = lng == Lang.KU ? x.Pharmacy.Name_Ku : lng == Lang.AR ? x.Pharmacy.Name_Ar : x.Pharmacy.Name,
                    Doctor = lng == Lang.KU ? x.TreatmentHistory.Patient.ServiceSupply.Person.FullName_Ku : lng == Lang.AR ? x.TreatmentHistory.Patient.ServiceSupply.Person.FullName_Ar : x.TreatmentHistory.Patient.ServiceSupply.Person.FullName,
                    Patient = lng == Lang.KU ? x.TreatmentHistory.Patient.Person.FullName_Ku : lng == Lang.AR ? x.TreatmentHistory.Patient.Person.FullName_Ar : x.TreatmentHistory.Patient.Person.FullName,
                    CreateDate = x.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss"),
                    StatusName = x.Status.GetLocalizedDisplayName()
                })
                .ToListAsync();

            return new DataTablesPagedResults<PharmacyPrescriptionListViewModel>
            {
                Items = items,
                TotalSize = size
            };
        }

        public async Task SetStatusAsync(int pharmacyId, int treatmentId, PrescriptionStatus status)
        {
            var pharmacyPrescription = await _prescriptionRepository.Table.FirstOrDefaultAsync(x => x.PharmacyId == pharmacyId && x.TreatmentHistoryId == treatmentId);

            if (pharmacyPrescription == null) throw new AwroNoreException("Prescription not found");

            pharmacyPrescription.Status = status;

            _prescriptionRepository.Update(pharmacyPrescription);
        }

        public async Task DeletePrescriptionAsync(int pharmacyId, int treatmentId)
        {
            var pharmacyPrescription = await _prescriptionRepository.Table.FirstOrDefaultAsync(x => x.PharmacyId == pharmacyId && x.TreatmentHistoryId == treatmentId);

            if (pharmacyPrescription == null) throw new AwroNoreException("Prescription not found");

            pharmacyPrescription.IsDeleted = true;

            _prescriptionRepository.Update(pharmacyPrescription);
        }
    }
}
