using AN.BLL.Services.Upload;
using AN.Core.Domain;
using AN.Core.DTO;
using AN.Core.Exceptions;
using AN.Core.ViewModels;
using AN.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AN.BLL.Services.MedicalRequest
{
    public class MedicalRequestService : IMedicalRequestService
    {
        private readonly BanobatDbContext _dbContext;
        private readonly IUploadService _uploadService;
        public MedicalRequestService(BanobatDbContext dbContext, IUploadService uploadService)
        {
            _dbContext = dbContext;
            _uploadService = uploadService;
        }

        public async Task CreateNewMedicalRequestAsync(string currentUsername, MedicalRequestDTO model)
        {
            var person = await _dbContext.Persons.FirstOrDefaultAsync(x => x.Mobile == currentUsername);

            if (person == null) throw new AwroNoreException("Not any person found for this mobile number");

            var strategy = _dbContext.Database.CreateExecutionStrategy();

            await strategy.ExecuteAsync(async () =>
            {
                using (var transaction = _dbContext.Database.BeginTransaction())
                {
                    var request = new AN.Core.Domain.MedicalRequest
                    {
                        Date = model.Date,
                        Note = model.Note,
                        RequestedCountryId = model.CountryId,
                        RequesterPersonId = person.Id,
                        CreatedAt = DateTime.Now
                    };

                    await _dbContext.MedicalRequests.AddAsync(request);

                    await _dbContext.SaveChangesAsync();

                    // Proccess Files
                    if (model.Files.Any())
                    {
                        // Files base url
                        var basePhotosUrl = _uploadService.GenerateMedicalRequestFilesBaseUrl(request.Id, request.CreatedAt);

                        var photosDictionary = new Dictionary<IFormFile, (string newFileName, string thumbName)>();

                        // Process Files Logical Names                      
                        foreach (var file in model.Files)
                        {
                            var (newFileName, thumbFileName) = _uploadService.GenerateMedicalRequestFileName(request.Id, file);

                            photosDictionary.Add(file, (newFileName, thumbFileName));

                            await _dbContext.Attachments.AddAsync(new Attachment
                            {
                                Name = newFileName,
                                Url = $"{basePhotosUrl}/{newFileName}",
                                ThumbnailUrl = $"{basePhotosUrl}/{thumbFileName}",
                                DeleteUrl = "DeleteUrl",
                                Size = (int)file.Length,
                                Order = model.Files.IndexOf(file),
                                CreatedAt = DateTime.Now,
                                Owner = AN.Core.Enums.FileOwner.MEDICAL_REQUEST,
                                OwnerTableId = request.Id,
                                FileType = AN.Core.Enums.FileType.Image,
                                Description = ""
                            });
                        }

                        await _dbContext.SaveChangesAsync();

                        await _uploadService.UploadMedicalRequestFilesAsync(request.Id, request.CreatedAt, photosDictionary);
                    }

                    transaction.Commit();
                }
            });
        }

        public async Task<DataTablesPagedResults<MedicalRequestListViewModel>> GetPagingListDataAsync(DataTablesParameters table)
        {
            IQueryable<AN.Core.Domain.MedicalRequest> query = _dbContext.MedicalRequests;

            if (table.Order != null && table.Order.Any())
            {
                var orderIndex = table.Order[0].Column;

                var orderDir = table.Order[0].Dir;

                if (orderIndex == 1 || orderIndex == 2)
                {
                    query = orderDir == DataTablesOrderDir.DESC ? query.OrderByDescending(x => x.CreatedAt) : query = query.OrderBy(x => x.CreatedAt);
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
                .Select(x => new MedicalRequestListViewModel
                {
                    Id = x.Id,
                    RequestDate = x.Date.ToString("yyyy/MM/dd HH:mm:ss"),
                    CountryName = x.RequestedCountry.Name,
                    PersonName = x.RequesterPerson.FullName,
                    PersonPhone = x.RequesterPerson.Mobile,
                    AttachmentsCount = _dbContext.Attachments.Count(a => a.Owner == AN.Core.Enums.FileOwner.MEDICAL_REQUEST && a.OwnerTableId == x.Id),
                })
                .ToListAsync();

            return new DataTablesPagedResults<MedicalRequestListViewModel>
            {
                Items = items,
                TotalSize = size
            };
        }

        public async Task<MedicalRequestDetailsViewModel> GetMedicalRequestDetailsAsync(int id)
        {
            var request = await _dbContext.MedicalRequests.FindAsync(id);

            if (request == null) throw new AwroNoreException("Request not found");

            var files = await _dbContext.Attachments.Where(x => x.Owner == AN.Core.Enums.FileOwner.MEDICAL_REQUEST && x.OwnerTableId == request.Id).ToListAsync();

            var result = new MedicalRequestDetailsViewModel
            {
                Id = request.Id,
                PersonName = request.RequesterPerson.FullName,
                CountryName = request.RequestedCountry.Name,
                Note = request.Note,
                PersonPhone = request.RequesterPerson.Mobile,
                RequestDate = request.Date.ToString("yyyy-MM-dd HH:mm:ss"),
                Attachments = files.Select(f => f.Url).ToList()
            };

            return result;
        }
    }
}
