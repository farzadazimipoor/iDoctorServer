using AN.BLL.Core.Services;
using AN.BLL.DataRepository;
using AN.BLL.DataRepository.HealthServices;
using AN.BLL.DataRepository.ServiceSupplies;
using AN.BLL.Services.Upload;
using AN.Core;
using AN.Core.Domain;
using AN.Core.Enums;
using AN.Core.Exceptions;
using AN.Core.Extensions;
using AN.Core.Resources.Global;
using AN.Core.ViewModels;
using AN.DAL;
using AN.Web.App_Code;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Shared.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AN.Web.Areas.BeautyCenterManager.Controllers
{
    public class OfferController : BeautyCenterManagerController
    {
        private readonly IOfferRepository _offerRepository;
        private readonly IServicesService _healthServiceService;
        private readonly IServiceSupplyService _serviceSupplyService;
        private readonly BanobatDbContext _dbContext;
        private readonly IUploadService _uploadService;
        private readonly IScheduleManager _scheduleManager;
        public OfferController(IWorkContext workContext,
                               IOfferRepository offerRepository,
                               IServicesService servicesService,
                               IServiceSupplyService serviceSupplyService, 
                               BanobatDbContext banobatDbContext,
                               IUploadService uploadService, IScheduleManager scheduleManager) : base(workContext)
        {
            _offerRepository = offerRepository;
            _healthServiceService = servicesService;
            _serviceSupplyService = serviceSupplyService;
            _dbContext = banobatDbContext;
            _uploadService = uploadService;
            _scheduleManager = scheduleManager;
        }


        public IActionResult Index()
        {
            ViewBag.Lang = Lng;

            return View(new OfferListViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> LoadTable([FromBody]DataTablesParameters param)
        {
            try
            {
                var results = await _offerRepository.GetDataAsync(param, centerId: CurrentBeautyCenter.Id, serviceSupplyIds: CurrentBeautyCenter.ServiceSupplyIds, isForAdmin: false);

                var offers = await Task.WhenAll(results.Items.Select(async (x) => new OfferListViewModel
                {
                    Id = x.Id,
                    Date = x.Date,
                    EndTime = x.EndTime,
                    StartTime = x.StartTime,
                    Status = x.Status,
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

        [HttpGet]
        public async Task<IActionResult> CreateUpdate(int? id = null)
        {
            ViewBag.OfferTypesList = MyEnumExtensions.EnumToSelectList<OfferType>().ToList();

            ViewBag.Lang = Lng;

            ViewBag.HealthServices = _healthServiceService.GetShiftCenterServicesListItems(CurrentBeautyCenter.Id, Lng).Select(x => new SelectListItem
            {
                Text = x.Text,
                Value = x.Value
            }).ToList();

            ViewBag.Doctors = await _serviceSupplyService.GetSelectListAsync(CurrentBeautyCenter.Id, CurrentBeautyCenter.ServiceSupplyIds);

            var model = new OfferCreateUpdateViewModel
            {
                Id = id,
                Date = DateTime.Now.ToString("yyyy/MM/dd")
            };

            if (id != null)
            {
                var offer = await _offerRepository.GetByIdAsync(id.Value);

                if (offer == null) throw new Exception("Patient Not Found");

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

                if (!string.IsNullOrEmpty(offer.Photo))
                {
                    ViewBag.PhotoPreview = "<img src=" + offer.Photo + " alt=\"Photo\">";
                }
            }

            return PartialView("CreateUpdate", model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUpdate(OfferCreateUpdateViewModel model)
        {
            try
            {
                if (!CurrentBeautyCenter.ServiceSupplyIds.Contains(model.ServiceSupplyId)) throw new AwroNoreException("You don not have permission to add offer to this doctor");

                var startDateTime = DateTime.Parse($"{model.Date} {model.StartTime}");

                var endDateTime = DateTime.Parse($"{model.Date} {model.Endtime}");

                var serviceSupply = await _dbContext.ServiceSupplies.FindAsync(model.ServiceSupplyId);

                if (serviceSupply == null) throw new AwroNoreException(Global.Err_DoctorNotFound);

                _scheduleManager.EnsureHasSchedule(serviceSupply, model.ShiftCenterServiceId ?? 0, startDateTime, endDateTime);

                var success = false;
                var message = Global.Err_ErrorOccured;

                var strategy = _dbContext.Database.CreateExecutionStrategy();
                await strategy.ExecuteAsync(async () =>
                {
                    using (var transaction = _dbContext.Database.BeginTransaction())
                    {
                        if (model.Id != null)
                        {
                            var offer = await _offerRepository.GetByIdAsync(model.Id.Value);

                            if (offer == null) throw new Exception("Patient Not Found");

                            offer.StartDateTime = startDateTime;
                            offer.EndDateTime = endDateTime;
                            offer.MaxCount = model.MaxCount;
                            offer.Description = model.Description;
                            offer.UpdatedAt = DateTime.Now;
                            offer.ServiceSupplyId = model.ServiceSupplyId;
                            offer.ShiftCenterServiceId = model.ShiftCenterServiceId;
                            offer.Type = model.Type;

                            _offerRepository.UpdateOffer(offer);

                            if (model.ImageUpload != null)
                            {
                                var (newName, thumbName, dirPath, baseUrl) = _uploadService.GenerateOfferPhotoName(offer.Id, Lang.EN.ToString(), model.ImageUpload);

                                offer.Photo = $"{baseUrl}/{newName}";

                                _dbContext.Offers.Attach(offer);

                                _dbContext.Entry(offer).State = EntityState.Modified;

                                await _dbContext.SaveChangesAsync();

                                await _uploadService.UploadOfferPhotoAsync(model.ImageUpload, dirPath, newName, thumbName);
                            }

                            message = Core.Resources.EntitiesResources.Messages.ItemUpdatedSuccessFully;
                        }
                        else
                        {
                            var uniqueCode = await _offerRepository.GenerateUniqueCodeAsync();

                            var offer = new Offer
                            {
                                StartDateTime = startDateTime,
                                EndDateTime = endDateTime,
                                MaxCount = model.MaxCount,
                                RemainedCount = model.MaxCount,
                                CreatedAt = DateTime.Now,
                                Description = model.Description,
                                ServiceSupplyId = model.ServiceSupplyId,
                                ShiftCenterServiceId = model.ShiftCenterServiceId,
                                Status = OfferStatus.PENDING,
                                Code = uniqueCode,
                                Type = model.Type,
                                Photo = "",
                                SendNotification = model.SendNotification,
                                NotificationTitle = model.NotificationTitle,
                                NotificationTitle_Ku = model.NotificationTitle_Ku,
                                NotificationTitle_Ar = model.NotificationTitle_Ar,
                                NotificationBody = model.NotificationBody,
                                NotificationBody_Ku = model.NotificationBody_Ku,
                                NotificationBody_Ar = model.NotificationBody_Ar
                            };

                            await _offerRepository.InsertOfferAsync(offer);

                            if (model.ImageUpload != null)
                            {
                                var (newName, thumbName, dirPath, baseUrl) = _uploadService.GenerateOfferPhotoName(offer.Id, Lang.EN.ToString(), model.ImageUpload);

                                offer.Photo = $"{baseUrl}/{newName}";

                                _dbContext.Offers.Attach(offer);

                                _dbContext.Entry(offer).State = EntityState.Modified;

                                await _dbContext.SaveChangesAsync();

                                await _uploadService.UploadOfferPhotoAsync(model.ImageUpload, dirPath, newName, thumbName);
                            }

                            message = Core.Resources.EntitiesResources.Messages.ItemAddedSuccessFully;
                        }

                        transaction.Commit();

                        success = true;
                    }
                });

                return Json(new { success, message });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}