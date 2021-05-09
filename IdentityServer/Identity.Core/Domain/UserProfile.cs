using Newtonsoft.Json;
using Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Identity.Core.Domain
{
    public class UserProfile : BaseEntity
    {
        public int? PersonId { get; set; }
        public int? CenterId { get; set; }

        public string _ServiceSupplyIds { get; set; }
        [NotMapped]
        public List<int> ServiceSupplyIds
        {
            get { return _ServiceSupplyIds == null ? null : JsonConvert.DeserializeObject<List<int>>(_ServiceSupplyIds); }
            set { _ServiceSupplyIds = JsonConvert.SerializeObject(value); }
        }       
        public LoginAs LoginAs { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
