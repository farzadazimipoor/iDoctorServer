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
    public class PrescriptionRepository : IPrescriptionRepository
    {
        private readonly IRepository<CenterPrescription> _prescriptionRepository;
        public PrescriptionRepository(IRepository<CenterPrescription> prescriptionRepository)
        {
            _prescriptionRepository = prescriptionRepository;
        }

        public async Task<CenterPrescription> GetByIdAsync(int id)
        {
            var entity = await _prescriptionRepository.GetByIdAsync(id);

            return entity;
        }

        public async Task<SonarDashboardViewModel> CenterDashboardDataAsync(int centerId)
        {
            var query = _prescriptionRepository.Table;

            query = query.Where(x => x.CenterId == centerId);

            var allCount = await query.CountAsync();

            var newCount = await query.CountAsync(x => x.Status == PrescriptionStatus.PENDING);

            var doneCount = await query.CountAsync(x => x.Status == PrescriptionStatus.DONE);

            var result = new SonarDashboardViewModel
            {
                AllPrescriptionCount = allCount,
                NewPrescriptionCount = newCount,
                DonePrescriptionCount = doneCount
            };

            return result;
        }

        public async Task<DataTablesPagedResults<SonarPrescriptionListViewModel>> GetDataTableAsync(DataTablesParameters table, PrescriptionFilterViewModel filters, Lang lng = Lang.KU)
        {
            IQueryable<CenterPrescription> query = _prescriptionRepository.Table;

            query = query.Where(x => x.CenterId == filters.CenterId);

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
                    query = orderDir == DataTablesOrderDir.DESC ? query.OrderByDescending(x => lng == Lang.KU ? x.Center.Name_Ku : lng == Lang.AR ? x.Center.Name_Ar : x.Center.Name) : query.OrderBy(x => lng == Lang.KU ? x.Center.Name_Ku : lng == Lang.AR ? x.Center.Name_Ar : x.Center.Name);
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
                .Select(x => new SonarPrescriptionListViewModel
                {
                    Id = x.Id,
                    CenterId = x.CenterId,
                    TreatmentHistoryId = x.TreatmentHistoryId,
                    Status = x.Status,
                    SonarCenter = lng == Lang.KU ? x.Center.Name_Ku : lng == Lang.AR ? x.Center.Name_Ar : x.Center.Name,
                    Doctor = lng == Lang.KU ? x.TreatmentHistory.Patient.ServiceSupply.Person.FullName_Ku : lng == Lang.AR ? x.TreatmentHistory.Patient.ServiceSupply.Person.FullName_Ar : x.TreatmentHistory.Patient.ServiceSupply.Person.FullName,
                    Patient = lng == Lang.KU ? x.TreatmentHistory.Patient.Person.FullName_Ku : lng == Lang.AR ? x.TreatmentHistory.Patient.Person.FullName_Ar : x.TreatmentHistory.Patient.Person.FullName,
                    CreateDate = x.CreatedAt.ToString("yyyy-MM-dd"),
                    StatusName = x.Status.GetLocalizedDisplayName()
                })
                .ToListAsync();

            return new DataTablesPagedResults<SonarPrescriptionListViewModel>
            {
                Items = items,
                TotalSize = size
            };
        }

        public async Task SetStatusAsync(int id, int centerId, int treatmentId, PrescriptionStatus status)
        {
            var pharmacyPrescription = await _prescriptionRepository.Table.FirstOrDefaultAsync(x => x.Id == id && x.CenterId == centerId && x.TreatmentHistoryId == treatmentId);

            if (pharmacyPrescription == null) throw new AwroNoreException(AN.Core.Resources.EntitiesResources.Messages.PrescriptionNotFound);

            pharmacyPrescription.Status = status;

            _prescriptionRepository.Update(pharmacyPrescription);
        }

        public async Task DeletePrescriptionAsync(int id, int centerId, int treatmentId)
        {
            var prescription = await _prescriptionRepository.Table.FirstOrDefaultAsync(x => x.Id == id && x.CenterId == centerId && x.TreatmentHistoryId == treatmentId);

            if (prescription == null) throw new AwroNoreException(AN.Core.Resources.EntitiesResources.Messages.PrescriptionNotFound);

            prescription.IsDeleted = true;

            _prescriptionRepository.Update(prescription);
        }
    }
}
