using AN.BLL.DataRepository;
using AN.BLL.DataRepository.Persons;
using AN.BLL.DataRepository.Polyclinics;
using AN.BLL.DataRepository.ServiceSupplies;
using AN.BLL.Services.IdentityServer;
using AN.Core.Enums;
using AN.Core.Exceptions;
using AN.Core.Extensions;
using AN.Core.Resources.EntitiesResources.Role;
using AN.Web.Areas.Admin.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Shared.Constants;
using Shared.DTO;
using Shared.Enums;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AN.Web.Areas.Admin.Controllers
{
    public class UserController : AdminController
    {
        private readonly IIdentityService _identityService;
        private readonly IPersonService _personService;
        private readonly IShiftCenterService _shiftCenterService;
        private readonly IPharmacyRepository _pharmacyRepository;
        private readonly IServiceSupplyService _serviceSupplyService;
        private readonly IMapper _mapper;
        private readonly ILogger<UserController> _logger;
        public UserController(IIdentityService identityService, IPersonService personService, IShiftCenterService shiftCenterService, IPharmacyRepository pharmacyRepository, IServiceSupplyService serviceSupplyService, IMapper mapper, ILogger<UserController> logger)
        {
            _identityService = identityService;
            _personService = personService;
            _shiftCenterService = shiftCenterService;
            _pharmacyRepository = pharmacyRepository;
            _serviceSupplyService = serviceSupplyService;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Lang = Lng;

            ViewBag.RolesList = GetRolesListItems();

            ViewBag.CentersList = await _shiftCenterService.GetSelectListAsync(Lng);

            ViewBag.PersonsList = await GetPersonListItemsAsync();

            return View(new UserListViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> LoadTable([FromBody] DataTablesParameters param)
        {
            try
            {
                var filtersModel = JsonConvert.DeserializeObject<UserFilterModel>(param.FiltersObject);

                var queryModel = new UsersQueryModel
                {
                    Parameters = param,
                    FilterModel = filtersModel
                };

                var url = IdentityAPI.Getting.PostQueryAsync(_identityService.IdentityBaseUrl, "user");

                var result = await _identityService.GetAsync<UsersQueryModel, UsersResultDTO>(url, queryModel);

                var users = result.Users.Select(async (x) => new UserListViewModel
                {
                    Id = x.Id,
                    UserName = x.UserName,
                    Mobile = x.Mobile,
                    Role = RolesResource.ResourceManager.GetString(x.Role),
                    Person = x.PersonId == null ? "" : Lng == Lang.KU ? (await _personService.GetByIdAsync(x.PersonId.Value))?.FullName_Ku :
                                                       Lng == Lang.AR ? (await _personService.GetByIdAsync(x.PersonId.Value))?.FullName_Ar : (await _personService.GetByIdAsync(x.PersonId.Value))?.FullName,
                    Center = x.CenterId == null ? "" : x.LoginAs == LoginAs.PHARMACYMANAGER ?
                                                       Lng == Lang.KU ? (await _pharmacyRepository.GetByIdAsync(x.CenterId.Value))?.Name_Ku :
                                                       Lng == Lang.AR ? (await _pharmacyRepository.GetByIdAsync(x.CenterId.Value))?.Name_Ar : (await _pharmacyRepository.GetByIdAsync(x.CenterId.Value))?.Name
                                                       :
                                                       Lng == Lang.KU ? (await _shiftCenterService.GetByIdAsync(x.CenterId.Value))?.Name_Ku :
                                                       Lng == Lang.AR ? (await _shiftCenterService.GetByIdAsync(x.CenterId.Value))?.Name_Ar : (await _shiftCenterService.GetByIdAsync(x.CenterId.Value))?.Name,
                    LockoutStatusHtml = await this.RenderViewToStringAsync("_UserItemLockoutStatus", (x.Id, x.IsLocked)),
                    ActionsHtml = await this.RenderViewToStringAsync("_UserItemActions", (x.Id, x.IsLocked))
                }).ToList();

                var finalUsers = await Task.WhenAll(users);

                return new JsonResult(new DataTablesResult<UserListViewModel>
                {
                    Draw = param.Draw,
                    Data = finalUsers.ToList(),
                    RecordsFiltered = result.TotalCount,
                    RecordsTotal = result.TotalCount
                });
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return new JsonResult(new { error = "Internal Server Error" });
            }
        }

        public async Task<IActionResult> CreateUpdate(string id)
        {
            ViewBag.RolesList = GetRolesListItems();

            ViewBag.CentersList = new List<SelectListItem>();

            ViewBag.PersonsList = await GetPersonListItemsAsync();

            ViewBag.ServiceSuppliesList = new List<SelectListItem>();

            if (string.IsNullOrEmpty(id)) return PartialView("Create", new UserCreateViewModel());

            var user = await _identityService.GetByIdAsync<UserDTO>("user", id);

            if (user == null) throw new AwroNoreException("User Not Found");

            if (user.Roles != null && user.Roles.Any())
            {
                ViewBag.CentersList = await GetCentersForRole(user.Roles.FirstOrDefault());
            }

            if (user.UserProfile.CenterId != null)
            {
                ViewBag.ServiceSuppliesList = await _serviceSupplyService.GetSelectListAsync(user.UserProfile.CenterId);
            }

            var updateViewModel = new UserUpdateViewModel
            {
                Id = user.Id,
                Email = user.Email,
                Mobile = user.Mobile,
                TwoFactorEnabled = user.TwoFactorEnabled,
                CenterId = user.UserProfile.CenterId,
                PersonId = user.UserProfile.PersonId,
                Role = user.Roles.FirstOrDefault(),
                ServiceSupplyIds = user.UserProfile.ServiceSupplyIds
            };

            return PartialView("Update", updateViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUpdate(UserCreateViewModel model)
        {
            if (model.Id == null && !ModelState.IsValid) return Json(new { success = false });

            var loginAs = SystemRoles.GetLoginAs(model.Role);

            if (loginAs == LoginAs.UNKNOWN) throw new AwroNoreException("User role is not valid");

            if (loginAs == LoginAs.ADMIN)
            {
                model.CenterId = null;
                model.ServiceSupplyIds = new List<int>();
            }
            else
            {
                if (model.CenterId == null) throw new AwroNoreException("No center is selected to manage");

                if (loginAs == LoginAs.POLYCLINICMANAGER || loginAs == LoginAs.SONARMANAGER || loginAs == LoginAs.LABMANAGER)
                {
                    var shiftCenter = await _shiftCenterService.GetByIdAsync(model.CenterId.Value);

                    if (shiftCenter == null) throw new AwroNoreException("You must select a center to manage");

                    if (loginAs == LoginAs.POLYCLINICMANAGER)
                    {
                        if (shiftCenter.Type != ShiftCenterType.Polyclinic && shiftCenter.Type != ShiftCenterType.Dentist && shiftCenter.Type != ShiftCenterType.HomeCare)
                            throw new AwroNoreException("You must select a center to manage");
                    }

                    if (loginAs == LoginAs.SONARMANAGER && shiftCenter.Type != ShiftCenterType.Sonography) throw new AwroNoreException("You must select a center to manage");

                    if (loginAs == LoginAs.LABMANAGER && shiftCenter.Type != ShiftCenterType.Laboratory) throw new AwroNoreException("You must select a center to manage");

                    if (model.ServiceSupplyIds.Any())
                    {
                        foreach (var item in model.ServiceSupplyIds)
                        {
                            var serviceSupply = shiftCenter.ServiceSupplies.FirstOrDefault(x => x.Id == item);

                            if (serviceSupply == null) throw new AwroNoreException("Selected doctor for center is not exists in center");
                        }
                    }
                }
                else if (loginAs == LoginAs.PHARMACYMANAGER)
                {
                    var pharmacy = await _pharmacyRepository.GetByIdAsync(model.CenterId.Value);

                    if (pharmacy == null) throw new AwroNoreException("You must select a pharmacy to manage");
                }
                else if (loginAs == LoginAs.BEAUTYCENTERMANAGER)
                {
                    var beautyCenter = await _shiftCenterService.GetByIdAsync(model.CenterId.Value);

                    if (beautyCenter == null || beautyCenter.Type != ShiftCenterType.BeautyCenter) throw new AwroNoreException("You must select a beauty center to manage");

                    if (model.ServiceSupplyIds.Any())
                    {
                        foreach (var item in model.ServiceSupplyIds)
                        {
                            var serviceSupply = beautyCenter.ServiceSupplies.FirstOrDefault(x => x.Id == item);

                            if (serviceSupply == null) throw new AwroNoreException("Selected doctor for center is not exists in center");
                        }
                    }
                }
            }

            var userDTO = new UserDTO
            {
                Id = model.Id,
                UserName = model.UserName,
                Email = model.Email,
                IsSystemUser = false,
                Mobile = model.Mobile,
                Password = model.Password,
                TwoFactorEnabled = model.TwoFactorEnabled,
                UserProfile = new UserProfileDTO
                {
                    CenterId = model.CenterId,
                    PersonId = model.PersonId,
                    ServiceSupplyIds = model.ServiceSupplyIds,
                    LoginAs = SystemRoles.GetLoginAs(model.Role)
                },
                Roles = new List<string> { model.Role }
            };

            if (model.Id == null)
            {
                var (_, isSucceeded, message, _, _) = await _identityService.PostCreateAsync("user", userDTO);

                return Json(new { success = isSucceeded, message });
            }
            else
            {
                var (isSucceeded, message) = await _identityService.PutUpdateAsync("user", userDTO);

                return Json(new { success = isSucceeded, message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            var (isSucceeded, message) = await _identityService.DeleteUserAsync("user", id);

            message = isSucceeded ? Core.Resources.EntitiesResources.Messages.ItemDeletedSuccessFully : message;

            return Json(new { success = isSucceeded, message });
        }

        [HttpGet]
        public async Task<IActionResult> Lockout(string id, bool isLocked)
        {
            var model = new LockoutUserDTO
            {
                Id = id,
                IsLocked = isLocked
            };

            var (isSucceeded, message) = await _identityService.PutLockoutAsync("user", model);

            message = isSucceeded ? Core.Resources.EntitiesResources.Messages.ActionDoneSuccesfully : message;

            return Json(new { success = isSucceeded, message });
        }

        public async Task<List<SelectListItem>> GetCentersForRole(string role)
        {
            var loginAs = SystemRoles.GetLoginAs(role);

            if (loginAs == LoginAs.POLYCLINICMANAGER)
            {
                return await _shiftCenterService.GetSelectListAsync(Lng, new List<ShiftCenterType> {
                    ShiftCenterType.Polyclinic,
                    ShiftCenterType.Dentist,
                    ShiftCenterType.HomeCare
                });
            }
            else if (loginAs == LoginAs.PHARMACYMANAGER)
            {
                return await _pharmacyRepository.GetSelectListItemsAsync(Lng);
            }
            else if (loginAs == LoginAs.SONARMANAGER)
            {
                return await _shiftCenterService.GetSelectListAsync(Lng, new List<ShiftCenterType> { ShiftCenterType.Sonography });
            }
            else if (loginAs == LoginAs.LABMANAGER)
            {
                return await _shiftCenterService.GetSelectListAsync(Lng, new List<ShiftCenterType> { ShiftCenterType.Laboratory });
            }
            else if (loginAs == LoginAs.BEAUTYCENTERMANAGER)
            {
                return await _shiftCenterService.GetSelectListAsync(Lng, new List<ShiftCenterType> { ShiftCenterType.BeautyCenter });
            }
            return new List<SelectListItem>();
        }

        public async Task<IList<SelectListItem>> GetServiceSuppliesForCenter(int centerId)
        {
            var result = await _serviceSupplyService.GetSelectListAsync(centerId);

            return result;
        }

        #region Helper Methods
        private List<SelectListItem> GetRolesListItems()
        {
            var rolesList = new List<SelectListItem>
            {
                new SelectListItem { Value = SystemRoles.ADMIN, Text = RolesResource.admin },
                new SelectListItem { Value = SystemRoles.POLYCLINICMANAGER , Text = RolesResource.polyclinicmanager },
                new SelectListItem { Value = SystemRoles.DOCTOR, Text = RolesResource.doctor },
                new SelectListItem { Value = SystemRoles.SECRETARY, Text = RolesResource.secretary },
                new SelectListItem { Value = SystemRoles.PHARMACYMANAGER, Text = RolesResource.pharmacymanager },
                new SelectListItem { Value = SystemRoles.SONARMANAGER, Text = RolesResource.sonarmanager },
                new SelectListItem { Value = SystemRoles.LABMANAGER, Text = RolesResource.labmanager },
                new SelectListItem { Value = SystemRoles.BEAUTYCENTERMANAGER, Text = RolesResource.beautycentermanager },

                new SelectListItem { Value = SystemRoles.CALLCENTER, Text = RolesResource.callcenter },
                new SelectListItem { Value = SystemRoles.HOMECARE, Text = RolesResource.homecare },
                new SelectListItem { Value = SystemRoles.EMS, Text = RolesResource.ems },
                new SelectListItem { Value = SystemRoles.MEDICALTOURISM, Text = RolesResource.medicaltourism },
            };

            return rolesList;
        }

        private async Task<List<SelectListItem>> GetPersonListItemsAsync()
        {
            var personsList = new List<SelectListItem>
            {
                new SelectListItem{Value = "", Text = "..."},
            };
            personsList.AddRange(await _personService.GetSelectListAsync(Lng));
            return personsList;
        }
        #endregion
    }
}