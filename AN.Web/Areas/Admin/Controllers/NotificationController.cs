using AN.BLL.Core.Services.Messaging.Notifications;
using AN.BLL.DataRepository;
using AN.BLL.Extensions;
using AN.BLL.Services.Upload;
using AN.Core.Domain;
using AN.Core.DTO;
using AN.Core.Extensions;
using AN.Core.Resources.EntitiesResources;
using AN.Core.ViewModels;
using AN.DAL;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Shared.Models;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AN.Web.Areas.Admin.Controllers
{
    public class NotificationController : AdminController
    {
        private readonly BanobatDbContext _dbContext;
        private readonly INotificationRepository _notificationRepository;
        private readonly IMapper _mapper;
        private readonly IUploadService _uploadService;
        private readonly INotificationService _notificationService;
        public NotificationController(BanobatDbContext dbContext, INotificationRepository notificationRepository, IMapper mapper, IUploadService uploadService, INotificationService notificationService)
        {
            _dbContext = dbContext;
            _notificationRepository = notificationRepository;
            _mapper = mapper;
            _uploadService = uploadService;
            _notificationService = notificationService;
        }

        public IActionResult Index()
        {
            ViewBag.Lang = Lng;

            return View(new NotificationViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> LoadTable([FromBody] DataTablesParameters param)
        {
            try
            {
                var filtersModel = JsonConvert.DeserializeObject<NotificationFilterViewModel>(param.FiltersObject);

                var results = await _notificationRepository.GetDataTableAsync(param, filtersModel, Lng);

                var notifications = await Task.WhenAll(results.Items.Select(async (x) => new NotificationViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    CreateDate = x.CreateDate,
                    ValidUntil = x.ValidUntil,
                    ActionsHtml = await this.RenderViewToStringAsync("_NotificationItemActions", x.Id)
                }).ToList());

                return new JsonResult(new DataTablesResult<NotificationViewModel>
                {
                    Draw = param.Draw,
                    Data = notifications,
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
        public IActionResult CreateUpdate(int? id = null)
        {
            var model = new NotificationCreateUpdateViewModel
            {
                Id = id,
                ValidUntil = DateTime.Now.ToString("yyyy/MM/dd")
            };

            return PartialView(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateUpdate(NotificationCreateUpdateViewModel model)
        {
            var strategy = _dbContext.Database.CreateExecutionStrategy();
            await strategy.ExecuteAsync(async () =>
            {
                using (var transaction = _dbContext.Database.BeginTransaction())
                {
                    var notification = _mapper.Map<Notification>(model);

                    await _dbContext.Notifications.AddAsync(notification);

                    await _dbContext.SaveChangesAsync();

                    var (newName, thumbName, dirPath, baseUrl) = _uploadService.GenerateNotificationImageName(notification.Id, model.Image);

                    notification.Image = $"{baseUrl}/{newName}";

                    _dbContext.Notifications.Attach(notification);

                    _dbContext.Entry(notification).State = EntityState.Modified;

                    await _dbContext.SaveChangesAsync();

                    await _uploadService.UploadNotificationImageAsync(model.Image, dirPath, newName, thumbName);

                    var notificationDTO = new NotificationListItemDTO
                    {
                        Id = notification.Id,
                        Text = notification.Text ?? notification.Text_Ku ?? notification.Text_Ar,
                        TextKu = notification.Text_Ku ?? notification.Text ?? notification.Text_Ar,
                        TextAr = notification.Text_Ar ?? notification.Text_Ku ?? notification.Text,
                        Title = notification.Title ?? notification.Title_Ku ?? notification.Title_Ar,
                        TitleKu = notification.Title_Ku ?? notification.Title ?? notification.Title_Ar,
                        TitleAr = notification.Title_Ar ?? notification.Title_Ku ?? notification.Title,                        
                        CreatedAt = notification.CreatedAt,
                        Description = notification.Description ?? notification.Description_Ku ?? notification.Description_Ar,
                        DescriptionKu = notification.Description_Ku ?? notification.Description ?? notification.Description_Ar,
                        DescriptionAr = notification.Description_Ar ?? notification.Description_Ku ?? notification.Description,
                        PayloadJson = notification.PayloadJson,
                        Image = notification.Image,
                        IsExpired = DateTime.Now > notification.ValidUntil
                    };                    
                    await _notificationService.SendInboxNotificationAsync(new BaseNotificationPayload
                    {
                        Title = notificationDTO.Title,
                        TitleKu = notificationDTO.TitleKu,
                        TitleAr = notificationDTO.TitleAr,
                        Body = notificationDTO.Text?.TruncateLongString(50),
                        BodyKu = notificationDTO.TextKu?.TruncateLongString(50),
                        BodyAr = notificationDTO.TextAr?.TruncateLongString(50)
                    }, notificationDTO);

                    transaction.Commit();

                }
            });

            return Json(new { success = true, message = Messages.ItemAddedSuccessFully });
        }

        public async Task<IActionResult> Delete(int id)
        {
            string message = Messages.AnErrorOccuredWhileDeleteItem;
            bool success = false;
            try
            {
                var strategy = _dbContext.Database.CreateExecutionStrategy();
                await strategy.ExecuteAsync(async () =>
                {
                    using (var transaction = _dbContext.Database.BeginTransaction())
                    {
                        var notification = await _dbContext.Notifications.FindAsync(id);

                        if (notification != null)
                        {
                            _dbContext.Notifications.Remove(notification);

                            await _dbContext.SaveChangesAsync();

                            _uploadService.RemoveNotificationImages(id);
                        }

                        message = Messages.ItemDeletedSuccessFully;

                        success = true;

                        transaction.Commit();

                    }
                });
            }
            catch (DbUpdateException ex)
            {
                if (ex.GetBaseException() is SqlException sqlException)
                {
                    var number = sqlException.Number;

                    if (number == 547)
                    {
                        message = Core.Resources.UI.AdminPanel.PanelResource.ItemIsUsedYouCannotDeleteIt;
                    }
                }
            }
            catch
            {
                message = Messages.AnErrorOccuredWhileDeleteItem;
            }

            return Json(new { success, message });
        }
    }
}