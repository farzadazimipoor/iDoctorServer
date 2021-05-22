using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AN.BLL.Services.Upload
{
    public interface IUploadService
    {
        #region Consultancy Voice Message
        (string newName, string dirPath, string baseUrl) GenerateConsultancyMessageVoiceName(int chatId, int messageId, IFormFile voice);
        Task UploadConsultancyMessageVoiceAsync(IFormFile voice, string dirPath, string newName);
        #endregion

        #region Consultancy Image Message
        (string newName, string thumbName, string dirPath, string baseUrl) GenerateConsultancyMessageImageName(int chatId, int messageId, IFormFile photo);

        Task UploadConsultancyMessageImageAsync(IFormFile photo, string dirPath, string newName, string thumbName);
        #endregion

        #region Person Avatar
        (string newName, string thumbName, string dirPath, string baseUrl) GeneratePersonAvatarName(int personId, IFormFile photo);

        Task UploadPersonAvatarAsync(IFormFile photo, string dirPath, string newName, string thumbName);

        void RemovePersonAvatar(int personId);
        #endregion

        #region ShiftCenter Gallery
        Task<AN.Core.Domain.Attachment> UploadShiftCenterGalleryImageAsync(int shiftCenterId, IFormFile photo);

        Task<string> UploadShiftCenterLogoAsync(int shiftCenterId, IFormFile photo);
        #endregion

        #region Treatment Attachments
        string GetTreatmentAttachDirectoryPath(int personId, int treatmentId);
        (string newName, string thumbName, string dirPath, string baseUrl) GenerateTreatmentAttachFileName(int personId, int treatmentId, IFormFile photo);
        Task UploadTreatmentAttachmentAsync(IFormFile photo, string dirPath, string newName, string thumbName);
        void RemoveTreatmentAttachment(string path, string thumbPath);
        #endregion

        #region Patient Attachments
        string GetPatientAttachDirectoryPath(int patientId);

        (string newName, string thumbName, string dirPath, string baseUrl) GeneratePatientAttachFileName(int patientId, IFormFile file);

        Task<AN.Core.Domain.Attachment> UploadPatientAttachmentAsync(int patientId, IFormFile file);
        #endregion

        #region Notification Image
        (string newName, string thumbName, string dirPath, string baseUrl) GenerateNotificationImageName(int notificationId, IFormFile photo);

        Task UploadNotificationImageAsync(IFormFile photo, string dirPath, string newName, string thumbName);

        void RemoveNotificationImages(int notificationId);
        #endregion

        #region Insurance Logo
        (string newName, string thumbName, string dirPath, string baseUrl) GenerateInsuranceLogoName(int insuranceId, IFormFile photo);

        Task UploadInsuranceLogoAsync(IFormFile photo, string dirPath, string newName, string thumbName);

        void RemoveInsuranceLogo(int insuranceId);
        #endregion

        #region Insurance Service Photo
        (string newName, string thumbName, string dirPath, string baseUrl) GenerateInsuranceServicePhotoName(int insuranceId, IFormFile photo);

        Task UploadInsuranceServicePhotoAsync(IFormFile photo, string dirPath, string newName, string thumbName);

        void RemoveInsuranceServicePhoto(int insuranceId);
        #endregion

        #region Cms Article Image
        (string newName, string thumbName, string dirPath, string baseUrl) GenerateCmsArticleImageName(int articleId, string lang, IFormFile photo);

        Task UploadCmsArticleImageAsync(IFormFile photo, string dirPath, string newName, string thumbName);

        void RemoveCmsArticleImages(int articleId, string lang = "");
        #endregion

        #region Offer Photo
        (string newName, string thumbName, string dirPath, string baseUrl) GenerateOfferPhotoName(int offerId, string lang, IFormFile photo);

        Task UploadOfferPhotoAsync(IFormFile photo, string dirPath, string newName, string thumbName);

        void RemoveOfferPhotoAvatar(int offerId, string lang = "");
        #endregion

        #region Insurance Service Attachments
        Task<AN.Core.Domain.Attachment> UploadInsuranceServiceAttachmentAsync(int insuranceServiceId, IFormFile photo);        
        Task RemoveInsuranceServiceAttachmentAsync(int attachmentId);
        #endregion

        #region Service Category Logo
        (string newName, string thumbName, string dirPath, string baseUrl) GenerateServiceCategoryLogoName(int catId, IFormFile photo);
        Task UploadServiceCategoryLogoAsync(IFormFile photo, string dirPath, string newName, string thumbName);
        void RemoveServiceCategoryLogo(int personId);
        #endregion

        #region Medical Request Attachment
        string GenerateMedicalRequestFilesBaseDirPath(int reqId, DateTime createdAt);

        string GenerateMedicalRequestFilesBaseUrl(int reqId, DateTime createdAt);

        string GenerateMedicalRequestFilesFullDirPath(int reqId, DateTime createdAt);

        // Full Url
        string GenerateMedicalRequestFilesFullUrl(int reqId, DateTime createdAt, string fileName);

        (string newName, string thumbName) GenerateMedicalRequestFileName(int reqId, IFormFile file);

        Task UploadMedicalRequestFilesAsync(int reqId, DateTime createdAt, Dictionary<IFormFile, (string newFileName, string thumbName)> files);

        void RemoveMedicalRequestFiles(int recId);
        #endregion

        Task<string> UploadHospitalLogoAsync(int hospitalId, IFormFile photo);

        Task<string> UploadClinicLogoAsync(int clinicId, IFormFile photo);

        Task RemoveAttachmentAsync(int attachmentId);
    }
}
