using AN.BLL.Core.Services.Messaging.SMS.Plivo;
using AN.BLL.DataRepository.Appointments;
using AN.BLL.DataRepository.PolyclinicMessages;
using AN.BLL.DataRepository.ServiceSupplies;
using AN.Core;
using AN.Core.Domain;
using AN.Core.Enums;
using AN.Core.Extensions;
using AN.Core.MyExceptions;
using AN.Core.Resources.EntitiesResources;
using AN.Core.Resources.Global;
using AN.Core.ViewModels;
using AN.DAL;
using AN.Web.App_Code;
using AN.Web.AppCode.Extensions;
using AN.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Shared.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AN.Web.Areas.PolyClinicManager.Controllers
{
    public class AppointmentController : PolyclinicManagerController
    {
        #region Fields
        private readonly IAppointmentService _appointmentService;
        private readonly IPlivoService _plivoService;
        private readonly IShiftCenterMessageService _polyclinicMessageService;
        private readonly IServiceSupplyService _serviceSupplyService;
        private readonly BanobatDbContext _dbContext;
        #endregion

        #region Ctor
        public AppointmentController(IAppointmentService appointmentService,
                                     IWorkContext workContext,
                                     IPlivoService plivoService,
                                     IShiftCenterMessageService polyclinicMessageService,
                                     IServiceSupplyService serviceSupplyService,
                                     BanobatDbContext dbContext) : base(workContext)
        {
            _appointmentService = appointmentService;
            _plivoService = plivoService;
            _polyclinicMessageService = polyclinicMessageService;
            _serviceSupplyService = serviceSupplyService;
            _dbContext = dbContext;
        }
        #endregion

        [Authorize(Roles = "polyclinicmanager,doctor,secretary,homecaremanager")]
        public async Task<IActionResult> Index(AppointmentStatus? currentStatus = null, string fromDate = "", string toDate = "")
        {
            ViewBag.Lang = Lng;

            ViewBag.Doctors = await _serviceSupplyService.GetSelectListAsync(CurrentPolyclinic.Id, CurrentPolyclinic.ServiceSupplyIds);

            ViewBag.CurrentStatus = currentStatus != null ? ((int)currentStatus).ToString() : "";

            ViewBag.FromDate = fromDate;

            ViewBag.ToDate = toDate;

            ViewBag.StatusList = MyEnumExtensions.EnumToSelectList<AppointmentStatus>().ToList();

            return View(new PolyclinicAppointmentListViewModel());
        }

        [HttpPost]
        [Authorize(Roles = "polyclinicmanager,doctor,secretary,homecaremanager")]
        public async Task<IActionResult> LoadTable([FromBody]DataTablesParameters param)
        {
            try
            {
                var filtersModel = JsonConvert.DeserializeObject<ShiftCenterAppointmentsFilterModel>(param.FiltersObject);

                var results = await _appointmentService.GetDataTableAsync(CurrentPolyclinic.Id, param, filtersModel, Lng, CurrentPolyclinic.ServiceSupplyIds);

                var turns = await Task.WhenAll(results.Items.Select(async (x) => new PolyclinicAppointmentListViewModel
                {
                    Id = x.Id,
                    Status = x.Status,
                    ReservationChannel = x.ReservationChannel,
                    Date = x.Date,
                    Doctor = x.ServiceSupplier,
                    Person = x.Person,
                    PatientMobile = x.PatientMobile,
                    Avatar = x.Avatar,
                    AvatarHtml = await this.RenderViewToStringAsync("_AppointmentItemAvatar", x.Avatar),
                    StatusHtml = await this.RenderViewToStringAsync("_AppointmentItemStatus", x.Status),
                    ChannelHtml = await this.RenderViewToStringAsync("_AppointmentItemChannel", x.ReservationChannel),
                    ActionsHtml = await this.RenderViewToStringAsync("_AppointmentItemActions", (x.Id, x.Status, x.HasTreatmentHistory, x.PersonId, x.ServiceSupplyId))
                }).ToList());

                return new JsonResult(new DataTablesResult<PolyclinicAppointmentListViewModel>
                {
                    Draw = param.Draw,
                    Data = turns.ToList(),
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
        public async Task<IActionResult> SetStatus(int id, AppointmentStatus status, bool isReservable)
        {
            try
            {
                var appointment =
                    _dbContext.Appointments
                    .FirstOrDefault(x => x.Id == id &&
                                         x.ServiceSupply.ShiftCenterId == CurrentPolyclinic.Id &&
                                         x.Status != status &&
                                         !x.IsDeleted);
                if (appointment == null)
                {
                    throw new EntityNotFoundException();
                }

                //keep this id before appointment removed
                var userReciverId = appointment.PersonId;
                var smsBody = "";
                string[] recepient = { $"964{appointment.Person.Mobile}" };
                var statuses = new byte[recepient.Length];
                var recId = new long[recepient.Length];

                var action = status == AppointmentStatus.Done ? Messages.HasDone : Messages.HasCanceled;
                smsBody = Global.Turn + " " + appointment.Start_DateTime.ToShortDateString() + Global.PolyclinicPrefix + " " + (Lng == Core.Enums.Lang.KU ? appointment.ServiceSupply.ShiftCenter.Name_Ku : appointment.ServiceSupply.ShiftCenter.Name_Ar) + " " + action;

                _dbContext.Entry(appointment).State = EntityState.Modified;
                appointment.Status = status;
                if (status == AppointmentStatus.Canceled && isReservable)
                {
                    appointment.IsDeleted = true;
                }

                try
                {
                    _plivoService.SendMessage(recepient.ToList(), smsBody);
                    if (0 == 0)
                    {
                        if (statuses.FirstOrDefault() == 0)
                        {
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
                    }
                }
                catch
                {

                }

                await _dbContext.SaveChangesAsync();

                return Json(new { success = true, message = Messages.ActionDoneSuccesfully });
            }
            catch
            {
                return Json(new { success = false, message = Messages.ErrorOccuredWhileDoneAction });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            try
            {
                var appointment = _appointmentService.GetAllForPolyClinic(CurrentPolyclinic.Id).FirstOrDefault(x => x.Id == id);
                if (appointment == null)
                {
                    throw new EntityNotFoundException();
                }
                _appointmentService.SoftDeleteAppointment(appointment.Id);
                TempData.Put("message", new MVCResultModel { status = MVCResultStatus.danger, message = Messages.ItemDeletedSuccessFully });
                return Redirect(Request.Headers["Referer"].ToString());
            }
            catch (Exception)
            {
                TempData.Put("message", new MVCResultModel { status = MVCResultStatus.danger, message = Messages.AnErrorOccuredWhileDeleteItem });
                return Redirect(Request.Headers["Referer"].ToString());
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult HardDelete(int id)
        {
            try
            {
                var appointment = _dbContext.Appointments.FirstOrDefault(x => x.Id == id && x.ServiceSupply.ShiftCenterId == CurrentPolyclinic.Id && x.IsDeleted);

                var messages = _dbContext.PoliclinicMessages.Where(x => x.AppointmentId == appointment.Id);
                if (messages != null)
                {
                    _dbContext.PoliclinicMessages.RemoveRange(messages);
                    _dbContext.SaveChanges();
                }

                var paymentInfoes = _dbContext.PaymentInfoes.Where(x => x.AppointmentId == appointment.Id);
                if (paymentInfoes != null)
                {
                    _dbContext.PaymentInfoes.RemoveRange(paymentInfoes);
                }

                _dbContext.Appointments.Remove(appointment);
                _dbContext.SaveChanges();

                TempData.Put("message", new MVCResultModel { status = MVCResultStatus.danger, message = Messages.ItemDeletedSuccessFully });

                return Redirect(Request.Headers["Referer"].ToString());
            }
            catch
            {
                TempData.Put("message", new MVCResultModel { status = MVCResultStatus.danger, message = Messages.AnErrorOccuredWhileDeleteItem });
                return Redirect(Request.Headers["Referer"].ToString());
            }
        }
    }
}