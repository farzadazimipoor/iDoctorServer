using AN.Core.DTO;
using AN.Core.DTO.Doctors;
using AN.Core.DTO.Rating;
using AN.Core.Enums;
using AN.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AN.BLL.Services.Doctors
{
    public interface IDoctorsService
    {
        Task<DoctorScheduleInfoDTO> GetSchedulesAsync(int ssId, Lang lang);

        Task<List<CenterTypeDTO>> GetSupportAppointmentsCenterTypesAsync(string baseUrl);

        Task<List<ServiceDTO>> GetCenterServicesAsync(int serviceSupplyId, Lang lang);

        Task<(long totalCount, int totalPages, List<DoctorListItemDTO>)> GetDoctorsListPagingAsync(DoctorFilterDTO filterModel, Lang lang, string hostAddress, int page = 0, int pageSize = 12);

        Task<DoctorsResultDTO> GetFavoriateDoctorsAsync(FavoriatesDTO model, Lang lang, string hostAddress);

        Task<ReservationType> GetReservationTypeAsync(int serviceSupplyId);

        Task<DoctorDetailsDTO> GetDoctorDetailsAsync(int serviceSupplyId, Lang lang, int? centerServiceId = null, int? offerId = null);

        Task<List<ImageUrlModel>> GetDoctorsPhotosGallery(int serviceSupplyId, Lang lang);

        Task<TurnModel> GetNextFirstAvailableTurnAsync(int serviceSupplyId, int centerServiceId, Lang lang);

        Task<DoctorReservationStatusDTO> GetDoctorReservationStatusAsync(int serviceSupplyId, int centerServiceId);

        Task<DateBookableTurnsDTO> GetBookableTurnsForDateAsync(int serviceSupplyId, int centerServiceId, string date);

        Task RateDoctorAsync(RatingDTO rating);

        Task UpdateSecretaryPhonesAsync();
    }
}
