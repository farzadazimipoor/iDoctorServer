using AN.BLL.Core.Services.Messaging.Notifications;
using AN.BLL.Helpers;
using AN.Core;
using AN.Core.Data;
using AN.Core.Domain;
using AN.Core.Enums;
using AN.Core.Exceptions;
using AN.Core.ViewModels;
using AN.DAL;
using Microsoft.EntityFrameworkCore;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace AN.BLL.DataRepository.Appointments
{
    public partial class AppointmentService : IAppointmentService
    {
        private readonly IRepository<Appointment> _appointmentRepository;
        private readonly BanobatDbContext _dbContext;
        private readonly INotificationService _notificationService;
        public AppointmentService(IRepository<Appointment> appointmentRepository,                                
                                  BanobatDbContext dbContext,
                                  INotificationService notificationService)
        {
            _appointmentRepository = appointmentRepository;
            _dbContext = dbContext;
            _notificationService = notificationService;
        }

        public IQueryable<Appointment> Table => _appointmentRepository.Table;

        public async Task<(int site, int app, int kiosk, int sms, int ussd, int voip, int outOfSchedule)> GetReservationChannelStatisticsAsync()
        {
            var query = _appointmentRepository.Table.Where(x => x.Paymentstatus != PaymentStatus.NotPayed && !x.IsDeleted);

            var site = await query.CountAsync(x => x.ReservationChannel == ReservationChannel.Website);
            var app = await query.CountAsync(x => x.ReservationChannel == ReservationChannel.MobileApplication);
            var kiosk = await query.CountAsync(x => x.ReservationChannel == ReservationChannel.Kiosk);
            var sms = await query.CountAsync(x => x.ReservationChannel == ReservationChannel.SMS);
            var ussd = await query.CountAsync(x => x.ReservationChannel == ReservationChannel.USSD);
            var voip = await query.CountAsync(x => x.ReservationChannel == ReservationChannel.VOIP);
            var outOfSchedule = await query.CountAsync(x => x.ReservationChannel == ReservationChannel.ClinicManagerSection);

            return (site, app, kiosk, sms, ussd, voip, outOfSchedule);
        }

        public async Task<(IPagedList<Appointment>, int count)> GetAppointmentsPagedListAsync(string sortOrder, string serviceSupplyId, string fromDate, string toDate, int? page, int? polyclinicId = null, AppointmentStatus? status = null)
        {
            var query = _appointmentRepository.Table.Where(a => !a.IsDeleted && a.Paymentstatus != PaymentStatus.NotPayed);

            if (!string.IsNullOrEmpty(serviceSupplyId))
            {
                var _serviceSupplyId = int.Parse(serviceSupplyId);
                query = query.Where(a => a.ServiceSupplyId == _serviceSupplyId);
            }

            if (polyclinicId != null && polyclinicId > 0)
            {
                query = query.Where(x => x.ServiceSupply.ShiftCenterId == polyclinicId);
            }

            if (status != null)
            {
                query = query.Where(x => x.Status == status);
            }

            if (!string.IsNullOrEmpty(fromDate))
            {
                var _fromDate = DateTime.Parse(fromDate);
                query = query.Where(a => a.Start_DateTime >= _fromDate);
            }
            if (!string.IsNullOrEmpty(toDate))
            {
                var _toDate = DateTime.Parse(toDate);
                query = query.Where(a => a.Start_DateTime <= _toDate);
            }
            switch (sortOrder)
            {
                case "Date":
                    query = query.OrderBy(a => a.Start_DateTime);
                    break;
                case "date_desc":
                    query = query.OrderByDescending(a => a.Start_DateTime);
                    break;
                default:
                    query = query.OrderBy(a => a.Start_DateTime);
                    break;
            }

            var count = await query.CountAsync();

            var pageSize = 10;

            var pageNumber = (page ?? 1);

            var result = query.ToPagedList(pageNumber, pageSize);

            return (result, count);
        }

        public async Task<DataTablesPagedResults<AppointmentListViewModel>> GetDataTableAsync(int shiftCenterId, DataTablesParameters table, ShiftCenterAppointmentsFilterModel filters, Lang lng = Lang.KU, List<int> serviceSupplyIds = null)
        {
            IQueryable<Appointment> query = _appointmentRepository.Table.Where(a => !a.IsDeleted && a.Paymentstatus != PaymentStatus.NotPayed);

            query = query.Where(x => x.ServiceSupply.ShiftCenterId == shiftCenterId);

            if (serviceSupplyIds != null && serviceSupplyIds.Any())
            {
                query = query.Where(a => serviceSupplyIds.Contains(a.ServiceSupplyId));
            }

            if (filters.ServiceSupplyId != null)
            {
                query = query.Where(a => a.ServiceSupplyId == filters.ServiceSupplyId);
            }

            if (filters.FromDate != null)
            {
                query = query.Where(a => a.Start_DateTime >= filters.FromDate);
            }

            if (filters.ToDate != null)
            {
                filters.ToDate = DateTime.Parse($"{filters.ToDate.Value.ToShortDateString()} 23:59:59");

                query = query.Where(a => a.Start_DateTime <= filters.ToDate);
            }

            if (filters.Status != null)
            {
                query = query.Where(x => x.Status == filters.Status);
            }

            if (table.Order != null && table.Order.Any())
            {
                var orderIndex = table.Order[0].Column;
                var orderDir = table.Order[0].Dir;

                if (orderIndex == 2)
                {
                    query = orderDir == DataTablesOrderDir.DESC ? query.OrderByDescending(x => x.Status) : query.OrderBy(x => x.Status);
                }
                else if (orderIndex == 3)
                {
                    query = orderDir == DataTablesOrderDir.DESC ? query.OrderByDescending(x => x.Start_DateTime) : query.OrderBy(x => x.Start_DateTime);
                }
                else if (orderIndex == 4)
                {
                    query = orderDir == DataTablesOrderDir.DESC ? query.OrderByDescending(x => x.ServiceSupply.Person.FullName) : query.OrderBy(x => x.ServiceSupply.Person.FullName);
                }
                else if (orderIndex == 5)
                {
                    query = orderDir == DataTablesOrderDir.DESC ? query.OrderByDescending(x => x.Person.FullName) : query.OrderBy(x => x.Person.FullName);
                }
                else if (orderIndex == 6)
                {
                    query = orderDir == DataTablesOrderDir.DESC ? query.OrderByDescending(x => x.Person.Mobile) : query.OrderBy(x => x.Person.Mobile);
                }
            }
            else
            {
                query = query.OrderBy(x => x.Status);
            }

            var size = await query.CountAsync();

            var items = await query
                .AsNoTracking()
                .Skip((table.Start / table.Length) * table.Length)
                .Take(table.Length)
                .Select(x => new AppointmentListViewModel
                {
                    Id = x.Id,
                    Status = x.Status,
                    ReservationChannel = x.ReservationChannel,
                    Date = x.Start_DateTime.ToString("yyyy-MM-dd HH:mm:ss"),
                    ServiceSupplier = lng == Lang.KU ? x.ServiceSupply.Person.FullName_Ku : lng == Lang.AR ? x.ServiceSupply.Person.FullName_Ar : x.ServiceSupply.Person.FullName,
                    Person = lng == Lang.KU ? x.Person.FullName_Ku : lng == Lang.AR ? x.Person.FullName_Ar : x.Person.FullName,
                    PatientMobile = x.Person.Mobile,
                    HasTreatmentHistory = x.TreatmentHistories.Any(),
                    PersonId = x.PersonId,
                    ServiceSupplyId = x.ServiceSupplyId,
                    Avatar = x.Person.RealAvatar
                })
                .ToListAsync();

            return new DataTablesPagedResults<AppointmentListViewModel>
            {
                Items = items,
                TotalSize = size
            };
        }

        public virtual async Task<int> GetAllAppointmentsCountAsync()
        {
            return await _appointmentRepository.Table.Where(x => !x.IsDeleted && x.Paymentstatus != PaymentStatus.NotPayed).CountAsync();
        }

        public virtual async Task<int> GetAllAppointmentsCountByStatusAsync(AppointmentStatus status)
        {
            var query = _appointmentRepository.Table.Where(x => x.Status == status && x.Paymentstatus != PaymentStatus.NotPayed);
            if (status != AppointmentStatus.Canceled)
                query = query.Where(x => !x.IsDeleted);

            return await query.CountAsync();
        }

        public virtual Appointment GetAppointmentById(int id)
        {
            if (id == 0)
                return null;

            return _appointmentRepository.Table.FirstOrDefault(x => x.Id == id);
        }

        public virtual async Task<Appointment> GetAppointmentByIdAsync(int id)
        {
            if (id == 0)
                return null;

            return await _appointmentRepository.Table.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Appointment GetLatestReservedAppointment()
        {
            //For using LastOrDefault() we must order by descending and use FirstOrDefault because of LINQ limitation
            return _appointmentRepository.Table.Where(a => !a.IsDeleted && a.Paymentstatus != PaymentStatus.NotPayed).AsEnumerable().LastOrDefault();
        }

        public virtual Appointment GetAppointmentForMobileInDate(int serviceSupplyId, int centerServiceId, string mobile, DateTime date)
        {
            if (date == null) throw new ArgumentNullException(nameof(date));

            var query = from a in _appointmentRepository.Table
                        where a.Person.Mobile.Equals(mobile) &&
                              a.ServiceSupplyId == serviceSupplyId &&
                              a.ShiftCenterServiceId == centerServiceId &&
                              a.Start_DateTime.Date == date.Date
                        select a;

            return query.FirstOrDefault();
        }

        public virtual async Task<Appointment> GetAppointmentByIdForServiceSupplyAsync(int serviceSupplyId, long appointmentId)
        {
            if (serviceSupplyId == 0 || appointmentId == 0)
                return null;

            var appointment = await (from a in _appointmentRepository.Table
                                     where a.Id == appointmentId && a.ServiceSupplyId == serviceSupplyId
                                     select a).FirstOrDefaultAsync();

            return appointment;
        }

        public virtual void UpdateAppointment(Appointment appointment)
        {
            if (appointment == null)
                throw new ArgumentNullException("appointment");

            _appointmentRepository.Update(appointment);
        }

        public virtual async Task<IList<Appointment>> GetAllPendingAppointmentsForServiceSupply(int serviceSupplyId)
        {
            if (serviceSupplyId == 0)
                return new List<Appointment>();

            var query = from a in _appointmentRepository.Table
                        where a.ServiceSupplyId == serviceSupplyId &&
                              a.Start_DateTime >= DateTime.Now &&
                              a.Status == AppointmentStatus.Pending &&
                              !a.IsDeleted
                        select a;

            return await query.ToListAsync();
        }

        public virtual async Task<IList<Appointment>> GetPendingAppointmentsForServiceSupplyInManualScheduleAsync(int serviceSupplyId, DateTime startTime, DateTime endTime)
        {
            if (serviceSupplyId == 0 || startTime == null || endTime == null) throw new ArgumentNullException();

            var query = from a in _appointmentRepository.Table
                        where a.ServiceSupplyId == serviceSupplyId &&
                              a.Status == AppointmentStatus.Pending &&
                              !a.IsDeleted &&
                              a.Start_DateTime >= startTime && a.End_DateTime <= endTime
                        select a;

            return await query.ToListAsync();
        }

        public virtual List<Appointment> GetPendingAppointmentsForServiceSupplyInManualSchedule(int serviceSupplyId, DateTime startTime, DateTime endTime)
        {
            if (serviceSupplyId == 0 || startTime == null || endTime == null) throw new ArgumentNullException();

            var query = from a in _appointmentRepository.Table
                        where a.ServiceSupplyId == serviceSupplyId &&
                              a.Status == AppointmentStatus.Pending &&
                              !a.IsDeleted &&
                              a.Start_DateTime >= startTime && a.End_DateTime <= endTime
                        select a;

            return query.ToList();
        }

        public virtual int GetQueueNumberForAppointment(int serviceSupplyId, int appointmentId, int polyclinicHealthServiceId, DateTime date)
        {
            if (serviceSupplyId == 0 || appointmentId == 0 || date == null) throw new ArgumentNullException();

            var query = (from a in _appointmentRepository.Table
                         where a.ServiceSupplyId == serviceSupplyId && !a.IsDeleted && a.Status == AppointmentStatus.Pending &&
                         a.ShiftCenterServiceId == polyclinicHealthServiceId &&
                         a.Start_DateTime.Date == date.Date
                         select a).OrderBy(x => x.Start_DateTime).ToList();

            var number = query.FindIndex(x => x.Id == appointmentId) + 1;

            return number;
        }

        public virtual IList<Appointment> GetAllAppointmentsForPolyclinicInDayOfWeek(int polyclinicId, int serviceSupplyId, AppointmentStatus status, string dayOfWeek, ScheduleShift shift)
        {
            if (polyclinicId == 0 || string.IsNullOrEmpty(dayOfWeek)) return new List<Appointment>();

            var shiftStartHour = shift == ScheduleShift.Morning ? Defaults.MorningStart.Hour : Defaults.EveningStart.Hour;
            var shiftStartMinute = shift == ScheduleShift.Morning ? Defaults.MorningStart.Minute : Defaults.EveningStart.Minute;

            var shiftEndHour = shift == ScheduleShift.Morning ? Defaults.MorningEnd.Hour : Defaults.EveningEnd.Hour;
            var shiftEndMinute = shift == ScheduleShift.Morning ? Defaults.MorningEnd.Minute : Defaults.EveningEnd.Minute;

            var query = (from a in _appointmentRepository.Table
                         where a.ServiceSupplyId == serviceSupplyId &&
                               a.ServiceSupply.ShiftCenterId == polyclinicId &&
                               a.Status == status

                         // TODO: Enable It Again 100%---------------------------------------
                         //DbFunctions.CreateTime(a.Start_DateTime.Hour, a.Start_DateTime.Minute, a.Start_DateTime.Second) >= DbFunctions.CreateTime(shiftStartHour, shiftStartMinute, 0) &&
                         //DbFunctions.CreateTime(a.Start_DateTime.Hour, a.Start_DateTime.Minute, a.Start_DateTime.Second) <= DbFunctions.CreateTime(shiftEndHour, shiftEndMinute, 0)
                         select a)
                        .AsEnumerable()
                        .Where(a => a.Start_DateTime.DayOfWeek.ToString() == dayOfWeek)
                        .ToList();

            return query;
        }

        public IQueryable<Appointment> GetAllForHospital(int hospitalId)
        {
            var query = from a in _appointmentRepository.Table
                        where a.ServiceSupply.ShiftCenter.Clinic.HospitalId == hospitalId && !a.IsDeleted && a.Paymentstatus != PaymentStatus.NotPayed
                        select a;
            return query;
        }

        public IQueryable<Appointment> GetAllForClinic(int clinicId)
        {
            var query = from a in _appointmentRepository.Table
                        where a.ServiceSupply.ShiftCenter.ClinicId == clinicId && !a.IsDeleted && a.Paymentstatus != PaymentStatus.NotPayed
                        select a;

            return query;
        }

        public IQueryable<Appointment> GetAllForPolyClinic(int polyclinicId)
        {
            var query = _appointmentRepository.Table.Where(x => x.ServiceSupply.ShiftCenterId == polyclinicId && !x.IsDeleted && x.Paymentstatus != PaymentStatus.NotPayed);
            return query;
        }

        public void SoftDeleteAppointment(int id)
        {
            var appointment = GetAppointmentById(id);
            appointment.IsDeleted = true;
            _appointmentRepository.Update(appointment);
        }

        public async Task<bool> IsExistTrackingNumberAsync(string trackingNumber)
        {
            if (string.IsNullOrEmpty(trackingNumber))
                return false;

            var exist = await _appointmentRepository.TableNoTracking.AnyAsync(x => x.UniqueTrackingCode.Equals(trackingNumber));
            return exist;
        }

        public async Task<string> GenerateUniqueTrackingNumberAsync()
        {
            string trackingNumber;
            do
            {
                trackingNumber = Utils.GetUniqueKey(size: 8, includeLetters: false);
            } while ((await IsExistTrackingNumberAsync(trackingNumber)));

            return trackingNumber;
        }

        public async Task<DataTablesPagedResults<AppointmentRequestsListViewModel>> GetAppointmentRequestsDataTableAsync(DataTablesParameters table, AppointmentRequestsFilterViewModel filters, Lang lng = Lang.KU)
        {
            IQueryable<Appointment> query = _appointmentRepository.Table;

            query = query.Where(x => x.Status == AppointmentStatus.Unknown && x.Description.Contains("#Requested"));

            if (!string.IsNullOrEmpty(filters.FilterString))
            {
                query = query.Where(x => x.Person.FullName.Contains(filters.FilterString) || x.ServiceSupply.Person.FullName.Contains(filters.FilterString) || x.ServiceSupply.ShiftCenter.Name.Contains(filters.FilterString));
            }
            if (filters.From != null)
            {
                query = query.Where(a => a.CreatedAt >= filters.From);
            }
            if (filters.To != null)
            {
                filters.To = DateTime.Parse($"{filters.To.Value.ToShortDateString()} 23:59:59");

                query = query.Where(a => a.CreatedAt <= filters.To);
            }
            if (filters.ServiceSupplyId != null)
            {
                query = query.Where(a => a.ServiceSupplyId == filters.ServiceSupplyId);
            }

            if (table.Order != null && table.Order.Any())
            {
                var orderIndex = table.Order[0].Column;
                var orderDir = table.Order[0].Dir;

                switch (orderIndex)
                {
                    case 0:
                    case 3:
                        // CreateDate
                        query = orderDir == DataTablesOrderDir.ASC ? query.OrderBy(x => x.CreatedAt) : query.OrderByDescending(x => x.CreatedAt);
                        break;
                    case 1:
                        // Status
                        query = orderDir == DataTablesOrderDir.ASC ? query.OrderBy(x => x.Status) : query.OrderByDescending(x => x.Status);
                        break;
                    case 2:
                        // Channel
                        query = orderDir == DataTablesOrderDir.ASC ? query.OrderBy(x => x.ReservationChannel) : query.OrderByDescending(x => x.ReservationChannel);
                        break;
                    case 4:
                        // CenterName
                        query = orderDir == DataTablesOrderDir.ASC ? query.OrderBy(x => x.ServiceSupply.ShiftCenter.Name) : query.OrderByDescending(x => x.ServiceSupply.ShiftCenter.Name);
                        break;
                    case 5:
                        // CenterPhone
                        query = orderDir == DataTablesOrderDir.ASC ? query.OrderBy(x => x.ServiceSupply.ShiftCenter.PhoneNumbers.FirstOrDefault()) : query.OrderByDescending(x => x.ServiceSupply.ShiftCenter.PhoneNumbers.FirstOrDefault());
                        break;
                    case 6:
                        // CenterAddress
                        query = orderDir == DataTablesOrderDir.ASC ? query.OrderBy(x => x.ServiceSupply.ShiftCenter.Address) : query.OrderByDescending(x => x.ServiceSupply.ShiftCenter.Address);
                        break;
                    case 7:
                        // Doctor
                        query = orderDir == DataTablesOrderDir.ASC ? query.OrderBy(x => x.ServiceSupply.Person.FirstName) : query.OrderByDescending(x => x.ServiceSupply.Person.FirstName);
                        break;
                    case 8:
                        // Patient
                        query = orderDir == DataTablesOrderDir.ASC ? query.OrderBy(x => x.Person.FirstName) : query.OrderByDescending(x => x.Person.FirstName);
                        break;
                    case 9:
                        // Mobile
                        query = orderDir == DataTablesOrderDir.ASC ? query.OrderBy(x => x.Person.Mobile) : query.OrderByDescending(x => x.Person.Mobile);
                        break;
                    case 10:
                        // Gender
                        query = orderDir == DataTablesOrderDir.ASC ? query.OrderBy(x => x.Person.Gender) : query.OrderByDescending(x => x.Person.Gender);
                        break;
                }
            }

            var size = await query.CountAsync();

            var items = await query
                .AsNoTracking()
                .Skip((table.Start / table.Length) * table.Length)
                .Take(table.Length)
                .Select(x => new AppointmentRequestsListViewModel
                {
                    Id = x.Id,
                    CreateDate = x.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss"),
                    CenterName = lng == Lang.KU ? x.ServiceSupply.ShiftCenter.Name_Ku : lng == Lang.AR ? x.ServiceSupply.ShiftCenter.Name_Ar : x.ServiceSupply.ShiftCenter.Name,
                    CenterPhone = x.ServiceSupply.ShiftCenter.PhoneNumbers.FirstOrDefault() != null ? x.ServiceSupply.ShiftCenter.PhoneNumbers.FirstOrDefault().PhoneNumber : "",
                    CenterAddress = lng == Lang.KU ? x.ServiceSupply.ShiftCenter.Address_Ku : lng == Lang.AR ? x.ServiceSupply.ShiftCenter.Address_Ar : x.ServiceSupply.ShiftCenter.Address,
                    Patient = x.Person != null ? lng == Lang.KU ? x.Person.FullName_Ku : lng == Lang.AR ? x.Person.FullName_Ar : x.Person.FullName : "",
                    Doctor = x.ServiceSupply.Person != null ? lng == Lang.KU ? x.ServiceSupply.Person.FullName_Ku : lng == Lang.AR ? x.ServiceSupply.Person.FullName_Ar : x.ServiceSupply.Person.FullName : "",
                    Mobile = x.Person != null ? x.Person.Mobile : "",
                    Gender = x.Person != null ? x.Person.Gender == Gender.Male ? AN.Core.Resources.Global.Global.Male : AN.Core.Resources.Global.Global.FeMale : "",
                    Avatar = x.Person != null ? x.Person.RealAvatar : "",
                    ReservationChannel = x.ReservationChannel,
                    Status = x.Status,
                    Service = x.ShiftCenterService != null ? $"{x.ShiftCenterService.Service.ServiceCategory.Name}/{x.ShiftCenterService.Service.Name}" : ""
                }).ToListAsync();

            return new DataTablesPagedResults<AppointmentRequestsListViewModel>
            {
                Items = items,
                TotalSize = size
            };
        }

        public async Task ApproveAppointmentRequestAsync(ApproveAppointmentRequestModel model)
        {
            var appointment = await _dbContext.Appointments.FindAsync(model.Id);

            if (appointment == null || string.IsNullOrEmpty(appointment.Description) || !appointment.Description.Contains("#Requested")) throw new AwroNoreException("Appointment request not found");

            if (appointment.Status != AppointmentStatus.Unknown) throw new AwroNoreException("This appointment request approved before");

            var strategy = _dbContext.Database.CreateExecutionStrategy();

            await strategy.ExecuteAsync(async () =>
            {
                using (var transaction = _dbContext.Database.BeginTransaction())
                {
                    appointment.Status = AppointmentStatus.Pending;

                    appointment.Start_DateTime = DateTime.Parse($"{model.Date.Date.ToShortDateString()} {model.StartTime}");

                    appointment.End_DateTime = DateTime.Parse($"{model.Date.Date.ToShortDateString()} {model.EndTime}");

                    _appointmentRepository.Update(appointment);

                    if (model.SendNotification)
                    {
                        if (appointment.Person.FcmInstanceIds != null && appointment.Person.FcmInstanceIds.Any())
                        {
                            var donePayload = new DoneAppointmentNotificationPayload
                            {
                                AppointmentId = appointment.Id,
                                NotificationType = NotificationType.AppointmentAccepted
                            };

                            foreach (var item in appointment.Person.FcmInstanceIds)
                            {
                                var title = "Accept Appointment";
                                var message = "Your appointment has been accepted";
                                await _notificationService.SendFcmToSingleDeviceAsync(item.InstanceId, title, message);
                            }
                        }
                    }

                    transaction.Commit();
                }
            });
        }

        public async Task DeleteAppointmentRequestAsync(int id)
        {
            var appointment = await _appointmentRepository.Table.FirstOrDefaultAsync(x => x.Id == id);

            if (appointment != null)
            {
                await _appointmentRepository.DeleteAsync(appointment);
            }
        }
    }
}
