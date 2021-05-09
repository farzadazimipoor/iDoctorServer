using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AN.Web.Areas.ClinicManager.Models
{
    public class CMReportingViewModel
    {
        public IEnumerable<SelectListItem> ListPolyclinics { get; set; }
        public IEnumerable<SelectListItem> ListServiceSupplies { get; set; }        
        public IEnumerable<SelectListItem> ListPaymentStatuses { get; set; }
        public IEnumerable<SelectListItem> ListHealthServices { get; set; }
        public int polyclinicId { get; set; }
        public int serviceSupplyId { get; set; }
        public string DoctorName { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }       
        public List<AppointmentReportModel> ListAppointments { get; set; }
    }

    public class AppointmentReportModel
    {
        public string DayOfWeek { get; set; }
        public string StartTime { get; set; }
        public string PatientName { get; set; }
        public string PatientMobile { get; set; }
    }

    public class ReportAllViewModel
    {
        [Required(ErrorMessageResourceType = typeof(AN.Core.Resources.Global.Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public int PolyclinicId { get; set; }
        public List<SelectListItem> ListPolyclinics { get; set; }
        [Required(ErrorMessageResourceType = typeof(AN.Core.Resources.Global.Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public string FromDate { get; set; } = DateTime.Now.ToShortDateString();
        [Required(ErrorMessageResourceType = typeof(AN.Core.Resources.Global.Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public string ToDate { get; set; } = DateTime.Now.ToShortDateString();
        public int Shift { get; set; }
        public List<SelectListItem> ListShifts { get; set; }
    }

    public class AppoinemetsToReportModel
    {
        public string RowNumber { get; set; }
        public DateTime StartDateTime { get; set; }
        public string PatientName { get; set; }
        public string PatientMobile { get; set; }
        public string PolyclinicName { get; set; }
        public string DoctorName { get; set; }
    }


    public class WorkingHoursReportViewModel
    {
        [Required(ErrorMessageResourceType = typeof(AN.Core.Resources.Global.Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public int PolyclinicId { get; set; }
        [Required(ErrorMessageResourceType = typeof(AN.Core.Resources.Global.Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public string FromDate { get; set; } = DateTime.Now.AddDays(-30).ToShortDateString();
        [Required(ErrorMessageResourceType = typeof(AN.Core.Resources.Global.Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public string ToDate { get; set; } = DateTime.Now.ToShortDateString();

        public List<SelectListItem> ListPolyclinics { get; set; }
    }
}