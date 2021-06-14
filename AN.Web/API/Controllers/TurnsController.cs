using AN.BLL.Core.Appointments;
using AN.BLL.Core.Appointments.InProgress;
using AN.BLL.Core.Services;
using AN.BLL.Core.Services.Messaging.Notifications;
using AN.BLL.DataRepository;
using AN.BLL.DataRepository.Appointments;
using AN.BLL.DataRepository.HealthServices;
using AN.BLL.DataRepository.Security;
using AN.BLL.DataRepository.ServiceSupplies;
using AN.BLL.DataRepository.Persons;
using AN.BLL.Services.Turns;
using AN.Core.DTO.Turn;
using AN.Core.Enums;
using AN.Core.Exceptions;
using AN.Core.Models;
using AN.Core.Resources.Global;
using AN.Core.Resources.New;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace AN.Web.API.Controllers
{
    [Route("api/awronore/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class TurnsController : ANBaseApiController
    {
        #region Fields
        private readonly ITurnsService _turnsService;
        private readonly IDoctorServiceManager _doctorServiceManager;
        private readonly IAppointmentService _appointmentService;
        private readonly IServiceSupplyService _serviceSupplyService;
        private readonly IServicesService _servicesService;
        private readonly IBlockedMobileService _blockedMobileService;
        private readonly IIPAsManager _iPAsManager;
        private readonly IPersonService _userService;
        private readonly IAppointmentsManager _appointmentsManager;
        private readonly INotificationService _notificationService;
        private readonly IOfferRepository _offerRepository;
        private static Logger logger;
        #endregion

        #region Ctor
        public TurnsController(ITurnsService turnsService,
                               IDoctorServiceManager doctorServiceManager,
                               IAppointmentService appointmentService,
                               IServiceSupplyService serviceSupplyService,
                               IServicesService servicesService,
                               IBlockedMobileService blockedMobileService,
                               IIPAsManager iPAsManager,
                               IPersonService userService,
                               IAppointmentsManager appointmentsManager,
                               INotificationService notificationService,
                               IOfferRepository offerRepository)
        {
            _turnsService = turnsService;
            _doctorServiceManager = doctorServiceManager;
            _userService = userService;
            _appointmentsManager = appointmentsManager;
            _notificationService = notificationService;
            _servicesService = servicesService;
            _blockedMobileService = blockedMobileService;
            _iPAsManager = iPAsManager;
            _appointmentService = appointmentService;
            _serviceSupplyService = serviceSupplyService;
            _offerRepository = offerRepository;

            logger = LogManager.GetCurrentClassLogger();
        }
        #endregion

        [HttpPost("book")]
        [ProducesResponseType(typeof(FinalBookTurnResultDTO), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> FinalBookTurn([FromBody] FinalBookTurnDTO model)
        {
            if (string.IsNullOrEmpty(CurrentUserName)) return Unauthorized();

            var mobile = CurrentUserName;

            // Check if this patient has reserved appointment today or not?
            if (_appointmentsManager.HaveAppointmentForDate(model.Date, mobile, model.ServiceSupplyId, model.CenterServiceId))
            {
                throw new AwroNoreException(Global.Err_UserHaveTurnForDate);
            }

            // Save Requested Turn
            if (model.IsRequested)
            {
                var (trackingCode, appointmentId) = await _appointmentsManager.CreateRequestedAppointmentAsync(mobile, model, requestLang:RequestLang);

                var result = new FinalBookTurnResultDTO
                {
                    IsSucceeded = true,
                    IsRequested = true,
                    Message = "داواکاری نۆرەکەتان بە سەرکەوتوویی تۆمار کرا",
                    Description = "This is just request",
                    TurnId = appointmentId,
                    TrackingCode = trackingCode
                };

                return Ok(result);
            }
            else
            {                
                var offerCode = string.Empty;

                var turnDate = DateTime.Parse(model.Date);
                var turnStartDateTime = DateTime.Parse($"{model.Date} {model.StartTime}");
                var turnEndDateTime = DateTime.Parse($"{model.Date} {model.EndTime}");

                var serviceSupply = await _serviceSupplyService.GetServiceSupplyByIdAsync(model.ServiceSupplyId);

                if (serviceSupply == null) throw new AwroNoreException(Global.Err_DoctorNotFound);

                var centerService = _servicesService.GetShiftCenterServiceById(model.CenterServiceId);

                if (centerService == null) throw new AwroNoreException(NewResource.NotAnyServiceDefinedForThisCenter);

                if (!serviceSupply.IsAvailable) throw new AwroNoreException(serviceSupply.ShiftCenter.Type == ShiftCenterType.BeautyCenter ? Global.BeautyCenterNotActive : Global.DoctorNotActive);

                if (_blockedMobileService.IsMobileBlocked(serviceSupply.ShiftCenterId, mobile))
                {
                    throw new AwroNoreException(Global.Err_MobileBlocked);
                }

                try
                {                   
                    // Ensure that user don't have another appointment with same time
                    await _appointmentsManager.EnsureNotHaveSameTimeAppointmentAsync(turnStartDateTime, mobile);

                    // Reserve Turn In In-Progress Appointments

                    var emptyPeriods = _doctorServiceManager.Calculate_Available_Empty_TimePeriods_By_Percent(serviceSupply, turnDate, centerService);
                    if (emptyPeriods == null || !emptyPeriods.Any()) throw new AwroNoreException(NewResource.TurnReservedBeforeByAnotherPerson);
                    var emptyTurn = emptyPeriods.FirstOrDefault(x => x.StartDateTime == turnStartDateTime && x.EndDateTime == turnEndDateTime);
                    if (emptyTurn == null) throw new AwroNoreException(NewResource.TurnReservedBeforeByAnotherPerson);
                    var ipa = new IPAModel
                    {
                        AddedAt = DateTime.Now,
                        ServiceSupplyId = model.ServiceSupplyId,
                        StartDateTime = emptyTurn.StartDateTime,
                        EndDateTime = emptyTurn.EndDateTime,
                        UserHostAgent = "Stand-WPF",
                        IsForSelectedDoctor = false,
                        PolyclinicHealthService = centerService,
                        OfferId = model.OfferId
                    };
                    if (_doctorServiceManager.IsAvailableEmptyTimePeriod(ipa.ServiceSupplyId, ipa.StartDateTime, ipa.EndDateTime, ipa.PolyclinicHealthService))
                    {
                        if (model.OfferId != null)
                        {
                            var offer = await _offerRepository.GetByIdAsync(model.OfferId.Value);

                            if (offer == null) throw new AwroNoreException("Offer Not Found");

                            offerCode = offer.Code;

                            var offerAllTimePeriods = _doctorServiceManager.CalculateAllTimePeriodsForOffer(offer);

                            if (offerAllTimePeriods == null) throw new AwroNoreException("Empty Turns Not Found");

                            var isEmptyOffer = offerAllTimePeriods.Any(x => x.Type == TimePeriodType.EmptyOffer && x.StartDateTime == turnStartDateTime && x.EndDateTime == turnEndDateTime);

                            if (!isEmptyOffer) throw new AwroNoreException("All Offer Appointments Are Reserved");
                        }

                        _iPAsManager.Insert(ipa);
                    }
                    else
                        throw new Exception(Global.Err_ValidTimePeriodNotFound);


                    var currentUser = await _userService.GetPersonByMobileAsync(mobile);

                    var patientModel = new PatientModel
                    {
                        Mobile = mobile,
                        Xlongitude = model.Xlongitude,
                        Ylatitude = model.Ylatitude
                    };

                    string message = string.Empty;
                    var queueNumber = -1;
                    var bookAppoint = await _appointmentsManager.BookAppointmentAsync(serviceSupply, patientModel, model.Date, model.StartTime, model.EndTime, true, PaymentStatus.Free, centerService, ReservationChannel.MobileApplication,requestLang: RequestLang, offerId: model.OfferId);
                    if (bookAppoint.Status == BookingAppointmentStatus.Success)
                    {
                        try
                        {
                            var appointment = _appointmentService.GetAppointmentById((int)bookAppoint.AppointmentId);
                            try
                            {
                                logger.Info("Begin try to send notification...");

                                var polyclinic = serviceSupply.ShiftCenter;
                                var instanceIds = new List<string>();
                                if (polyclinic.FcmInstanceIds != null && polyclinic.FcmInstanceIds.Count() > 0)
                                    instanceIds = polyclinic.FcmInstanceIds.Where(x => x.IsOn).Select(x => x.FcmId).ToList();
                                if (instanceIds.Count > 0)
                                {
                                    var patientName = appointment.Person.FullName;
                                    var date = appointment.Start_DateTime.ToShortDateString();
                                    var title = "New Turn!";
                                    var text = patientName + " reserved turn for " + date;

                                    foreach (var item in instanceIds)
                                    {
                                        await _notificationService.SendFcmToSingleDeviceAsync(item, title, text);
                                    }
                                }
                            }
                            catch (Exception e)
                            {
                                logger.Error("Error sending notification...");
                                logger.Error(e.Message);
                                logger.Error(e.InnerException);
                            }
                            queueNumber = _appointmentService.GetQueueNumberForAppointment(serviceSupply.Id, appointment.Id, centerService.Id, appointment.Start_DateTime);

                            if (serviceSupply.ShiftCenter.IsIndependent)
                            {
                                if (serviceSupply.ShiftCenter.FinalBookMessage_Ku != null)
                                    message = serviceSupply.ShiftCenter.FinalBookMessage_Ku;
                            }
                            else if (serviceSupply.ShiftCenter.Clinic.IsIndependent)
                            {
                                if (serviceSupply.ShiftCenter.Clinic.FinalBookMessage_Ku != null)
                                    message = serviceSupply.ShiftCenter.Clinic.FinalBookMessage_Ku;
                            }
                            else if (serviceSupply.ShiftCenter.Clinic.Hospital.FinalBookMessage_Ku != null)
                            {
                                message = serviceSupply.ShiftCenter.Clinic.Hospital.FinalBookMessage_Ku;
                            }
                        }
                        catch { }
                    }
                    var result = new FinalBookTurnResultDTO
                    {
                        IsSucceeded = bookAppoint.Status == BookingAppointmentStatus.Success,
                        Message = bookAppoint.Message,
                        TurnId = (int)bookAppoint.AppointmentId,
                        QueueNumber = queueNumber,
                        TrackingCode = bookAppoint.TrackingCode,
                        OfferCode = offerCode
                    };
                    return Ok(result);
                }
                catch (Exception e)
                {
                    try
                    {
                        _iPAsManager.Delete(model.ServiceSupplyId, turnStartDateTime);
                    }
                    catch
                    {
                        // IGNORED
                    }

                    if (e is AwroNoreException)
                    {
                        return Ok(new FinalBookTurnResultDTO
                        {
                            IsSucceeded = false,
                            Message = e.Message
                        });
                    }
                    throw e;
                }
            }            
        }

        [HttpPost("myturns/{pageIndex:int}/{limit:int}", Name = "UserTurnsList")]
        [ProducesResponseType(typeof(UserTurnsResultDTO), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetUserTurns([FromBody]UserTurnsFilterDTO filterModel, int pageIndex, int limit = 12)
        {
            if (string.IsNullOrEmpty(CurrentUserName)) return Unauthorized();

            filterModel.UserMobile = CurrentUserName;

            var (totalCount, _, doctors) = await _turnsService.GetUserTurnsListPagingAsync(filterModel, RequestLang, HostAddress, pageIndex, limit);

            var result = new UserTurnsResultDTO
            {
                TotalCount = totalCount,
                Turns = doctors
            };

            return Ok(result);
        }

        [HttpGet("setstatus/{turnId:int}/{newStatus:int}")]
        public async Task<IActionResult> SetTurnStatus(int turnId, AppointmentStatus newStatus)
        {
            if (string.IsNullOrEmpty(CurrentUserName)) return Unauthorized();

            await _turnsService.SetTurnStatusAsync(turnId, newStatus, CurrentUserName);

            return Ok();
        }
    }
}