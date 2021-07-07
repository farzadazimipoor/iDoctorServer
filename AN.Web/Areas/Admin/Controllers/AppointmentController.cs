using AN.BLL.DataRepository.Appointments;
using AN.BLL.DataRepository.ServiceSupplies;
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

namespace AN.Web.Areas.Admin.Controllers
{

    public class AppointmentController : AdminController
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IServiceSupplyService _serviceSupplyService;
        public AppointmentController(IAppointmentService appointmentService,
                                     IServiceSupplyService serviceSupplyService)
        {
            _appointmentService = appointmentService;
            _serviceSupplyService = serviceSupplyService;
        }

        public async Task<ViewResult> Index(string sortOrder, string currentServiceSupplyIdFilter, string serviceSupplyId, string currentFromDateFilter, string fromDate, string currentToDateFilter, string toDate, int? page)
        {
            ViewBag.Lang = Lng;

            ViewBag.CurrentSort = sortOrder;

            ViewBag.DateSortParam = sortOrder == "Date" ? "date_desc" : "Date";            

            if (serviceSupplyId != null)
            {
                page = 1;
            }
            else
            {
                serviceSupplyId = currentServiceSupplyIdFilter;
            }

            if (fromDate != null)
            {
                page = 1;
            }
            else
            {
                fromDate = currentFromDateFilter;
            }

            if (toDate != null)
            {
                page = 1;
            }
            else
            {
                toDate = currentToDateFilter;
            }

            ViewBag.CurrentServiceSupplyIdFilter = serviceSupplyId;
            ViewBag.CurrentFromDateFilter = fromDate;
            ViewBag.CurrentToDateFilter = toDate;

            var (appointments, count) = await _appointmentService.GetAppointmentsPagedListAsync(sortOrder, serviceSupplyId, fromDate, toDate, page);

            ViewBag.AppointsCount = count;

            ViewBag.Doctors = await _serviceSupplyService.GetSelectListAsync();

            return View(appointments);
        }       
    }
}