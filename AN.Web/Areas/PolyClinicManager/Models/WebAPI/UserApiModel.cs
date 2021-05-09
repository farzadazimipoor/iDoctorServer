using AN.Core;
using AN.Core.Enums;
using System.Collections.Generic;

namespace AN.Web.Areas.PolyClinicManager.Models.WebAPI
{
    public class UserApiModel
    {
        public string Name { get; set; }
        public string Family { get; set; }
        public string Avatar { get; set; }
        public string Phone { get; set; }
        public bool HaveEditPermission { get; set; }
    }

    public class PatientUserInfoApiModel : UserApiModel
    {        
        public string Insurance { get; set; }
        public string InsuranNumber { get; set; }
    }

    public class DoctorsApiModel : UserApiModel
    {
        public bool IsAvailable { get; set; } = false;
        public int ServiceSupplyId { get; set; }
        public int Duration { get; set; }
        public int OnlineReservationPercent { get; set; }
        public string ReservationType { get; set; }
        public string MedicalCouncilNumber { get; set; }
        public List<string> Expertises { get; set; }
    }


    public class UpdateServiceSupplyApiModel
    {
        public bool IsAvailable { get; set; }
        public int Duration { get; set; }
        public int OnlineReservationPercent { get; set; }
        public ReservationType ReservationType { get; set; }        
    }

    public class UpdateServiceSupplyResponseApiModel
    {
        public string Status { get; set; }
        public string Message { get; set; }
    }
}