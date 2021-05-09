using Shared.Enums;
using System.Collections.Generic;

namespace Shared.DTO
{
    public class UserDTO
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public bool TwoFactorEnabled { get; set; } = false;
        public bool IsSystemUser { get; set; } = false;
        public UserProfileDTO UserProfile { get; set; }
        public List<string> Roles { get; set; }
    }

    public class UserProfileDTO
    {
        public int? PersonId { get; set; }
        public int? CenterId { get; set; }
        public List<int> ServiceSupplyIds { get; set; }
        public LoginAs LoginAs { get; set; }
    }

    public class UserFilterDTO
    {
        public LoginAs? LoginAs { get; set; }
        public int? PersonId { get; set; }
        public int? CenterId { get; set; }
        public List<int> ServiceSupplyIds { get; set; }
        public int Start { get; set; }
        public int Length { get; set; }
    }

    public class UserListItemDTO
    {
        public string Id { get; set; }
        public string UserName { get; set; }      
        public string Mobile { get; set; }     
        public LoginAs LoginAs { get; set; }
        public string RoleId { get; set; }
        public string Role { get; set; }
        public int? PersonId { get; set; }
        public int? CenterId { get; set; }
        public bool IsLocked { get; set; }
        public List<int> ServiceSupplyIds { get; set; }
    }

    public class UsersResultDTO
    {
        public List<UserListItemDTO> Users { get; set; }
        public int TotalCount { get; set; }
    }

    public class ChangePasswordDTO
    {
        public string Username { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }

    public class LockoutUserDTO
    {
        public string Id { get; set; }
        public int? ForDays { get; set; }
        public bool IsLocked { get; set; }
    }
}
