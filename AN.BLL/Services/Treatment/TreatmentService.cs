using AN.BLL.Services.Upload;
using AN.Core.Domain;
using AN.Core.DTO.Treatment;
using AN.Core.Enums;
using AN.Core.Exceptions;
using AN.Core.Resources.New;
using AN.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AN.BLL.Services.Treatment
{
    public class TreatmentService : ITreatmentService
    {
        private readonly IUploadService _uploadService;
        private readonly BanobatDbContext _dbContext;
        public TreatmentService(IUploadService uploadService, BanobatDbContext dbContext)
        {
            _uploadService = uploadService;
            _dbContext = dbContext;
        }


        public async Task<(long totalCount, int totalPages, List<TreatmentDTO>)> GetTreatmentsListPagingAsync(string mobile, Lang lang, int page = 0, int pageSize = 12)
        {
            var query = _dbContext.TreatmentHistories.Where(x => x.Patient.Person.Mobile == mobile);

            var totalCount = await query.LongCountAsync();

            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

            query = query.OrderByDescending(x => x.VisitDate).Skip(pageSize * page).Take(pageSize);

            var treatments = query.AsEnumerable().Select(x => new TreatmentDTO
            {
                Id = x.Id,
                UserId = x.Patient.PersonId,
                Fullname = lang == Lang.KU ? x.Patient.Person.FullName_Ku : lang == Lang.AR ? x.Patient.Person.FullName_Ar : x.Patient.Person.FullName,
                ServiceSupplyId = x.Patient.ServiceSupplyId.Value,
                DoctorName = lang == Lang.KU ? x.Patient.ServiceSupply.Person.FullName_Ku : lang == Lang.AR ? x.Patient.ServiceSupply.Person.FullName_Ar : x.Patient.ServiceSupply.Person.FullName,
                VisitDate = x.VisitDate.ToShortDateString()
            }).ToList();

            return (totalCount, totalPages, treatments);
        }

        public async Task<TreatmentDetailsDTO> GetTreatmentDetailsAsync(string mobile, int id, Lang lang)
        {
            var treatment = await _dbContext.TreatmentHistories.FindAsync(id);

            if (treatment == null) throw new AwroNoreException(NewResource.TreatmentNotFound);

            if (treatment.Patient.Person.Mobile != mobile) throw new AwroNoreException(NewResource.UserCannotAccessTreatment);

            var attachments = await _dbContext.Attachments.Where(x => x.Owner == FileOwner.TREATMENT_HISTORY && x.OwnerTableId == treatment.Id).Select(x => new TreatmentAttachDTO
            {
                CreatedAt = x.CreatedAt.ToShortDateString(),
                Description = x.Description,
                FileType = x.FileType,
                Id = x.Id,
                ThumbnailUrl = x.ThumbnailUrl,
                Url = x.Url
            }).ToListAsync();

            var details = new TreatmentDetailsDTO
            {
                Id = treatment.Id,
                VisitDate = treatment.VisitDate.ToShortDateString(),
                Problems = lang == Lang.AR ? treatment.Problems_Ar : lang == Lang.KU ? treatment.Problems_Ku : treatment.Problems,
                Treatments = lang == Lang.AR ? treatment.Treatments_Ar : lang == Lang.KU ? treatment.Treatments_Ku : treatment.Treatments,
                Description = lang == Lang.AR ? treatment.Description_Ar : lang == Lang.KU ? treatment.Description_Ku : treatment.Description,
                DoctorName = lang == Lang.AR ? treatment.Patient.ServiceSupply.Person.FullName_Ar : lang == Lang.KU ? treatment.Patient.ServiceSupply.Person.FullName_Ku : treatment.Patient.ServiceSupply.Person.FullName,
                Fullname = lang == Lang.AR ? treatment.Patient.Person.FullName_Ar : lang == Lang.KU ? treatment.Patient.Person.FullName_Ku : treatment.Patient.Person.FullName,                
                ServiceSupplyId = treatment.Patient.ServiceSupplyId.Value,
                UserId = treatment.Patient.PersonId,
                TreatmentAttaches = attachments,
                TreatmentItems = treatment.TreatmentsItems.Select(x => new TreatmentItemDTO
                {
                    Id = x.Id,
                    DateStarted = x.DateStarted,
                    Description = lang == Lang.AR ? treatment.Description_Ar : treatment.Description_Ku,
                    Dosage = x.Dosage,
                    DrugName = x.DrugId != null ? (lang == Lang.AR ? x.Drug.GenericName_Ar : x.Drug.GenericName_Ku) : lang == Lang.AR ? x.CustomDrugName_Ar : x.CustomDrugName_Ku,
                    Frequency = x.Frequency,
                    Quantity = x.Quantity
                }).ToList()
            };

            return details;
        }

        public async Task<List<TreatmentAttachDTO>> SetNewAttachmentsAsync(List<IFormFile> files, int treatmentId, string username)
        {
            var person = await _dbContext.Persons.FirstOrDefaultAsync(x => x.Mobile == username);

            if (person == null) throw new AwroNoreException(NewResource.UserNotFound);

            var treatment = await _dbContext.TreatmentHistories.FindAsync(treatmentId);

            if (treatment == null) throw new AwroNoreException(NewResource.TreatmentNotFound);

            if (treatment.Patient.Person.Mobile != username) throw new AwroNoreException(NewResource.UserCannotAccessTreatment);

            var mainDirectoryPath = _uploadService.GetTreatmentAttachDirectoryPath(person.Id, treatment.Id);

            #region Process Photos & Generate New Names
            var photosDictionary = new Dictionary<IFormFile, (string newName, string thumbName, string dirPath, string baseUrl)>();
            var newPhotos = new List<Attachment>();
            if (files != null && files.Any())
            {
                foreach (var photo in files)
                {
                    var (newName, thumbName, dirPath, baseUrl) = _uploadService.GenerateTreatmentAttachFileName(person.Id, treatment.Id, photo);

                    photosDictionary.Add(photo, (newName, thumbName, dirPath, baseUrl));

                    newPhotos.Add(new Attachment
                    {
                        Name = newName,
                        CreatedAt = DateTime.Now,
                        DeleteUrl = $"{baseUrl}/{newName}",
                        Url = $"{baseUrl}/{newName}",
                        Order = 1,
                        ThumbnailUrl = $"{baseUrl}/{thumbName}",
                        Size = (int)photo.Length,
                        FileType = FileType.Image,
                        Owner = FileOwner.TREATMENT_HISTORY,
                        OwnerTableId = treatment.Id
                    });
                }
            }
            #endregion

            var result = new List<TreatmentAttachDTO>();
            var strategy = _dbContext.Database.CreateExecutionStrategy();
            await strategy.ExecuteAsync(async () =>
            {
                using (var transaction = _dbContext.Database.BeginTransaction())
                {
                    if (newPhotos.Any())
                    {
                        await _dbContext.Attachments.AddRangeAsync(newPhotos);

                        await _dbContext.SaveChangesAsync();

                        result = newPhotos.Select(x => new TreatmentAttachDTO
                        {
                            CreatedAt = x.CreatedAt.ToShortDateString(),
                            Description = x.Description,
                            FileType = x.FileType,
                            Id = x.Id,
                            ThumbnailUrl = x.ThumbnailUrl,
                            Url = x.Url
                        }).ToList();

                        foreach (var photo in photosDictionary)
                        {
                            await _uploadService.UploadTreatmentAttachmentAsync(photo.Key, photo.Value.dirPath, photo.Value.newName, photo.Value.thumbName);                           
                        }
                    }
                    transaction.Commit();
                }
            });

            return result;
        }

        public async Task RemoveTreatmentAttachmentAsync(int treatmentId, int attachId, string userName)
        {
            var person = await _dbContext.Persons.FirstOrDefaultAsync(x => x.Mobile == userName);

            if (person == null) throw new AwroNoreException(NewResource.UserNotFound);

            var treatment = await _dbContext.TreatmentHistories.FindAsync(treatmentId);

            if (treatment == null) throw new AwroNoreException(NewResource.TreatmentNotFound);

            var attachment = await _dbContext.Attachments.FirstOrDefaultAsync(x => x.Owner == FileOwner.TREATMENT_HISTORY && x.OwnerTableId == treatment.Id);

            if(attachment != null)
            {
                var strategy = _dbContext.Database.CreateExecutionStrategy();
                await strategy.ExecuteAsync(async() =>
                {
                    using (var transaction = _dbContext.Database.BeginTransaction())
                    {
                        var dirPath = _uploadService.GetTreatmentAttachDirectoryPath(person.Id, treatment.Id);

                        var path = $"{dirPath}\\{attachment.Name}";

                        var thumbPath = $"{dirPath}\\{Path.GetFileName(attachment.ThumbnailUrl)}";

                        _dbContext.Attachments.Remove(attachment);

                        await _dbContext.SaveChangesAsync();

                        _uploadService.RemoveTreatmentAttachment(path, thumbPath);

                        transaction.Commit();
                    }
                });
            }
        }
    }
}
