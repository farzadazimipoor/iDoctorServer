using AN.BLL.Services.Upload;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AN.Web.Controllers
{
    [Serializable]
    public class InputFileModel
    {       
        public string FileName { get; set; }
        public string FileSize { get; set; }
        public string FileId { get; set; }
        public string ChunkIndex { get; set; }
        public string ChunkCount { get; set; }
    }

    [Serializable]
    public class GalleryPhotoFileModel : InputFileModel
    {
        public IFormFile GalleryPhoto { get; set; }
    }

    [Serializable]
    public class PatientAttachFileModel : InputFileModel
    {
        public IFormFile PatientAttachment { get; set; }
    }

    [Serializable]
    public class LogoFileModel : InputFileModel
    {
        public IFormFile LogoPhoto { get; set; }
    }

    [Serializable]
    public class InsuranceServiceAttachmentModel : InputFileModel
    {
        public IFormFile File { get; set; }
    }

    [Serializable]
    public class UploadResultModel
    {
        public string ChunkIndex { get; set; }
        public string InitialPreview { get; set; }
        public InitialPreviewConfig InitialPreviewConfig { get; set; }
        public bool Append { get; set; }
    }

    [Serializable]
    public class InitialPreviewConfig
    {
        public string Type { get; set; }
        public string Caption { get; set; }
        public string Key { get; set; }
        public string FileId { get; set; }
        public string Size { get; set; }
        public string ZoomData { get; set; }
    }

    public class UploadController : Controller
    {
        private readonly IUploadService _uploadService;
        public UploadController(IUploadService uploadService)
        {
            _uploadService = uploadService;
        }

        public async Task<IActionResult> UploadShiftCenterGalleryPhoto(int id, GalleryPhotoFileModel model)
        {
            try
            {
                var createdAttachment = await _uploadService.UploadShiftCenterGalleryImageAsync(id, model.GalleryPhoto) ?? throw new Exception("Error Upload File");

                return Json(new UploadResultModel
                {
                    ChunkIndex = model.ChunkIndex,
                    InitialPreview = createdAttachment.ThumbnailUrl,
                    InitialPreviewConfig = new InitialPreviewConfig
                    {
                        Type = "",
                        Caption = "",
                        Key = "",
                        FileId = model.FileId,
                        Size = "",
                        ZoomData = ""
                    },
                    Append = true
                });
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message });
            }
        }

        /// <summary>
        /// Delete images
        /// </summary>
        /// <param name="id">this is attachment id</param>
        /// <returns></returns>
        public async Task<IActionResult> DeleteShiftCenterGalleryPhoto(int id)
        {
            await _uploadService.RemoveAttachmentAsync(id);

            return Json(new UploadResultModel
            {                               
                Append = false
            });
        }

        public async Task<IActionResult> UploadShiftCenterLogo(int id, LogoFileModel model)
        {
            try
            {
                var logoUrl = await _uploadService.UploadShiftCenterLogoAsync(id, model.LogoPhoto) ?? throw new Exception("Error Upload File");

                return Json(new UploadResultModel
                {
                    ChunkIndex = model.ChunkIndex,
                    InitialPreview = logoUrl,
                    InitialPreviewConfig = new InitialPreviewConfig
                    {
                        Type = "",
                        Caption = "",
                        Key = "",
                        FileId = model.FileId,
                        Size = "",
                        ZoomData = ""                        
                    },
                    Append = true
                });
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message });
            }
        }

        public async Task<IActionResult> UploadHospitalLogo(int id, LogoFileModel model)
        {
            try
            {
                var logoUrl = await _uploadService.UploadHospitalLogoAsync(id, model.LogoPhoto) ?? throw new Exception("Error Upload File");

                return Json(new UploadResultModel
                {
                    ChunkIndex = model.ChunkIndex,
                    InitialPreview = logoUrl,
                    InitialPreviewConfig = new InitialPreviewConfig
                    {
                        Type = "",
                        Caption = "",
                        Key = "",
                        FileId = model.FileId,
                        Size = "",
                        ZoomData = ""
                    },
                    Append = true
                });
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message });
            }
        }


        public async Task<IActionResult> UploadClinicLogo(int id, LogoFileModel model)
        {
            try
            {
                var logoUrl = await _uploadService.UploadClinicLogoAsync(id, model.LogoPhoto) ?? throw new Exception("Error Upload File");

                return Json(new UploadResultModel
                {
                    ChunkIndex = model.ChunkIndex,
                    InitialPreview = logoUrl,
                    InitialPreviewConfig = new InitialPreviewConfig
                    {
                        Type = "",
                        Caption = "",
                        Key = "",
                        FileId = model.FileId,
                        Size = "",
                        ZoomData = ""
                    },
                    Append = true
                });
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message });
            }
        }


        [Authorize(Roles = "polyclinicmanager,doctor,secretary,sonarmanager,beautycentermanager")]
        public async Task<IActionResult> UploadPatientAttachment(int id, PatientAttachFileModel model)
        {
            try
            {
                var createdAttachment = await _uploadService.UploadPatientAttachmentAsync(id, model.PatientAttachment) ?? throw new Exception("Error Upload File");

                return Json(new UploadResultModel
                {
                    ChunkIndex = model.ChunkIndex,
                    InitialPreview = createdAttachment.ThumbnailUrl,
                    InitialPreviewConfig = new InitialPreviewConfig
                    {
                        Type = "",
                        Caption = "",
                        Key = "",
                        FileId = model.FileId,
                        Size = "",
                        ZoomData = ""
                    },
                    Append = true
                });
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message });
            }
        }

        public async Task<IActionResult> UploadInsuranceServiceAttachment(int id, InsuranceServiceAttachmentModel model)
        {
            try
            {
                var createdAttachment = await _uploadService.UploadInsuranceServiceAttachmentAsync(id, model.File) ?? throw new Exception("Error Upload File");

                return Json(new UploadResultModel
                {
                    ChunkIndex = model.ChunkIndex,
                    InitialPreview = createdAttachment.ThumbnailUrl,
                    InitialPreviewConfig = new InitialPreviewConfig
                    {
                        Type = "",
                        Caption = "",
                        Key = "",
                        FileId = model.FileId,
                        Size = "",
                        ZoomData = ""
                    },
                    Append = true
                });
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message });
            }
        }

        /// <summary>
        /// Delete images
        /// </summary>
        /// <param name="id">this is attachment id</param>
        /// <returns></returns>
        public async Task<IActionResult> DeleteInsuranceServiceAttachment(int id)
        {
            await _uploadService.RemoveInsuranceServiceAttachmentAsync(id);

            return Json(new UploadResultModel
            {
                Append = false
            });
        }       
    }
}