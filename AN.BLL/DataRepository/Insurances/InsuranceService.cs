using AN.BLL.Services.Upload;
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

namespace AN.BLL.DataRepository.Insurances
{
    public class InsuranceService : IInsuranceService
    {
        private readonly IRepository<Insurance> _insuranceRepository;
        private readonly IUploadService _uploadService;
        public InsuranceService(IRepository<Insurance> insuranceRepository, IUploadService uploadService)
        {
            _insuranceRepository = insuranceRepository;
            _uploadService = uploadService;
        }

        public async Task<List<InsuranceItemDTO>> GetInsurancesAsync(Lang lng, string hostAddress, int? cityId = null)
        {
            IQueryable<Insurance> query = _insuranceRepository.Table;

            if(cityId != null)
            {
                query = query.Where(x => x.CityBranches.Any(c => c.CityId == cityId));
            }

            var result = await query.Select(x => new InsuranceItemDTO { 
                Id = x.Id,
                Name = lng == Lang.AR ? x.Name_Ar : lng == Lang.KU ? x.Name_Ku : x.Name,
                Logo = x.FullLogoUrl(hostAddress)
            }).ToListAsync();

            return result;
        }

        public async Task<DataTablesPagedResults<InsuranceListItemViewModel>> GetDataTableAsync(DataTablesParameters table, InsuranceFilterViewModel filters, Lang lng = Lang.KU)
        {
            IQueryable<Insurance> query = _insuranceRepository.Table;

            if (!string.IsNullOrEmpty(filters.FilterString))
            {
                query = query.Where(x => x.Name.Contains(filters.FilterString) || x.Name_Ku.Contains(filters.FilterString) || x.Name_Ar.Contains(filters.FilterString) ||
                                         x.Description.Contains(filters.FilterString) || x.Description_Ku.Contains(filters.FilterString) || x.Description_Ar.Contains(filters.FilterString));
            }

            if (table.Order != null && table.Order.Any())
            {
                var orderIndex = table.Order[0].Column;
                var orderDir = table.Order[0].Dir;
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
                .Select(x => new InsuranceListItemViewModel
                {
                    Id = x.Id,
                    Name = lng == Lang.EN ? x.Name : lng == Lang.AR ? x.Name_Ar : x.Name_Ku,
                    CreatedAt = x.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss"),
                    Logo = x.RealLogo
                })
                .ToListAsync();

            return new DataTablesPagedResults<InsuranceListItemViewModel>
            {
                Items = items,
                TotalSize = size
            };
        }

        public async Task<Insurance> GetByIdAsync(int id)
        {
            var insurance = await _insuranceRepository.GetByIdAsync(id);

            return insurance;
        }

        public async Task<List<Insurance>> GetAllInsurancesAsync()
        {
            var query = await _insuranceRepository.Table.ToListAsync();

            return query;
        }

        public async Task<List<SelectListItem>> GetSelectListItemsAsync(Lang lang)
        {
            var result = await _insuranceRepository.Table.Select(x => new SelectListItem
            {
                Text = lang == Lang.EN ? x.Name : lang == Lang.AR ? x.Name_Ar : x.Name_Ku,
                Value = x.Id.ToString()
            }).ToListAsync();

            return result;
        }

        public async Task<int> CreateUpdateInsuranceAsync(InsuranceCRUDViewModel model)
        {
            var strategy = _insuranceRepository.Database.CreateExecutionStrategy();

            await strategy.ExecuteAsync(async () =>
            {
                using (var transaction = _insuranceRepository.Database.BeginTransaction())
                {
                    if (model.Id != null)
                    {
                        var insurance = await _insuranceRepository.GetByIdAsync(model.Id.Value);

                        if (insurance == null) throw new Exception("Insurance Not Found");

                        insurance.Name = model.Name;
                        insurance.Name_Ar = model.Name_Ar;
                        insurance.Name_Ku = model.Name_Ku;
                        insurance.Description = model.Description;
                        insurance.Description_Ar = model.Description_Ar;
                        insurance.Description_Ku = model.Description_Ku;

                        _insuranceRepository.Update(insurance);

                        if (model.Image != null)
                        {
                            var (newName, thumbName, dirPath, baseUrl) = _uploadService.GenerateInsuranceLogoName(insurance.Id, model.Image);

                            insurance.Logo = $"{baseUrl}/{newName}";

                            _insuranceRepository.Update(insurance);

                            await _uploadService.UploadInsuranceLogoAsync(model.Image, dirPath, newName, thumbName);
                        }
                    }
                    else
                    {
                        var insurance = new Insurance
                        {
                            Name = model.Name,
                            Name_Ar = model.Name_Ar,
                            Name_Ku = model.Name_Ku,
                            Description = model.Description,
                            Description_Ar = model.Description_Ar,
                            Description_Ku = model.Description_Ku,
                            CreatedAt = DateTime.Now,
                        };

                        await _insuranceRepository.InsertAsync(insurance);

                        if (model.Image != null)
                        {
                            var (newName, thumbName, dirPath, baseUrl) = _uploadService.GenerateInsuranceLogoName(insurance.Id, model.Image);

                            insurance.Logo = $"{baseUrl}/{newName}";

                            _insuranceRepository.Update(insurance);

                            await _uploadService.UploadInsuranceLogoAsync(model.Image, dirPath, newName, thumbName);
                        }

                        model.Id = insurance.Id;
                    }

                    transaction.Commit();
                }
            });

            return model.Id.Value;
        }

        public async Task DeleteInsuranceAsync(int id)
        {
            var strategy = _insuranceRepository.Database.CreateExecutionStrategy();

            await strategy.ExecuteAsync(async () =>
            {
                using (var transaction = _insuranceRepository.Database.BeginTransaction())
                {
                    var insurance = await _insuranceRepository.GetByIdAsync(id);

                    if (insurance != null)
                    {
                        await _insuranceRepository.DeleteAsync(insurance);

                        _uploadService.RemoveInsuranceLogo(id);
                    }

                    transaction.Commit();
                }
            });
        }
    }
}
