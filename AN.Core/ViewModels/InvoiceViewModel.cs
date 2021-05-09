using AN.Core.Resources.Global;
using JqueryDataTables.ServerSide.AspNetCoreWeb.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AN.Core.ViewModels
{
    public class InvoiceListItemViewModel
    {
        public int Id { get; set; }

        [SearchableString]
        [Sortable(Default = true)]
        [Display(Name = "Doctor", ResourceType = typeof(Global))]
        public string Doctor { get; set; }

        [SearchableString]
        [Sortable(Default = false)]
        [Display(Name = "Patient", ResourceType = typeof(Global))]
        public string Patient { get; set; }

        [SearchableString]
        [Sortable(Default = false)]
        [Display(Name = "Gender", ResourceType = typeof(Global))]
        public string Gender { get; set; }       

        [SearchableString]
        [Sortable(Default = false)]
        [Display(Name = "VisitDate", ResourceType = typeof(Global))]
        public string VisitDate { get; set; }

        [Sortable(Default = false)]
        [Display(Name = "TotalInDollars", ResourceType = typeof(Global))]
        public decimal Amount { get; set; }

        public string Avatar { get; set; }

        public string AvatarHtml { get; set; }

        public string ActionsHtml { get; set; }
    }

    public class InvoiceFilterViewModel
    {
        public string FilterString { get; set; }
        public DateTime? VisitFrom { get; set; }
        public DateTime? VisitTo { get; set; }
        public int? PatientId { get; set; }
        public int? DoctorId { get; set; }
        public List<int> ServiceSupplyIds { get; set; }
    }

}
