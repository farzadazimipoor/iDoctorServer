using Identity.Core.Domain;
using Identity.DAL.Repository;
using Shared.DTO;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Identity.BLL.DataRepository.UserRepository
{
    public interface IUserRepository : IRepository<ApplicationUser>
    {
        Task<string> GenerateAndSendOTPAsync(string mobile);

        ApplicationUser GetUserAccount(string mobile);

        void InsertNewUserAccount(string username, string password, string phone, out Guid userGuid);

        Task<ApplicationUser> FindBySubjectIdAsync(string subjectId);

        Task<IList<string>> GetRolesAsync(ApplicationUser user);

        Task<UserDTO> GetUserByIdAsync(string id);

        Task<(bool isSucceed, string message, string createdId)> CreateUserAsync(UserDTO model);

        Task<(bool isSucceed, string message)> UpdateUserAsync(UserDTO model);

        Task<(bool isSucceed, string message)> DeleteUserAsync(string id);

        Task<UsersResultDTO> GetUsersPagingListAsync(UsersQueryModel queryModel);

        Task<(bool isSucceed, string message)> ChangePasswordAsync(ChangePasswordDTO model);

        Task<(bool isSucceed, string message)> LockoutUserAccountAsync(LockoutUserDTO model);
    }
}
