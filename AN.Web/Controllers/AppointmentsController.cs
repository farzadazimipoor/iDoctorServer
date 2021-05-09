using AN.BLL.Core.Services.Messaging.SMS.Plivo;
using AN.BLL.DataRepository.Appointments;
using AN.BLL.DataRepository.PolyclinicMessages;
using AN.BLL.DataRepository.ServiceSupplies;
using AN.Core;
using AN.Core.Domain;
using AN.Core.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AN.Web.Controllers
{

    [Authorize(Roles = "Admin,HospitalManager,ClinicManager,PolyClinicManager")]
    public class AppointmentsController : CpanelBaseController
    {
        #region Ctor
        private readonly IAppointmentService _appointmentService;
        private readonly IServiceSupplyService _serviceSupplyService;
        private readonly IShiftCenterMessageService _polyclinicMessageService;
        private readonly IPlivoService _plivoService;
        public AppointmentsController(
                                      IAppointmentService appointmentService,
                                      IServiceSupplyService serviceSupplyService,
                                      IShiftCenterMessageService polyclinicMessageService,
                                      IPlivoService plivoService,
                                      IWorkContext workContext) : base(workContext)
        {
            _appointmentService = appointmentService;
            _serviceSupplyService = serviceSupplyService;
            _polyclinicMessageService = polyclinicMessageService;
            _plivoService = plivoService;
        } 
        #endregion

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]       
        public virtual async Task<JsonResult> CancelAppointment(int serviceSupplyId, long? appointmentId, bool sendSMS)
        {
            try
            {
                if (serviceSupplyId == 0 || appointmentId == null)
                    return Json(new { Error = "Bad Request" });

                var serviceSupply = await GetServiceSupply(serviceSupplyId);

                var appointment = await _appointmentService.GetAppointmentByIdForServiceSupplyAsync(serviceSupply.Id, (long)appointmentId);
                if (appointment == null)
                    return Json(new { Error = "Turn Not Found" });

                appointment.Status = AppointmentStatus.Canceled;
                appointment.IsDeleted = true;
                _appointmentService.UpdateAppointment(appointment);

                var smsSended = false;

                if (sendSMS)
                {
                    try
                    {
                        string[] recepient = { $"964{appointment.Person.Mobile}" };

                        var date = appointment.Start_DateTime.ToShortDateString();
                        var doctorName = appointment.ServiceSupply.Person.FullName;
                        var centerName = appointment.ServiceSupply.ShiftCenter.IsIndependent ? appointment.ServiceSupply.ShiftCenter.Name_Ku : appointment.ServiceSupply.ShiftCenter.Clinic.Name_Ku;

                        var smsBody = $"According to the absence of the doctor {doctorName} in {centerName} at {date}, your turn canceled";

                        _plivoService.SendMessage(recepient.ToList(), smsBody);

                        _polyclinicMessageService.InsertShiftCenterMessage(new ShiftCenterMessage
                        {
                            Type = MessageType.SMS,
                            Category = MessageCategory.Announcement,
                            About = MessageActionAbout.CancelAppointment,
                            SendingDate = DateTime.Now,
                            Recipient = recepient.FirstOrDefault(),
                            MessageBody = smsBody,
                            MessageId = 1,
                            MessageStatus = 100, //وضعیت دلیوری نامشخص
                            ShiftCenterId = appointment.ServiceSupply.ShiftCenterId,
                            ReceiverPersonId = appointment.PersonId,
                            SenderUserName = CurrentUserName,
                            AppointmentId = appointment.Id,
                            CreatedAt = DateTime.Now
                        });

                        smsSended = true;
                    }
                    catch
                    {

                    }
                }
                return Json(new { Content = "OK", SMSSended = smsSended });

            }
            catch (Exception ex)
            {
                return Json(new { Error = ex.Message });
            }
        }

        [HttpPost]       
        public virtual async Task<JsonResult> CancelAll(int serviceSupplyId, string date, string start, string end)
        {
            try
            {
                if (serviceSupplyId == 0 || string.IsNullOrEmpty(date) || string.IsNullOrEmpty(start) || string.IsNullOrEmpty(end))
                    return Json(new { Error = "Bad Request" });

                var serviceSupply = await GetServiceSupply(serviceSupplyId);

                var _start = DateTime.Parse(date + " " + start);
                var _end = DateTime.Parse(date + " " + end);

                var pendingAppointments = await _appointmentService.GetPendingAppointmentsForServiceSupplyInManualScheduleAsync(serviceSupplyId, _start, _end);

                foreach (var appointment in pendingAppointments)
                {
                    appointment.Status = AppointmentStatus.Canceled;
                    appointment.IsDeleted = true;
                    _appointmentService.UpdateAppointment(appointment);

                    try
                    {
                        var status = new byte[1];
                        var recId = new long[1];
                        string[] recepient = { $"964{appointment.Person.Mobile}" };

                        var _date = appointment.Start_DateTime.ToShortDateString();
                        var doctorName = appointment.ServiceSupply.Person.FullName;
                        var centerName = appointment.ServiceSupply.ShiftCenter.IsIndependent ? appointment.ServiceSupply.ShiftCenter.Name_Ku : appointment.ServiceSupply.ShiftCenter.Clinic.Name_Ku;

                        var smsBody = $"According to the absence of the doctor {doctorName} in {centerName} at {date}, your turn canceled";

                        _plivoService.SendMessage(recepient.ToList(), smsBody);

                        _polyclinicMessageService.InsertShiftCenterMessage(new ShiftCenterMessage
                        {
                            Type = MessageType.SMS,
                            Category = MessageCategory.Announcement,
                            About = MessageActionAbout.CancelAppointment,
                            SendingDate = DateTime.Now,
                            Recipient = recepient.FirstOrDefault(),
                            MessageBody = smsBody,
                            MessageId = recId.FirstOrDefault(),
                            MessageStatus = 100, //وضعیت دلیوری نامشخص
                            ShiftCenterId = appointment.ServiceSupply.ShiftCenterId,
                            ReceiverPersonId = appointment.PersonId,
                            SenderUserName = CurrentUserName,
                            AppointmentId = appointment.Id,
                            CreatedAt = DateTime.Now
                        });
                    }
                    catch
                    {

                    }
                }

                return Json(new { Content = "OK", SMSSended = true });

            }
            catch (Exception ex)
            {
                return Json(new { Error = ex.Message });
            }
        }

        private async Task<ServiceSupply> GetServiceSupply(int serviceSupplyId)
        {
            var result = await _serviceSupplyService.GetServiceSupplyForAreaAsync(serviceSupplyId);

            if (result == null) throw new Exception("Doctor Not Found");

            return result;
        }
    }
}