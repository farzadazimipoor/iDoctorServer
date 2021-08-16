using AN.Core.Enums;
using AN.Core.Resources.Global;
using JqueryDataTables.ServerSide.AspNetCoreWeb.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace AN.Core.ViewModels
{
    public class AppointmentRequestsListViewModel
    {
        public int Id { get; set; }

        public AppointmentStatus Status { get; set; }

        public ReservationChannel ReservationChannel { get; set; }

        public AppointmentProgressStatus? ProgressStatus { get; set; }

        [SearchableString]
        [Sortable(Default = false)]
        [Display(Name = "Center", ResourceType = typeof(Global))]
        public string CenterName { get; set; }

        [SearchableString]
        [Sortable(Default = false)]
        [Display(Name = "Phone", ResourceType = typeof(Global))]
        public string CenterPhone { get; set; }

        [SearchableString]
        [Sortable(Default = false)]
        [Display(Name = "Address", ResourceType = typeof(Global))]
        public string CenterAddress { get; set; }

        [SearchableString]
        [Sortable(Default = true)]
        [Display(Name = "Doctor", ResourceType = typeof(Global))]
        public string Doctor { get; set; }

        [SearchableString]
        [Sortable(Default = true)]
        [Display(Name = "Patient", ResourceType = typeof(Global))]
        public string Patient { get; set; }

        [SearchableString]
        [Sortable(Default = false)]
        [Display(Name = "Mobile", ResourceType = typeof(Global))]
        public string Mobile { get; set; }

        [SearchableString]
        [Sortable(Default = false)]
        [Display(Name = "Gender", ResourceType = typeof(Global))]
        public string Gender { get; set; }

        [SearchableString]
        [Sortable(Default = true)]
        [Display(Name = "Date", ResourceType = typeof(Global))]
        public string CreateDate { get; set; }

        [SearchableString]
        [Sortable(Default = true)]
        [Display(Name = "Service", ResourceType = typeof(Global))]
        public string Service { get; set; }

        public bool IsHomeCare { get; set; }

        public string Avatar { get; set; }

        public string AvatarHtml { get; set; }

        public string StatusHtml { get; set; }

        public string ProgressStatusHtml { get; set; }

        public string ChannelHtml { get; set; }

        public string ActionsHtml { get; set; }
    }

    public class AppointmentRequestDetailsViewModel : AppointmentRequestsListViewModel
    {
        public string Xlongitude {get; set; }
        public string Ylatitude { get; set; }
    }

    public class AppointmentRequestsFilterViewModel
    {
        public int? ShiftCenterId { get; set; }
        public string FilterString { get; set; }
        public int? ServiceSupplyId { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
    }

    public class ApproveAppointmentRequestModel
    {
        public int Id { get; set; }

        [Display(Name = "Date", ResourceType = typeof(Global))]
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public DateTime Date { get; set; }

        [Display(Name = "FromTime", ResourceType = typeof(Global))]
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public string StartTime { get; set; }

        [Display(Name = "ToTime", ResourceType = typeof(Global))]
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public string EndTime { get; set; }

        [Display(Name = "SendNotification", ResourceType = typeof(Global))]
        public bool SendNotification { get; set; }
    }
}
