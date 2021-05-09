using AN.BLL.Core.Services.Messaging.Notifications;
using AN.BLL.DataRepository;
using AN.BLL.Extensions;
using AN.BLL.Services.Upload;
using AN.Core.Domain;
using AN.Core.DTO;
using AN.Core.Enums;
using AN.Core.Exceptions;
using AN.Core.Extensions;
using AN.Core.Resources.EntitiesResources;
using AN.Core.ViewModels;
using AN.DAL;
using AN.Web.App_Code;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Shared.Models;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AN.Web.Areas.Admin.Controllers
{
    public class CmsController : AdminController
    {
        private readonly IContentCategoryRepository _categoryRepository;
        private readonly IContentArticleRepository _articleRepository;
        private readonly BanobatDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IUploadService _uploadService;
        private readonly INotificationService _notificationService;
        public CmsController(IContentCategoryRepository categoryRepository,
                             IContentArticleRepository articleRepository,
                             BanobatDbContext dbContext,
                             IMapper mapper,
                             IUploadService uploadService,
                             INotificationService notificationService)
        {
            _categoryRepository = categoryRepository;
            _articleRepository = articleRepository;
            _dbContext = dbContext;
            _mapper = mapper;
            _uploadService = uploadService;
            _notificationService = notificationService;
        }

        #region Categories
        public IActionResult Categories()
        {
            ViewBag.Lang = Lng;

            ViewBag.LayoutStyles = MyEnumExtensions.EnumToSelectList<ContentLayoutStyle>().ToList();

            return View(new CmsCategoryItemViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> LoadCmsCategoryTable([FromBody] DataTablesParameters param)
        {
            try
            {
                var filtersModel = JsonConvert.DeserializeObject<CmsCategoryFilterViewModel>(param.FiltersObject);

                var results = await _categoryRepository.GetDataTableAsync(param, filtersModel, Lng);

                var categories = await Task.WhenAll(results.Items.Select(async (x) => new CmsCategoryItemViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    CreateDate = x.CreateDate,
                    LayoutStyle = x.LayoutStyle,
                    ActionsHtml = await this.RenderViewToStringAsync("_CmsCategoryItemActions", x.Id)
                }).ToList());

                return new JsonResult(new DataTablesResult<CmsCategoryItemViewModel>
                {
                    Draw = param.Draw,
                    Data = categories,
                    RecordsFiltered = results.TotalSize,
                    RecordsTotal = results.TotalSize
                });
            }
            catch (Exception e)
            {
                return new JsonResult(new { error = "Internal Server Error" });
            }
        }

        [HttpGet]
        public async Task<IActionResult> CreateUpdateCategory(int? id)
        {
            ViewBag.LayoutStyles = MyEnumExtensions.EnumToSelectList<ContentLayoutStyle>().ToList();

            var model = new CmsCategoryCreateUpdateViewModel
            {
                Id = id
            };

            if (id != null)
            {
                var category = await _dbContext.ContentCategories.FindAsync(id);

                if (category == null) throw new AwroNoreException("Category not found");

                model = _mapper.Map<CmsCategoryCreateUpdateViewModel>(category);
            }

            return PartialView(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateUpdateCategory(CmsCategoryCreateUpdateViewModel model)
        {
            if (model.Id != null)
            {
                var category = await _dbContext.ContentCategories.FindAsync(model.Id);

                if (category == null) throw new AwroNoreException("Category not found");

                category.Title = model.Title;
                category.Title_Ar = model.Title_Ar;
                category.Title_Ku = model.Title_Ku;
                category.LayoutStyle = model.LayoutStyle;
                category.UpdatedAt = DateTime.Now;

                _dbContext.Entry(category).State = EntityState.Modified;
            }
            else
            {
                var category = _mapper.Map<ContentCategory>(model);

                await _dbContext.ContentCategories.AddAsync(category);
            }

            await _dbContext.SaveChangesAsync();

            return Json(new { success = true, message = Messages.ActionDoneSuccesfully });
        }

        public async Task<IActionResult> DeleteCategory(int id)
        {
            string message = Messages.AnErrorOccuredWhileDeleteItem;
            bool success = false;
            try
            {
                var category = await _dbContext.ContentCategories.FindAsync(id);

                if (category != null)
                {
                    _dbContext.ContentCategories.Remove(category);

                    await _dbContext.SaveChangesAsync();
                }

                message = Messages.ItemDeletedSuccessFully;

                success = true;
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
        #endregion

        #region Articles
        public async Task<IActionResult> Articles()
        {
            ViewBag.Lang = Lng;

            ViewBag.ContentCategories = await _dbContext.ContentCategories.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = Lng == Lang.AR ? x.Title_Ar : Lng == Lang.KU ? x.Title_Ku : x.Title }).ToListAsync();

            return View(new CmsArticleItemViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> LoadCmsArticleTable([FromBody] DataTablesParameters param)
        {
            try
            {
                var filtersModel = JsonConvert.DeserializeObject<CmsArticleFilterViewModel>(param.FiltersObject);

                if (!string.IsNullOrEmpty(filtersModel.IsPublishedFilter))
                {
                    filtersModel.IsPublished = filtersModel.IsPublishedFilter == "on" ? true : false;
                }

                var results = await _articleRepository.GetDataTableAsync(param, filtersModel, Lng);

                var articles = await Task.WhenAll(results.Items.Select(async (x) => new CmsArticleItemViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    CreateDate = x.CreateDate,
                    Category = x.Category,
                    IsPublished = x.IsPublished,
                    Summary = x.Summary,
                    ImageHtml = await this.RenderViewToStringAsync("_CmsArticleImage", x.ImageUrl),
                    ActionsHtml = await this.RenderViewToStringAsync("_CmsArticleItemActions", x.Id),
                }).ToList());

                return new JsonResult(new DataTablesResult<CmsArticleItemViewModel>
                {
                    Draw = param.Draw,
                    Data = articles,
                    RecordsFiltered = results.TotalSize,
                    RecordsTotal = results.TotalSize
                });
            }
            catch (Exception e)
            {
                return new JsonResult(new { error = "Internal Server Error" });
            }
        }

        [HttpGet]
        public async Task<IActionResult> CreateUpdateArticle(int? id)
        {
            ViewBag.ReaderTypes = MyEnumExtensions.EnumToSelectList<ArticleReaderType>().ToList();

            ViewBag.ContentCategories = await _dbContext.ContentCategories.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = Lng == Lang.AR ? x.Title_Ar : Lng == Lang.KU ? x.Title_Ku : x.Title }).ToListAsync();

            var model = new CmsArticleCreateUpdateViewModel
            {
                Id = id
            };

            if (id != null)
            {
                var article = await _dbContext.ContentArticles.FindAsync(id);

                if (article == null) throw new AwroNoreException("Article not found");

                if (!string.IsNullOrEmpty(article.ThumbnailUrl))
                {
                    ViewBag.AvatarPreview = "<img src=" + article.ThumbnailUrl + " alt=\"Image\">";
                }

                if (!string.IsNullOrEmpty(article.ThumbnailUrl_Ku))
                {
                    ViewBag.AvatarPreviewKu = "<img src=" + article.ThumbnailUrl_Ku + " alt=\"Image\">";
                }

                if (!string.IsNullOrEmpty(article.ThumbnailUrl_Ar))
                {
                    ViewBag.AvatarPreviewAr = "<img src=" + article.ThumbnailUrl_Ar + " alt=\"Image\">";
                }

                model = _mapper.Map<CmsArticleCreateUpdateViewModel>(article);
            }

            return PartialView(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateUpdateArticle(CmsArticleCreateUpdateViewModel model)
        {
            var success = false;
            var message = Core.Resources.Global.Global.Err_ErrorOccured;

            var strategy = _dbContext.Database.CreateExecutionStrategy();
            await strategy.ExecuteAsync(async () =>
            {
                using (var transaction = _dbContext.Database.BeginTransaction())
                {
                    ContentArticle article;

                    if (model.Id != null)
                    {
                        article = await _dbContext.ContentArticles.FindAsync(model.Id);

                        if (article == null) throw new AwroNoreException("Article not found");

                        article.Title = model.Title;
                        article.Title_Ar = model.Title_Ar;
                        article.Title_Ku = model.Title_Ku;
                        article.Summary = model.Summary;
                        article.Summary_Ar = model.Summary_Ar;
                        article.Summary_Ku = model.Summary_Ku;
                        article.Body = model.Body;
                        article.Body_Ar = model.Body_Ar;
                        article.Body_Ku = model.Body_Ku;
                        article.ContentCategoryId = model.ContentCategoryId;
                        article.IsPublished = model.IsPublished;
                        article.ReaderType = model.ReaderType;
                        article.UpdatedAt = DateTime.Now;

                        _dbContext.Entry(article).State = EntityState.Modified;

                        await _dbContext.SaveChangesAsync();

                        message = Messages.ItemUpdatedSuccessFully;
                    }
                    else
                    {
                        article = _mapper.Map<ContentArticle>(model);

                        await _dbContext.ContentArticles.AddAsync(article);

                        await _dbContext.SaveChangesAsync();

                        message = Messages.ItemAddedSuccessFully;
                    }

                    if (model.Image != null)
                    {
                        var (newName, thumbName, dirPath, baseUrl) = _uploadService.GenerateCmsArticleImageName(article.Id, Lang.EN.ToString(), model.Image);

                        article.ImageUrl = $"{baseUrl}/{newName}";

                        article.ThumbnailUrl = $"{baseUrl}/{thumbName}";

                        _dbContext.ContentArticles.Attach(article);

                        _dbContext.Entry(article).State = EntityState.Modified;

                        await _dbContext.SaveChangesAsync();

                        await _uploadService.UploadCmsArticleImageAsync(model.Image, dirPath, newName, thumbName);
                    }

                    if (model.Image_Ku != null)
                    {
                        var (newName, thumbName, dirPath, baseUrl) = _uploadService.GenerateCmsArticleImageName(article.Id, Lang.KU.ToString(), model.Image_Ku);

                        article.ImageUrl_Ku = $"{baseUrl}/{newName}";

                        article.ThumbnailUrl_Ku = $"{baseUrl}/{thumbName}";

                        _dbContext.ContentArticles.Attach(article);

                        _dbContext.Entry(article).State = EntityState.Modified;

                        await _dbContext.SaveChangesAsync();

                        await _uploadService.UploadCmsArticleImageAsync(model.Image_Ku, dirPath, newName, thumbName);
                    }

                    if (model.Image_Ar != null)
                    {
                        var (newName, thumbName, dirPath, baseUrl) = _uploadService.GenerateCmsArticleImageName(article.Id, Lang.AR.ToString(), model.Image_Ar);

                        article.ImageUrl_Ar = $"{baseUrl}/{newName}";

                        article.ThumbnailUrl_Ar = $"{baseUrl}/{thumbName}";

                        _dbContext.ContentArticles.Attach(article);

                        _dbContext.Entry(article).State = EntityState.Modified;

                        await _dbContext.SaveChangesAsync();

                        await _uploadService.UploadCmsArticleImageAsync(model.Image_Ar, dirPath, newName, thumbName);
                    }

                    if (model.SendNotification)
                    {
                        if (!model.IsPublished) throw new AwroNoreException("For send notification, you must publish article");

                        var title = article.Title ?? article.Title_Ku ?? article.Title_Ar;
                        var titleKu = article.Title_Ku ?? article.Title ?? article.Title_Ar;
                        var titleAr = article.Title_Ar ?? article.Title_Ku ?? article.Title;

                        var body = article.Summary ?? article.Summary_Ku ?? article.Summary_Ar;
                        var bodyKu = article.Summary_Ku ?? article.Summary ?? article.Summary_Ar;
                        var bodyAr = article.Summary_Ar ?? article.Summary_Ku ?? article.Summary;

                        var articleDTO = new CmsArticleDTO
                        {
                            Id = article.Id,
                            CategoryId = article.ContentCategoryId,
                            ReaderType = article.ReaderType,
                            Title = title,
                            Summary = body
                        };

                        await _notificationService.SendPublishArticleNotificationAsync(new BaseNotificationPayload
                        {
                            Title = title,
                            TitleKu = titleKu,
                            TitleAr = titleAr,
                            Body = body?.TruncateLongString(50),
                            BodyKu = bodyKu?.TruncateLongString(50),
                            BodyAr = bodyAr?.TruncateLongString(50),
                        }, articleDTO);
                    }

                    transaction.Commit();

                    success = true;

                }
            });

            return Json(new { success, message });
        }

        public async Task<IActionResult> DeleteArticle(int id)
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
                        var article = await _dbContext.ContentArticles.FindAsync(id);

                        if (article != null)
                        {
                            _dbContext.ContentArticles.Remove(article);

                            await _dbContext.SaveChangesAsync();

                            _uploadService.RemoveCmsArticleImages(id);
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
        #endregion
    }
}