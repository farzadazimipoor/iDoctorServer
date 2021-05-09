using AN.BLL.DataRepository.Clinics;
using AN.BLL.DataRepository.PolyclinicMessages;
using AN.Core.Enums;
using AN.Web.Areas.ClinicManager.Models;
using Microsoft.AspNetCore.Mvc;
using NLog;
using X.PagedList;
using System;
using System.Linq;

namespace AN.Web.Areas.ClinicManager.Controllers
{
    public class MessageController : ClinicManagerController
    {
        #region Fields
        private static Logger logger;
        private readonly IShiftCenterMessageService _polyclinicMessageService;
        private readonly IClinicService _clinicService;
        #endregion

        #region Ctor
        public MessageController(IClinicService clinicService, IShiftCenterMessageService polyclinicMessageService) : base(clinicService)
        {
            _clinicService = clinicService;
            _polyclinicMessageService = polyclinicMessageService;

            logger = LogManager.GetCurrentClassLogger();
        }
        #endregion

        [HttpGet]
        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.RecipientNameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.SendingDateSortParam = sortOrder == "SendingDate" ? "date_desc" : "SendingDate";
            ViewBag.RecipientMobileSortParam = sortOrder == "RecipientMobile" ? "rmobile_desc" : "RecipientMobile";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var messages = from m in _polyclinicMessageService.Table
                           where m.ShiftCenter.ClinicId == CurrentClinic.Id && m.Type == MessageType.SMS
                           select new CMMessageViewModel
                           {
                               RecipientName = m.ReceiverPerson.FirstName + " " + m.ReceiverPerson.SecondName + " " + m.ReceiverPerson.ThirdName,
                               RecipientNumber = m.Recipient,
                               SendingDate = m.SendingDate,
                               PolyclinicName = Lng == Lang.KU ? m.ShiftCenter.Name_Ku : m.ShiftCenter.Name_Ar,
                               DoctorName = m.Appointment.ServiceSupply.Person.FirstName + " " + m.Appointment.ServiceSupply.Person.SecondName + " " + m.Appointment.ServiceSupply.Person.ThirdName,
                               About = m.About,
                               DeliveryStatus = (long)m.MessageStatus
                           };

            if (!string.IsNullOrEmpty(searchString))
            {
                messages = messages.Where(m =>
                m.RecipientName.Contains(searchString) ||
                m.RecipientNumber.Contains(searchString) ||
                m.DoctorName.Contains(searchString) ||
                m.PolyclinicName.Contains(searchString)
                );
            }

            switch (sortOrder)
            {
                case "name_desc":
                    messages = messages.OrderByDescending(a => a.RecipientName);
                    break;
                case "SendingDate":
                    messages = messages.OrderBy(a => a.SendingDate);
                    break;
                case "date_desc":
                    messages = messages.OrderByDescending(a => a.SendingDate);
                    break;
                case "RecipientMobile":
                    messages = messages.OrderBy(a => a.RecipientNumber);
                    break;
                case "rmobile_desc":
                    messages = messages.OrderByDescending(a => a.RecipientNumber);
                    break;
                default:
                    messages = messages.OrderByDescending(a => a.SendingDate);
                    break;
            }

            var pageSize = 10;
            var pageNumber = (page ?? 1);
            return View(messages.ToPagedList(pageNumber, pageSize));
        }
    }
}