using Identity.BLL.Services.Kurtename;
using Identity.BLL.Services.Plivo;
using Identity.BLL.Services.RouteMobile;
using Identity.Core.Domain;
using Identity.Core.Exceptions;
using Identity.Core.Models;
using Identity.DAL;
using Identity.DAL.Repository;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Shared.Constants;
using Shared.DTO;
using Shared.Models;
using Shared.Resources.IdentityMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.BLL.DataRepository.UserRepository
{
    public class UserRepository : Repository<ApplicationUser>, IUserRepository
    {
        private readonly AppIdentityDbContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IPlivoSmsService _plivoSmsService;
        private readonly IKurtenameSmsService _kurtenameSmsService;
        private readonly IRouteMobileService _routeMobileService;
        private readonly ILogger<UserRepository> _logger;
        private readonly IOptions<AppSettings> _settings;
        public UserRepository(AppIdentityDbContext dbContext, 
                              UserManager<ApplicationUser> userManager, 
                              RoleManager<ApplicationRole> roleManager, 
                              IPlivoSmsService plivoSmsService, 
                              IKurtenameSmsService kurtenameSmsService,
                              IRouteMobileService routeMobileService,
                              ILogger<UserRepository> logger, 
                              IOptions<AppSettings> settings) : base(dbContext)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _roleManager = roleManager;
            _plivoSmsService = plivoSmsService;
            _kurtenameSmsService = kurtenameSmsService;
            _routeMobileService = routeMobileService;
            _logger = logger;
            _settings = settings;
        }

        public async Task<string> GenerateAndSendOTPAsync(string mobile)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.UserName == mobile);

            if(user == null) throw new AwronoreIdentityException("Not any user found for this mobile number");

            // TODO: This is just for apple review
            if(mobile == "7500001122")
            {
                return "2020";
            }

            if (user.LastOTPTime != null)
            {
                var diffSeconds = (DateTime.UtcNow - user.LastOTPTime.Value).TotalSeconds;

                if (diffSeconds < _settings.Value.AwronoreSettings.OtpTimeOut) throw new AwronoreIdentityException("OTP is sended to you before. please try again in 2 minutes later");
            }

            var digit = 4;
            string otp;
            do
            {
                otp = new Random().Next(0, (int)Math.Pow(10, digit) - 1).ToString("####");
            } while (otp.Length != 4);

            var msg = string.Format("Phone number {0} OTP is {1}", mobile, otp);

            _logger.LogInformation(string.Format("\n{0}\n{1}\n{0}\n", new string('*', msg.Length), msg));

            var receipinet = $"964{mobile}";

            var receipinets = new List<string> { receipinet };           

            var strategy = _dbContext.Database.CreateExecutionStrategy();

            await strategy.ExecuteAsync(async () =>
            {
                using (var transaction = _dbContext.Database.BeginTransaction())
                {
                    user.LastOTPCode = otp;

                    user.LastOTPTime = DateTime.UtcNow;

                    _dbContext.Entry(user).State = EntityState.Modified;

                    await _dbContext.SaveChangesAsync();

                    // await _plivoSmsService.SendSmsAsync(receipinets, msg);

                    //await _kurtenameSmsService.SendSmsAsync(receipinet, msg);

                    await _routeMobileService.SendSmsAsync(receipinet, msg);

                    transaction.Commit();                    
                }
            });

            return otp;
        }

        public ApplicationUser GetUserAccount(string mobile)
        {
            if (string.IsNullOrEmpty(mobile) || mobile.Length < 10) throw new Exception("Mobile is not valid");

            var isNumeric = double.TryParse(mobile, out _);

            if (!isNumeric) throw new Exception("Mobile Number Is Not Valid");

            if (mobile.Length > 10)
            {
                mobile = mobile.Substring(mobile.Length - 10);
            }

            var current = _dbContext.Users.FirstOrDefault(x => x.UserName == mobile);

            if (current != null) return current;

            InsertNewUserAccount(mobile, mobile, mobile, out Guid id);

            current = _dbContext.Users.FirstOrDefault(x => x.UserName == mobile);

            return current;
        }

        public void InsertNewUserAccount(string username, string password, string phone, out Guid userGuid)
        {
            var isNumeric = double.TryParse(phone, out _);

            if (!isNumeric) throw new Exception("Mobile Number Is Not Valid");

            if (username == phone)
            {
                if (phone.Length < 10)
                    throw new Exception("Mobile Length Must Be 10");

                if (phone.Length > 10)
                {
                    phone = phone.Substring(phone.Length - 10);
                    username = phone;
                }
            }

            userGuid = Guid.NewGuid();
            Insert(new ApplicationUser
            {
                Id = userGuid.ToString(),
                UserName = username,
                NormalizedUserName = username.ToUpper(),
                PasswordHash = password.Sha256(),
                PhoneNumber = phone,
                PhoneNumberConfirmed = true,
                TwoFactorEnabled = true,
                SecurityStamp = $"{userGuid}".Sha256()
            });
            _dbContext.SaveChanges();
        }

        public async Task<ApplicationUser> FindBySubjectIdAsync(string subjectId)
        {
            var user = await _userManager.FindByIdAsync(subjectId);

            var userProfile = await _dbContext.UserProfiles.FirstOrDefaultAsync(x => x.UserId == subjectId);

            if (user != null)
            {
                user.UserProfile = userProfile;
            }

            return user;
        }

        public async Task<IList<string>> GetRolesAsync(ApplicationUser user)
        {
            var result = await _userManager.GetRolesAsync(user);

            return result;
        }

        public async Task<UserDTO> GetUserByIdAsync(string id)
        {
            if (string.IsNullOrEmpty(id)) throw new ArgumentNullException("User id is null");

            var user = await _userManager.FindByIdAsync(id);

            if (user == null) throw new Exception("User not found");

            var roles = await _dbContext.UserRoles.Where(x => x.UserId == user.Id).Select(r => r.Role.Name).ToListAsync();

            var userProfile = await _dbContext.UserProfiles.FirstOrDefaultAsync(x => x.UserId == id);

            var result = new UserDTO
            {
                Id = user.Id,
                UserName = user.UserName,
                Mobile = user.PhoneNumber,
                Email = user.Email,
                TwoFactorEnabled = user.TwoFactorEnabled,
                IsSystemUser = user.IsSystemUser,
                UserProfile = new UserProfileDTO
                {
                    CenterId = userProfile?.CenterId,
                    PersonId = userProfile?.PersonId,
                    ServiceSupplyIds = userProfile?.ServiceSupplyIds,
                    LoginAs = userProfile?.LoginAs ?? Shared.Enums.LoginAs.UNKNOWN,
                },
                Roles = roles
            };

            return result;
        }

        public async Task<(bool isSucceed, string message, string createdId)> CreateUserAsync(UserDTO model)
        {
            try
            {
                if (model == null) throw new ArgumentNullException("User data is null");

                if (!SystemRoles.GetAllSystemRoles.Contains(model.Roles.FirstOrDefault())) throw new Exception("Role is not valid");

                var user = new ApplicationUser
                {
                    UserName = model.UserName.Trim().ToLower(),
                    NormalizedUserName = model.UserName.Trim().ToUpper(),
                    TwoFactorEnabled = model.TwoFactorEnabled,
                    IsSystemUser = model.IsSystemUser,
                    UserProfile = new UserProfile
                    {
                        PersonId = model.UserProfile.PersonId,
                        CenterId = model.UserProfile.CenterId,
                        ServiceSupplyIds = model.UserProfile.ServiceSupplyIds,
                        LoginAs = model.UserProfile.LoginAs,
                        IsDeleted = false,
                        CreatedAt = DateTime.Now,
                    }
                };

                if (!string.IsNullOrEmpty(model.Email))
                {
                    user.Email = model.Email.Trim().ToLower();
                    user.NormalizedEmail = model.Email.Trim().ToUpper();
                    user.EmailConfirmed = true;
                }

                if (!string.IsNullOrEmpty(model.Mobile))
                {
                    var isNumeric = double.TryParse(model.Mobile, out _);

                    if (!isNumeric) throw new Exception(Shared.Resources.GlobalShared.CreateUserSuccess);

                    if (model.Mobile.Length < 10) throw new Exception(Shared.Resources.GlobalShared.CreateUserSuccess);

                    if (model.Mobile.Length > 10)
                    {
                        model.Mobile = model.Mobile.Substring(model.Mobile.Length - 10);
                    }

                    user.PhoneNumber = model.Mobile;
                    user.PhoneNumberConfirmed = true;
                }

                var createResult = await _userManager.CreateAsync(user, model.Password);

                if (createResult.Succeeded)
                {
                    foreach (var role in model.Roles)
                    {
                        try
                        {
                            await _userManager.AddToRoleAsync(user, role.Trim().ToLower());
                        }
                        catch { }
                    }

                    return (true, Shared.Resources.GlobalShared.CreateUserSuccess, user.Id);
                }

                throw new Exception(createResult.Errors.FirstOrDefault().Description);
            }
            catch (Exception e)
            {
                return (false, e.Message, string.Empty);
            }
        }

        public async Task<(bool isSucceed, string message)> UpdateUserAsync(UserDTO model)
        {
            try
            {
                var (isSucceed, message) = (true, "User updated successfully");

                var user = await _userManager.FindByIdAsync(model.Id);

                if (user == null) throw new Exception("User not found");

                user.Email = model.Email;
                if (!string.IsNullOrEmpty(model.Email))
                {
                    user.Email = model.Email.Trim().ToLower();
                    user.NormalizedEmail = model.Email.Trim().ToUpper();
                    user.EmailConfirmed = true;
                }
                user.PhoneNumber = model.Mobile;
                user.TwoFactorEnabled = model.TwoFactorEnabled;

                var userProfile = await _dbContext.UserProfiles.FirstOrDefaultAsync(x => x.UserId == user.Id);

                if(userProfile == null) throw new Exception("User profile not found");

                userProfile.PersonId = model.UserProfile.PersonId;
                userProfile.LoginAs = model.UserProfile.LoginAs;
                userProfile.CenterId = model.UserProfile.CenterId;
                userProfile.ServiceSupplyIds = model.UserProfile.ServiceSupplyIds;

                _dbContext.Entry(userProfile).State = EntityState.Modified;

                var result = await _userManager.UpdateAsync(user);

                if (!result.Succeeded)
                {
                    isSucceed = false;
                    message = result.Errors.FirstOrDefault().Description;
                }
                else
                {
                    if(!await _userManager.IsInRoleAsync(user, model.Roles.FirstOrDefault()))
                    {
                        var userRoles = await _dbContext.UserRoles.Where(x => x.UserId == user.Id).ToListAsync();
                        if (userRoles.Any())
                        {
                            foreach(var item in userRoles)
                            {
                                var role = await _roleManager.FindByIdAsync(item.RoleId);
                                if(role != null)
                                {
                                    await _userManager.RemoveFromRoleAsync(user, role.Name);
                                }                                
                            }
                        }

                        foreach (var role in model.Roles)
                        {
                            try
                            {
                                await _userManager.AddToRoleAsync(user, role.Trim().ToLower());
                            }
                            catch { }
                        }
                    }
                    await _dbContext.SaveChangesAsync();
                }

                return (isSucceed, message);
            }
            catch (Exception e)
            {
                return (false, e.Message);
            }
        }

        public async Task<(bool isSucceed, string message)> DeleteUserAsync(string id)
        {
            try
            {
                var (isSucceed, message) = (true, "User deleted successfully");

                var user = await _userManager.FindByIdAsync(id);

                if (user.UserName == "rootadmin" || user.UserName == "admin" || user.IsSystemUser) throw new Exception("You can not remove system user");

                if (user != null)
                {
                    var result = await _userManager.DeleteAsync(user);

                    if (!result.Succeeded)
                    {
                        isSucceed = false;
                        message = result.Errors.FirstOrDefault().Description;
                    }
                }

                return (isSucceed, message);
            }
            catch (Exception e)
            {
                return (false, e.Message);
            }
        }

        public async Task<UsersResultDTO> GetUsersPagingListAsync(UsersQueryModel queryModel)
        {
            var filterModel = queryModel.FilterModel;

            var tableParams = queryModel.Parameters;

            IQueryable<ApplicationUser> query = _dbContext.Users.Include(x => x.UserProfile).Include(x => x.UserRoles);

            query = query.Where(x => !x.IsSystemUser && x.UserProfile != null);

            if (!string.IsNullOrEmpty(filterModel.FilterString))
            {
                query = query.Where(x => x.UserName.Contains(filterModel.FilterString) || x.PhoneNumber.Contains(filterModel.FilterString));
            }

            if (!string.IsNullOrEmpty(filterModel.Role))
            {
                var role = await _roleManager.FindByNameAsync(filterModel.Role);

                if (role != null)
                {
                    query = query.Where(x => x.UserRoles.Any(ur => ur.RoleId == role.Id));
                }
            }

            if (filterModel.CenterId != null)
            {
                query = query.Where(x => x.UserProfile != null && x.UserProfile.CenterId == filterModel.CenterId);
            }

            if (filterModel.PersonId != null)
            {
                query = query.Where(x => x.UserProfile != null && x.UserProfile.PersonId == filterModel.PersonId);
            }

            if (tableParams.Order != null && tableParams.Order.Any())
            {
                var orderIndex = tableParams.Order[0].Column;
                var orderDir = tableParams.Order[0].Dir;

                if (orderIndex == 1)
                {
                    query = orderDir == DataTablesOrderDir.DESC ? query.OrderByDescending(x => x.UserName) : query.OrderBy(x => x.UserName);
                }
                else if (orderIndex == 2)
                {
                    query = orderDir == DataTablesOrderDir.DESC ? query.OrderByDescending(x => x.UserProfile.PersonId) : query.OrderBy(x => x.UserProfile.PersonId);
                }
                else if (orderIndex == 3)
                {
                    query = orderDir == DataTablesOrderDir.DESC ? query.OrderByDescending(x => x.UserProfile.CenterId) : query.OrderBy(x => x.UserProfile.CenterId);
                }
                else if (orderIndex == 4)
                {
                    query = orderDir == DataTablesOrderDir.DESC ? query.OrderByDescending(x => x.PhoneNumber) : query.OrderBy(x => x.PhoneNumber);
                }
            }
            else
            {
                query = query.OrderByDescending(x => x.UserProfile.LoginAs);
            }

            var size = await query.CountAsync();

            try
            {
                var users = await query.AsNoTracking().Skip((tableParams.Start / tableParams.Length) * tableParams.Length).Take(tableParams.Length).ToListAsync();

                var finalUsers = new List<UserListItemDTO>();

                foreach (var x in users)
                {
                    var roleId = string.Empty;
                    var roleName = string.Empty;
                    if (x.UserRoles != null && x.UserRoles.Any())
                    {
                        var userRole = x.UserRoles.FirstOrDefault();
                        var role = await _roleManager.FindByIdAsync(userRole.RoleId);
                        if (role != null)
                        {
                            roleId = role.Id;
                            roleName = role.Name;
                        }
                    }

                    finalUsers.Add(new UserListItemDTO
                    {
                        Id = x.Id,
                        UserName = x.UserName,
                        Mobile = x.PhoneNumber,
                        LoginAs = x.UserProfile.LoginAs,
                        CenterId = x.UserProfile.CenterId,
                        PersonId = x.UserProfile.PersonId,
                        ServiceSupplyIds = x.UserProfile.ServiceSupplyIds,
                        Role = roleName,
                        RoleId = roleId,
                        IsLocked = x.LockoutEnabled && x.LockoutEnd.HasValue && x.LockoutEnd > DateTime.Now
                    });
                }

                return new UsersResultDTO
                {
                    Users = finalUsers,
                    TotalCount = size
                };

            }
            catch (Exception)
            {
                return new UsersResultDTO
                {
                    Users = new List<UserListItemDTO>(),
                    TotalCount = size
                };
            }
        }

        public async Task<(bool isSucceed, string message)> ChangePasswordAsync(ChangePasswordDTO model)
        {
            try
            {
                var (isSucceed, message) = (true, "Password changed successfully");

                var user = await _userManager.FindByNameAsync(model.Username);

                if (user == null) throw new Exception("User not found");

                if (user.UserName == "rootadmin" || user.UserName == "admin" || user.IsSystemUser) throw new Exception("You can not change system user password");

                var result = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);

                if (!result.Succeeded)
                {
                    isSucceed = false;

                    message = GetIdentityResultMessage(result, "Error in change password");
                }

                return (isSucceed, message);
            }
            catch (Exception e)
            {
                return (false, e.Message);
            }
        }

        public async Task<(bool isSucceed, string message)> LockoutUserAccountAsync(LockoutUserDTO model)
        {
            try
            {
                var (isSucceed, message) = (true, model.IsLocked ? "User lockedout successfully" : "User unlock successfully");

                var user = await _userManager.FindByIdAsync(model.Id);

                if (user == null) throw new Exception("User not found");

                if (user.UserName.ToLower().Equals("rootadmin") || user.UserName == "admin" || user.IsSystemUser) throw new Exception("You can not lockout system user");

                IdentityResult result;

                if (model.IsLocked)
                {
                    result = await _userManager.SetLockoutEnabledAsync(user, true);

                    if (result.Succeeded)
                    {
                        if (model.ForDays.HasValue)
                        {
                            result = await _userManager.SetLockoutEndDateAsync(user, DateTimeOffset.UtcNow.AddDays(model.ForDays.Value));
                        }
                        else
                        {
                            result = await _userManager.SetLockoutEndDateAsync(user, DateTimeOffset.MaxValue);
                        }
                    }
                }
                else
                {
                    result = await _userManager.SetLockoutEndDateAsync(user, null);
                }

                if (!result.Succeeded)
                {
                    isSucceed = false;
                    message = GetIdentityResultMessage(result, "Unknown error occured");
                }

                return (isSucceed, message);
            }
            catch (Exception e)
            {
                return (false, e.Message);
            }
        }

        private string GetIdentityResultMessage(IdentityResult result, string defaultMessage = "")
        {
            if (result == null) return defaultMessage;

            var identityError = result.Errors.FirstOrDefault();

            if (identityError == null) return defaultMessage;

            return IdentityMessages.ResourceManager.GetString(identityError.Code) ?? identityError.Description;
        }
    }
}
