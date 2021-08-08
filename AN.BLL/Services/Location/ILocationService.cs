using AN.Core.DTO.Doctors;
using AN.Core.DTO.Location;
using AN.Core.Enums;
using System.Collections.Generic;

namespace AN.BLL.Services.Location
{
    public interface ILocationService
    {
        List<NearByDoctorDTO> GetNearbyShiftCenters(double x_longitude, double y_latitude, DoctorFilterDTO filterModel, double radiusMeters, Lang lang);
    }
}
