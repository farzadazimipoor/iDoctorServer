using AN.Core.Domain;
using AN.Core.Enums;
using AN.Core.Resources.Global;
using AN.Core.ViewModels;
using AN.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AN.BLL.Services.Reports
{
    public class DashboardReportsService : IDashboardReportsService
    {
        private readonly BanobatDbContext _dbContext;
        public DashboardReportsService(BanobatDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CenterAppointmentsDashboardModel> GetShiftCenterDashboardDataAsync(int centerId, List<int> serviceSupplyIds = null)
        {
            IQueryable<Appointment> appointsQuery = _dbContext.Appointments;

            appointsQuery = appointsQuery.Where(x => x.ServiceSupply.ShiftCenterId == centerId);

            if (serviceSupplyIds != null && serviceSupplyIds.Any())
            {
                appointsQuery = appointsQuery.Where(x => serviceSupplyIds.Contains(x.ServiceSupplyId));
            }

            var weekDaysCount = new List<(string Date, int Counts)>();
            for (var dt = DateTime.Now.AddDays(-7); dt <= DateTime.Now; dt = dt.AddDays(1))
            {
                var date = dt.Date == DateTime.Now.Date ? Global.Today : dt.ToString("MM/dd");
                var dayCount = await appointsQuery.CountAsync(x => x.Start_DateTime.Date == dt.Date);
                weekDaysCount.Add((date, dayCount));                
            }

            var result = new CenterAppointmentsDashboardModel
            {
                AllAppointmentsCount = await appointsQuery.CountAsync(),
                TodayAppointmentsCount = await appointsQuery.CountAsync(x => x.Start_DateTime.Date == DateTime.Now.Date),
                DoneAppointsCount = await appointsQuery.CountAsync(x => x.Status == AppointmentStatus.Done),
                CanceledAppointsCount = await appointsQuery.CountAsync(x => x.Status == AppointmentStatus.Canceled),
                PendingAppointsCount = await appointsQuery.CountAsync(x => x.Status == AppointmentStatus.Pending && x.Start_DateTime >= DateTime.Now),
                DaysAppoints = weekDaysCount
            };

            return result;
        }
    }
}
