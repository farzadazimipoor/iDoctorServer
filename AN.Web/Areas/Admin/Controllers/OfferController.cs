using AN.BLL.Core.Services;
using AN.BLL.Core.Services.Messaging.Notifications;
using AN.BLL.DataRepository;
using AN.BLL.DataRepository.HealthServices;
using AN.BLL.DataRepository.Polyclinics;
using AN.BLL.DataRepository.ServiceSupplies;
using AN.BLL.Services.Upload;
using AN.Core.Domain;
using AN.Core.Enums;
using AN.Core.Exceptions;
using AN.Core.Extensions;
using AN.Core.Resources.Global;
using AN.Core.ViewModels;
using AN.DAL;
using AN.Web.App_Code;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AN.Web.Areas.Admin.Controllers
{
    public class OfferController : AdminController
    {
        private readonly IOfferRepository _offerRepository;
        private readonly INotificationService _notificationService;
        private readonly BanobatDbContext _dbContext;
        private readonly IUploadService _uploadService;
        private readonly IScheduleManager _scheduleManager;
        private readonly IShiftCenterService _shiftCenterService;
        private readonly IServicesService _servicesService;
        private readonly IServiceSupplyService _serviceSupplyService;
        public OfferController(IOfferRepository offerRepository, INotificationService notificationService, BanobatDbContext dbContext, IUploadService uploadService, IScheduleManager scheduleManager, IShiftCenterService shiftCenterService, IServicesService servicesService, IServiceSupplyService serviceSupplyService)
        {
            _offerRepository = offerRepository;
            _notificationService = notificationService;
            _dbContext = dbContext;
            _uploadService = uploadService;
            _scheduleManager = scheduleManager;
            _shiftCenterService = shiftCenterService;
            _servicesService = servicesService;
            _serviceSupplyService = serviceSupplyService;
        }

        public IActionResult Index()
        {
            ViewBag.Lang = Lng;

            return View(new OfferListViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> LoadTable([FromBody] DataTablesParameters param)
        {
            try
            {
                HttpContext.Session.SetString(nameof(DataTablesParameters), JsonConvert.SerializeObject(param));

                var results = await _offerRepository.GetDataAsync(param, isForAdmin: true);

                var offers = await Task.WhenAll(results.Items.Select(async (x) => new OfferListViewModel
                {
                    Id = x.Id,
                    Date = x.Date,
                    EndTime = x.EndTime,
                    StartTime = x.StartTime,
                    Status = x.Status,
                    OfferStatus = x.OfferStatus,
                    CenterName = x.CenterName,
                    Type = x.Type,
                    Visits = x.Visits,
                    Appointments = x.Appointments,
                    ActionsHtml = await this.RenderViewToStringAsync("_OfferItemActions", x)
                }).ToList());

                return new JsonResult(new DataTablesResult<OfferListViewModel>
                {
                    Draw = param.Draw,
                    Data = offers.ToList(),
                    RecordsFiltered = results.TotalSize,
                    RecordsTotal = results.TotalSize
                });
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                return new JsonResult(new { error = "Internal Server Error" });
            }
        }

        public async Task<IActionResult> SetOfferStatus(int id, OfferStatus newStatus)
        {
            var offer = await _offerRepository.SetNewStatusAsync(id, newStatus);

            if (newStatus == OfferStatus.APPROVED && offer.SendNotification)
            {
                try
                {
                    await _notificationService.SendInboxOfferNotificationAsync(new BaseNotificationPayload
                    {
                        Title = offer.NotificationTitle ?? offer.NotificationTitle_Ku ?? offer.NotificationTitle_Ar,
                        TitleKu = offer.NotificationTitle_Ku ?? offer.NotificationTitle ?? offer.NotificationTitle_Ar,
                        TitleAr = offer.NotificationTitle_Ar ?? offer.NotificationTitle_Ku ?? offer.NotificationTitle,
                        Body = offer.NotificationBody ?? offer.NotificationBody_Ku ?? offer.NotificationBody_Ar,
                        BodyKu = offer.NotificationBody_Ku ?? offer.NotificationBody_Ar ?? offer.NotificationBody,
                        BodyAr = offer.NotificationBody_Ar ?? offer.NotificationBody_Ku ?? offer.NotificationBody,
                    });
                }
                catch { }
            }

            return new JsonResult(new { success = true });
        }

        public async Task<IActionResult> Delete(int id)
        {
            //TODO:  Remove offer pics

            await _offerRepository.DeleteAsync(id);

            return new JsonResult(new { success = true });
        }

        [HttpGet]
        public async Task<IActionResult> CreateUpdate(OfferType type, int? id = null)
        {
            ViewBag.Lang = Lng;

            ViewBag.CurrencyTypes = MyEnumExtensions.EnumToSelectList<CurrencyType>().ToList();

            var centers = await _shiftCenterService.GetSelectListAsync(Lng);

            ViewBag.ShiftCenters = centers;

            var healthServices = new List<SelectListItem>();   
            
            var doctors = new List<SelectListItem>();

            if (centers.Any())
            {
                var firstCenter = centers.FirstOrDefault();

                healthServices = GetCenterServices(int.Parse(firstCenter.Value));

                doctors = (await _serviceSupplyService.GetSelectListAsync(int.Parse(firstCenter.Value))).ToList();
            }

            ViewBag.HealthServices = healthServices;

            ViewBag.Doctors = doctors;

            var model = new OfferCreateUpdateViewModel
            {
                Id = id,
                Date = DateTime.Now.ToString("yyyy/MM/dd"),
                Type = type,
                StartAt = DateTime.Now,
                ExpiredAt = DateTime.Now.AddDays(1)
            };

            if (id != null)
            {
                var offer = await _offerRepository.GetByIdAsync(id.Value);

                if (offer == null) throw new Exception("Patient Not Found");

                model.Title = offer.Title;
                model.Title_Ar = offer.Title_Ar;
                model.Title_Ku = offer.Title_Ku;

                model.Summary = offer.Summary;
                model.Summary_Ar = offer.Summary_Ar;
                model.Summary_Ku = offer.Summary_Ku;

                model.ShowDiscountBanner = offer.ShowDiscountBanner;
                model.DiscountPercentange = offer.DiscountPercentange;
                model.OldPrice = offer.OldPrice;
                model.CurrentPrice = offer.CurrentPrice;
                model.CurrencyType = offer.CurrencyType;

                model.ShiftCenterId = offer.ShiftCenterService.ShiftCenterId;
                model.Date = offer.StartDateTime.Value.ToShortDateString();
                model.StartTime = offer.StartDateTime.Value.ToShortTimeString();
                model.Endtime = offer.EndDateTime.Value.ToShortTimeString();
                model.MaxCount = offer.MaxCount ?? 0;
                model.Description = offer.Description;
                model.ServiceSupplyId = offer.ServiceSupplyId;
                model.ShiftCenterServiceId = offer.ShiftCenterServiceId ?? 0;
                model.Type = offer.Type;
                model.SendNotification = offer.SendNotification;
                model.NotificationTitle = offer.NotificationTitle;
                model.NotificationTitle_Ku = offer.NotificationTitle_Ku;
                model.NotificationTitle_Ar = offer.NotificationTitle_Ar;
                model.NotificationBody = offer.NotificationBody;
                model.NotificationBody_Ku = offer.NotificationBody_Ku;
                model.NotificationBody_Ar = offer.NotificationBody_Ar;
                model.StartAt = offer.StartAt;
                model.ExpiredAt = offer.ExpiredAt;

                if (!string.IsNullOrEmpty(offer.Photo))
                {
                    ViewBag.PhotoPreview = "<img src=" + offer.Photo + " alt=\"Photo\">";
                }

                if (!string.IsNullOrEmpty(offer.Photo_Ku))
                {
                    ViewBag.PhotoPreviewKu = "<img src=" + offer.Photo_Ku + " alt=\"Photo\">";
                }

                if (!string.IsNullOrEmpty(offer.Photo_Ar))
                {
                    ViewBag.PhotoPreviewAr = "<img src=" + offer.Photo_Ar + " alt=\"Photo\">";
                }
            }

            return PartialView("CreateUpdate", model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUpdate(OfferCreateUpdateViewModel model)
        {
            try
            {
                // if (model.Type == OfferType.AD) throw new AwroNoreException("Last version of application is not published to support this type of offers");               

                var success = false;
                var message = Global.Err_ErrorOccured;

                Offer offer = null;

                var serviceSupply = await _dbContext.ServiceSupplies.FindAsync(model.ServiceSupplyId);

                if (serviceSupply == null) throw new AwroNoreException(Global.Err_DoctorNotFound);

                DateTime? startDateTime = null;
                DateTime? endDateTime = null;

                if (model.Type == OfferType.FREE_APPOINTMENTS)
                {
                    if (model.ShiftCenterServiceId == null) throw new AwroNoreException("Please select service");

                    if (model.MaxCount == null || model.MaxCount <= 0) throw new AwroNoreException("Max capacity must be greater than 0");

                    if(string.IsNullOrEmpty(model.Date) || string.IsNullOrEmpty(model.StartTime) || string.IsNullOrEmpty(model.Endtime)) throw new AwroNoreException("Please enter valid schedule time");

                    startDateTime = DateTime.Parse($"{model.Date} {model.StartTime}");

                    endDateTime = DateTime.Parse($"{model.Date} {model.Endtime}");

                    _scheduleManager.EnsureHasSchedule(serviceSupply, model.ShiftCenterServiceId ?? 0, startDateTime.Value, endDateTime.Value);
                }

                var strategy = _dbContext.Database.CreateExecutionStrategy();
                await strategy.ExecuteAsync(async () =>
                {
                    using (var transaction = _dbContext.Database.BeginTransaction())
                    {
                        if (model.Id != null)
                        {
                            offer = await _offerRepository.GetByIdAsync(model.Id.Value);

                            if (offer == null) throw new Exception("Offer Not Found");

                            offer.Title = model.Title;
                            offer.Title_Ar = model.Title_Ar;
                            offer.Title_Ku = model.Title_Ku;
                            offer.Summary = model.Summary;
                            offer.Summary_Ar = model.Summary_Ar;
                            offer.Summary_Ku = model.Summary_Ku;
                            offer.DiscountPercentange = model.DiscountPercentange;
                            offer.OldPrice = model.OldPrice;
                            offer.CurrentPrice = model.CurrentPrice;
                            offer.CurrencyType = model.CurrencyType;
                            offer.ShowDiscountBanner = model.ShowDiscountBanner;
                            offer.StartDateTime = startDateTime;
                            offer.EndDateTime = endDateTime;
                            offer.MaxCount = model.MaxCount;
                            offer.Description = model.Description;
                            offer.UpdatedAt = DateTime.Now;
                            offer.ServiceSupplyId = model.ServiceSupplyId;
                            offer.ShiftCenterServiceId = model.ShiftCenterServiceId;
                            offer.Type = model.Type;
                            offer.StartAt = model.StartAt;
                            offer.ExpiredAt = model.ExpiredAt;

                            _offerRepository.UpdateOffer(offer);                            

                            message = Core.Resources.EntitiesResources.Messages.ItemUpdatedSuccessFully;
                        }
                        else
                        {
                            var uniqueCode = await _offerRepository.GenerateUniqueCodeAsync();

                            offer = new Offer
                            {
                                Title = model.Title,
                                Title_Ar = model.Title_Ar,
                                Title_Ku = model.Title_Ku,
                                Summary = model.Summary,
                                Summary_Ar = model.Summary_Ar,
                                Summary_Ku = model.Summary_Ku,
                                DiscountPercentange = model.DiscountPercentange,
                                OldPrice = model.OldPrice,
                                CurrentPrice = model.CurrentPrice,
                                CurrencyType = model.CurrencyType,     
                                ShowDiscountBanner = model.ShowDiscountBanner,
                                StartDateTime = startDateTime,
                                EndDateTime = endDateTime,
                                MaxCount = model.MaxCount,
                                RemainedCount = model.MaxCount,
                                CreatedAt = DateTime.Now,
                                Description = model.Description,
                                ServiceSupplyId = model.ServiceSupplyId,
                                ShiftCenterServiceId = model.ShiftCenterServiceId == 0 ? null : model.ShiftCenterServiceId,
                                Status = OfferStatus.APPROVED,
                                Code = uniqueCode,
                                Type = model.Type,
                                Photo = "",
                                SendNotification = model.SendNotification,
                                NotificationTitle = model.NotificationTitle,
                                NotificationTitle_Ku = model.NotificationTitle_Ku,
                                NotificationTitle_Ar = model.NotificationTitle_Ar,
                                NotificationBody = model.NotificationBody,
                                NotificationBody_Ku = model.NotificationBody_Ku,
                                NotificationBody_Ar = model.NotificationBody_Ar,
                                StartAt = model.StartAt,
                                ExpiredAt = model.ExpiredAt                                
                            };

                            await _offerRepository.InsertOfferAsync(offer);                           

                            message = Core.Resources.EntitiesResources.Messages.ItemAddedSuccessFully;
                        }

                        if (model.ImageUpload != null)
                        {
                            var (newName, thumbName, dirPath, baseUrl) = _uploadService.GenerateOfferPhotoName(offer.Id, Lang.EN.ToString(), model.ImageUpload);

                            offer.Photo = $"{baseUrl}/{newName}";

                            _dbContext.Offers.Attach(offer);

                            _dbContext.Entry(offer).State = EntityState.Modified;

                            await _dbContext.SaveChangesAsync();

                            await _uploadService.UploadOfferPhotoAsync(model.ImageUpload, dirPath, newName, thumbName);
                        }

                        if (model.ImageUpload_Ar != null)
                        {
                            var (newName, thumbName, dirPath, baseUrl) = _uploadService.GenerateOfferPhotoName(offer.Id, Lang.AR.ToString(), model.ImageUpload_Ar);

                            offer.Photo_Ar = $"{baseUrl}/{newName}";

                            _dbContext.Offers.Attach(offer);

                            _dbContext.Entry(offer).State = EntityState.Modified;

                            await _dbContext.SaveChangesAsync();

                            await _uploadService.UploadOfferPhotoAsync(model.ImageUpload_Ar, dirPath, newName, thumbName);
                        }

                        if (model.ImageUpload_Ku != null)
                        {
                            var (newName, thumbName, dirPath, baseUrl) = _uploadService.GenerateOfferPhotoName(offer.Id, Lang.KU.ToString(), model.ImageUpload_Ku);

                            offer.Photo_Ku = $"{baseUrl}/{newName}";

                            _dbContext.Offers.Attach(offer);

                            _dbContext.Entry(offer).State = EntityState.Modified;

                            await _dbContext.SaveChangesAsync();

                            await _uploadService.UploadOfferPhotoAsync(model.ImageUpload_Ku, dirPath, newName, thumbName);
                        }

                        transaction.Commit();

                        success = true;
                    }
                });

                try
                {
                    if(offer != null && offer.SendNotification)
                    {
                        await _notificationService.SendInboxOfferNotificationAsync(new BaseNotificationPayload
                        {
                            Title = offer.NotificationTitle ?? offer.NotificationTitle_Ku ?? offer.NotificationTitle_Ar,
                            TitleKu = offer.NotificationTitle_Ku ?? offer.NotificationTitle ?? offer.NotificationTitle_Ar,
                            TitleAr = offer.NotificationTitle_Ar ?? offer.NotificationTitle_Ku ?? offer.NotificationTitle,
                            Body = offer.NotificationBody ?? offer.NotificationBody_Ku ?? offer.NotificationBody_Ar,
                            BodyKu = offer.NotificationBody_Ku ?? offer.NotificationBody_Ar ?? offer.NotificationBody,
                            BodyAr = offer.NotificationBody_Ar ?? offer.NotificationBody_Ku ?? offer.NotificationBody,
                        });
                    }
                }
                catch
                {

                }

                return Json(new { success, message });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public List<SelectListItem> GetCenterServices(int centerId)
        {
            var result =  _servicesService.GetShiftCenterServicesListItems(centerId, Lng).Select(x => new SelectListItem
            {
                Text = x.Text,
                Value = x.Value
            }).ToList();

            return result;
        }
    }
}