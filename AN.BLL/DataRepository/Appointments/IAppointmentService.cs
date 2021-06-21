using AN.Core.Domain;
using AN.Core.Enums;
using AN.Core.ViewModels;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace AN.BLL.DataRepository.Appointments
{
    public partial interface IAppointmentService
    {
        IQueryable<Appointment> Table { get; }

        Task<(int site, int app, int kiosk, int sms, int ussd, int voip, int outOfSchedule)> GetReservationChannelStatisticsAsync();

        Task<(IPagedList<Appointment>, int count)> GetAppointmentsPagedListAsync(string sortOrder, string serviceSupplyId, string fromDate, string toDate, int? page, int? polyclinicId = null, AppointmentStatus? status = null);

        Task<int> GetAllAppointmentsCountAsync();

        Task<int> GetAllAppointmentsCountByStatusAsync(AppointmentStatus status);

        Appointment GetAppointmentById(int id);

        Appointment GetAppointmentForMobileInDate(int serviceSupplyId, int centerServiceId, string mobile, DateTime date);

        Task<Appointment> GetAppointmentByIdAsync(int id);

        Task<Appointment> GetAppointmentByIdForServiceSupplyAsync(int serviceSupplyId, long appointmentId);

        void UpdateAppointment(Appointment appointment);       

        /// <summary>
        /// یافتن نوبت های آینده در بازه زمانی یک ساعت کاری دستی تعریف شده
        /// </summary>
        /// <param name="serviceSupplyId"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        Task<IList<Appointment>> GetPendingAppointmentsForServiceSupplyInManualScheduleAsync(int serviceSupplyId, DateTime startTime, DateTime endTime);

        List<Appointment> GetPendingAppointmentsForServiceSupplyInManualSchedule(int serviceSupplyId, DateTime startTime, DateTime endTime);

        int GetQueueNumberForAppointment(int serviceSupplyId, int appointmentId, int polyclinicHealthServiceId, DateTime date);        

        IList<Appointment> GetAllAppointmentsForPolyclinicInDayOfWeek(int polyclinicId, int serviceSupplyId, AppointmentStatus status, string dayOfWeek, ScheduleShift shift);

        Task<IList<Appointment>> GetAllPendingAppointmentsForServiceSupply(int serviceSupplyId);      

        IQueryable<Appointment> GetAllForHospital(int hospitalId);

        IQueryable<Appointment> GetAllForClinic(int clinicId);

        IQueryable<Appointment> GetAllForPolyClinic(int polyclinicId);      

        void SoftDeleteAppointment(int id);

        Task<bool> IsExistTrackingNumberAsync(string trackingNumber);

        Task<string> GenerateUniqueTrackingNumberAsync();

        Task<DataTablesPagedResults<AppointmentListViewModel>> GetDataTableAsync(int shiftCenterId, DataTablesParameters table, ShiftCenterAppointmentsFilterModel filters, Lang lng = Lang.KU, List<int> serviceSupplyIds = null);

        Task<DataTablesPagedResults<AppointmentRequestsListViewModel>> GetAppointmentRequestsDataTableAsync(DataTablesParameters table, AppointmentRequestsFilterViewModel filters, Lang lng = Lang.KU);

        Task ApproveAppointmentRequestAsync(ApproveAppointmentRequestModel model);

        Task DeleteAppointmentRequestAsync(int id);

        Task ChangeAppointmentRequestProgressStatusAsync(int id, AppointmentProgressStatus status);
    }
}
