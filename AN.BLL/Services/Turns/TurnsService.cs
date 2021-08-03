using AN.BLL.DataRepository.Appointments;
using AN.BLL.DataRepository.ServiceSupplies;
using AN.BLL.DataRepository.Persons;
using AN.BLL.Helpers;
using AN.Core.DTO.Turn;
using AN.Core.Enums;
using AN.Core.Exceptions;
using AN.Core.Resources.Global;
using AN.Core.Resources.New;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AN.BLL.Services.Turns
{
    public class TurnsService : ITurnsService
    {
        private readonly IPersonService _userService;
        private readonly IAppointmentService _appointmentService;
        private readonly IServiceSupplyService _serviceSupplyService;
        public TurnsService(IPersonService userService, IAppointmentService appointmentService, IServiceSupplyService serviceSupplyService)
        {
            _userService = userService;
            _appointmentService = appointmentService;
            _serviceSupplyService = serviceSupplyService;
        }

        public async Task<(long totalCount, int totalPages, List<UserTurnItemDTO>)> GetUserTurnsListPagingAsync(UserTurnsFilterDTO filterModel, Lang lang, string hostAddress, int page = 0, int pageSize = 12)
        {
            if (filterModel == null || string.IsNullOrEmpty(filterModel.UserMobile)) return (0, 0, new List<UserTurnItemDTO>());

            var person = await _userService.GetPersonByMobileAsync(filterModel.UserMobile);

            if(person == null) return (0, 0, new List<UserTurnItemDTO>());

            var query = _appointmentService.Table.IgnoreQueryFilters().Where(x => x.PersonId == person.Id);
          
            if (!string.IsNullOrEmpty(filterModel.FilterString))
            {
                query = query.Where(x => (Global.Doctor + " " + x.ServiceSupply.Person.FullName + " " + x.ServiceSupply.Person.FullName_Ar + " " + x.ServiceSupply.Person.FullName_Ku).Contains(filterModel.FilterString));
            }

            if(filterModel.Status != null)
            {
                query = query.Where(x => x.Status == filterModel.Status || (filterModel.Status == AppointmentStatus.Pending && x.Status == AppointmentStatus.Unknown && x.Description.Contains("#Requested")));
            }

            if(filterModel.From != null)
            {
                query = query.Where(x => x.Start_DateTime >= filterModel.From);
            }

            if (filterModel.To != null)
            {
                query = query.Where(x => x.Start_DateTime <= filterModel.To);
            }

            if(filterModel.CenterType != null)
            {
                query = query.Where(x => x.ServiceSupply.ShiftCenter.Type.HasFlag(filterModel.CenterType));
            }

            var totalCount = await query.LongCountAsync();

            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

            var turns = await query.OrderBy(x => x.Start_DateTime).Skip(pageSize * page).Take(pageSize).Select(x => new UserTurnItemDTO
            {
                Id = x.Id,
                ServiceSupplyId = x.ServiceSupplyId,
                Date = x.Start_DateTime.ToShortDateString(),
                StartTime = x.Start_DateTime.ToShortTimeString(),
                EndTime = x.End_DateTime.ToShortTimeString(),
                Status = x.Status,
                DoctorName = lang == Lang.KU ? x.ServiceSupply.Person.FullName_Ku : lang == Lang.AR ? x.ServiceSupply.Person.FullName_Ar :  x.ServiceSupply.Person.FullName,
                DoctorAvatar = x.ServiceSupply.Person.RealAvatar,
                DayOfWeek = Utils.ConvertDayOfWeek(x.Start_DateTime.DayOfWeek.ToString()),
                IsRated = x.Rate != null,
                AverageRating = (x.Rate != null) ? x.Rate.Rating : 5,
                TrackingCode = x.UniqueTrackingCode,
                CenterServiceId = x.ShiftCenterServiceId,
                Service = lang == Lang.KU ? x.ShiftCenterService.Service.Name_Ku : lang == Lang.AR ? x.ShiftCenterService.Service.Name_Ar : x.ShiftCenterService.Service.Name
            }).ToListAsync();

            foreach(var item in turns)
            {
                var x = await _serviceSupplyService.GetServiceSupplyByIdAsync(item.ServiceSupplyId);
                if(x != null)
                {
                    var firstExpertise = x?.DoctorExpertises.FirstOrDefault();

                    item.DoctorExpertiseCategory = firstExpertise != null ? lang == Lang.AR ? firstExpertise.Expertise.ExpertiseCategory.Name_Ar : lang == Lang.KU ? firstExpertise.Expertise.ExpertiseCategory.Name_Ku : firstExpertise.Expertise.ExpertiseCategory.Name : "";
                }
            }

            return (totalCount, totalPages, turns);
        }

        public async Task SetTurnStatusAsync(int turnId, AppointmentStatus newStatus, string username)
        {
            var turn = await _appointmentService.GetAppointmentByIdAsync(turnId);

            if (turn == null) throw new AwroNoreException(NewResource.TurnNotFound);

            if(turn.Person.Mobile != username) throw new AwroNoreException(NewResource.UserCannotAccessTurn);

            turn.Status = newStatus;

            if(newStatus == AppointmentStatus.Canceled)
            {
                turn.IsDeleted = true;
            }

            _appointmentService.UpdateAppointment(turn);
        }
    }
}
