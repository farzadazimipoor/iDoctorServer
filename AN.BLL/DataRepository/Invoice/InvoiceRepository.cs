using AN.Core.Data;
using AN.Core.Domain;
using AN.Core.Enums;
using AN.Core.Extensions;
using AN.Core.ViewModels;
using Microsoft.EntityFrameworkCore;
using Shared.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AN.BLL.DataRepository
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly IRepository<Invoice> _invoiceRepository;
        public InvoiceRepository(IRepository<Invoice> invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        public async Task<Invoice> GetInvoiceByIdAsync(int id)
        {
            return await _invoiceRepository.GetByIdAsync(id);
        }

        public async Task<DataTablesPagedResults<InvoiceListItemViewModel>> GetDataTableAsync(int shiftCenterId, DataTablesParameters table, InvoiceFilterViewModel filters, Lang lng = Lang.KU)
        {
            IQueryable<Invoice> query = _invoiceRepository.Table.Where(a => a.Patient.ServiceSupply.ShiftCenterId == shiftCenterId);

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
                .Select(x => new InvoiceListItemViewModel
                {
                    Id = x.Id,
                    VisitDate = x.VisitDate.ToString("yyyy/MM/dd"),
                    Patient = lng == Lang.KU ? x.Patient.Person.FullName_Ku : lng == Lang.AR ? x.Patient.Person.FullName_Ar : x.Patient.Person.FullName,
                    Doctor = lng == Lang.KU ? x.Patient.ServiceSupply.Person.FullName_Ku : lng == Lang.AR ? x.Patient.ServiceSupply.Person.FullName_Ar : x.Patient.ServiceSupply.Person.FullName,
                    Gender = x.Patient.Person.Gender.GetLocalizedDisplayName(),
                    Avatar = x.Patient.Person.RealAvatar,
                    Amount = x.InvoiceItems.Sum(i => i.Price)
                })
                .ToListAsync();

            return new DataTablesPagedResults<InvoiceListItemViewModel>
            {
                Items = items,
                TotalSize = size
            };
        }
    }
}
