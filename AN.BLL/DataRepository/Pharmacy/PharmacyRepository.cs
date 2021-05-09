using AN.Core.Data;
using AN.Core.Domain;
using AN.Core.DTO;
using AN.Core.Enums;
using AN.Core.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AN.BLL.DataRepository
{
    public class PharmacyRepository : IPharmacyRepository
    {
        private readonly IRepository<Pharmacy> _pharmacyRepository;
        public PharmacyRepository(IRepository<Pharmacy> pharmacyRepository)
        {
            _pharmacyRepository = pharmacyRepository;
        }

        public async Task<Pharmacy> GetByIdAsync(int id)
        {
            var result = await _pharmacyRepository.Table.FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        public async Task InsertPharmacyAsync(Pharmacy pharmacy)
        {
            await _pharmacyRepository.InsertAsync(pharmacy);
        }

        public void UpdatePharmacy(Pharmacy pharmacy)
        {
            _pharmacyRepository.Update(pharmacy);
        }

        public async Task<DataTablesPagedResults<PharmacyListViewModel>> GetDataAsync(DataTablesParameters table, Lang lng = Lang.KU)
        {
            IQueryable<Pharmacy> query = _pharmacyRepository.TableNoTracking;          

            // Do Filters & Ordering Here

            var size = await query.CountAsync();

            var items = await query
                .AsNoTracking()
                .Skip((table.Start / table.Length) * table.Length)
                .Take(table.Length)
                .Select(x => new PharmacyListViewModel
                {
                    Id = x.Id,
                    Name = lng == Lang.KU ? x.Name_Ku : lng == Lang.AR ? x.Name_Ar : x.Name,
                    City = lng == Lang.KU ? x.City.Name_Ku : lng == Lang.AR ? x.City.Name_Ar : x.City.Name,
                    Address = lng == Lang.KU ? x.Address_Ku : lng == Lang.AR ? x.Address_Ar : x.Address                    
                })
                .ToListAsync();

            return new DataTablesPagedResults<PharmacyListViewModel>
            {
                Items = items,
                TotalSize = size
            };
        }

        public async Task<(long totalCount, int totalPages, List<PharmacyItemDTO>)> GetPharmaciesListAsync(Lang lang, int page = 0, int pageSize = 12)
        {
            var query = _pharmacyRepository.Table;

            var totalCount = await query.LongCountAsync();

            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

            query = query.Skip(pageSize * page).Take(pageSize);

            var offers = await query.Select(x => new PharmacyItemDTO
            {
                Id = x.Id,
                Name = lang == Lang.KU ? x.Name_Ku : lang == Lang.AR ? x.Name_Ar : x.Name,
                Address = lang == Lang.KU ? x.Address_Ku : lang == Lang.AR ? x.Address_Ar : x.Address,
                City = lang == Lang.KU ? x.City.Name_Ku : lang == Lang.AR ? x.City.Name_Ar : x.City.Name,
                Avatar = x.Avatar
            }).ToListAsync();            

            return (totalCount, totalPages, offers);
        }

        public async Task<List<SelectListItem>> GetSelectListItemsAsync(Lang lang = Lang.KU, int? cityId = null)
        {
            var query = _pharmacyRepository.Table;

            if(cityId != null)
            {
                query = query.Where(x => x.CityId == cityId);
            }

            var result = await query.Select(x => new SelectListItem
            {
                Text = lang == Lang.KU ? x.Name_Ku : lang == Lang.AR ? x.Name_Ar : x.Name,
                Value = x.Id.ToString()
            }).ToListAsync();

            return result;
        }
    }
}
