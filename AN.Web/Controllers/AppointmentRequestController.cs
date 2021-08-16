using AN.BLL.DataRepository.Appointments;
using AN.BLL.DataRepository.ServiceSupplies;
using AN.Core;
using AN.Core.Enums;
using AN.Core.Exceptions;
using AN.Core.Extensions;
using AN.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shared.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AN.Web.Controllers
{
    public class AppointmentRequestController : CpanelBaseController
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IServiceSupplyService _serviceSupplyService;
        private readonly IWorkContext _workContext;
        public AppointmentRequestController(IAppointmentService appointmentService,
                                            IServiceSupplyService serviceSupplyService, IWorkContext workContext) : base(workContext)
        {
            _appointmentService = appointmentService;
            _serviceSupplyService = serviceSupplyService;
            _workContext = workContext;
        }

        public async Task<IActionResult> Requests()
        {
            ViewBag.Lang = Lng;

            ViewBag.Doctors = await _serviceSupplyService.GetSelectListAsync();

            return View(new AppointmentRequestsListViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> LoadAppointmentRequestsTable([FromBody] DataTablesParameters param)
        {
            try
            {
                var filtersModel = JsonConvert.DeserializeObject<AppointmentRequestsFilterViewModel>(param.FiltersObject);

                if(_workContext.WorkingArea != null && _workContext.WorkingArea.LoginAs != Shared.Enums.LoginAs.ADMIN && _workContext.WorkingArea.Id > 0)
                {
                    if (!User.IsInRole(Shared.Constants.SystemRoles.CALLCENTER))
                    {
                        filtersModel.ShiftCenterId = _workContext.WorkingArea.Id;
                    }                    
                }                

                var results = await _appointmentService.GetAppointmentRequestsDataTableAsync(param, filtersModel, Lng);

                var requests = await Task.WhenAll(results.Items.Select(async (x) => new AppointmentRequestsListViewModel
                {
                    Id = x.Id,
                    CenterAddress = x.CenterAddress,
                    Patient = x.Patient,
                    Doctor = x.Doctor,
                    ReservationChannel = x.ReservationChannel,
                    Status = x.Status,
                    CreateDate = x.CreateDate,
                    Mobile = x.Mobile,
                    Gender = x.Gender,
                    CenterName = x.CenterName,
                    CenterPhone = x.CenterPhone,
                    Avatar = x.Avatar,
                    Service = x.Service,
                    IsHomeCare = x.IsHomeCare,
                    ProgressStatus = x.ProgressStatus,
                    AvatarHtml = await this.RenderViewToStringAsync("_AppointmentRequestPersonAvatar", x.Avatar),
                    ActionsHtml = await this.RenderViewToStringAsync("_AppointmentRequestActions", (x.Id, x.Status)),
                    ChannelHtml = await this.RenderViewToStringAsync("_AppointmentRequestChannels", x.ReservationChannel),
                    StatusHtml = await this.RenderViewToStringAsync("_AppointmentRequestStatus", x.Status),
                    ProgressStatusHtml = await this.RenderViewToStringAsync("_AppointmentRequestProgressStatus", (x.Id, x.Status, x.IsHomeCare, x.ProgressStatus)),
                }).ToList());

                return new JsonResult(new DataTablesResult<AppointmentRequestsListViewModel>
                {
                    Draw = param.Draw,
                    Data = requests.ToList(),
                    RecordsFiltered = results.TotalSize,
                    RecordsTotal = results.TotalSize
                });
            }
            catch (Exception e)
            {
                return new JsonResult(new { error = "Internal Server Error" });
            }
        }

        public async Task<IActionResult> Details(int id)
        {
            var result = await _appointmentService.GetAppointmentRequestDetailsAsync(id, Lng);

            return PartialView(result);
        }

        public async Task<IActionResult> ApproveAppointmentRequest(int id)
        {
            var appointmentRequest = await _appointmentService.GetAppointmentByIdAsync(id);

            if (appointmentRequest == null) throw new AwroNoreException("Appointment request not found");

            var model = new ApproveAppointmentRequestModel
            {
                Id = id,
                Date = appointmentRequest.Start_DateTime,
                StartTime = appointmentRequest.Start_DateTime.ToShortTimeString(),
                EndTime = appointmentRequest.End_DateTime.ToShortTimeString(),
                SendNotification = true
            };

            return PartialView(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ApproveAppointmentRequest(ApproveAppointmentRequestModel model)
        {
            await _appointmentService.ApproveAppointmentRequestAsync(model);

            return Json(new { success = true, message = Core.Resources.EntitiesResources.Messages.ActionDoneSuccesfully });
        }

        public async Task<IActionResult> DeleteAppointmentRequest(int id)
        {
            await _appointmentService.DeleteAppointmentRequestAsync(id);

            return Json(new { success = true, message = Core.Resources.EntitiesResources.Messages.ItemDeletedSuccessFully });
        }

        public async Task<IActionResult> ChangeAppointmentRequestProgressStatus(int id, AppointmentProgressStatus status)
        {
            await _appointmentService.ChangeAppointmentRequestProgressStatusAsync(id, status);

            return Json(new { success = true, message = Core.Resources.EntitiesResources.Messages.ActionDoneSuccesfully });
        }
    }
}
