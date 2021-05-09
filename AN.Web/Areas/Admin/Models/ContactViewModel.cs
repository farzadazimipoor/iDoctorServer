using System.ComponentModel.DataAnnotations;

namespace AN.Web.Areas.Admin.Models
{
    public class ContactViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Sender", ResourceType = typeof(Core.Resources.Global.Global))]
        public string Name { get; set; }

        [Display(Name = "Topic", ResourceType = typeof(Core.Resources.Global.Global))]
        public string Topic { get; set; }

        public bool IsUnread { get; set; }
    }

    public class ContactReadModel
    {
        [Display(Name = "Email", ResourceType = typeof(Core.Resources.Global.Global))]
        public string Email { get; set; }

        [Display(Name = "Sender", ResourceType = typeof(Core.Resources.Global.Global))]
        public string Name { get; set; }

        [Display(Name = "Mobile", ResourceType = typeof(Core.Resources.Global.Global))]
        public string Mobile { get; set; }
       
        public string Topic { get; set; }
      
        public string Message { get; set; }

        public bool IsArchived { get; set; }

        public bool IsUnread { get; set; }
    }
}