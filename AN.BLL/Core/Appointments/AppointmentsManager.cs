using AN.BLL.Core.Appointments.InProgress;
using AN.BLL.Core.Services;
using AN.BLL.Core.Services.Messaging.Notifications;
using AN.BLL.Core.Services.Messaging.SMS.Kurtename;
using AN.BLL.Core.Services.Messaging.SMS.Plivo;
using AN.BLL.DataRepository.Appointments;
using AN.BLL.Helpers;
using AN.Core;
using AN.Core.Domain;
using AN.Core.DTO.Turn;
using AN.Core.Enums;
using AN.Core.Exceptions;
using AN.Core.Models;
using AN.Core.MyExceptions;
using AN.Core.Resources.EntitiesResources;
using AN.Core.Resources.Global;
using AN.Core.Resources.New;
using AN.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Shared.Settings;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AN.BLL.Core.Appointments
{
    public class AppointmentsManager : IAppointmentsManager
    {
        #region Fields
        private readonly BanobatDbContext _dbContext;
        private readonly IPlivoService _plivoService;
        private readonly IAppointmentService _appointmentService;
        private readonly IDoctorServiceManager _doctorServiceManager;
        private readonly IIPAsManager _iPAsManager;
        private readonly IWorkContext _workContext;
        private readonly INotificationService _notificationService;
        private readonly IOptions<AppSettings> _settings;
        private readonly IScheduleManager _scheduleManager;
        private readonly IKurtenameSmsService _smsService;
        #endregion

        #region Ctor
        public AppointmentsManager(BanobatDbContext dbContext,
                                   IPlivoService plivoService,
                                   IAppointmentService appointmentService,
                                   IDoctorServiceManager doctorServiceManager,
                                   IIPAsManager iPAsManager,
                                   IWorkContext workContext,
                                   INotificationService notificationService,
                                   IOptions<AppSettings> settings,
                                   IScheduleManager scheduleManager,
                                   IKurtenameSmsService smsService)
        {
            _dbContext = dbContext;
            _plivoService = plivoService;
            _appointmentService = appointmentService;
            _doctorServiceManager = doctorServiceManager;
            _iPAsManager = iPAsManager;
            _workContext = workContext;
            _notificationService = notificationService;
            _settings = settings;
            _scheduleManager = scheduleManager;
            _smsService = smsService;
        }
        #endregion

        private Lang Lng => _workContext.Lang;

        public async Task<BookingAppointmentResult> BookAppointmentAsync(
            ServiceSupply serviceSupply,
            PatientModel patinetModel,
            string Date,
            string StartTime,
            string EndTime,
            bool _existUser,
            PaymentStatus paymentStatus,
            ShiftCenterService polyclinicHealthService,
            ReservationChannel channel,
            Lang requestLang,
            int? offerId = null)
        {
            var resultMessage = Messages.ErrorOccuredWhileFinalBookTurn;
            try
            {
                if (serviceSupply == null) throw new ArgumentNullException(nameof(serviceSupply));

                if (string.IsNullOrEmpty(Date) || string.IsNullOrEmpty(StartTime) || string.IsNullOrEmpty(EndTime)) throw new ArgumentNullException("Date");

                var tmpStatus = paymentStatus == PaymentStatus.NotPayed ? AppointmentStatus.Unknown : AppointmentStatus.Pending;

                var startDateTime = DateTime.Parse(Date + " " + StartTime);

                var endDateTime = DateTime.Parse(Date + " " + EndTime);

                var date = DateTime.Parse(Date).Date;

                long appointmentId = -1;
                string trackingCode = string.Empty;

                var strategy = _dbContext.Database.CreateExecutionStrategy();
                await strategy.ExecuteAsync(async () =>
                {
                    using (var transaction = _dbContext.Database.BeginTransaction())
                    {
                        try
                        {
                            if (offerId != null)
                            {
                                var offer = await _dbContext.Offers.FindAsync(offerId.Value);

                                if (offer == null) throw new AwroNoreException("Offer Not Found");

                                if (offer.RemainedCount <= 0) throw new AwroNoreException("All Offer Appointments Are Reserved");

                                offer.RemainedCount -= 1;

                                _dbContext.Entry(offer).State = EntityState.Modified;

                                await _dbContext.SaveChangesAsync();
                            }

                            #region book appointment for new user
                            if (!_existUser)
                            {
                                var patientUser = new Person
                                {
                                    NamePrefix = patinetModel.NamePrefix,
                                    FirstName = patinetModel.FirstName,
                                    SecondName = patinetModel.SecondName,
                                    ThirdName = patinetModel.ThirdName,
                                    Age = patinetModel.Age,
                                    Gender = patinetModel.Gender,
                                    Mobile = patinetModel.Mobile,
                                    ZipCode = patinetModel.ZipCode,
                                    Address = patinetModel.Address,
                                    Description = patinetModel.Description,
                                    CreatedAt = DateTime.Now,
                                    IsApproved = true,
                                    IsDeleted = false,
                                    CreatorRole = Shared.Enums.LoginAs.UNKNOWN,
                                    CreationPlaceId = null
                                };

                                _dbContext.Persons.Add(patientUser);

                                _dbContext.SaveChanges();

                                // TODO: 
                                // var createUser = userManager.Create(patientUser, patinetModel.Password);

                                //if (createUser.Succeeded)
                                //{
                                //    var assignPatientRole = userManager.AddToRole(patientUser.Id, UsersRoleName.Patient.ToString());
                                //    if (!assignPatientRole.Succeeded)
                                //    {
                                //        throw new Exception(Messages.ErrorOccuredWhileAssignRole);
                                //    }
                                //}

                                _dbContext.PatientPersonInfo.Add(new PatientPersonInfo
                                {
                                    PersonId = patientUser.Id,
                                    CreatedAt = DateTime.Now
                                });

                                #region Set Patient Insurance
                                int? _patientInsuranceId = null;

                                if (patinetModel.InsuranceId != 0 && patinetModel.InsuranceNumber != null)
                                {
                                    var _patientInsurance = new PatientInsurance
                                    {
                                        UserPatientId = patientUser.Id,
                                        ServiceSupplyInsuranceId = patinetModel.InsuranceId,
                                        InsuranceNumber = patinetModel.InsuranceNumber,
                                        CreatedAt = DateTime.Now
                                    };
                                    _dbContext.PatientInsurances.Add(_patientInsurance);
                                    _dbContext.SaveChanges();
                                    _patientInsuranceId = _patientInsurance.Id;
                                }
                                #endregion

                                var finalBookabeTimePeriods = _doctorServiceManager.CalculateFinalBookableTimePeriods(serviceSupply, startDateTime, polyclinicHealthService);

                                if (finalBookabeTimePeriods == null || finalBookabeTimePeriods.Count() <= 0)
                                    throw new Exception(Messages.ValidEmptyTimePeriodNotFound);

                                var ipaTimePeriod = finalBookabeTimePeriods.FirstOrDefault(f => f.StartDateTime == startDateTime && f.EndDateTime == endDateTime && f.Type == TimePeriodType.InProgressAppointment);

                                if (ipaTimePeriod == null)
                                    throw new Exception(Messages.ValidEmptyTimePeriodNotFound);

                                trackingCode = await _appointmentService.GenerateUniqueTrackingNumberAsync();

                                var appointment = new Appointment
                                {
                                    UniqueTrackingCode = trackingCode,
                                    Book_DateTime = DateTime.Now,
                                    Start_DateTime = startDateTime,
                                    End_DateTime = endDateTime,
                                    Description = " ",
                                    Status = tmpStatus,
                                    ServiceSupplyId = serviceSupply.Id,
                                    PersonId = patientUser.Id,
                                    PatientInsuranceId = _patientInsuranceId,
                                    IsAnnounced = false,
                                    Paymentstatus = paymentStatus,
                                    IsDeleted = false,
                                    ShiftCenterServiceId = polyclinicHealthService.Id,
                                    ReservationChannel = channel,
                                    CreatedAt = DateTime.Now,
                                    OfferId = offerId,
                                    RequestLang = requestLang,
                                    PersonLocation = new NetTopologySuite.Geometries.Point(patinetModel.Xlongitude, patinetModel.Ylatitude)
                                    {
                                        SRID = 4326 // Set the SRID (spatial reference system id) to 4326, which is the spatial reference system used by Google maps (WGS84)
                                    }
                                };
                                _dbContext.Appointments.Add(appointment);
                                _dbContext.SaveChanges();

                                #region Send SMS notification    
                                if (channel != ReservationChannel.Kiosk)
                                {
                                    try
                                    {
                                        var doctor_name = serviceSupply.Person.FullName;
                                        var persian_dayOfWeek = Utils.ConvertDayOfWeek(startDateTime.DayOfWeek.ToString());
                                        var day_number = startDateTime.ToShortDateString().Split('/')[2];
                                        var persian_month = Utils.GetMonthName(startDateTime);
                                        var year_number = startDateTime.ToShortDateString().Split('/')[0];
                                        var time = startDateTime.ToShortTimeString();

                                        var smsBody = $"{Messages.YourAppointmentForDoctor} { doctor_name} ، { persian_dayOfWeek} { day_number} { persian_month} {year_number} ،{Global.Hour}: {time}";

                                        if (channel == ReservationChannel.ClinicManagerSection)
                                            smsBody = smsBody = "Turn for doctor  " + doctor_name + ", " + persian_dayOfWeek + " " + day_number + " " + persian_month + " " + year_number;

                                        string[] recepient = { $"964{patinetModel.Mobile}" };

                                        if (serviceSupply.ShiftCenter.IsIndependent)
                                        {
                                            if (Lng == Lang.KU)
                                            {
                                                if (serviceSupply.ShiftCenter.FinalBookSMSMessage_Ku != null) smsBody = serviceSupply.ShiftCenter.FinalBookSMSMessage_Ku;
                                            }
                                            else if (Lng == Lang.AR)
                                            {
                                                if (serviceSupply.ShiftCenter.FinalBookSMSMessage_Ar != null) smsBody = serviceSupply.ShiftCenter.FinalBookSMSMessage_Ar;
                                            }
                                        }
                                        else if (serviceSupply.ShiftCenter.Clinic != null && serviceSupply.ShiftCenter.Clinic.IsIndependent)
                                        {
                                            if (Lng == Lang.KU)
                                            {
                                                if (serviceSupply.ShiftCenter.Clinic.FinalBookSMSMessage_Ku != null) smsBody = serviceSupply.ShiftCenter.Clinic.FinalBookSMSMessage_Ku;
                                            }
                                            else if (Lng == Lang.AR)
                                            {
                                                if (serviceSupply.ShiftCenter.Clinic.FinalBookSMSMessage_Ar != null) smsBody = serviceSupply.ShiftCenter.Clinic.FinalBookSMSMessage_Ar;
                                            }
                                        }
                                        else if (serviceSupply.ShiftCenter.Clinic != null && serviceSupply.ShiftCenter.Clinic.Hospital != null)
                                        {
                                            if (Lng == Lang.KU)
                                            {
                                                if (serviceSupply.ShiftCenter.Clinic.Hospital.FinalBookSMSMessage_Ku != null) smsBody = serviceSupply.ShiftCenter.Clinic.Hospital.FinalBookSMSMessage_Ku;
                                            }
                                            else if (Lng == Lang.AR)
                                            {
                                                if (serviceSupply.ShiftCenter.Clinic.Hospital.FinalBookSMSMessage_Ar != null) smsBody = serviceSupply.ShiftCenter.Clinic.Hospital.FinalBookSMSMessage_Ar;
                                            }
                                        }

                                        _plivoService.SendMessage(recepient.ToList(), smsBody);

                                        _dbContext.Entry(appointment).State = EntityState.Modified;

                                        appointment.IsAnnounced = true;
                                    }
                                    catch
                                    {

                                    }
                                }
                                #endregion

                                _iPAsManager.Delete(serviceSupply.Id, startDateTime);

                                _dbContext.SaveChanges();

                                appointmentId = appointment.Id;
                            }
                            #endregion

                            #region book appointment for existing user 
                            else if (_existUser == true)
                            {
                                var user = await _dbContext.Persons.FirstOrDefaultAsync(u => u.Mobile == patinetModel.Mobile);
                                if (user == null) throw new EntityNotFoundException();

                                // TODO
                                //if (!userManager.IsInRole(user.Id, UsersRoleName.Patient.ToString()))
                                //{
                                //    var assignPatientRole = userManager.AddToRole(user.Id, UsersRoleName.Patient.ToString());
                                //    if (!assignPatientRole.Succeeded)
                                //    {
                                //        throw new Exception(Messages.ErrorOccuredWhileAssignRole);
                                //    }
                                //}

                                if (user.PatientPersonInfo == null)
                                {
                                    _dbContext.PatientPersonInfo.Add(new PatientPersonInfo
                                    {
                                        PersonId = user.Id,
                                        CreatedAt = DateTime.Now
                                    });
                                }

                                #region Set Patient Insurance
                                //Check if user already used current insurance name and number
                                int? patientInsuranId = null;
                                if (patinetModel.InsuranceId != 0 && patinetModel.InsuranceNumber != null)
                                {
                                    var oldInsurance = user.PatientPersonInfo.PatientInsurances.FirstOrDefault(pi => pi.InsuranceNumber == patinetModel.InsuranceNumber && pi.ServiceSupplyInsuranceId == patinetModel.InsuranceId);
                                    if (oldInsurance == null)
                                    {
                                        var _patientInsurance = new PatientInsurance
                                        {
                                            UserPatientId = user.Id,
                                            ServiceSupplyInsuranceId = patinetModel.InsuranceId,
                                            InsuranceNumber = patinetModel.InsuranceNumber,
                                            CreatedAt = DateTime.Now
                                        };
                                        _dbContext.PatientInsurances.Add(_patientInsurance);
                                        _dbContext.SaveChanges();
                                        patientInsuranId = _patientInsurance.Id;
                                    }
                                    else
                                    {
                                        patientInsuranId = oldInsurance.Id;
                                    }
                                }
                                #endregion

                                var finalBookabeTimePeriods = _doctorServiceManager.CalculateFinalBookableTimePeriods(serviceSupply, startDateTime, polyclinicHealthService);

                                if (finalBookabeTimePeriods == null || finalBookabeTimePeriods.Count() <= 0)
                                    throw new Exception(Messages.ValidEmptyTimePeriodNotFound);

                                var ipaTimePeriod = finalBookabeTimePeriods.FirstOrDefault(f => f.StartDateTime == startDateTime && f.EndDateTime == endDateTime && f.Type == TimePeriodType.InProgressAppointment);

                                if (ipaTimePeriod == null)
                                    throw new Exception(Messages.ValidEmptyTimePeriodNotFound);

                                trackingCode = await _appointmentService.GenerateUniqueTrackingNumberAsync();

                                var appointment = new Appointment
                                {
                                    UniqueTrackingCode = trackingCode,
                                    Book_DateTime = DateTime.Now,
                                    Start_DateTime = startDateTime,
                                    End_DateTime = endDateTime,
                                    Description = " ",
                                    Status = tmpStatus,
                                    ServiceSupplyId = serviceSupply.Id,
                                    PersonId = user.Id,
                                    PatientInsuranceId = patientInsuranId,
                                    IsAnnounced = false,
                                    Paymentstatus = paymentStatus,
                                    IsDeleted = false,
                                    ShiftCenterServiceId = polyclinicHealthService.Id,
                                    ReservationChannel = channel,
                                    CreatedAt = DateTime.Now,
                                    OfferId = offerId,
                                    RequestLang = requestLang,
                                    PersonLocation = new NetTopologySuite.Geometries.Point(patinetModel.Xlongitude, patinetModel.Ylatitude)
                                    {
                                        SRID = 4326 // Set the SRID (spatial reference system id) to 4326, which is the spatial reference system used by Google maps (WGS84)
                                    }
                                };

                                _dbContext.Appointments.Add(appointment);

                                _dbContext.SaveChanges();

                                #region Send SMS notification  
                                if (channel != ReservationChannel.Kiosk)
                                {
                                    try
                                    {
                                        var doctor_name = serviceSupply.Person.FullName;
                                        var persian_dayOfWeek = Utils.ConvertDayOfWeek(startDateTime.DayOfWeek.ToString());
                                        var day_number = startDateTime.ToShortDateString().Split('/')[2];
                                        var persian_month = Utils.GetMonthName(startDateTime);
                                        var year_number = startDateTime.ToShortDateString().Split('/')[0];
                                        var time = startDateTime.ToShortTimeString();

                                        var smsBody = $"{Messages.YourAppointmentForDoctor} { doctor_name} ، { persian_dayOfWeek} { day_number} { persian_month} {year_number} ،{Global.Hour}: {time}";

                                        if (channel == ReservationChannel.ClinicManagerSection)
                                            smsBody = smsBody = "Turn for doctor  " + doctor_name + ", " + persian_dayOfWeek + " " + day_number + " " + persian_month + " " + year_number;

                                        string[] recepient = { $"964{patinetModel.Mobile}" };

                                        if (serviceSupply.ShiftCenter.IsIndependent)
                                        {
                                            if (Lng == Lang.KU)
                                            {
                                                if (serviceSupply.ShiftCenter.FinalBookSMSMessage_Ku != null) smsBody = serviceSupply.ShiftCenter.FinalBookSMSMessage_Ku;
                                            }
                                            else if (Lng == Lang.AR)
                                            {
                                                if (serviceSupply.ShiftCenter.FinalBookSMSMessage_Ar != null) smsBody = serviceSupply.ShiftCenter.FinalBookSMSMessage_Ar;
                                            }
                                        }
                                        else if (serviceSupply.ShiftCenter.Clinic != null && serviceSupply.ShiftCenter.Clinic.IsIndependent)
                                        {
                                            if (Lng == Lang.KU)
                                            {
                                                if (serviceSupply.ShiftCenter.Clinic.FinalBookSMSMessage_Ku != null) smsBody = serviceSupply.ShiftCenter.Clinic.FinalBookSMSMessage_Ku;
                                            }
                                            else if (Lng == Lang.AR)
                                            {
                                                if (serviceSupply.ShiftCenter.Clinic.FinalBookSMSMessage_Ar != null) smsBody = serviceSupply.ShiftCenter.Clinic.FinalBookSMSMessage_Ar;
                                            }
                                        }
                                        else if (serviceSupply.ShiftCenter.Clinic != null && serviceSupply.ShiftCenter.Clinic.Hospital != null)
                                        {
                                            if (Lng == Lang.KU)
                                            {
                                                if (serviceSupply.ShiftCenter.Clinic.Hospital.FinalBookSMSMessage_Ku != null) smsBody = serviceSupply.ShiftCenter.Clinic.Hospital.FinalBookSMSMessage_Ku;
                                            }
                                            else if (Lng == Lang.AR)
                                            {
                                                if (serviceSupply.ShiftCenter.Clinic.Hospital.FinalBookSMSMessage_Ar != null) smsBody = serviceSupply.ShiftCenter.Clinic.Hospital.FinalBookSMSMessage_Ar;
                                            }
                                        }

                                        _plivoService.SendMessage(recepient.ToList(), smsBody);

                                        _dbContext.Entry(appointment).State = EntityState.Modified;

                                        appointment.IsAnnounced = true;
                                    }
                                    catch
                                    {

                                    }
                                }
                                #endregion

                                _iPAsManager.Delete(serviceSupply.Id, startDateTime);

                                _dbContext.SaveChanges();

                                appointmentId = appointment.Id;
                            }
                            #endregion                            

                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            throw ex;
                        }
                    }
                });
                return new BookingAppointmentResult
                {
                    Status = BookingAppointmentStatus.Success,
                    Message = Messages.TurnBookedFinally,
                    AppointmentId = appointmentId,
                    TrackingCode = trackingCode
                };
            }
            catch (Exception ex)
            {
                resultMessage = ex.Message;
            }
            return new BookingAppointmentResult
            {
                Status = BookingAppointmentStatus.Failure,
                Message = resultMessage
            };
        }

        public async Task<(string trackingCode, int appointmentId)> CreateRequestedAppointmentAsync(string userMobile, FinalBookTurnDTO model, Lang requestLang)
        {
            var person = await _dbContext.Persons.FirstOrDefaultAsync(x => x.Mobile == userMobile);

            if (person == null) throw new AwroNoreException("Person not found");

            var turnDate = DateTime.Parse(model.Date);
            var turnStartDateTime = DateTime.Parse($"{model.Date} {model.StartTime}");
            var turnEndDateTime = DateTime.Parse($"{model.Date} {model.EndTime}");

            var serviceSupply = await _dbContext.ServiceSupplies.FindAsync(model.ServiceSupplyId);

            if (serviceSupply == null) throw new AwroNoreException(Global.Err_DoctorNotFound);

            var centerService = await _dbContext.CenterServices.FindAsync(model.CenterServiceId);

            if (centerService == null) throw new AwroNoreException(NewResource.NotAnyServiceDefinedForThisCenter);

            _scheduleManager.EnsureHasSchedule(serviceSupply, model.CenterServiceId, turnStartDateTime, turnEndDateTime, passIfNoSchedules: true);

            // Ensure that user don't have another appointment with same time
            await EnsureNotHaveSameTimeAppointmentAsync(turnStartDateTime, userMobile);

            var trackingCode = await _appointmentService.GenerateUniqueTrackingNumberAsync();

            var appointment = new Appointment
            {
                UniqueTrackingCode = trackingCode,
                Book_DateTime = DateTime.Now,
                Start_DateTime = turnStartDateTime,
                End_DateTime = turnEndDateTime,
                Description = "#Requested",
                Status = AppointmentStatus.Unknown,
                ServiceSupplyId = serviceSupply.Id,
                PersonId = person.Id,
                PatientInsuranceId = null,
                IsAnnounced = false,
                Paymentstatus = PaymentStatus.Free,
                IsDeleted = false,
                ShiftCenterServiceId = centerService.Id,
                ReservationChannel = ReservationChannel.MobileApplication,
                CreatedAt = DateTime.Now,
                OfferId = null,
                RequestLang = requestLang,
                PersonLocation = new NetTopologySuite.Geometries.Point(model.Xlongitude, model.Ylatitude)
                {
                    SRID = 4326 // Set the SRID (spatial reference system id) to 4326, which is the spatial reference system used by Google maps (WGS84)
                }
            };

            _dbContext.Appointments.Add(appointment);

            // Send notification for agents here
            var agents = _settings?.Value?.AwroNoreSettings?.RequestAppointmentAgents;
            if (agents != null && agents.Any())
            {
                foreach (var agent in agents)
                {
                    var agentPerson = await _dbContext.Persons.FirstOrDefaultAsync(x => x.Mobile == agent);

                    if (agentPerson != null)
                    {
                        var title = "Appointment Request";
                        var message = "New Appointment Request Created";
                        foreach (var item in agentPerson.FcmInstanceIds)
                        {
                            await _notificationService.SendFcmToSingleDeviceAsync(item.InstanceId, title, message);
                        }
                    }
                }
            }

            // Send SMS For Doctor
            try
            {
                var posetMessage = $"نۆرەیەک داواکراوە لە ڕێگای ئەوڕۆنۆرە{Environment.NewLine}" +
                                   $"ژمارە: {person.Mobile}{Environment.NewLine}" +
                                   $"ناو: {person.FullName}";

                if (serviceSupply.ServiceSupplyInfo != null && !string.IsNullOrEmpty(serviceSupply.ServiceSupplyInfo.Phone))
                {
                    var mobile = serviceSupply.ServiceSupplyInfo.Phone;

                    var isNumeric = double.TryParse(mobile, out _);

                    if (isNumeric)
                    {
                        if (mobile.Length > 10)
                        {
                            mobile = mobile.Substring(mobile.Length - 10);
                        }

                        if (mobile.StartsWith("7"))
                        {
                            var receipinet = $"964{mobile}";

                            await _smsService.SendSmsAsync(receipinet, posetMessage);
                        }
                    }
                }
            }
            catch
            {
                // IGNORED
            }

            await _dbContext.SaveChangesAsync();

            return (trackingCode, appointment.Id);
        }

        public bool HaveAppointmentForDate(string date, string mobile, int serviceSupplyId, int centerServiceId)
        {
            var _date = DateTime.Parse(date).Date;

            return _appointmentService.GetAppointmentForMobileInDate(serviceSupplyId, centerServiceId, mobile, _date) != null;
        }

        public async Task EnsureNotHaveSameTimeAppointmentAsync(DateTime dateTime, string mobile)
        {
            var hasSameTurns = await _dbContext.Appointments.Where(x => x.Person.Mobile == mobile && x.Start_DateTime == dateTime).AnyAsync();

            if (hasSameTurns) throw new AwroNoreException(Messages.HaveAppointmentWithAnotherDoctorAtTime);
        }
    }
}
