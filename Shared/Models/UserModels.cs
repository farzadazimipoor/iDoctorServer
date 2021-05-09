using Shared.Enums;

namespace Shared.Models
{
    public class UserFilterModel
    {
        public string FilterString { get; set; }
        public int? PersonId { get; set; }
        public int? CenterId { get; set; }
        public int? ServiceSupplyId { get; set; }
        public string Role { get; set; }
    }

    public class UsersQueryModel
    {
        public DataTablesParameters Parameters { get; set; }
        public UserFilterModel FilterModel { get; set; }
    }
}
