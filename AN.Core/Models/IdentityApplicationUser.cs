using System.Collections.Generic;

namespace AN.Core.Models
{
    public class IdentityApplicationUser
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public string LoginAs { get; set; }
        public List<string> Roles { get; set; } = new List<string>();
    }
}
