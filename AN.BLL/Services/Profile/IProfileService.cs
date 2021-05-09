using AN.Core.DTO.Profile;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace AN.BLL.Services.Profile
{
    public interface IProfileService
    {
        Task<ProfileStatusDTO> GetUserProfileStatusAsync(string mobile, string fcmToken);

        Task<ProfileStatusDTO> CreateOrUpdateUserProfileAsync(ProfileCRUDDTO profile);

        Task<ProfileCRUDDTO> GetUserProfileDataAsync(string mobile);

        Task<string> UpdateProfileAvatarAsync(string mobile, IFormFile photo);

        Task<string> RemoveProfileAvatarAsync(string mobile);

        Task LogoutPersonFromDeviceAsync(string mobile, string fcmInstanceId);

        Task<DiseaseRecordsFormDTO> GetDiseaseRecordsFormAsync(string mobile);

        Task UpdateDiseaseRecordsFormAsync(string mobile, DiseaseRecordsFormDTO form);
    }
}
