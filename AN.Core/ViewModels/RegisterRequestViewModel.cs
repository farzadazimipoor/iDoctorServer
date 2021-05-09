using AN.Core.Resources.Global;
using JqueryDataTables.ServerSide.AspNetCoreWeb.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace AN.Core.ViewModels
{
    public class RegisterRequestsListViewModel
    {
        public int Id { get; set; }

        [SearchableString]
        [Sortable(Default = true)]
        [Display(Name = "Date", ResourceType = typeof(Global))]
        public string CreateDate { get; set; }

        [SearchableString]
        [Sortable(Default = true)]
        [Display(Name = "Name", ResourceType = typeof(Global))]
        public string Name { get; set; }

        [SearchableString]
        [Sortable(Default = false)]
        [Display(Name = "Mobile", ResourceType = typeof(Global))]
        public string Mobile { get; set; }

        [SearchableString]
        [Sortable(Default = false)]
        [Display(Name = "Gender", ResourceType = typeof(Global))]
        public string Gender { get; set; }

        [SearchableString]
        [Sortable(Default = false)]
        [Display(Name = "Center", ResourceType = typeof(Global))]
        public string CenterName { get; set; }

        [SearchableString]
        [Sortable(Default = false)]
        [Display(Name = "Phone", ResourceType = typeof(Global))]
        public string CenterPhone { get; set; }

        [Display(Name = "City", ResourceType = typeof(Global))]
        public string CenterCity { get; set; }

        [Display(Name = "Type", ResourceType = typeof(Global))]
        public string CenterType { get; set; }

        public string Avatar { get; set; }

        public string AvatarHtml { get; set; }

        public string ActionsHtml { get; set; }
    }   

    public class RegisterRequestsFilterViewModel
    {
        public string FilterString { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
    }   
}

