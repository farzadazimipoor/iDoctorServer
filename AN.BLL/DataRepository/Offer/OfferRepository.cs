using AN.BLL.Helpers;
using AN.Core.Data;
using AN.Core.Domain;
using AN.Core.Enums;
using AN.Core.Extensions;
using AN.Core.MyExceptions;
using AN.Core.ViewModels;
using Microsoft.EntityFrameworkCore;
using Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AN.BLL.DataRepository
{
    public class OfferRepository : IOfferRepository
    {
        private readonly IRepository<Offer> _offerRepository;
        public OfferRepository(IRepository<Offer> offerRepository)
        {
            _offerRepository = offerRepository;
        }

        public async Task<Offer> GetByIdAsync(int id)
        {
            var result = await _offerRepository.Table.FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        public async Task InsertOfferAsync(Offer offer)
        {
            await _offerRepository.InsertAsync(offer);
        }

        public void UpdateOffer(Offer offer)
        {
            _offerRepository.Update(offer);
        }

        public async Task<DataTablesPagedResults<OfferListViewModel>> GetDataAsync(DataTablesParameters table, int? centerId = null, List<int> serviceSupplyIds = null, bool isForAdmin = false)
        {
            IQueryable<Offer> query = _offerRepository.TableNoTracking;

            if (!isForAdmin)
            {
                if (centerId != null)
                {
                    query = query.Where(x => x.ServiceSupply.ShiftCenterId == centerId);
                }

                if (serviceSupplyIds != null && serviceSupplyIds.Any())
                {
                    query = query.Where(x => serviceSupplyIds.Contains(x.ServiceSupplyId));
                }
            }

            if (table.Order != null && table.Order.Any())
            {
                var orderIndex = table.Order[0].Column;
                var orderDir = table.Order[0].Dir;

                if (orderIndex == 1 || orderIndex == 2)
                {
                    query = orderDir == DataTablesOrderDir.DESC ? query.OrderByDescending(x => x.StartDateTime) : query = query.OrderBy(x => x.StartDateTime);
                }
                else if (orderIndex == 3)
                {
                    query = orderDir == DataTablesOrderDir.DESC ? query.OrderByDescending(x => x.EndDateTime) : query = query.OrderBy(x => x.EndDateTime);
                }
                else if (orderIndex == 4)
                {
                    query = orderDir == DataTablesOrderDir.DESC ? query.OrderByDescending(x => x.Status) : query.OrderBy(x => x.Status);
                }
                else
                {
                    query = query.OrderByDescending(x => x.CreatedAt);
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
                .Select(x => new OfferListViewModel
                {
                    Id = x.Id,
                    Date = x.CreatedAt.ToString("yyyy/MM/dd HH:mm:ss"),
                    StartTime = x.StartAt.ToString("yyyy/MM/dd HH:mm:ss"),
                    EndTime = x.ExpiredAt.ToString("yyyy/MM/dd HH:mm:ss"),
                    Status = x.Status.GetLocalizedDisplayName(),
                    OfferStatus = x.Status,
                    CenterName = x.ServiceSupply.ShiftCenter.Name,
                    Type = x.Type.ToString(),
                    Visits = x.VisitsCount,
                    Appointments = x.Appointments.Count
                })
                .ToListAsync();

            return new DataTablesPagedResults<OfferListViewModel>
            {
                Items = items,
                TotalSize = size
            };
        }

        public async Task<Offer> SetNewStatusAsync(int id, OfferStatus newStatus)
        {
            var offer = await GetByIdAsync(id);

            if (offer == null) throw new EntityNotFoundException("Offer Not Found");

            offer.Status = newStatus;

            UpdateOffer(offer);

            return offer;
        }

        public async Task<bool> IsExistCodeAsync(string code)
        {
            if (string.IsNullOrEmpty(code))
                return false;

            var exist = await _offerRepository.TableNoTracking.AnyAsync(x => x.Code.Equals(code));
            return exist;
        }


        public async Task<string> GenerateUniqueCodeAsync()
        {
            var code = string.Empty;
            do
            {
                code = Utils.GetUniqueKey(size: 5);
            } while ((await IsExistCodeAsync(code)));

            return code;
        }

        public async Task DeleteAsync(int id)
        {
            var offer = await GetByIdAsync(id);

            if (offer != null)
            {
                await _offerRepository.DeleteAsync(offer);
            }
        }
    }
}
