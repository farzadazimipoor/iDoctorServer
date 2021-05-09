using AN.BLL.DataRepository.Persons;
using AN.BLL.Services.IdentityServer;
using AN.Core.Domain;
using AN.Core.Enums;
using AN.Core.Exceptions;
using AN.Core.Models;
using AN.Core.ViewModels;
using AN.DAL;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.Constants;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AN.Web.API.Controllers
{
    [Route("api/awronore/[controller]")]
    [ApiController]
    public class DownloadController : ANBaseApiController
    {
        private readonly BanobatDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IPersonService _personService;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IIdentityService _identityService;
        public DownloadController(BanobatDbContext dbContext, IMapper mapper, IPersonService personService, IHostingEnvironment hostingEnvironment, IIdentityService identityService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _personService = personService;
            _hostingEnvironment = hostingEnvironment;
            _identityService = identityService;
        }

        private string BasePrescriptLocalPath => "wwwroot\\uploaded\\prescriptions\\prescript_base.mrt";

        private string BasePrescriptFullPath => Path.Combine(_hostingEnvironment.ContentRootPath, BasePrescriptLocalPath);

        private  string ContentType => "application/zip";

        private  string ZipFilePath => Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", $"uploaded\\archive\\apps\\offlineapp.zip");

        private  string ReadmeFileName => "SetupPackage/PrimaryVolumePath/Awronore/InitiateData.xml";

        private string Role => "polyclinicmanager";

        /// <summary>
        /// Serves a file as ZIP.
        /// </summary>
        [HttpPost("offlineapp", Name = "GetOfflineZipFile")]
        public async Task<IActionResult> GetZipFile([FromBody]RegisterDownloadAppModel inputModel)
        {
            HttpContext.Response.ContentType = ContentType;

            byte[] resultFileBytes = null;

            // Center & Person Data
            #region Validations
            if (string.IsNullOrEmpty(inputModel.Mobile)) throw new Exception("Mobile is not valid");

            if (inputModel.Mobile.Length > 10)
            {
                inputModel.Mobile = inputModel.Mobile.Substring(inputModel.Mobile.Length - 10);
            }
            else if (inputModel.Mobile.Length < 10)
            {
                inputModel.Mobile = inputModel.Mobile.PadLeft(10, '0');
            }

            var isMobileValid = long.TryParse(inputModel.Mobile, out long mobileNumber);

            if (!isMobileValid) throw new AwroNoreException("Mobile is not valid");

            var existPerson = await _dbContext.Persons.FirstOrDefaultAsync(x => x.Mobile == inputModel.Mobile);

            var existCenter = await _dbContext.ShiftCenters.FirstOrDefaultAsync(x => x.Type == inputModel.CenterType && x.Name == inputModel.PoliClinicName && x.Name_Ku == inputModel.PoliClinicName && x.Name_Ar == inputModel.PoliClinicName && x.CityId == inputModel.CityId);

            var phones = new List<ShiftCenterPhoneModel>
                {
                    new ShiftCenterPhoneModel
                    {
                        PhoneNumber = inputModel.Mobile
                    }
            }; 
            #endregion

            var strategy = _dbContext.Database.CreateExecutionStrategy();
            await strategy.ExecuteAsync(async () =>
            {
                using (var transaction = _dbContext.Database.BeginTransaction())
                {
                    // DB operations
                    // TODO: Add db operations here (Create person & Center)
                    #region ShiftCenter
                    var center = existCenter;
                    if (center == null)
                    {
                        center = new ShiftCenter
                        {
                            Type = inputModel.CenterType,
                            Name = inputModel.PoliClinicName,
                            Name_Ku = inputModel.PoliClinicName,
                            Name_Ar = inputModel.PoliClinicName,
                            Description = inputModel.Description,
                            Description_Ku = inputModel.Description,
                            Description_Ar = inputModel.Description,
                            CityId = inputModel.CityId,
                            Address = inputModel.PoliClinicAddress,
                            Address_Ku = inputModel.PoliClinicAddress,
                            Address_Ar = inputModel.PoliClinicAddress,
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
                            Notification = "Offline",
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
                    }

                    var person = existPerson;
                    if (person == null)
                    {
                        person = new Person
                        {
                            Mobile = inputModel.Mobile,
                            MobileConfirmed = false,
                            FirstName = inputModel.FirstName,
                            FirstName_Ku = inputModel.FirstName,
                            FirstName_Ar = inputModel.FirstName,
                            SecondName = inputModel.SecondName,
                            SecondName_Ku = inputModel.SecondName,
                            SecondName_Ar = inputModel.SecondName,
                            ThirdName = inputModel.ThirdName,
                            ThirdName_Ku = inputModel.ThirdName,
                            ThirdName_Ar = inputModel.ThirdName,
                            UniqueId = await _personService.GenerateUniqueIdAsync(),
                            Avatar = null,
                            Age = 0,
                            Gender = inputModel.Gender,
                            BloodType = Core.Enums.BloodType.Unknown,
                            IsApproved = true,
                            IsEmployee = true,
                            IsDeleted = false,
                            Birthdate = DateTime.Now,
                            Address = "",
                            CreatedAt = DateTime.Now,
                            CreationPlaceId = null,
                            CreatorRole = Shared.Enums.LoginAs.UNKNOWN,
                            Email = inputModel.Email,
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
                    #endregion

                    #region ShiftCenter Person
                    var centerPerson = await _dbContext.ShiftCenterPersons.FirstOrDefaultAsync(x => x.PersonId == person.Id && x.ShiftCenterId == center.Id);
                    if (centerPerson == null)
                    {
                        centerPerson = new ShiftCenterPersons
                        {
                            IsManager = true,
                            PersonId = person.Id,
                            ShiftCenterId = center.Id,
                            CreatedAt = DateTime.Now
                        };

                        await _dbContext.ShiftCenterPersons.AddAsync(centerPerson);

                        await _dbContext.SaveChangesAsync();
                    }
                    #endregion

                    #region Service Supply
                    var serviceSupply = await _dbContext.ServiceSupplies.FirstOrDefaultAsync(x => x.PersonId == person.Id && x.ShiftCenterId == center.Id);
                    if (serviceSupply == null)
                    {
                        serviceSupply = new ServiceSupply
                        {
                            Duration = 5,
                            ShiftCenterId = center.Id,
                            ReservationType = ReservationType.Selective,
                            PersonId = person.Id,
                            OnlineReservationPercent = 100,
                            IsAvailable = false,
                            StartReservationDate = DateTime.Now,
                            VisitPrice = 0,
                            PrePaymentPercent = 0,
                            PaymentType = PaymentType.Free,
                            ReservationRangeStartPoint = 0,
                            ReservationRangeEndPointPosition = Position.AFTER,
                            ReservationRangeEndPointDiffMinutes = 30,
                            RankScore = 0,
                            CreatedAt = DateTime.Now,
                            Notification = "",
                            Notification_Ar = "",
                            Notification_Ku = "",
                            PrescriptionPath = ""
                        };

                        _dbContext.ServiceSupplies.Add(serviceSupply);

                        await _dbContext.SaveChangesAsync();

                        await _dbContext.ServiceSupplyInfo.AddAsync(new ServiceSupplyInfo
                        {
                            ServiceSupplyId = serviceSupply.Id,
                            MedicalCouncilNumber = "",
                            AcceptionDate = DateTime.Now,
                            Bio = "",
                            Bio_Ar = "",
                            Bio_Ku = "",
                            Website = "",
                            Description = "#Requested",
                            Description_Ar = "#Requested",
                            Description_Ku = "#Requested",
                            Picture = "",
                            IsDeleted = false,
                            WorkExperience = 0,
                            CreatedAt = DateTime.Now
                        });

                        await _dbContext.SaveChangesAsync();
                    }
                    #endregion

                    #region Prescription File
                    var destinationDirPath = $"wwwroot\\uploaded\\prescriptions\\shiftcenters\\{center.Id}\\{serviceSupply.Id}";

                    var fullDestinationDirPath = Path.Combine(_hostingEnvironment.ContentRootPath, destinationDirPath);

                    if (!Directory.Exists(fullDestinationDirPath))
                    {
                        Directory.CreateDirectory(fullDestinationDirPath);
                    }

                    _dbContext.Entry(serviceSupply).State = EntityState.Modified;

                    serviceSupply.PrescriptionPath = Path.Combine(destinationDirPath, $"prescript_{serviceSupply.Id}.mrt");

                    await _dbContext.SaveChangesAsync();

                    var destinationPrescriptPath = Path.Combine(_hostingEnvironment.ContentRootPath, serviceSupply.PrescriptionPath);

                    if (!System.IO.File.Exists(destinationPrescriptPath))
                    {
                        // Remove all existing files
                        try
                        {
                            DirectoryInfo di = new DirectoryInfo("fullDestinationDirPath");

                            foreach (FileInfo file in di.GetFiles())
                            {
                                file.Delete();
                            }
                        }
                        catch
                        {
                            // Ignored
                        }
                        try
                        {
                            System.IO.File.Copy(BasePrescriptFullPath, destinationPrescriptPath, true);
                        }
                        catch
                        {
                            throw new AwroNoreException("Can not copy prescription file. please try again");
                        }
                    }
                    #endregion

                    // HTTP operations
                    #region Identity User
                    var userDTO = new UserDTO
                    {
                        UserName = inputModel.Username,
                        Email = inputModel.Email,
                        IsSystemUser = false,
                        Mobile = inputModel.Mobile,
                        Password = inputModel.Password,
                        TwoFactorEnabled = false,
                        UserProfile = new UserProfileDTO
                        {
                            CenterId = center.Id,
                            PersonId = person.Id,
                            ServiceSupplyIds = new List<int> { serviceSupply.Id },
                            LoginAs = SystemRoles.GetLoginAs(Role)
                        },
                        Roles = new List<string> { Role }
                    };

                    var (_, isSucceeded, message, _, _) = await _identityService.PostCreateAsync("user", userDTO);
                    
                    // if (!isSucceeded) throw new AwroNoreException(message);
                    #endregion

                    // IO operations
                    #region Zip Archive Operations
                    using (FileStream zipToOpen = new FileStream(ZipFilePath, FileMode.Open))
                    {
                        using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Update))
                        {
                            // Delete old readme file
                            var item = archive.Entries.FirstOrDefault(x => x.FullName == ReadmeFileName);
                            if (item != null)
                            {
                                item.Delete();
                            }

                            // Create new readme file
                            var readmeEntry = archive.CreateEntry(ReadmeFileName);

                            // Read new file and write data
                            using (Stream writer = readmeEntry.Open())
                            {
                                var xmlSerializer = new XmlSerializer(typeof(RegisterOfflineResult));

                                var resultModel = new RegisterOfflineResult
                                {
                                    Doctor = _mapper.Map<RegisterOfflineData>(inputModel)
                                };

                                xmlSerializer.Serialize(writer, resultModel);
                            }
                        }
                    }

                    resultFileBytes = await System.IO.File.ReadAllBytesAsync(ZipFilePath); 
                    #endregion

                    transaction.Commit();
                }
            });

            // Create result file
            var result = new FileContentResult(resultFileBytes, ContentType)
            {
                FileDownloadName = $"{Path.GetFileName(ZipFilePath)}"
            };

            return result;
        }
    }
}