using AN.Core.Domain;
using AN.Core.DTO.Consultancy;
using System.Collections.Generic;

namespace AN.Core.MyComparers
{
    /// <summary>
    /// این کلاس مشخص می کند که دو شی یوزر در چه شرایطی می توانند برابر باشند
    /// </summary>
    public class UserComprarer : IEqualityComparer<Person>
    {
        public bool Equals(Person x, Person y)
        {
            //اینجا مشخص کردم که در صورت برابری شماره ملی یا نام کاربری دو یوزر با هم برابرند            
            if (x.Mobile == y.Mobile)
                return true;

            return false;
        }

        public int GetHashCode(Person obj)
        {
            return obj.Mobile.GetHashCode();
        }
    }


    public class AppointmentComprarer : IEqualityComparer<Appointment>
    {
        public bool Equals(Appointment x, Appointment y)
        {
            if (x.Start_DateTime == y.Start_DateTime)
                return true;

            return false;
        }

        public int GetHashCode(Appointment obj)
        {
            return obj.Start_DateTime.GetHashCode();
        }
    }

    public class ConsultancyGroupDoctorComprarer : IEqualityComparer<ConsultancyGroupDoctorDTO>
    {
        public bool Equals(ConsultancyGroupDoctorDTO x, ConsultancyGroupDoctorDTO y)
        {
            if (x.Id == y.Id)
                return true;

            return false;
        }

        public int GetHashCode(ConsultancyGroupDoctorDTO obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}
