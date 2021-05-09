using AN.Core.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace AN.Core.DTO.Profile
{
    public class ProfileDTO : BaseDTO
    {
        public string IdentityUserId { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Avatar { get; set; }
        /// <summary>
        /// To determine if photo uploaded for person or the avatar is default     
        /// </summary>
        public bool HasAvatar { get; set; }
        public bool HasDiseaseRecordsForm { get; set; }
    }

    public class ProfileStatusDTO : ProfileDTO
    {
        public bool IsNewUser { get; set; }
        /// <summary> 
        /// Check if logged in user has doctor role or not?
        /// </summary>
        public bool IsDoctor { get; set; }
    }

    public class ProfileCRUDDTO : ProfileDTO
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; } // 0 = Male, 1 = Female
        public DateTime? Birthdate { get; set; }
        [Range(1, 500)] // Kilogram
        public float? Weight { get; set; }    
        [Range(1, 300)] // CM
        public float? Height { get; set; }
        public string IdNumber { get; set; }   
        public string Address { get; set; }
        public MarriageStatus? MarriageStatus { get; set; } // 0 = Single, 1 = Married
        public Language? Language { get; set; } // 0 = kurdish, 1 = arabic, 2 = persian, 3 = english     
        public string FcmToken { get; set; }
    }
}
