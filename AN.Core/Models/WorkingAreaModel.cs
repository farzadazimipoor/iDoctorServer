using Shared.Enums;
using System.Collections.Generic;

namespace AN.Core.Models
{
    /// <summary>
    /// Represents current working area (center): Hospital, Clinic, Polyclinic, Pharmacy, Sonar Or Beauty Center
    /// </summary>
    public class WorkingAreaModel
    {
        /// <summary>
        /// This is id of center (Center id that user can manage)
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Center Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// User logged in as
        /// </summary>
        public LoginAs LoginAs { get; set; } = LoginAs.UNKNOWN;       

        /// <summary>
        /// The service suppliers ids that user can manage (if null, user can manage all of them)
        /// </summary>
        public List<int> ServiceSupplyIds { get; set; }

        public string UserTitle { get; set; }

        public string SystemTitle { get; set; }

        public CurrentUser CurrentUser { get; set; } = new CurrentUser();
    }

    public class CurrentUser
    {
        public string UserId { get; set; }
        public int PersonId { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Avatar { get; set; }        
    }
}
