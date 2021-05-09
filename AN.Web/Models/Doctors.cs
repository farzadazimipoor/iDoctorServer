using System.Collections.Generic;

namespace AN.Web.Models
{
    public class DoctorsPaginationDTO
    {
        public int TotalCount { get; set; }
        public List<DoctorItemDTO> Doctors { get; set; }
    }

    public class DoctorItemDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Avatar { get; set; }
        public bool HasEmptyTurn { get; set; }
        public string Expertise { get; set; }
        public string Address { get; set; }
    }

    public class DoctorsFilterDTO
    {
        public string SearchTerm { get; set; }
        public int? Expertise { get; set; }
        public int? Clinic { get; set; }
        public int? Hospital { get; set; }
        public int? City { get; set; }
        public bool HasEmptyTurn { get; set; } 
        public int Gender { get; set; }
    }

    public class DoctorDetailsViewModel
    {
        public string Avatar { get; set; }
        public string FullName { get; set; }
        public string ExpertiseCategory { get; set; }
        public List<string> Expertises { get; set; }
        public string MedicalCouncilNumber { get; set; }
        public List<string> Phones { get; set; }
        public string Address { get; set; }
    }
}