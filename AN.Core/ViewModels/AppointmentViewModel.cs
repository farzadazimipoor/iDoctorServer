using AN.Core.Enums;
using AN.Core.Resources.Global;
using JqueryDataTables.ServerSide.AspNetCoreWeb.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace AN.Core.ViewModels
{
    public class AppointmentListViewModel
    {
        public int Id { get; set; }

        public AppointmentStatus Status { get; set; }

        public string StatusHtml { get; set; }

        public ReservationChannel ReservationChannel { get; set; }

        public string ChannelHtml { get; set; }

        [SearchableString]
        [Sortable(Default = true)]
        [Display(Name = "Date", ResourceType = typeof(Global))]
        public string Date { get; set; }

        [SearchableString]
        [Sortable(Default = false)]
        [Display(Name = "Person", ResourceType = typeof(Global))]
        public string Person { get; set; }

        [SearchableString]
        [Sortable(Default = false)]
        [Display(Name = "Mobile", ResourceType = typeof(Global))]
        public string PatientMobile { get; set; }    

        public string ServiceSupplier { get; set; }
        
        public bool HasTreatmentHistory { get; set; }

        public int PersonId { get; set; }

        public int ServiceSupplyId { get; set; }

        public string Avatar { get; set; }

        public string AvatarHtml { get; set; }

        public string ActionsHtml { get; set; }
    }

    public class PolyclinicAppointmentListViewModel : AppointmentListViewModel
    {
        [SearchableString]
        [Sortable(Default = false)]
        [Display(Name = "Doctor", ResourceType = typeof(Global))]
        public string Doctor { get; set; }
    }

    public class BeautyCenterAppointmentListViewModel : AppointmentListViewModel
    {
        [SearchableString]
        [Sortable(Default = false)]
        [Display(Name = "Employee", ResourceType = typeof(Global))]
        public string Employee { get; set; }
    }

    public class ShiftCenterAppointmentsFilterModel
    {
        public int? ServiceSupplyId { get; set; }

        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }

        public AppointmentStatus? Status { get; set; }
    }
}
