using AN.BLL.Core.Services;
using AN.BLL.DataRepository.Appointments;
using AN.BLL.DataRepository.HealthServices;
using AN.BLL.DataRepository.Persons;
using AN.BLL.DataRepository.Rating;
using AN.BLL.DataRepository.ServiceSupplies;
using AN.BLL.Extensions;
using AN.BLL.Helpers;
using AN.Core.DTO;
using AN.Core.DTO.Doctors;
using AN.Core.DTO.Rating;
using AN.Core.Enums;
using AN.Core.Exceptions;
using AN.Core.Models;
using AN.Core.Resources.Global;
using AN.Core.Resources.New;
using AN.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AN.BLL.Services.Doctors
{
    public class DoctorsService : IDoctorsService
    {
        private readonly BanobatDbContext _dbContext;
        private readonly IAppointmentService _appointmentService;
        private readonly IServiceSupplyService _serviceSupplyService;
        private readonly IDoctorServiceManager _doctorServiceManager;
        private readonly IServicesService _servicesService;
        private readonly IRatingService _ratingService;
        private readonly IPersonService _userService;
        public DoctorsService(BanobatDbContext dbContext,
                              IServiceSupplyService serviceSupplyService,
                              IDoctorServiceManager doctorServiceManager,
                              IServicesService servicesService,
                              IRatingService ratingService,
                              IAppointmentService appointmentService,
                              IPersonService userService)
        {
            _dbContext = dbContext;
            _serviceSupplyService = serviceSupplyService;
            _doctorServiceManager = doctorServiceManager;
            _servicesService = servicesService;
            _ratingService = ratingService;
            _appointmentService = appointmentService;
            _userService = userService;
        }

        public async Task<DoctorScheduleInfoDTO> GetSchedulesAsync(int ssId, Lang lang)
        {
            var query = _dbContext.UsualSchedulePlans.Where(x => x.ServiceSupplyId == ssId).OrderBy(x => x.DayOfWeek);

            var morning = await query.Where(x => x.Shift == ScheduleShift.Morning).GroupBy(x => x.DayOfWeek).Select(cms => new DayScheduleInfoDTO
            {
                DayOfWeek = cms.Key.GetLocalizedDayOfWeek(lang),
                Schedules = cms.Select(s => new ScheduleInfoDTO
                {
                    DayOfWeek = s.DayOfWeek.GetLocalizedDayOfWeek(lang),
                    StartTime = s.StartTime,
                    EndTime = s.EndTime,
                    Service = s.ShiftCenterService != null ? lang == Lang.EN ? s.ShiftCenterService.Service.Name : lang == Lang.KU ? s.ShiftCenterService.Service.Name_Ku : s.ShiftCenterService.Service.Name_Ar : null,
                    MaxCount = s.MaxCount
                }).ToList()
            }).ToListAsync();

            var evening = await query.Where(x => x.Shift == ScheduleShift.Evening).GroupBy(x => x.DayOfWeek).Select(cms => new DayScheduleInfoDTO
            {
                DayOfWeek = cms.Key.GetLocalizedDayOfWeek(lang),
                Schedules = cms.Select(s => new ScheduleInfoDTO
                {
                    DayOfWeek = s.DayOfWeek.GetLocalizedDayOfWeek(lang),
                    StartTime = s.StartTime,
                    EndTime = s.EndTime,
                    Service = s.ShiftCenterService != null ? lang == Lang.EN ? s.ShiftCenterService.Service.Name : lang == Lang.KU ? s.ShiftCenterService.Service.Name_Ku : s.ShiftCenterService.Service.Name_Ar : null,
                    MaxCount = s.MaxCount
                }).ToList()
            }).ToListAsync();

            var result = new DoctorScheduleInfoDTO
            {
                Morning = morning,
                Evening = evening
            };

            return result;
        }

        public async Task<List<CenterTypeDTO>> GetSupportAppointmentsCenterTypesAsync(string baseUrl)
        {
            var result = new List<CenterTypeDTO>();

            var query = _dbContext.ShiftCenters.Where(x => x.SupportAppointments && x.ServiceSupplies.Any());

            foreach (ShiftCenterType p in Enum.GetValues(typeof(ShiftCenterType)))
            {
                if (await query.AnyAsync(q => q.Type.HasFlag(p)))
                {
                    result.Add(new CenterTypeDTO
                    {
                        Title = p.GetLocalizedDisplayName(),
                        IconPath = $"{baseUrl}/images/centers/{p.GetCenterTypeIconsFolderName()}/{p.GetCenterTypeIconsFolderName()}.png",
                        CenterType = p
                    });
                }
            }

            result = result.OrderBy(x => x.CenterType.GetCenterTypeOrder()).ToList();

            return result;
        }

        public async Task<List<ServiceDTO>> GetCenterServicesAsync(int serviceSupplyId, Lang lang)
        {
            var servicesSupply = await _serviceSupplyService.GetServiceSupplyByIdAsync(serviceSupplyId);

            if (servicesSupply == null) return new List<ServiceDTO>();

            var result = servicesSupply.ShiftCenter.PolyclinicHealthServices.Select(ps => new ServiceDTO
            {
                Id = ps.Id,
                Name = lang == Lang.EN ? ps.Service.Name : lang == Lang.AR ? ps.Service.Name_Ar : ps.Service.Name_Ku,
                Price = ps.Price ?? ps.Service.Price,
                CategoryId = ps.Service.ServiceCategoryId,
                CurrencyType = ps.CurrencyType.ToString(),
                CategoryCenterType = ps.Service.ServiceCategory.CenterType
            }).ToList();

            return result;
        }

        public async Task<(long totalCount, int totalPages, List<DoctorListItemDTO>)> GetDoctorsListPagingAsync(DoctorFilterDTO filterModel, Lang lang, string hostAddress, int page = 0, int pageSize = 12)
        {
            if (filterModel == null) return (0, 0, new List<DoctorListItemDTO>());

            var query = _serviceSupplyService.Table;

            // Only centers that support appointments
            query = query.Where(x => x.ShiftCenter.SupportAppointments && x.Id != 1 && x.Id != 65);

            if(filterModel.CenterType != null)
            {
                // Only one center type
                query = query.Where(x => x.ShiftCenter.Type.HasFlag(filterModel.CenterType));
            }            

            // Filter by service
            if (filterModel.ServiceId != null)
            {
                query = query.Where(x => x.ShiftCenter.PolyclinicHealthServices.Any(ss => ss.HealthServiceId == filterModel.ServiceId));
            }

            //Filter by city
            if (filterModel.CityId != null)
            {
                query = query.Where(x => x.ShiftCenter.CityId == filterModel.CityId);
            }

            if (filterModel.CenterType == ShiftCenterType.Polyclinic || filterModel.CenterType == ShiftCenterType.Dentist)
            {
                if (filterModel.HospitalId != null)
                {
                    query = query.Where(x => x.ShiftCenter.Clinic.HospitalId == filterModel.HospitalId);
                }

                if (filterModel.ClinicId != null)
                {
                    query = query.Where(x => x.ShiftCenter.ClinicId == filterModel.ClinicId);
                }
            }

            //Filter by expertise category
            if (filterModel.SpecialityId != null)
            {
                query = query.Where(x => x.ServiceSupplyInfo != null && x.DoctorExpertises.Any(fe => filterModel.SpecialityId == fe.Expertise.ExpertiseCategoryId));
            }

            if (filterModel.SubSpecialityId != null)
            {
                query = query.Where(x => x.ServiceSupplyInfo != null && x.DoctorExpertises.Any(de => de.ExpertiseId == filterModel.SubSpecialityId));
            }

            if (filterModel.Expertises != null && filterModel.Expertises.Any())
            {
                query = query.Where(x => x.ServiceSupplyInfo != null && x.DoctorExpertises.Any(e => filterModel.Expertises.Contains(e.ExpertiseId)));
            }

            //Filter by name
            if (!string.IsNullOrEmpty(filterModel.FilterString))
            {
                query = query.Where(x =>
                (Global.Doctor + " " + x.Person.FirstName + " " + x.Person.SecondName + " " + x.Person.ThirdName).Contains(filterModel.FilterString) ||
                (Global.Doctor + " " + x.Person.FirstName_Ku + " " + x.Person.SecondName_Ku + " " + x.Person.ThirdName_Ku).Contains(filterModel.FilterString) ||
                (Global.Doctor + " " + x.Person.FirstName_Ar + " " + x.Person.SecondName_Ar + " " + x.Person.ThirdName_Ar).Contains(filterModel.FilterString));
            }

            if (filterModel.ConsultancyEnabled != null && filterModel.ConsultancyEnabled == true)
            {
                query = query.Where(x => x.ConsultancyEnabled);
            }

            // Filter by insurance
            if (filterModel.InsuranceId != null)
            {
                query = query.Where(x => x.Insurances.Any(i => i.InsuranceId == filterModel.InsuranceId));
            }

            var totalCount = await query.LongCountAsync();

            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

            if (!filterModel.HaveTurns)
            {
                query = query.OrderByDescending(x => x.TotalRating).ThenByDescending(x => x.Appointments.Count).Skip(pageSize * page).Take(pageSize);
            }

            var doctors = (from x in query.AsEnumerable()
                           let shiftCenterService = x.ShiftCenter.PolyclinicHealthServices.FirstOrDefault(ss => ss.HealthServiceId == filterModel.ServiceId)
                           let firstExpertise = x.DoctorExpertises.FirstOrDefault()
                           select new DoctorListItemDTO
                           {
                               Id = x.Id,
                               FullName = filterModel.CenterType == ShiftCenterType.BeautyCenter ? lang == Lang.KU ? x.ShiftCenter.Name_Ku : lang == Lang.AR ? x.ShiftCenter.Name_Ar : x.ShiftCenter.Name : lang == Lang.KU ? x.Person.FullName_Ku : lang == Lang.AR ? x.Person.FullName_Ar : x.Person.FullName,
                               Avatar = x.Person.RealAvatar,
                               ExpertiseCategory = firstExpertise != null ? lang == Lang.AR ? firstExpertise.Expertise.ExpertiseCategory.Name_Ar : lang == Lang.KU ? firstExpertise.Expertise.ExpertiseCategory.Name_Ku : firstExpertise.Expertise.ExpertiseCategory.Name : "",
                               Address = lang == Lang.KU ? x.ShiftCenter.Address_Ku : lang == Lang.AR ? x.ShiftCenter.Address_Ar : x.ShiftCenter.Address,
                               AverageRating = x.AverageRating != null ? (double)Math.Round((decimal)x.AverageRating, 2) : 5,
                               CenterServiceId = shiftCenterService?.Id,
                               Service = shiftCenterService == null ? "" : lang == Lang.KU ? shiftCenterService.Service.Name_Ku : lang == Lang.AR ? shiftCenterService.Service.Name_Ar : shiftCenterService.Service.Name,
                               ReservationType = x.ReservationType,
                               CenterType = x.ShiftCenter.Type,
                               // TODO: Reminder => Find Offers Too in this method (FindFirstDateEmptyTimePeriodsFromNow)
                               TimePeriods = shiftCenterService == null ? new DoctorTimePeriods() : _doctorServiceManager.FindFirstDateEmptyTimePeriodsFromNow(x, shiftCenterService),
                               ConsultancyEnabled = x.ConsultancyEnabled,
                               CanRequestTurn = x.ServiceSupplyInfo != null && x.ServiceSupplyInfo.Description.Contains("#Requested")
                           }).ToList();

            if (filterModel.HaveTurns == true)
            {
                doctors = doctors.Where(d => d.TimePeriods.TimePeriods.Any()).ToList();

                totalCount = doctors.Count;

                totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

                var result = doctors.Skip(pageSize * page).Take(pageSize).ToList();
            }

            return (totalCount, totalPages, doctors);
        }

        public async Task<DoctorsResultDTO> GetFavoriateDoctorsAsync(FavoriatesDTO model, Lang lang, string hostAddress)
        {
            if (model == null || !model.Favorites.Any()) return new DoctorsResultDTO
            {
                TotalCount = 0,
                Doctors = new List<DoctorListItemDTO>()
            };

            var query = _serviceSupplyService.Table;

            query = query.Where(x => x.ShiftCenter.SupportAppointments);

            query = query.Where(x => model.Favorites.Any(f => f.ServiceSupplyId == x.Id) && /*x.IsAvailable*/ x.Id != 1 && x.Id != 65);

            var totalCount = await query.LongCountAsync();

            var doctors = (from x in query.AsEnumerable()
                           let shiftCenterService = x.ShiftCenter.PolyclinicHealthServices.FirstOrDefault(ss => ss.Id == model.Favorites.FirstOrDefault(f => f.ServiceSupplyId == x.Id)?.CenterServiceId)
                           let firstExpertise = x.DoctorExpertises.FirstOrDefault()
                           select new DoctorListItemDTO
                           {
                               Id = x.Id,
                               FullName = lang == Lang.KU ? x.Person.FullName_Ku : lang == Lang.AR ? x.Person.FullName_Ar : x.Person.FullName,
                               Avatar = x.Person.RealAvatar,
                               ExpertiseCategory = firstExpertise != null ? lang == Lang.AR ? firstExpertise.Expertise.ExpertiseCategory.Name_Ar : lang == Lang.KU ? firstExpertise.Expertise.ExpertiseCategory.Name_Ku : firstExpertise.Expertise.ExpertiseCategory.Name : "",
                               Address = lang == Lang.KU ? x.ShiftCenter.Address_Ku : lang == Lang.AR ? x.ShiftCenter.Address_Ar : x.ShiftCenter.Address,
                               AverageRating = x.AverageRating != null ? (double)Math.Round((decimal)x.AverageRating, 2) : 5,
                               CenterServiceId = shiftCenterService?.Id,
                               Service = shiftCenterService == null ? "" : lang == Lang.KU ? shiftCenterService.Service.Name_Ku : lang == Lang.AR ? shiftCenterService.Service.Name_Ar : shiftCenterService.Service.Name,
                               ReservationType = x.ReservationType,
                               CenterType = x.ShiftCenter.Type,
                               // TODO: Reminder => Find Offers Too in this method (FindFirstDateEmptyTimePeriodsFromNow)
                               TimePeriods = shiftCenterService == null ? new DoctorTimePeriods() : _doctorServiceManager.FindFirstDateEmptyTimePeriodsFromNow(x, shiftCenterService),
                               ConsultancyEnabled = x.ConsultancyEnabled,
                               CanRequestTurn = x.ServiceSupplyInfo != null && x.ServiceSupplyInfo.Description.Contains("#Requested")
                           }).ToList();

            var result = new DoctorsResultDTO
            {
                TotalCount = totalCount,
                Doctors = doctors
            };

            return result;
        }

        public async Task<ReservationType> GetReservationTypeAsync(int serviceSupplyId)
        {
            var doctor = await _serviceSupplyService.GetServiceSupplyByIdAsync(serviceSupplyId);

            if (doctor == null) throw new AwroNoreException(Global.Err_DoctorNotFound);

            return doctor.ReservationType;
        }

        public async Task<DoctorDetailsDTO> GetDoctorDetailsAsync(int serviceSupplyId, Lang lang, int? centerServiceId = null, int? offerId = null)
        {
            var serviceSupply = await _serviceSupplyService.GetServiceSupplyByIdAsync(serviceSupplyId);

            if (serviceSupply == null) throw new AwroNoreException(Global.Err_DoctorNotFound);

            var Lng = lang;

            // Get all places that doctor work
            var suppliedSerivices = _serviceSupplyService.Table.Where(x => x.PersonId == serviceSupply.PersonId && x.IsAvailable).ToList();
            var healthCentersWorkingHours = new List<DoctorCenterModel>();
            foreach (var item in suppliedSerivices)
            {
                var centerName = "";
                var centertype = HealthCenterType.Polyclinic;
                var centerAddress = "";
                if (item.ShiftCenter.IsIndependent)
                {
                    centerName = Lng == Lang.AR ? item.ShiftCenter.Name_Ar : Lng == Lang.KU ? item.ShiftCenter.Name_Ku : item.ShiftCenter.Name;
                    centertype = HealthCenterType.Polyclinic;
                    centerAddress = Lng == Lang.AR ? $"{item.ShiftCenter.City.Name_Ar}: {item.ShiftCenter.Address_Ar}" : lang == Lang.KU ? $"{item.ShiftCenter.City.Name_Ku}: {item.ShiftCenter.Address_Ku}" : $"{item.ShiftCenter.City.Name}: {item.ShiftCenter.Address}";
                }
                else if (!item.ShiftCenter.IsIndependent && item.ShiftCenter.Clinic.IsIndependent)
                {
                    centerName = Lng == Lang.AR ? item.ShiftCenter.Clinic.Name_Ar : Lng == Lang.KU ? item.ShiftCenter.Clinic.Name_Ku : item.ShiftCenter.Clinic.Name;
                    centertype = HealthCenterType.Clinic;
                    centerAddress = Lng == Lang.AR ? item.ShiftCenter.Clinic.City.Name_Ar : Lng == Lang.KU ? item.ShiftCenter.Clinic.City.Name_Ku + ": " + item.ShiftCenter.Clinic.Address_Ku : item.ShiftCenter.Clinic.City.Name + ": " + item.ShiftCenter.Clinic.Address;
                }
                else
                {
                    centerName = Lng == Lang.AR ? item.ShiftCenter.Clinic.Hospital.Name_Ar : Lng == Lang.KU ? item.ShiftCenter.Clinic.Hospital.Name_Ku : item.ShiftCenter.Clinic.Hospital.Name;
                    centertype = HealthCenterType.Hospital;
                    centerAddress = Lng == Lang.AR ? $"{item.ShiftCenter.Clinic.Hospital.City.Name_Ar}: {item.ShiftCenter.Clinic.Hospital.Address_Ar}" : Lng == Lang.KU ? $"{item.ShiftCenter.Clinic.Hospital.City.Name_Ku}: {item.ShiftCenter.Clinic.Hospital.Address_Ku}" : $"{item.ShiftCenter.Clinic.Hospital.City.Name}: {item.ShiftCenter.Clinic.Hospital.Address}";
                }

                var WorkingHours = new List<WorkingHourModel>();
                var plans = item.UsualSchedulePlans.Where(x => x.ServiceSupplyId == serviceSupplyId).OrderBy(x => x.DayOfWeek).ToList();
                foreach (var schedule in plans)
                {
                    WorkingHours.Add(new WorkingHourModel
                    {
                        DayOfWeek = Utils.ConvertDayOfWeek(schedule.DayOfWeek.ToString()),
                        Shift = schedule.Shift == ScheduleShift.Morning ? Global.Morning : Global.Evening,
                        FromTime = schedule.StartTime,
                        ToTime = schedule.EndTime,
                        Service = Lng == Lang.AR ? schedule.ShiftCenterService?.Service.Name_Ar : Lng == Lang.KU ? schedule.ShiftCenterService?.Service.Name_Ku : schedule.ShiftCenterService?.Service.Name,
                        MaxCount = schedule.MaxCount
                    });
                }

                healthCentersWorkingHours.Add(new DoctorCenterModel
                {
                    CenterName = centerName,
                    CenterType = centertype,
                    CenterAddress = centerAddress,
                    WorkingHoures = WorkingHours
                });
            }

            TurnModel firstTurn = null;
            if (centerServiceId != null)
            {
                firstTurn = await GetNextFirstAvailableTurnAsync(serviceSupplyId, centerServiceId.Value, lang);
            }

            var firstExpertise = serviceSupply.DoctorExpertises.FirstOrDefault();

            var result = new DoctorDetailsDTO
            {
                Id = serviceSupply.Id,
                FullName = lang == Lang.KU ? serviceSupply.Person.FullName_Ku : lang == Lang.AR ? serviceSupply.Person.FullName_Ar : serviceSupply.Person.FullName,
                Avatar = serviceSupply.Person.RealAvatar,
                ExpertiseCategory = firstExpertise != null ? lang == Lang.AR ? firstExpertise.Expertise.ExpertiseCategory.Name_Ar : lang == Lang.KU ? firstExpertise.Expertise.ExpertiseCategory.Name_Ku : firstExpertise.Expertise.ExpertiseCategory.Name : "",
                Address = lang == Lang.KU ? serviceSupply.ShiftCenter.Address_Ku : lang == Lang.AR ? serviceSupply.ShiftCenter.Address_Ar : serviceSupply.ShiftCenter.Address,
                HasEmptyTurn = firstTurn != null,
                Province = serviceSupply.ShiftCenter.IsIndependent ? (Lng == Lang.AR ? serviceSupply.ShiftCenter.City.Province.Name_Ar : Lng == Lang.KU ? serviceSupply.ShiftCenter.City.Province.Name_Ku : serviceSupply.ShiftCenter.City.Province.Name) : (Lng == Lang.AR ? serviceSupply.ShiftCenter.Clinic.City.Province.Name_Ar : Lng == Lang.KU ? serviceSupply.ShiftCenter.Clinic.City.Province.Name_Ku : serviceSupply.ShiftCenter.Clinic.City.Province.Name),
                MedicalCouncilNumber = serviceSupply.ServiceSupplyInfo?.MedicalCouncilNumber,
                FirstAvailableTurn = firstTurn,
                Latitude = serviceSupply.ShiftCenter.Location?.Y.ToString(),
                Longitude = serviceSupply.ShiftCenter.Location?.X.ToString(),
                Schedules = await GetSchedulesAsync(serviceSupply.Id, lang)
            };
            if (serviceSupply.ShiftCenter.PhoneNumbers != null)
            {
                result.Phones = serviceSupply.ShiftCenter.PhoneNumbers.Where(p => p.IsForReserve).Select(x => new ShiftCenterPhoneModel
                {
                    PhoneNumber = x.PhoneNumber,
                    IsForReserve = x.IsForReserve
                }).ToList();
            }
            result.Expertises = serviceSupply.DoctorExpertises.Select(x => Lng == Lang.AR ? x.Expertise.Name_Ar : Lng == Lang.KU ? x.Expertise.Name_Ku : x.Expertise.Name).ToList();
            result.Description = Lng == Lang.AR ? serviceSupply.ShiftCenter.Description_Ar : Lng == Lang.KU ? serviceSupply.ShiftCenter.Description_Ku : serviceSupply.ShiftCenter.Description;
            result.Notification = Lng == Lang.AR ? serviceSupply.ShiftCenter.Notification_Ar : Lng == Lang.KU ? serviceSupply.ShiftCenter.Notification_Ku : serviceSupply.ShiftCenter.Notification;
            result.WorkingCenters = healthCentersWorkingHours;
            var photosQuery = _dbContext.Attachments.Where(x => x.Owner == FileOwner.SHIFT_CENTER && x.OwnerTableId == serviceSupply.ShiftCenterId && x.FileType == FileType.Image);
            result.Photos = await photosQuery.Select(x => x.Url).ToListAsync();
            result.PhotosThumbs = await photosQuery.Select(x => x.ThumbnailUrl).ToListAsync();

            result.Grades = serviceSupply.ServiceSupplyInfo?.DoctorScientificCategories.Select(x => Lng == Lang.AR ? x.ScientificCategory.Name_Ar : Lng == Lang.KU ? x.ScientificCategory.Name_Ku : x.ScientificCategory.Name).ToList();
            result.Bio = Lng == Lang.EN ? serviceSupply.ServiceSupplyInfo?.Bio : Lng == Lang.AR ? serviceSupply.ServiceSupplyInfo?.Bio_Ar : serviceSupply.ServiceSupplyInfo?.Bio_Ku;

            if (offerId != null)
            {
                var offer = await _dbContext.Offers.FindAsync(offerId);

                if (offer != null)
                {
                    offer.VisitsCount += 1;

                    _dbContext.Attach(offer);

                    _dbContext.Entry(offer).State = EntityState.Modified;

                    _dbContext.Offers.Update(offer);

                    await _dbContext.SaveChangesAsync();
                }
            }

            return result;
        }

        public async Task<List<ImageUrlModel>> GetDoctorsPhotosGallery(int serviceSupplyId, Lang lang)
        {
            var serviceSupply = await _serviceSupplyService.GetServiceSupplyByIdAsync(serviceSupplyId);

            if (serviceSupply == null) return new List<ImageUrlModel>();

            var images = await _dbContext.Attachments.Where(x => x.Owner == FileOwner.SHIFT_CENTER && x.OwnerTableId == serviceSupply.ShiftCenterId && x.FileType == FileType.Image).Select(x => new ImageUrlModel { Url = x.Url, ThumbUrl = x.ThumbnailUrl }).ToListAsync();

            return images;
        }

        /// <summary>
        /// Get Next First Available Turn For Doctor
        /// </summary>
        /// <param name="serviceSupplyId">Doctor or any person that supplies a service in shift center</param>
        /// <param name="centerServiceId">Service that will be supplied in shift center</param>
        /// <param name="lang">Request Language</param>
        /// <returns></returns>
        public async Task<TurnModel> GetNextFirstAvailableTurnAsync(int serviceSupplyId, int centerServiceId, Lang lang)
        {
            var serviceSupply = await _serviceSupplyService.GetServiceSupplyByIdAsync(serviceSupplyId);

            if (serviceSupply == null) throw new AwroNoreException(Global.Err_DoctorNotFound);

            if (!serviceSupply.IsAvailable) return null;

            var centerService = _servicesService.GetShiftCenterServiceById(centerServiceId);

            if (centerService == null) return null;

            var firstTurn = _doctorServiceManager.FindFirstEmptyTimePeriodFromNow(serviceSupply, centerService);

            if (firstTurn == null) return null;

            var result = new TurnModel
            {
                Date = firstTurn.StartDateTime.Date.ToShortDateString(),
                DayOfWeek = Utils.ConvertDayOfWeek(firstTurn.StartDateTime.DayOfWeek.ToString()),
                StartTime = firstTurn.StartDateTime.ToShortTimeString(),
                EndTime = firstTurn.EndDateTime.ToShortTimeString()
            };

            return result;
        }

        public async Task<DoctorReservationStatusDTO> GetDoctorReservationStatusAsync(int serviceSupplyId, int centerServiceId)
        {
            var serviceSupply = await _serviceSupplyService.GetServiceSupplyByIdAsync(serviceSupplyId);

            if (serviceSupply == null) throw new AwroNoreException(Global.Err_DoctorNotFound);

            var centerService = _servicesService.GetShiftCenterServiceById(centerServiceId);

            if (centerService == null) throw new AwroNoreException(NewResource.NotAnyServiceDefinedForThisCenter);

            if (!serviceSupply.IsAvailable)
            {
                return new DoctorReservationStatusDTO
                {
                    Id = serviceSupply.Id,
                    HasAvailableTurn = false,
                    Message = Global.NoAvailableTurnFound,
                    Description = serviceSupply.ShiftCenter.Type.HasFlag(ShiftCenterType.BeautyCenter) ? Global.BeautyCenterNotActive : Global.DoctorNotActive,
                    CanRequestTurn = serviceSupply.ServiceSupplyInfo != null && serviceSupply.ServiceSupplyInfo.Description.Contains("#Requested")
                };
            }

            var firstTurn = _doctorServiceManager.FindFirstEmptyTimePeriodFromNow(serviceSupply, centerService);

            if (firstTurn == null)
            {
                return new DoctorReservationStatusDTO
                {
                    Id = serviceSupply.Id,
                    HasAvailableTurn = false,
                    Message = Global.NoAvailableTurnFound,
                    Description = serviceSupply.ShiftCenter.Type.HasFlag(ShiftCenterType.BeautyCenter) ? Global.BeautyCenterNotHaveAvailableTurn : Global.DoctorNotHaveAvailableTurn,
                    CanRequestTurn = serviceSupply.ServiceSupplyInfo != null && serviceSupply.ServiceSupplyInfo.Description.Contains("#Requested")
                };
            }

            var result = new DoctorReservationStatusDTO
            {
                Id = serviceSupply.Id,
                CenterServiceId = centerService.Id,
                HasAvailableTurn = true,
                ReservationType = serviceSupply.ReservationType,
                FirstTurnDate = firstTurn.StartDateTime.ToShortDateString(),
                BookableTurns = new List<TurnModel>()
            };

            if (serviceSupply.ReservationType == ReservationType.Sequentially)
            {
                result.BookableTurns.Add(new TurnModel
                {
                    DayOfWeek = Utils.ConvertDayOfWeek(firstTurn.StartDateTime.DayOfWeek.ToString()),
                    Date = firstTurn.StartDateTime.Date.ToShortDateString(),
                    StartTime = firstTurn.StartDateTime.ToShortTimeString(),
                    EndTime = firstTurn.EndDateTime.ToShortTimeString()
                });
            }
            else
            {
                var date = DateTime.Parse(result.FirstTurnDate);

                var emptyPeriods = _doctorServiceManager.Calculate_Available_Empty_TimePeriods_By_Percent(serviceSupply, date, centerService);

                if (emptyPeriods != null && emptyPeriods.Any())
                {
                    var turns = emptyPeriods.ToList().Select(ep => new TurnModel
                    {
                        DayOfWeek = Utils.ConvertDayOfWeek(ep.StartDateTime.DayOfWeek.ToString()),
                        Date = ep.StartDateTime.Date.ToShortDateString(),
                        StartTime = ep.StartDateTime.ToString("HH:mm"),
                        EndTime = ep.EndDateTime.ToString("HH:mm")
                    }).ToList();

                    result.BookableTurns.AddRange(turns);
                }
            }

            return result;
        }

        public async Task<DateBookableTurnsDTO> GetBookableTurnsForDateAsync(int serviceSupplyId, int centerServiceId, string date)
        {
            var serviceSupply = await _serviceSupplyService.GetServiceSupplyByIdAsync(serviceSupplyId);

            if (serviceSupply == null) throw new AwroNoreException(Global.Err_DoctorNotFound);

            var result = new DateBookableTurnsDTO
            {
                TotalCount = 0,
                BookableTurns = new List<TurnModel>()
            };

            if (!serviceSupply.IsAvailable) return result;

            var centerService = _servicesService.GetShiftCenterServiceById(centerServiceId);

            if (centerService == null) return result;

            var turnDate = DateTime.Parse(date);

            var emptyPeriods = _doctorServiceManager.Calculate_Available_Empty_TimePeriods_By_Percent(serviceSupply, turnDate, centerService);

            if (emptyPeriods != null && emptyPeriods.Any())
            {
                var turns = emptyPeriods.ToList().Select(ep => new TurnModel
                {
                    DayOfWeek = Utils.ConvertDayOfWeek(ep.StartDateTime.DayOfWeek.ToString()),
                    Date = ep.StartDateTime.Date.ToShortDateString(),
                    StartTime = ep.StartDateTime.ToString("HH:mm"),
                    EndTime = ep.EndDateTime.ToString("HH:mm")
                }).ToList();

                result.TotalCount = turns.Count;
                result.BookableTurns.AddRange(turns);
            }

            return result;
        }

        public async Task RateDoctorAsync(RatingDTO rating)
        {
            // Get Current UserId Here (From Token)
            var user = _userService.GetById(rating.UserId);

            if (user == null) throw new AwroNoreException(NewResource.UserNotFound);

            // Check if appointment for current user
            if (rating.AppointmentId != null)
            {
                var appoint = await _appointmentService.GetAppointmentByIdAsync(rating.AppointmentId.Value);

                if (appoint == null) throw new AwroNoreException(NewResource.TurnNotFound);

                if (appoint.PersonId != rating.UserId) throw new AwroNoreException(NewResource.YouCannotPostRatingForThisDoctor);
            }

            // Check if rated before
            var oldRate = await _ratingService.Table.FirstOrDefaultAsync(x => x.PersonId == rating.UserId && x.ServiceSupplyId == rating.ServiceSupplyId && x.AppointmentId == rating.AppointmentId);

            if (oldRate != null) throw new AwroNoreException(NewResource.YouPostRatingBefore);

            var serviceSupply = await _dbContext.ServiceSupplies.FindAsync(rating.ServiceSupplyId);

            if (serviceSupply == null) throw new AwroNoreException(Global.Err_DoctorNotFound);

            var strategy = _dbContext.Database.CreateExecutionStrategy();

            await strategy.ExecuteAsync(async () =>
            {
                using (var transaction = _dbContext.Database.BeginTransaction())
                {
                    await _dbContext.ServiceSupplyRatings.AddAsync(new AN.Core.Domain.ServiceSupplyRating
                    {
                        AppointmentId = rating.AppointmentId,
                        PersonId = rating.UserId,
                        ServiceSupplyId = rating.ServiceSupplyId,
                        Rating = rating.AverageRating,
                        Review = rating.Review,
                        CreatedAt = DateTime.Now
                    });

                    await _dbContext.SaveChangesAsync();

                    if (!serviceSupply.TotalRaters.HasValue) serviceSupply.TotalRaters = 0;
                    if (!serviceSupply.TotalRating.HasValue) serviceSupply.TotalRating = 0;
                    if (!serviceSupply.AverageRating.HasValue) serviceSupply.AverageRating = 0;

                    serviceSupply.TotalRaters++;
                    serviceSupply.TotalRating += rating.AverageRating;
                    serviceSupply.AverageRating = serviceSupply.TotalRating / serviceSupply.TotalRaters;

                    _dbContext.ServiceSupplies.Update(serviceSupply);

                    await _dbContext.SaveChangesAsync();

                    transaction.Commit();
                }
            });
        }

        public async Task UpdateSecretaryPhonesAsync()
        {
            var serviceSupplies = await _dbContext.ServiceSupplies.ToListAsync();

            foreach (var item in serviceSupplies)
            {
                if (item.ServiceSupplyInfo == null)
                {
                    item.ServiceSupplyInfo = new AN.Core.Domain.ServiceSupplyInfo
                    {
                        Phone = item.Person.Mobile,
                        ServiceSupplyId = item.Id,
                        CreatedAt = DateTime.Now
                    };
                }
                else
                {
                    if (string.IsNullOrEmpty(item.ServiceSupplyInfo.Phone))
                    {
                        item.ServiceSupplyInfo.Phone = item.Person.Mobile;
                    }
                }

                _dbContext.ServiceSupplies.Update(item);
            }

            await _dbContext.SaveChangesAsync();
        }
    }
}
