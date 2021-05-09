using AN.BLL.Services.Upload;
using AN.Core.Domain;
using AN.Core.DTO;
using AN.Core.Enums;
using AN.Core.ViewModels;
using AN.DAL;
using Microsoft.EntityFrameworkCore;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AN.BLL.Services
{
    public class InsuranceServiceService : IInsuranceServiceService
    {
        private readonly IUploadService _uploadService;
        private readonly BanobatDbContext _dbContext;
        public InsuranceServiceService(IUploadService uploadService, BanobatDbContext dbContext)
        {
            _uploadService = uploadService;
            _dbContext = dbContext;
        }

        public async Task<List<InsuranceServiceItemDTO>> GetInsuranceServicesAsync(int insuranceId, Lang lng, string hostAddress)
        {
            IQueryable<InsuranceService> query = _dbContext.InsuranceServices;

            query = query.Where(x => x.InsuranceId == insuranceId);

            var result = await query.Select(x => new InsuranceServiceItemDTO { 
                Id = x.Id,
                Title = lng == Lang.AR ? x.Title_Ar : lng == Lang.KU ? x.Title_Ku : x.Title,
                Summary = lng == Lang.AR ? x.Summary_Ar : lng == Lang.KU ? x.Summary_Ku : x.Summary,
                Description = lng == Lang.AR ? x.Description_Ar : lng == Lang.KU ? x.Description_Ku : x.Description,
                HasAttachments = x.HasAttachments,
                Photo = x.FullPhotoUrl(hostAddress)
            }).ToListAsync();

            return result;
        }

        public async Task<DataTablesPagedResults<InsuranceServiceListItemViewModel>> GetDataTableAsync(DataTablesParameters table, InsuranceServiceFilterViewModel filters, Lang lng = Lang.KU)
        {
            IQueryable<InsuranceService> query = _dbContext.InsuranceServices;

            if(filters.InsuranceId != null)
            {
                query = query.Where(x => x.InsuranceId == filters.InsuranceId);
            }

            if (!string.IsNullOrEmpty(filters.FilterString))
            {
                query = query.Where(x => x.Title.Contains(filters.FilterString) || x.Title_Ku.Contains(filters.FilterString) || x.Title_Ar.Contains(filters.FilterString) ||
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
                .Select(x => new InsuranceServiceListItemViewModel
                {
                    Id = x.Id,
                    Title = lng == Lang.EN ? x.Title : lng == Lang.AR ? x.Title_Ar : x.Title_Ku,
                    Summary = lng == Lang.EN ? x.Summary : lng == Lang.AR ? x.Summary_Ar : x.Summary_Ku,
                    CreateDate = x.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss"),
                    Insurance = lng == Lang.EN ? x.Insurance.Name : lng == Lang.AR ? x.Insurance.Name_Ar : x.Insurance.Name_Ku,
                    PhotoUrl = x.RealPhoto
                })
                .ToListAsync();

            return new DataTablesPagedResults<InsuranceServiceListItemViewModel>
            {
                Items = items,
                TotalSize = size
            };
        }

        public async Task<InsuranceService> GetByIdAsync(int id)
        {
            var service = await _dbContext.InsuranceServices.FindAsync(id);

            return service;
        }      
        
        public async Task UpdateAsync(InsuranceService insuranceService)
        {
            _dbContext.InsuranceServices.Attach(insuranceService);

            _dbContext.Entry(insuranceService).State = EntityState.Modified;

            await _dbContext.SaveChangesAsync();
        }

        public async Task InsertAsync(InsuranceService insuranceService)
        {
            await _dbContext.InsuranceServices.AddAsync(insuranceService);

            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(InsuranceService insuranceService)
        {
            _dbContext.InsuranceServices.Remove(insuranceService);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<int> CreateUpdateInsuranceServiceAsync(InsuranceServiceCRUDViewModel model)
        {
            var strategy = _dbContext.Database.CreateExecutionStrategy();

            await strategy.ExecuteAsync(async () =>
            {
                using (var transaction = _dbContext.Database.BeginTransaction())
                {
                    if (model.Id != null)
                    {
                        var service = await GetByIdAsync(model.Id.Value);

                        if (service == null) throw new Exception("Insurance Service Not Found");

                        service.Title = model.Title;
                        service.Title_Ar = model.Title_Ar;
                        service.Title_Ku = model.Title_Ku;
                        service.Summary = model.Summary;
                        service.Summary_Ar = model.Summary_Ar;
                        service.Summary_Ku = model.Summary_Ku;
                        service.Description = model.Description;
                        service.Description_Ar = model.Description_Ar;
                        service.Description_Ku = model.Description_Ku;
                        service.InsuranceId = model.InsuranceId;
                        service.UpdatedAt = DateTime.Now;

                        await UpdateAsync(service);

                        if (model.Photo != null)
                        {
                            var (newName, thumbName, dirPath, baseUrl) = _uploadService.GenerateInsuranceServicePhotoName(service.Id, model.Photo);

                            service.Photo = $"{baseUrl}/{newName}";

                            await UpdateAsync(service);

                            await _uploadService.UploadInsuranceServicePhotoAsync(model.Photo, dirPath, newName, thumbName);
                        }
                    }
                    else
                    {
                        var insuranceService = new InsuranceService
                        {
                            Title = model.Title,
                            Title_Ar = model.Title_Ar,
                            Title_Ku = model.Title_Ku,
                            Summary = model.Summary,
                            Summary_Ar = model.Summary_Ar,
                            Summary_Ku = model.Summary_Ku,
                            Description = model.Description,
                            Description_Ar = model.Description_Ar,
                            Description_Ku = model.Description_Ku,
                            HasAttachments = false,
                            InsuranceId = model.InsuranceId,                            
                            CreatedAt = DateTime.Now,
                        };

                        await InsertAsync(insuranceService);

                        if (model.Photo != null)
                        {
                            var (newName, thumbName, dirPath, baseUrl) = _uploadService.GenerateInsuranceServicePhotoName(insuranceService.Id, model.Photo);

                            insuranceService.Photo = $"{baseUrl}/{newName}";

                            await UpdateAsync(insuranceService);

                            await _uploadService.UploadInsuranceServicePhotoAsync(model.Photo, dirPath, newName, thumbName);
                        }

                        model.Id = insuranceService.Id;
                    }

                    transaction.Commit();
                }
            });

            return model.Id.Value;
        }

        public async Task DeleteInsuranceServiceAsync(int id)
        {
            var strategy = _dbContext.Database.CreateExecutionStrategy();

            await strategy.ExecuteAsync(async () =>
            {
                using (var transaction = _dbContext.Database.BeginTransaction())
                {
                    var insurance = await GetByIdAsync(id);

                    if (insurance != null)
                    {
                        await DeleteAsync(insurance);

                        _uploadService.RemoveInsuranceServicePhoto(id);
                    }

                    transaction.Commit();
                }
            });
        }
    }
}
