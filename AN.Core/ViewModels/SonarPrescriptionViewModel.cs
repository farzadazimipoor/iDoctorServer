using AN.Core.Enums;
using AN.Core.Resources.Global;
using JqueryDataTables.ServerSide.AspNetCoreWeb.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace AN.Core.ViewModels
{
    public class SonarPrescriptionListViewModel
    {
        public int Id { get; set; }

        public int CenterId { get; set; }

        public int TreatmentHistoryId { get; set; }

        public PrescriptionStatus Status { get; set; }

        [SearchableString]
        [Sortable(Default = true)]
        [Display(Name = "Polyclinic", ResourceType = typeof(Global))]
        public string SonarCenter { get; set; }

        [SearchableString]
        [Sortable(Default = false)]
        [Display(Name = "Doctor", ResourceType = typeof(Global))]
        public string Doctor { get; set; }

        [SearchableString]
        [Sortable(Default = false)]
        [Display(Name = "Patient", ResourceType = typeof(Global))]
        public string Patient { get; set; }

        [SearchableString]
        [Sortable(Default = false)]
        [Display(Name = "Date", ResourceType = typeof(Global))]
        public string CreateDate { get; set; }

        [SearchableString]
        [Sortable(Default = false)]
        [Display(Name = "Status", ResourceType = typeof(Global))]
        public string StatusName { get; set; }

        public string ActionsHtml { get; set; }
    }

    public class PrescriptionFilterViewModel
    {
        public int CenterId { get; set; }

        public string FilterString { get; set; }

        public PrescriptionStatus? Status { get; set; }

        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }
    }
}
