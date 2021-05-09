using AN.Core.Data;
using AN.Core.Enums;
using AN.Core.Models;
using Newtonsoft.Json;
using Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AN.Core.Domain
{
    public class Person : BaseEntity
    {
        public Person()
        {
            Children = new HashSet<Person>();
            Appointments = new HashSet<Appointment>();
            ServiceSupplies = new HashSet<ServiceSupply>();
            HospitalPersons = new HashSet<HospitalPersons>();
            ClinicPersons = new HashSet<ClinicPersons>();
            ShiftCenterPersons = new HashSet<ShiftCenterPersons>();
            ShiftCenterMessages = new HashSet<ShiftCenterMessage>();
            Rates = new HashSet<ServiceSupplyRating>();
            IdentityUsers = new HashSet<IdentityUser>();
            Patients = new HashSet<Patient>();
            Consultancies = new HashSet<Consultancy>();
            ConsultancyMessages = new HashSet<ConsultancyMessage>();
            MedicalRequests = new HashSet<MedicalRequest>();
        }

        public string NamePrefix { get; set; }

        public string FirstName { get; set; }
        public string FirstName_Ku { get; set; }
        public string FirstName_Ar { get; set; }

        public string SecondName { get; set; }
        public string SecondName_Ku { get; set; }
        public string SecondName_Ar { get; set; }

        public string ThirdName { get; set; }
        public string ThirdName_Ku { get; set; }
        public string ThirdName_Ar { get; set; }

        [NotMapped]
        public string FullName => $"{FirstName} {SecondName} {ThirdName}";

        [NotMapped]
        public string FullName_Ku => $"{FirstName_Ku} {SecondName_Ku} {ThirdName_Ku}";

        [NotMapped]
        public string FullName_Ar => $"{FirstName_Ar} {SecondName_Ar} {ThirdName_Ar}";

        public float? Age { get; set; } = 0;

        public Gender Gender { get; set; }

        [MaxLength(10), MinLength(10)]       
        public string Mobile { get; set; }

        public string Email { get; set; }

        public string ZipCode { get; set; }

        public string Address { get; set; }

        public string Avatar { get; set; }

        [NotMapped]
        public string RealAvatar => !string.IsNullOrEmpty(Avatar) ? Avatar : Gender == Gender.Male ? "/images/avatars/NoAvatar.jpg" : "/images/avatars/NoAvatar_Female.jpg";

        public string Description { get; set; }

        public bool IsApproved { get; set; } = true;

        public int? CreationPlaceId { get; set; }

        public LoginAs? CreatorRole { get; set; }

        [MaxLength(5), MinLength(5)]
        public string UniqueId { get; set; }

        public DateTime? Birthdate { get; set; }

        [Range(1, 500)] // Kilogram
        public float? Weight { get; set; }

        [Range(1, 300)] // CM
        public float? Height { get; set; }      

        public string IdNumber { get; set; }

        public MarriageStatus? MarriageStatus { get; set; }

        public Language? Language { get; set; }    
        
        public BloodType? BloodType { get; set; }        

        public string _FcmInstanceIds { get; set; }
        [NotMapped]
        public List<FcmInstanceIdModel> FcmInstanceIds
        {
            get
            {
                if (!string.IsNullOrEmpty(_FcmInstanceIds))
                {
                    try
                    {
                        return JsonConvert.DeserializeObject<List<FcmInstanceIdModel>>(_FcmInstanceIds);
                    }
                    catch { }
                }
                return null;
            }
            set { _FcmInstanceIds = JsonConvert.SerializeObject(value); }
        }

        /// <summary>
        /// This is required because of public users. When we want to select a person as doctor/serviceSupplier for a center, system must only load employee persons and not all persons
        /// </summary>
        public bool IsEmployee { get; set; } = false;

        /// <summary>
        /// When create person in cpanel without identity user or any person that create it's own family without identity user, this must be false till person create it's user and login himself
        /// </summary>
        public bool MobileConfirmed { get; set; } = false;

        public int? ParentId { get; set; }

        public virtual Person Parent { get; set; }
        public virtual PatientPersonInfo PatientPersonInfo { get; set; }
        public virtual DiseaseRecordsForm DiseaseRecordsForm { get; set; }

        public virtual ICollection<Person> Children { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<ServiceSupply> ServiceSupplies { get; set; }
        public virtual ICollection<HospitalPersons> HospitalPersons { get; set; }
        public virtual ICollection<ClinicPersons> ClinicPersons { get; set; }
        public virtual ICollection<ShiftCenterPersons> ShiftCenterPersons { get; set; }
        public virtual ICollection<ShiftCenterMessage> ShiftCenterMessages { get; set; }
        public virtual ICollection<ServiceSupplyRating> Rates { get; set; }
        public virtual ICollection<IdentityUser> IdentityUsers { get; set; }
        public virtual ICollection<Patient> Patients { get; set; }
        public virtual ICollection<Consultancy> Consultancies { get; set; }
        public virtual ICollection<ConsultancyMessage> ConsultancyMessages { get; set; }
        public virtual ICollection<MedicalRequest> MedicalRequests { get; set; }
    }
}
