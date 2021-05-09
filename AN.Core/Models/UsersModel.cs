using AN.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace AN.Core.Models
{
    public class BaseUserModel
    {
        public string NamePrefix { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string SecondName { get; set; }

        [Required]
        public string ThirdName { get; set; }
      
        public int Age { get; set; }

        public Gender Gender { get; set; }
      
        [MaxLength(10)]
        [MinLength(10)]
        [Required]
        public string Mobile { get; set; }

        public string Email { get; set; }

        public string ZipCode { get; set; }

        public string Address { get; set; }

        public string Description { get; set; }     
        
        public string Password { get; set; }   
    }



    public class DoctorModel : BaseUserModel
    {
        public string ScientificCategory { get; set; }

        public string MedicalCouncilNumber { get; set; }

        public bool IsActive { get; set; }

        public bool IsAvailableNow { get; set; }

        public int ExpertiseId { get; set; }

        public string Picture { get; set; }

        public int WorkExperience { get; set; }

        public string WebSite { get; set; }
    }
    

    public class PatientModel : BaseUserModel
    {
        public bool IsForeign { get; set; }

        public int InsuranceId { get; set; }

        public string InsuranceNumber { get; set; }
    }    
    
}
