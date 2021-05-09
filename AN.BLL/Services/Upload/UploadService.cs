using AN.Core.Exceptions;
using AN.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AN.BLL.Services.Upload
{
    public class UploadService : IUploadService
    {
        private readonly BanobatDbContext _dbContext;
        public UploadService(BanobatDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region Consultancy Voice Message
        public (string newName, string dirPath, string baseUrl) GenerateConsultancyMessageVoiceName(int chatId, int messageId, IFormFile voice)
        {
            var originFileName = voice.FileName;
            var ext = Path.GetExtension(originFileName);
            var time = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss-fffff");
            var newFileName = $"msg_{time}{ext}";
            var dirPath = $"uploaded\\consultancy\\{chatId}\\{messageId}";
            var baseUrl = $"/{dirPath.Replace("\\", "/")}";

            return (newFileName,  dirPath, baseUrl);
        }

        public async Task UploadConsultancyMessageVoiceAsync(IFormFile voice, string dirPath, string newName)
        {
            var fullDirectoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", dirPath);

            if (Directory.Exists(fullDirectoryPath))
            {
                // Delete Previews Images If Any Exists
                if (Directory.GetFiles(fullDirectoryPath, "*.*", SearchOption.AllDirectories).Any())
                {
                    foreach (var file in Directory.GetFiles(fullDirectoryPath, "*.*", SearchOption.AllDirectories))
                    {
                        if (File.Exists(file))
                        {
                            File.Delete(file);
                        }
                    }
                }
            }
            else
            {
                Directory.CreateDirectory(fullDirectoryPath);
            }

            var path = Path.Combine(fullDirectoryPath, newName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await voice.CopyToAsync(stream);
            }
        }
        #endregion

        #region Consultancy Image Message
        public (string newName, string thumbName, string dirPath, string baseUrl) GenerateConsultancyMessageImageName(int chatId, int messageId, IFormFile photo)
        {
            var originFileName = photo.FileName;
            var ext = Path.GetExtension(originFileName);
            var time = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss-fffff");
            var newFileName = $"msg_{time}{ext}";
            var thumbFileName = $"msg_{time}.thumb{ext}";
            var dirPath = $"uploaded\\consultancy\\{chatId}\\{messageId}";
            var baseUrl = $"/{dirPath.Replace("\\", "/")}";

            return (newFileName, thumbFileName, dirPath, baseUrl);
        }

        public async Task UploadConsultancyMessageImageAsync(IFormFile photo, string dirPath, string newName, string thumbName)
        {
            var fullDirectoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", dirPath);

            if (Directory.Exists(fullDirectoryPath))
            {
                // Delete Previews Images If Any Exists
                if (Directory.GetFiles(fullDirectoryPath, "*.*", SearchOption.AllDirectories).Any())
                {
                    foreach (var file in Directory.GetFiles(fullDirectoryPath, "*.*", SearchOption.AllDirectories))
                    {
                        if (File.Exists(file))
                        {
                            File.Delete(file);
                        }
                    }
                }
            }
            else
            {
                Directory.CreateDirectory(fullDirectoryPath);
            }

            var path = Path.Combine(fullDirectoryPath, newName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await photo.CopyToAsync(stream);
            }

            var thumbPath = Path.Combine(fullDirectoryPath, thumbName);
            using (var image = Image.FromFile(path))
            {
                Image thumb = image.GetThumbnailImage(120, 120, () => false, IntPtr.Zero);
                thumb.Save(thumbPath);
            }
        }
        #endregion

        #region Person Avatar
        public (string newName, string thumbName, string dirPath, string baseUrl) GeneratePersonAvatarName(int personId, IFormFile photo)
        {
            var originFileName = photo.FileName;
            var ext = Path.GetExtension(originFileName);
            var time = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss-fffff");
            var newFileName = $"avatar_{time}{ext}";
            var thumbFileName = $"avatar_{time}.thumb{ext}";
            var dirPath = $"uploaded\\avatars\\{personId}";
            var baseUrl = $"/{dirPath.Replace("\\", "/")}";

            return (newFileName, thumbFileName, dirPath, baseUrl);
        }

        public async Task UploadPersonAvatarAsync(IFormFile photo, string dirPath, string newName, string thumbName)
        {
            var fullDirectoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", dirPath);

            if (Directory.Exists(fullDirectoryPath))
            {
                // Delete Previews Images If Any Exists
                if (Directory.GetFiles(fullDirectoryPath, "*.*", SearchOption.AllDirectories).Any())
                {
                    foreach (var file in Directory.GetFiles(fullDirectoryPath, "*.*", SearchOption.AllDirectories))
                    {
                        if (File.Exists(file))
                        {
                            File.Delete(file);
                        }
                    }
                }
            }
            else
            {
                Directory.CreateDirectory(fullDirectoryPath);
            }

            var path = Path.Combine(fullDirectoryPath, newName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await photo.CopyToAsync(stream);
            }

            var thumbPath = Path.Combine(fullDirectoryPath, thumbName);
            using (var image = Image.FromFile(path))
            {
                Image thumb = image.GetThumbnailImage(120, 120, () => false, IntPtr.Zero);
                thumb.Save(thumbPath);
            }
        }

        public void RemovePersonAvatar(int personId)
        {
            var dirPath = $"uploaded\\avatars\\{personId}";

            var fullDirectoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", dirPath);

            if (Directory.Exists(fullDirectoryPath))
            {
                // Delete Previews Images If Any Exists
                if (Directory.GetFiles(fullDirectoryPath, "*.*", SearchOption.AllDirectories).Any())
                {
                    foreach (var file in Directory.GetFiles(fullDirectoryPath, "*.*", SearchOption.AllDirectories))
                    {
                        if (File.Exists(file))
                        {
                            File.Delete(file);
                        }
                    }
                }
            }
        }
        #endregion

        #region ShiftCenter Gallery
        public async Task<AN.Core.Domain.Attachment> UploadShiftCenterGalleryImageAsync(int shiftCenterId, IFormFile photo)
        {
            var shiftCenter = await _dbContext.ShiftCenters.FindAsync(shiftCenterId);

            if (shiftCenter == null) throw new AwroNoreException("Shift Center Not Found");

            AN.Core.Domain.Attachment attachment = null;

            var strategy = _dbContext.Database.CreateExecutionStrategy();

            await strategy.ExecuteAsync(async () =>
            {
                using (var transaction = _dbContext.Database.BeginTransaction())
                {
                    var originFileName = photo.FileName;
                    var ext = Path.GetExtension(originFileName);
                    var time = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss-fffff");
                    var newFileName = $"gallery_{time}{ext}";
                    var thumbFileName = $"gallery_{time}.thumb{ext}";
                    var physicalDirPath = $"uploaded\\gallery\\shiftcenters\\{shiftCenterId}";
                    var baseUrl = $"/{physicalDirPath.Replace("\\", "/")}";

                    attachment = new AN.Core.Domain.Attachment
                    {
                        Owner = AN.Core.Enums.FileOwner.SHIFT_CENTER,
                        OwnerTableId = shiftCenterId,
                        CreatedAt = DateTime.Now,
                        FileType = AN.Core.Enums.FileType.Image,
                        IsDeleted = false,
                        Url = $"{baseUrl}/{newFileName}",
                        ThumbnailUrl = $"{baseUrl}/{thumbFileName}",
                        DeleteUrl = $"{baseUrl}/{newFileName}",
                        Name = newFileName,
                        Size = photo.Length,
                        Description = "Gallery Image",
                        Order = 0
                    };

                    await _dbContext.Attachments.AddAsync(attachment);

                    await _dbContext.SaveChangesAsync();

                    var fullDirectoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", physicalDirPath);

                    if (!Directory.Exists(fullDirectoryPath))
                    {
                        Directory.CreateDirectory(fullDirectoryPath);
                    }

                    var path = Path.Combine(fullDirectoryPath, newFileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await photo.CopyToAsync(stream);
                    }

                    var thumbPath = Path.Combine(fullDirectoryPath, thumbFileName);
                    using (var image = Image.FromFile(path))
                    {
                        Image thumb = image.GetThumbnailImage(120, 120, () => false, IntPtr.Zero);
                        thumb.Save(thumbPath);
                    }

                    transaction.Commit();
                }
            });

            return attachment;
        }

        public async Task<string> UploadShiftCenterLogoAsync(int shiftCenterId, IFormFile photo)
        {
            var shiftCenter = await _dbContext.ShiftCenters.FindAsync(shiftCenterId);

            if (shiftCenter == null) throw new AwroNoreException("Shift Center Not Found");

            string logoUrl = string.Empty;

            var strategy = _dbContext.Database.CreateExecutionStrategy();

            await strategy.ExecuteAsync(async () =>
            {
                using (var transaction = _dbContext.Database.BeginTransaction())
                {
                    var originFileName = photo.FileName;
                    var ext = Path.GetExtension(originFileName);
                    var time = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss-fffff");
                    var newFileName = $"logo_{time}{ext}";
                    var physicalDirPath = $"uploaded\\logos\\shiftcenters\\{shiftCenterId}";
                    var baseUrl = $"/{physicalDirPath.Replace("\\", "/")}";

                    logoUrl = $"{baseUrl}/{newFileName}";

                    shiftCenter.Logo = logoUrl;

                    _dbContext.ShiftCenters.Attach(shiftCenter);

                    _dbContext.Entry(shiftCenter).State = EntityState.Modified;

                    await _dbContext.SaveChangesAsync();                   

                    var fullDirectoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", physicalDirPath);

                    if (!Directory.Exists(fullDirectoryPath))
                    {
                        Directory.CreateDirectory(fullDirectoryPath);
                    }

                    var path = Path.Combine(fullDirectoryPath, newFileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await photo.CopyToAsync(stream);
                    }                   

                    transaction.Commit();
                }
            });

            return logoUrl;
        }
        #endregion

        #region Treatment Attachment
        public string GetTreatmentAttachDirectoryPath(int personId, int treatmentId)
        {
            return $"uploaded\\attachments\\treatments\\{personId}\\{treatmentId}";
        }

        public (string newName, string thumbName, string dirPath, string baseUrl) GenerateTreatmentAttachFileName(int personId, int treatmentId, IFormFile photo)
        {
            var originFileName = photo.FileName;
            var ext = Path.GetExtension(originFileName);
            var time = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss-fffff");
            var newFileName = $"attach_{time}{ext}";
            var thumbFileName = $"attach_{time}.thumb{ext}";
            var dirPath = GetTreatmentAttachDirectoryPath(personId, treatmentId);
            var baseUrl = $"/{dirPath.Replace("\\", "/")}";
            return (newFileName, thumbFileName, dirPath, baseUrl);
        }

        public async Task UploadTreatmentAttachmentAsync(IFormFile photo, string dirPath, string newName, string thumbName)
        {
            var fullDirectoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", dirPath);

            if (!Directory.Exists(fullDirectoryPath))
            {
                Directory.CreateDirectory(fullDirectoryPath);
            }

            var path = Path.Combine(fullDirectoryPath, newName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await photo.CopyToAsync(stream);
            }

            var thumbPath = Path.Combine(fullDirectoryPath, thumbName);
            using (var image = Image.FromFile(path))
            {
                Image thumb = image.GetThumbnailImage(120, 120, () => false, IntPtr.Zero);
                thumb.Save(thumbPath);
            }
        }

        public void RemoveTreatmentAttachment(string path, string thumbPath)
        {
            var fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", path);

            var fullThumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", thumbPath);

            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }

            if (File.Exists(fullThumbPath))
            {
                File.Delete(fullThumbPath);
            }
        }
        #endregion

        #region Patient Attachments
        public string GetPatientAttachDirectoryPath(int patientId)
        {
            return $"uploaded\\attachments\\patients\\{patientId}";
        }

        public (string newName, string thumbName, string dirPath, string baseUrl) GeneratePatientAttachFileName(int patientId, IFormFile file)
        {
            var originFileName = file.FileName;
            var ext = Path.GetExtension(originFileName);          
            var time = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss-fffff");
            var newFileName = $"attach_{time}{ext}";           
            var thumbFileName = $"attach_{time}.thumb{ext}";
            var dirPath = GetPatientAttachDirectoryPath(patientId);
            var baseUrl = $"/{dirPath.Replace("\\", "/")}";
            return (newFileName, thumbFileName, dirPath, baseUrl);
        }

        public async Task<AN.Core.Domain.Attachment> UploadPatientAttachmentAsync(int patientId, IFormFile file)
        {
            var patient = await _dbContext.Patients.FindAsync(patientId);

            if (patient == null) throw new AwroNoreException("Patient Not Found");

            AN.Core.Domain.Attachment attachment = null;

            var strategy = _dbContext.Database.CreateExecutionStrategy();

            await strategy.ExecuteAsync(async () =>
            {
                using (var transaction = _dbContext.Database.BeginTransaction())
                {
                    var (newName, thumbName, dirPath, baseUrl) = GeneratePatientAttachFileName(patientId, file);                   

                    attachment = new AN.Core.Domain.Attachment
                    {
                        Owner = AN.Core.Enums.FileOwner.PATIENT,
                        OwnerTableId = patientId,
                        CreatedAt = DateTime.Now,
                        FileType = AN.Core.Enums.FileType.Image,
                        IsDeleted = false,
                        Url = $"{baseUrl}/{newName}",
                        ThumbnailUrl = $"{baseUrl}/{thumbName}",
                        DeleteUrl = $"{baseUrl}/{newName}",
                        Name = newName,
                        Size = file.Length,
                        Description = "Patient Attachment",
                        Order = 0
                    };

                    await _dbContext.Attachments.AddAsync(attachment);

                    await _dbContext.SaveChangesAsync();

                    var fullDirectoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", dirPath);

                    if (!Directory.Exists(fullDirectoryPath))
                    {
                        Directory.CreateDirectory(fullDirectoryPath);
                    }

                    var path = Path.Combine(fullDirectoryPath, newName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    var thumbPath = Path.Combine(fullDirectoryPath, thumbName);
                    using (var image = Image.FromFile(path))
                    {
                        Image thumb = image.GetThumbnailImage(120, 120, () => false, IntPtr.Zero);
                        thumb.Save(thumbPath);
                    }

                    transaction.Commit();
                }
            });

            return attachment;
        }
        #endregion

        #region Notification Image
        public (string newName, string thumbName, string dirPath, string baseUrl) GenerateNotificationImageName(int notificationId, IFormFile photo)
        {
            var originFileName = photo.FileName;
            var ext = Path.GetExtension(originFileName);
            var time = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss-fffff");
            var newFileName = $"noti_{time}{ext}";
            var thumbFileName = $"noti_{time}.thumb{ext}";
            var dirPath = $"uploaded\\notifications\\{notificationId}";
            var baseUrl = $"/{dirPath.Replace("\\", "/")}";

            return (newFileName, thumbFileName, dirPath, baseUrl);
        }

        public async Task UploadNotificationImageAsync(IFormFile photo, string dirPath, string newName, string thumbName)
        {
            var fullDirectoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", dirPath);

            if (Directory.Exists(fullDirectoryPath))
            {
                // Delete Previews Images If Any Exists
                if (Directory.GetFiles(fullDirectoryPath, "*.*", SearchOption.AllDirectories).Any())
                {
                    foreach (var file in Directory.GetFiles(fullDirectoryPath, "*.*", SearchOption.AllDirectories))
                    {
                        if (File.Exists(file))
                        {
                            File.Delete(file);
                        }
                    }
                }
            }
            else
            {
                Directory.CreateDirectory(fullDirectoryPath);
            }

            var path = Path.Combine(fullDirectoryPath, newName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await photo.CopyToAsync(stream);
            }          
        }

        public void RemoveNotificationImages(int notificationId)
        {
            var dirPath = $"uploaded\\notifications\\{notificationId}";

            var fullDirectoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", dirPath);

            if (Directory.Exists(fullDirectoryPath))
            {
                // Delete Previews Images If Any Exists
                if (Directory.GetFiles(fullDirectoryPath, "*.*", SearchOption.AllDirectories).Any())
                {
                    foreach (var file in Directory.GetFiles(fullDirectoryPath, "*.*", SearchOption.AllDirectories))
                    {
                        if (File.Exists(file))
                        {
                            File.Delete(file);
                        }
                    }
                }
            }
        }
        #endregion

        #region Cms Article Image
        public (string newName, string thumbName, string dirPath, string baseUrl) GenerateCmsArticleImageName(int articleId, string lang, IFormFile photo)
        {
            var originFileName = photo.FileName;
            var ext = Path.GetExtension(originFileName);
            var time = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss-fffff");
            var newFileName = $"article_{time}{ext}";
            var thumbFileName = $"article_{time}.thumb{ext}";
            var dirPath = $"uploaded\\articles\\{articleId}\\{lang}";
            var baseUrl = $"/{dirPath.Replace("\\", "/")}";

            return (newFileName, thumbFileName, dirPath, baseUrl);
        }

        public async Task UploadCmsArticleImageAsync(IFormFile photo, string dirPath, string newName, string thumbName)
        {
            var fullDirectoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", dirPath);

            if (Directory.Exists(fullDirectoryPath))
            {
                // Delete Previews Images If Any Exists
                if (Directory.GetFiles(fullDirectoryPath, "*.*", SearchOption.AllDirectories).Any())
                {
                    foreach (var file in Directory.GetFiles(fullDirectoryPath, "*.*", SearchOption.AllDirectories))
                    {
                        if (File.Exists(file))
                        {
                            File.Delete(file);
                        }
                    }
                }
            }
            else
            {
                Directory.CreateDirectory(fullDirectoryPath);
            }

            var path = Path.Combine(fullDirectoryPath, newName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await photo.CopyToAsync(stream);
            }

            var thumbPath = Path.Combine(fullDirectoryPath, thumbName);
            using (var image = Image.FromFile(path))
            {
                Image thumb = image.GetThumbnailImage(120, 120, () => false, IntPtr.Zero);
                thumb.Save(thumbPath);
            }
        }

        public void RemoveCmsArticleImages(int articleId, string lang = "")
        {
            var dirPath = $"uploaded\\articles\\{articleId}";

            if (!string.IsNullOrEmpty(lang))
            {
                dirPath += $"\\{lang}";
            }

            var fullDirectoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", dirPath);

            if (Directory.Exists(fullDirectoryPath))
            {
                // Delete Previews Images If Any Exists
                if (Directory.GetFiles(fullDirectoryPath, "*.*", SearchOption.AllDirectories).Any())
                {
                    foreach (var file in Directory.GetFiles(fullDirectoryPath, "*.*", SearchOption.AllDirectories))
                    {
                        if (File.Exists(file))
                        {
                            File.Delete(file);
                        }
                    }
                }
            }
        }
        #endregion

        #region Offer Photo
        public (string newName, string thumbName, string dirPath, string baseUrl) GenerateOfferPhotoName(int offerId, string lang, IFormFile photo)
        {
            var originFileName = photo.FileName;
            var ext = Path.GetExtension(originFileName);
            var time = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss-fffff");
            var newFileName = $"offer_{time}{ext}";
            var thumbFileName = $"offer_{time}.thumb{ext}";
            var dirPath = $"uploaded\\photos\\offers\\{offerId}\\{lang}";
            var baseUrl = $"/{dirPath.Replace("\\", "/")}";

            return (newFileName, thumbFileName, dirPath, baseUrl);
        }

        public async Task UploadOfferPhotoAsync(IFormFile photo, string dirPath, string newName, string thumbName)
        {
            var fullDirectoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", dirPath);

            if (Directory.Exists(fullDirectoryPath))
            {
                // Delete Previews Images If Any Exists
                if (Directory.GetFiles(fullDirectoryPath, "*.*", SearchOption.AllDirectories).Any())
                {
                    foreach (var file in Directory.GetFiles(fullDirectoryPath, "*.*", SearchOption.AllDirectories))
                    {
                        if (File.Exists(file))
                        {
                            File.Delete(file);
                        }
                    }
                }
            }
            else
            {
                Directory.CreateDirectory(fullDirectoryPath);
            }

            var path = Path.Combine(fullDirectoryPath, newName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await photo.CopyToAsync(stream);
            }            
        }

        public void RemoveOfferPhotoAvatar(int offerId, string lang = "")
        {
            var dirPath = $"uploaded\\photos\\offers\\{offerId}";

            if (!string.IsNullOrEmpty(lang))
            {
                dirPath += $"\\{lang}";
            }

            var fullDirectoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", dirPath);

            if (Directory.Exists(fullDirectoryPath))
            {
                // Delete Previews Images If Any Exists
                if (Directory.GetFiles(fullDirectoryPath, "*.*", SearchOption.AllDirectories).Any())
                {
                    foreach (var file in Directory.GetFiles(fullDirectoryPath, "*.*", SearchOption.AllDirectories))
                    {
                        if (File.Exists(file))
                        {
                            File.Delete(file);
                        }
                    }
                }
            }
        }
        #endregion

        #region Insurance Logo
        public (string newName, string thumbName, string dirPath, string baseUrl) GenerateInsuranceLogoName(int insuranceId, IFormFile photo)
        {
            var originFileName = photo.FileName;
            var ext = Path.GetExtension(originFileName);
            var time = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss-fffff");
            var newFileName = $"ins_{time}{ext}";
            var thumbFileName = $"ins_{time}.thumb{ext}";
            var dirPath = $"uploaded\\insurances\\{insuranceId}";
            var baseUrl = $"/{dirPath.Replace("\\", "/")}";

            return (newFileName, thumbFileName, dirPath, baseUrl);
        }

        public async Task UploadInsuranceLogoAsync(IFormFile photo, string dirPath, string newName, string thumbName)
        {
            var fullDirectoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", dirPath);

            if (Directory.Exists(fullDirectoryPath))
            {
                // Delete Previews Images If Any Exists
                if (Directory.GetFiles(fullDirectoryPath, "*.*", SearchOption.AllDirectories).Any())
                {
                    foreach (var file in Directory.GetFiles(fullDirectoryPath, "*.*", SearchOption.AllDirectories))
                    {
                        if (File.Exists(file))
                        {
                            File.Delete(file);
                        }
                    }
                }
            }
            else
            {
                Directory.CreateDirectory(fullDirectoryPath);
            }

            var path = Path.Combine(fullDirectoryPath, newName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await photo.CopyToAsync(stream);
            }
        }

        public void RemoveInsuranceLogo(int insuranceId)
        {
            var dirPath = $"uploaded\\insurances\\{insuranceId}";

            var fullDirectoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", dirPath);

            if (Directory.Exists(fullDirectoryPath))
            {
                // Delete Previews Images If Any Exists
                if (Directory.GetFiles(fullDirectoryPath, "*.*", SearchOption.AllDirectories).Any())
                {
                    foreach (var file in Directory.GetFiles(fullDirectoryPath, "*.*", SearchOption.AllDirectories))
                    {
                        if (File.Exists(file))
                        {
                            File.Delete(file);
                        }
                    }
                }
            }
        }
        #endregion

        #region Insurance Service Photo
        public (string newName, string thumbName, string dirPath, string baseUrl) GenerateInsuranceServicePhotoName(int insuranceServiceId, IFormFile photo)
        {
            var originFileName = photo.FileName;
            var ext = Path.GetExtension(originFileName);
            var time = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss-fffff");
            var newFileName = $"ins_{time}{ext}";
            var thumbFileName = $"ins_{time}.thumb{ext}";
            var dirPath = $"uploaded\\insurances\\services\\{insuranceServiceId}";
            var baseUrl = $"/{dirPath.Replace("\\", "/")}";

            return (newFileName, thumbFileName, dirPath, baseUrl);
        }

        public async Task UploadInsuranceServicePhotoAsync(IFormFile photo, string dirPath, string newName, string thumbName)
        {
            var fullDirectoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", dirPath);

            if (Directory.Exists(fullDirectoryPath))
            {
                // Delete Previews Images If Any Exists
                if (Directory.GetFiles(fullDirectoryPath, "*.*", SearchOption.AllDirectories).Any())
                {
                    foreach (var file in Directory.GetFiles(fullDirectoryPath, "*.*", SearchOption.AllDirectories))
                    {
                        if (File.Exists(file))
                        {
                            File.Delete(file);
                        }
                    }
                }
            }
            else
            {
                Directory.CreateDirectory(fullDirectoryPath);
            }

            var path = Path.Combine(fullDirectoryPath, newName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await photo.CopyToAsync(stream);
            }
        }

        public void RemoveInsuranceServicePhoto(int insuranceServiceId)
        {
            var dirPath = $"uploaded\\insurances\\services\\{insuranceServiceId}";

            var fullDirectoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", dirPath);

            if (Directory.Exists(fullDirectoryPath))
            {
                // Delete Previews Images If Any Exists
                if (Directory.GetFiles(fullDirectoryPath, "*.*", SearchOption.AllDirectories).Any())
                {
                    foreach (var file in Directory.GetFiles(fullDirectoryPath, "*.*", SearchOption.AllDirectories))
                    {
                        if (File.Exists(file))
                        {
                            File.Delete(file);
                        }
                    }
                }
            }
        }
        #endregion

        #region Insurance Service Attachments
        public async Task<AN.Core.Domain.Attachment> UploadInsuranceServiceAttachmentAsync(int insuranceServiceId, IFormFile photo)
        {
            var insuranceService = await _dbContext.InsuranceServices.FindAsync(insuranceServiceId);

            if (insuranceService == null) throw new AwroNoreException("Shift Center Not Found");

            AN.Core.Domain.Attachment attachment = null;

            var strategy = _dbContext.Database.CreateExecutionStrategy();

            await strategy.ExecuteAsync(async () =>
            {
                using (var transaction = _dbContext.Database.BeginTransaction())
                {
                    var originFileName = photo.FileName;
                    var ext = Path.GetExtension(originFileName);
                    var time = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss-fffff");
                    var newFileName = $"attach_{time}{ext}";
                    var thumbFileName = $"attach_{time}.thumb{ext}";
                    var physicalDirPath = $"uploaded\\attachments\\insuranceservices\\{insuranceServiceId}";
                    var baseUrl = $"/{physicalDirPath.Replace("\\", "/")}";

                    attachment = new AN.Core.Domain.Attachment
                    {
                        Owner = AN.Core.Enums.FileOwner.INSURANCE_DOCUMENT,
                        OwnerTableId = insuranceServiceId,
                        CreatedAt = DateTime.Now,
                        FileType = AN.Core.Enums.FileType.Image,
                        IsDeleted = false,
                        Url = $"{baseUrl}/{newFileName}",
                        ThumbnailUrl = $"{baseUrl}/{thumbFileName}",
                        DeleteUrl = $"{baseUrl}/{newFileName}",
                        Name = newFileName,
                        Size = photo.Length,
                        Description = "Gallery Image",
                        Order = 0
                    };

                    await _dbContext.Attachments.AddAsync(attachment);

                    if (!insuranceService.HasAttachments)
                    {
                        insuranceService.HasAttachments = true;

                        _dbContext.InsuranceServices.Attach(insuranceService);

                        _dbContext.Entry(insuranceService).State = EntityState.Modified;                       
                    }

                    await _dbContext.SaveChangesAsync();

                    var fullDirectoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", physicalDirPath);

                    if (!Directory.Exists(fullDirectoryPath))
                    {
                        Directory.CreateDirectory(fullDirectoryPath);
                    }

                    var path = Path.Combine(fullDirectoryPath, newFileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await photo.CopyToAsync(stream);
                    }

                    var thumbPath = Path.Combine(fullDirectoryPath, thumbFileName);
                    using (var image = Image.FromFile(path))
                    {
                        Image thumb = image.GetThumbnailImage(120, 120, () => false, IntPtr.Zero);
                        thumb.Save(thumbPath);
                    }

                    transaction.Commit();
                }
            });

            return attachment;
        }

        public async Task RemoveInsuranceServiceAttachmentAsync(int attachmentId)
        {
            var attachment = await _dbContext.Attachments.FindAsync(attachmentId);

            if (attachment == null) return;

            var insuranceService = await _dbContext.InsuranceServices.FindAsync(attachment.OwnerTableId);

            if (insuranceService == null) throw new AwroNoreException("Shift Center Not Found");

            var strategy = _dbContext.Database.CreateExecutionStrategy();

            await strategy.ExecuteAsync(async () =>
            {
                using (var transaction = _dbContext.Database.BeginTransaction())
                {
                    _dbContext.Attachments.Remove(attachment);
                    
                    var remainedAttaches = await _dbContext.Attachments.AnyAsync(x => x.Owner == AN.Core.Enums.FileOwner.INSURANCE_DOCUMENT && x.Id != attachmentId && x.OwnerTableId == insuranceService.Id);

                    if (!remainedAttaches)
                    {
                        insuranceService.HasAttachments = false;

                        _dbContext.InsuranceServices.Attach(insuranceService);

                        _dbContext.Entry(insuranceService).State = EntityState.Modified;
                    }

                    await _dbContext.SaveChangesAsync();

                    var baseDirPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");

                    string mainFilePath = $"{baseDirPath}{attachment.Url.Replace('/', '\\')}";

                    var thumbFilePath = $"{baseDirPath}{attachment.ThumbnailUrl.Replace('/', '\\')}";

                    if (File.Exists(mainFilePath))
                    {
                        File.Delete(mainFilePath);
                    }

                    if (File.Exists(thumbFilePath))
                    {
                        File.Delete(thumbFilePath);
                    }

                    transaction.Commit();
                }
            });
        }
        #endregion

        #region Service Category Logo
        public (string newName, string thumbName, string dirPath, string baseUrl) GenerateServiceCategoryLogoName(int catId, IFormFile photo)
        {
            var originFileName = photo.FileName;
            var ext = Path.GetExtension(originFileName);
            var time = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss-fffff");
            var newFileName = $"logo_{time}{ext}";
            var thumbFileName = $"logo_{time}.thumb{ext}";
            var dirPath = $"uploaded\\services\\{catId}";
            var baseUrl = $"/{dirPath.Replace("\\", "/")}";

            return (newFileName, thumbFileName, dirPath, baseUrl);
        }

        public async Task UploadServiceCategoryLogoAsync(IFormFile photo, string dirPath, string newName, string thumbName)
        {
            var fullDirectoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", dirPath);

            if (Directory.Exists(fullDirectoryPath))
            {
                // Delete Previews Images If Any Exists
                if (Directory.GetFiles(fullDirectoryPath, "*.*", SearchOption.AllDirectories).Any())
                {
                    foreach (var file in Directory.GetFiles(fullDirectoryPath, "*.*", SearchOption.AllDirectories))
                    {
                        if (File.Exists(file))
                        {
                            File.Delete(file);
                        }
                    }
                }
            }
            else
            {
                Directory.CreateDirectory(fullDirectoryPath);
            }

            var path = Path.Combine(fullDirectoryPath, newName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await photo.CopyToAsync(stream);
            }

            var thumbPath = Path.Combine(fullDirectoryPath, thumbName);
            using (var image = Image.FromFile(path))
            {
                Image thumb = image.GetThumbnailImage(120, 120, () => false, IntPtr.Zero);
                thumb.Save(thumbPath);
            }
        }

        public void RemoveServiceCategoryLogo(int categoryId)
        {
            var dirPath = $"uploaded\\services\\{categoryId}";

            var fullDirectoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", dirPath);

            if (Directory.Exists(fullDirectoryPath))
            {
                // Delete Previews Images If Any Exists
                if (Directory.GetFiles(fullDirectoryPath, "*.*", SearchOption.AllDirectories).Any())
                {
                    foreach (var file in Directory.GetFiles(fullDirectoryPath, "*.*", SearchOption.AllDirectories))
                    {
                        if (File.Exists(file))
                        {
                            File.Delete(file);
                        }
                    }
                }
            }
        }
        #endregion

        public async Task<string> UploadHospitalLogoAsync(int hospitalId, IFormFile photo)
        {
            var hospital = await _dbContext.Hospitals.FindAsync(hospitalId);

            if (hospital == null) throw new AwroNoreException("Hospital Not Found");

            string logoUrl = string.Empty;

            var strategy = _dbContext.Database.CreateExecutionStrategy();

            await strategy.ExecuteAsync(async () =>
            {
                using (var transaction = _dbContext.Database.BeginTransaction())
                {
                    var originFileName = photo.FileName;
                    var ext = Path.GetExtension(originFileName);
                    var time = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss-fffff");
                    var newFileName = $"logo_{time}{ext}";
                    var physicalDirPath = $"uploaded\\logos\\hospitals\\{hospitalId}";
                    var baseUrl = $"/{physicalDirPath.Replace("\\", "/")}";

                    logoUrl = $"{baseUrl}/{newFileName}";

                    hospital.Logo = logoUrl;

                    _dbContext.Hospitals.Attach(hospital);

                    _dbContext.Entry(hospital).State = EntityState.Modified;

                    await _dbContext.SaveChangesAsync();

                    var fullDirectoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", physicalDirPath);

                    if (!Directory.Exists(fullDirectoryPath))
                    {
                        Directory.CreateDirectory(fullDirectoryPath);
                    }

                    var path = Path.Combine(fullDirectoryPath, newFileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await photo.CopyToAsync(stream);
                    }

                    transaction.Commit();
                }
            });

            return logoUrl;
        }

        public async Task<string> UploadClinicLogoAsync(int clinicId, IFormFile photo)
        {
            var clinic = await _dbContext.Clinics.FindAsync(clinicId);

            if (clinic == null) throw new AwroNoreException("Clinic Not Found");

            string logoUrl = string.Empty;

            var strategy = _dbContext.Database.CreateExecutionStrategy();

            await strategy.ExecuteAsync(async () =>
            {
                using (var transaction = _dbContext.Database.BeginTransaction())
                {
                    var originFileName = photo.FileName;
                    var ext = Path.GetExtension(originFileName);
                    var time = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss-fffff");
                    var newFileName = $"logo_{time}{ext}";
                    var physicalDirPath = $"uploaded\\logos\\clinics\\{clinicId}";
                    var baseUrl = $"/{physicalDirPath.Replace("\\", "/")}";

                    logoUrl = $"{baseUrl}/{newFileName}";

                    clinic.Logo = logoUrl;

                    _dbContext.Clinics.Attach(clinic);

                    _dbContext.Entry(clinic).State = EntityState.Modified;

                    await _dbContext.SaveChangesAsync();

                    var fullDirectoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", physicalDirPath);

                    if (!Directory.Exists(fullDirectoryPath))
                    {
                        Directory.CreateDirectory(fullDirectoryPath);
                    }

                    var path = Path.Combine(fullDirectoryPath, newFileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await photo.CopyToAsync(stream);
                    }

                    transaction.Commit();
                }
            });

            return logoUrl;
        }

        public async Task RemoveAttachmentAsync(int attachmentId)
        {
            var attachment = await _dbContext.Attachments.FindAsync(attachmentId);

            if (attachment == null) return;

            var strategy = _dbContext.Database.CreateExecutionStrategy();

            await strategy.ExecuteAsync(async () =>
            {
                using (var transaction = _dbContext.Database.BeginTransaction())
                {
                     _dbContext.Attachments.Remove(attachment);

                    await _dbContext.SaveChangesAsync();

                    var baseDirPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");

                    string mainFilePath = $"{baseDirPath}{attachment.Url.Replace('/', '\\')}";

                    var thumbFilePath = $"{baseDirPath}{attachment.ThumbnailUrl.Replace('/', '\\')}";

                    if (File.Exists(mainFilePath))
                    {
                        File.Delete(mainFilePath);
                    }

                    if (File.Exists(thumbFilePath))
                    {
                        File.Delete(thumbFilePath);
                    }                    

                    transaction.Commit();
                }
            });
        }
    }
}
