using AN.BLL.Core.Services;
using AN.BLL.DataRepository.ServiceSupplies;
using AN.Core.DTO.Doctors;
using AN.Core.DTO.Location;
using AN.Core.Enums;
using AN.Core.Resources.Global;
using NetTopologySuite.Geometries;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AN.BLL.Services.Location
{
    public class LocationService : ILocationService
    {
        private readonly IServiceSupplyService _serviceSupplyService;
        private readonly IDoctorServiceManager _doctorServiceManager;
        public LocationService(IServiceSupplyService serviceSupplyService, IDoctorServiceManager doctorServiceManager)
        {
            _serviceSupplyService = serviceSupplyService;
            _doctorServiceManager = doctorServiceManager;
        }

        public async Task<List<NearByDoctorDTO>> GetNearbyShiftCentersAsync(double x_longitude, double y_latitude, DoctorFilterDTO filterModel, double radiusMeters, Lang lang)
        {
            if (filterModel == null) return new List<NearByDoctorDTO>();

            var myLocation = new Point(x_longitude, y_latitude)
            {
                SRID = 4326
            };

            var query = _serviceSupplyService.Table;

            // Only centers that support appointments
            query = query.Where(x => x.ShiftCenter.SupportAppointments);

            // Only one center type
            query = query.Where(x => x.ShiftCenter.Type.HasFlag(filterModel.CenterType) && x.Id != 1 && x.Id != 65);

            // Filter by service
            query = query.Where(x => x.ShiftCenter.PolyclinicHealthServices.Any(ss => ss.HealthServiceId == filterModel.ServiceId));

            //Filter by city
            if (filterModel.CityId != null)
            {
                query = query.Where(x => x.ShiftCenter.CityId == filterModel.CityId);
            }

            if (filterModel.CenterType == ShiftCenterType.Polyclinic || filterModel.CenterType == ShiftCenterType.Dentist)
            {
                if (filterModel.HospitalId != null)
                {
                    query = query.Where(x => x.ShiftCenter.Clinic.HospitalId == filterModel.HospitalId);
                }

                if (filterModel.ClinicId != null)
                {
                    query = query.Where(x => x.ShiftCenter.ClinicId == filterModel.ClinicId);
                }
            }

            //Filter by expertise category
            if (filterModel.SpecialityId != null)
            {
                query = query.Where(x => x.ServiceSupplyInfo != null && x.DoctorExpertises.Any(fe => filterModel.SpecialityId == fe.Expertise.ExpertiseCategoryId));
            }

            if (filterModel.SubSpecialityId != null)
            {
                query = query.Where(x => x.ServiceSupplyInfo != null && x.DoctorExpertises.Any(de => de.ExpertiseId == filterModel.SubSpecialityId));
            }

            if (filterModel.Expertises != null && filterModel.Expertises.Any())
            {
                query = query.Where(x => x.ServiceSupplyInfo != null && x.DoctorExpertises.Any(e => filterModel.Expertises.Contains(e.ExpertiseId)));
            }

            //Filter by name
            if (!string.IsNullOrEmpty(filterModel.FilterString))
            {
                query = query.Where(x =>
                (Global.Doctor + " " + x.Person.FirstName + " " + x.Person.SecondName + " " + x.Person.ThirdName).Contains(filterModel.FilterString) ||
                (Global.Doctor + " " + x.Person.FirstName_Ku + " " + x.Person.SecondName_Ku + " " + x.Person.ThirdName_Ku).Contains(filterModel.FilterString) ||
                (Global.Doctor + " " + x.Person.FirstName_Ar + " " + x.Person.SecondName_Ar + " " + x.Person.ThirdName_Ar).Contains(filterModel.FilterString));
            }

            if (filterModel.ConsultancyEnabled != null && filterModel.ConsultancyEnabled == true)
            {
                query = query.Where(x => x.ConsultancyEnabled);
            }

            // Find NearBy
            query = query.Where(x => x.ShiftCenter.Location.Distance(myLocation) <= radiusMeters);

            var doctorsWithinRadius = (from x in query.AsEnumerable()
                                             let shiftCenterService = x.ShiftCenter.PolyclinicHealthServices.FirstOrDefault(ss => ss.HealthServiceId == filterModel.ServiceId)
                                             let firstExpertise = x.DoctorExpertises.FirstOrDefault()
                                             select new NearByDoctorDTO
                                             {
                                                 Id = x.Id,
                                                 FullName = lang == Lang.KU ? x.Person.FullName_Ku : lang == Lang.AR ? x.Person.FullName_Ar : x.Person.FullName,
                                                 CenterId = x.ShiftCenterId,
                                                 CenterName = lang == Lang.AR ? x.ShiftCenter.Name_Ar : lang == Lang.KU ? x.ShiftCenter.Name_Ku : x.ShiftCenter.Name,
                                                 CenterAddress = lang == Lang.AR ? x.ShiftCenter.Address_Ar : lang == Lang.KU ? x.ShiftCenter.Address_Ku : x.ShiftCenter.Address,
                                                 X_Longitude = x.ShiftCenter.Location.Coordinate.X,
                                                 Y_Latitude = x.ShiftCenter.Location.Coordinate.Y,
                                                 Distance = x.ShiftCenter.Location.Distance(myLocation),
                                                 Avatar = x.Person.RealAvatar,
                                                 AverageRating = x.AverageRating ?? 5,
                                                 HasEmptyTurn = false,
                                                 CenterServiceId = shiftCenterService.Id,
                                                 Service = shiftCenterService == null ? "" : lang == Lang.KU ? shiftCenterService.Service.Name_Ku : lang == Lang.AR ? shiftCenterService.Service.Name_Ar : shiftCenterService.Service.Name,
                                                 ReservationType = x.ReservationType,
                                                 ExpertiseCategory = firstExpertise != null ? lang == Lang.AR ? firstExpertise.Expertise.ExpertiseCategory.Name_Ar : lang == Lang.KU ? firstExpertise.Expertise.ExpertiseCategory.Name_Ku : firstExpertise.Expertise.ExpertiseCategory.Name : "",                                                 
                                                 TimePeriods = shiftCenterService == null ? new DoctorTimePeriods() : _doctorServiceManager.FindFirstDateEmptyTimePeriodsFromNow(x, shiftCenterService),
                                             }).ToList();

            if(filterModel.HaveTurns == true)
            {
                var result = doctorsWithinRadius.Where(d => d.TimePeriods.TimePeriods.Any()).ToList();

                return result;
            }
            else
            {
                return doctorsWithinRadius;
            }           
        }
    }
}
