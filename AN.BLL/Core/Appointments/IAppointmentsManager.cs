using AN.Core.Domain;
using AN.Core.DTO.Turn;
using AN.Core.Enums;
using AN.Core.Models;
using System;
using System.Threading.Tasks;

namespace AN.BLL.Core.Appointments
{
    public interface IAppointmentsManager
    {
        Task<BookingAppointmentResult> BookAppointmentAsync(
            ServiceSupply serviceSupply,
            PatientModel patinetModel,
            string Date,
            string StartTime,
            string EndTime,
            bool _existUser,
            PaymentStatus paymentStatus,
            ShiftCenterService polyclinicHealthService,
            ReservationChannel channel,
            Lang requestLang,
            int? offerId = null);

        Task<(string trackingCode, int appointmentId)> CreateRequestedAppointmentAsync(string userMobile, FinalBookTurnDTO model, Lang requestLang);


        bool HaveAppointmentForDate(string date, string mobile, int serviceSupplyId, int centerServiceId);

        Task EnsureNotHaveSameTimeAppointmentAsync(DateTime dateTime, string mobile);
    }
}
