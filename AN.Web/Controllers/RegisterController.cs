using AN.BLL.Core.Services.Messaging.Notifications;
using AN.BLL.DataRepository.Persons;
using AN.Core.Domain;
using AN.Core.Models;
using AN.Core.ViewModels;
using AN.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Shared.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AN.Web.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IPersonService _personService;
        private readonly BanobatDbContext _dbContext;
        private readonly ILogger<RegisterController> _logger;
        private readonly IOptions<AppSettings> _settings;
        private readonly INotificationService _notificationService;
        public RegisterController(IPersonService personService, BanobatDbContext dbContext, ILogger<RegisterController> logger, IOptions<AppSettings> options, INotificationService notificationService)
        {
            _personService = personService;
            _dbContext = dbContext;
            _logger = logger;
            _settings = options;
            _notificationService = notificationService;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("register/centers")]
        public async Task<IActionResult> RegisterCenters(RegisterPoliClinicViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    _logger.LogError("######## Model Is Not Valid");
                    _logger.LogError($"######## - Captcha Response: {model.GoogleReCaptchaResponse}");
                    foreach (var modelStateVal in ViewData.ModelState.Values)
                    {
                        foreach (var error in modelStateVal.Errors)
                        {
                            var errorMessage = error.ErrorMessage;
                            var exception = error.Exception;
                            _logger.LogError($"######## - {errorMessage}: {exception}");
                        }
                    }
                    return Redirect("https://awronore.krd/register-error.html");
                }

                // Prevent XSS Attacks
                //model.FirstName = Sanitizer.GetSafeHtmlFragment(model.FirstName);

                //model.SecondName = Sanitizer.GetSafeHtmlFragment(model.SecondName);

                //model.ThirdName = Sanitizer.GetSafeHtmlFragment(model.ThirdName);

                //model.Description = Sanitizer.GetSafeHtmlFragment(model.Description);

                //model.Email = Sanitizer.GetSafeHtmlFragment(model.Email);

                //model.PoliClinicAddress = Sanitizer.GetSafeHtmlFragment(model.PoliClinicAddress);

                //model.PoliClinicName = Sanitizer.GetSafeHtmlFragment(model.PoliClinicName);

                //model.Mobile = Sanitizer.GetSafeHtmlFragment(model.Mobile);

                if (string.IsNullOrEmpty(model.FirstName) || string.IsNullOrEmpty(model.SecondName) || string.IsNullOrEmpty(model.ThirdName) || string.IsNullOrEmpty(model.Description) || string.IsNullOrEmpty(model.Email) || string.IsNullOrEmpty(model.PoliClinicAddress) || string.IsNullOrEmpty(model.PoliClinicName))
                {
                    throw new Exception("Model data is not valid");
                }

                if (string.IsNullOrEmpty(model.Mobile)) throw new Exception("Mobile is not valid");

                if (model.Mobile.Length > 10)
                {
                    model.Mobile = model.Mobile.Substring(model.Mobile.Length - 10);
                }
                else if (model.Mobile.Length < 10)
                {
                    model.Mobile = model.Mobile.PadLeft(10, '0');
                    _logger.LogError($"######## - Mobile smaller than 10 ({model.Mobile})");
                }

                var isMobileValid = long.TryParse(model.Mobile, out long mobileNumber);

                if (!isMobileValid) throw new Exception("Mobile is not valid");

                var existPerson = await _dbContext.Persons.FirstOrDefaultAsync(x => x.Mobile == model.Mobile);

                var phones = new List<ShiftCenterPhoneModel>
                {
                    new ShiftCenterPhoneModel
                    {
                        PhoneNumber = model.Mobile
                    }
                };

                var strategy = _dbContext.Database.CreateExecutionStrategy();
                await strategy.ExecuteAsync(async () =>
                {
                    using (var transaction = _dbContext.Database.BeginTransaction())
                    {
                        var center = new ShiftCenter
                        {
                            Type = model.CenterType,
                            Name = model.PoliClinicName,
                            Name_Ku = model.PoliClinicName,
                            Name_Ar = model.PoliClinicName,
                            Description = model.Description,
                            Description_Ku = model.Description,
                            Description_Ar = model.Description,
                            CityId = model.CityId,
                            Address = model.PoliClinicAddress,
                            Address_Ku = model.PoliClinicAddress,
                            Address_Ar = model.PoliClinicAddress,
                            IsIndependent = true,
                            ClinicId = null,
                            BookingRestrictionHours = 0,
                            CreatedAt = DateTime.Now,
                            PhoneNumbers = phones,
                            IsApproved = false,
                            IsDeleted = false,
                            ActiveDaysAhead = 30,
                            AutomaticScheduleEnabled = false,
                            FinalBookMessage = "",
                            FinalBookMessage_Ar = "",
                            FinalBookMessage_Ku = "",
                            FinalBookSMSMessage = "",
                            FinalBookSMSMessage_Ar = "",
                            FinalBookSMSMessage_Ku = "",
                            Notification = "",
                            Notification_Ar = "",
                            Notification_Ku = "",
                            PrescriptionPath = "",
                            Location = new NetTopologySuite.Geometries.Point(0.0, 0.0)
                            {
                                SRID = 4326 // Set the SRID (spatial reference system id) to 4326, which is the spatial reference system used by Google maps (WGS84)
                            },
                        };

                        await _dbContext.ShiftCenters.AddAsync(center);

                        await _dbContext.SaveChangesAsync();

                        var person = existPerson;

                        if (person == null)
                        {
                            person = new Person
                            {
                                Mobile = model.Mobile,
                                MobileConfirmed = false,
                                FirstName = model.FirstName,
                                FirstName_Ku = model.FirstName,
                                FirstName_Ar = model.FirstName,
                                SecondName = model.SecondName,
                                SecondName_Ku = model.SecondName,
                                SecondName_Ar = model.SecondName,
                                ThirdName = model.ThirdName,
                                ThirdName_Ku = model.ThirdName,
                                ThirdName_Ar = model.ThirdName,
                                UniqueId = await _personService.GenerateUniqueIdAsync(),
                                Avatar = null,
                                Age = 0,
                                Gender = model.Gender,
                                BloodType = Core.Enums.BloodType.Unknown,
                                IsApproved = false,
                                IsEmployee = false,
                                IsDeleted = false,
                                Birthdate = DateTime.Now,
                                Address = "",
                                CreatedAt = DateTime.Now,
                                CreationPlaceId = null,
                                CreatorRole = Shared.Enums.LoginAs.UNKNOWN,
                                Email = model.Email,
                                Description = "",
                                Weight = 0,
                                Height = 0,
                                ZipCode = "",
                                IdNumber = "",
                                Language = null,
                                MarriageStatus = null
                            };

                            await _dbContext.Persons.AddAsync(person);

                            await _dbContext.SaveChangesAsync();
                        }

                        var centerPerson = new ShiftCenterPersons
                        {
                            IsManager = true,
                            PersonId = person.Id,
                            ShiftCenterId = center.Id,
                            CreatedAt = DateTime.Now                           
                        };

                        await _dbContext.ShiftCenterPersons.AddAsync(centerPerson);

                        await _dbContext.SaveChangesAsync();

                        transaction.Commit();
                    }
                });

                try
                {
                    // Send notification for agents here
                    var agents = _settings?.Value?.AwroNoreSettings?.RequestAppointmentAgents;
                    if (agents != null && agents.Any())
                    {
                        foreach (var agent in agents)
                        {
                            var agentPerson = await _dbContext.Persons.FirstOrDefaultAsync(x => x.Mobile == agent);

                            if (agentPerson != null)
                            {
                                var title = "Registration Request";
                                var message = "New Registration Request Created";
                                foreach (var item in agentPerson.FcmInstanceIds)
                                {
                                    await _notificationService.SendFcmToSingleDeviceAsync(item.InstanceId, title, message);
                                }
                            }
                        }
                    }
                }
                catch
                {
                    // IGNORED
                }

                _logger.LogInformation("####### Registered Successfully");

                return Redirect("https://awronore.krd/registered-successfully.html");
            }
            catch (Exception e)
            {
                _logger.LogError($"######## {e.Message}");
                return Redirect("https://awronore.krd/register-error.html");
            }
        }
    }
}