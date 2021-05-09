using AN.BLL.DataRepository.Persons;
using AN.BLL.Services.Upload;
using AN.Core.Domain;
using AN.Core.DTO.Profile;
using AN.Core.Exceptions;
using AN.Core.Models;
using AN.Core.Resources.New;
using AN.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AN.BLL.Services.Profile
{
    public class ProfileService : IProfileService
    {
        private readonly IPersonService _personService;
        private readonly IUploadService _uploadService;
        private readonly BanobatDbContext _dbContext;
        public ProfileService(BanobatDbContext dbContext, IPersonService personService, IUploadService uploadService)
        {
            _personService = personService;
            _uploadService = uploadService;
            _dbContext = dbContext;
        }

        public async Task<ProfileStatusDTO> GetUserProfileStatusAsync(string mobile, string fcmToken)
        {
            var person = await _personService.GetPersonByMobileAsync(mobile);

            if (person == null)
            {
                return new ProfileStatusDTO
                {
                    IsNewUser = true
                };
            }

            if (!string.IsNullOrEmpty(fcmToken))
            {
                var currentFcmIds = person.FcmInstanceIds;

                if (currentFcmIds != null)
                {
                    if (!currentFcmIds.Any(x => x.InstanceId == fcmToken))
                    {
                        currentFcmIds.Add(new FcmInstanceIdModel
                        {
                            InstanceId = fcmToken,
                            IsOn = true
                        });
                    }
                }
                else
                {
                    currentFcmIds = new List<FcmInstanceIdModel>
                    {
                        new FcmInstanceIdModel
                        {
                            InstanceId = fcmToken,
                            IsOn = true
                        }
                    };
                }

                person.FcmInstanceIds = currentFcmIds;
            }

            person.MobileConfirmed = true;

            _personService.UpdatePerson(person);

            return new ProfileStatusDTO
            {
                IsNewUser = false,
                Id = person.Id,
                FullName = person.FullName,
                Username = mobile,
                Email = person.Email,
                Mobile = person.Mobile,
                Avatar = person.RealAvatar,
                HasAvatar = !string.IsNullOrEmpty(person.Avatar),
                HasDiseaseRecordsForm = person.DiseaseRecordsForm != null
            };
        }

        public async Task<ProfileStatusDTO> CreateOrUpdateUserProfileAsync(ProfileCRUDDTO profile)
        {
            var person = await _personService.GetPersonByMobileAsync(profile.Mobile);

            if (person == null) // Create new user profile
            {
                person = new Person
                {
                    FirstName = profile.FirstName,
                    FirstName_Ku = profile.FirstName,
                    FirstName_Ar = profile.FirstName,
                    SecondName = profile.SecondName,
                    SecondName_Ar = profile.SecondName,
                    SecondName_Ku = profile.SecondName,
                    ThirdName = profile.ThirdName,
                    ThirdName_Ar = profile.ThirdName,
                    ThirdName_Ku = profile.ThirdName,
                    Age = profile.Age,
                    Address = profile.Address,
                    Birthdate = profile.Birthdate,                    
                    Gender = profile.Gender,
                    Height = profile.Height,
                    Language = profile.Language,
                    MarriageStatus = profile.MarriageStatus,
                    Mobile = profile.Mobile,
                    IdNumber = profile.IdNumber,
                    Weight = profile.Weight,
                    CreatedAt = DateTime.Now,
                    IsApproved = true,
                    IsDeleted = false,
                    Email = profile.Email,                    
                    IsEmployee = false,
                    MobileConfirmed = true,                   
                    IdentityUsers = new List<IdentityUser>
                    {
                        new IdentityUser
                        {
                            UserId = profile.IdentityUserId,
                            UserName = profile.Username,
                            Email = profile.Email,
                            CreatedAt = DateTime.Now
                        }
                    }
                };

                if (!string.IsNullOrEmpty(profile.FcmToken))
                {
                    person.FcmInstanceIds = new List<FcmInstanceIdModel>
                    {
                        new FcmInstanceIdModel
                        {
                            InstanceId = profile.FcmToken,
                            IsOn = true
                        }
                    };
                }

                person.UniqueId = await _personService.GenerateUniqueIdAsync();

                _personService.InsertNewPerson(person);
            }
            else
            {
                person.FirstName = profile.FirstName;
                person.FirstName_Ar = profile.FirstName;
                person.FirstName_Ku = profile.FirstName;
                person.SecondName = profile.SecondName;
                person.SecondName_Ar = profile.SecondName;
                person.SecondName_Ku = profile.SecondName;
                person.ThirdName = profile.ThirdName;
                person.ThirdName_Ar = profile.ThirdName;
                person.ThirdName_Ku = profile.ThirdName;
                person.Age = profile.Age;
                person.Birthdate = profile.Birthdate;
                person.Address = profile.Address;              
                person.IdNumber = profile.IdNumber;
                person.Weight = profile.Weight;
                person.Height = profile.Height;
                person.MarriageStatus = profile.MarriageStatus;
                person.Language = profile.Language;
                person.Gender = profile.Gender;
                person.Email = profile.Email;
                person.MobileConfirmed = true;
                person.UpdatedAt = DateTime.Now;

                _personService.UpdatePerson(person);
            }

            var result = new ProfileStatusDTO
            {
                Id = person.Id,
                IdentityUserId = profile.IdentityUserId,
                FullName = person.FullName,
                Username = person.Mobile,
                Email = person.Email,
                Mobile = person.Mobile,               
                IsNewUser = false,
                Avatar = person.RealAvatar,
                HasAvatar = !string.IsNullOrEmpty(person.Avatar)
            };

            return result;
        }

        public async Task<ProfileCRUDDTO> GetUserProfileDataAsync(string mobile)
        {
            var person = await _personService.GetPersonByMobileAsync(mobile);

            if (person == null) throw new AwroNoreException(NewResource.UserNotFound);

            var result = new ProfileCRUDDTO
            {
                Id = person.Id,
                FirstName = person.FirstName,
                SecondName = person.SecondName,
                ThirdName = person.ThirdName,
                Age = (int)person.Age,               
                Birthdate = person.Birthdate,
                Email = person.Email,
                FullName = person.FullName,
                Gender = person.Gender,
                Height = person.Height ?? 0,
                IdNumber = person.IdNumber ?? "",
                Language = person.Language,               
                MarriageStatus = person.MarriageStatus,
                Mobile = person.Mobile,
                Username = person.Mobile,
                Weight = person.Weight ?? 0,
                Address = person.Address,
                Avatar = person.RealAvatar,
                HasAvatar = !string.IsNullOrEmpty(person.Avatar)
            };

            return result;
        }

        public async Task<string> UpdateProfileAvatarAsync(string mobile, IFormFile photo)
        {
            var person = await _dbContext.Persons.FirstOrDefaultAsync(x => x.Mobile == mobile);

            if (person == null) throw new AwroNoreException(NewResource.UserNotFound);

            var strategy = _dbContext.Database.CreateExecutionStrategy();

            await strategy.ExecuteAsync(async () =>
            {
                using (var transaction = _dbContext.Database.BeginTransaction())
                {
                    var (newName, thumbName, dirPath, baseUrl) = _uploadService.GeneratePersonAvatarName(person.Id, photo);

                    person.Avatar = $"{baseUrl}/{thumbName}";

                    _dbContext.Persons.Attach(person);

                    _dbContext.Entry(person).State = EntityState.Modified;

                    await _dbContext.SaveChangesAsync();

                    await _uploadService.UploadPersonAvatarAsync(photo, dirPath, newName, thumbName);

                    transaction.Commit();
                }
            });

            return person.RealAvatar;
        }

        public async Task<string> RemoveProfileAvatarAsync(string mobile)
        {
            var person = await _dbContext.Persons.FirstOrDefaultAsync(x => x.Mobile == mobile);

            if (person == null) throw new AwroNoreException(NewResource.UserNotFound);

            var strategy = _dbContext.Database.CreateExecutionStrategy();

            await strategy.ExecuteAsync(async () =>
            {
                using (var transaction = _dbContext.Database.BeginTransaction())
                {
                    person.Avatar = null;

                    _dbContext.Persons.Attach(person);

                    _dbContext.Entry(person).State = EntityState.Modified;

                    await _dbContext.SaveChangesAsync();

                    _uploadService.RemovePersonAvatar(person.Id);

                    transaction.Commit();
                }
            });

            return person.RealAvatar;
        }

        public async Task LogoutPersonFromDeviceAsync(string mobile, string fcmInstanceId)
        {
            var person = await _dbContext.Persons.FirstOrDefaultAsync(x => x.Mobile == mobile);

            if (person != null)
            {
                var currentFcmIds = person.FcmInstanceIds;

                if (currentFcmIds != null)
                {
                    currentFcmIds.RemoveAll(x => x.InstanceId == fcmInstanceId);

                    person.FcmInstanceIds = currentFcmIds;

                    _dbContext.Persons.Attach(person);

                    _dbContext.Entry(person).State = EntityState.Modified;

                    await _dbContext.SaveChangesAsync();
                }
            }
        }

        public async Task<DiseaseRecordsFormDTO> GetDiseaseRecordsFormAsync(string mobile)
        {
            var person = await _dbContext.Persons.FirstOrDefaultAsync(x => x.Mobile == mobile);

            if (person != null && person.DiseaseRecordsForm != null)
            {
                var form = person.DiseaseRecordsForm;

                return new DiseaseRecordsFormDTO
                {
                    Age = form.Age,
                    DoYouSmoke = form.DoYouSmoke,
                    DrugsYouUsed = form.DrugsYouUsed,
                    HadSurgery = form.HadSurgery,
                    HasLongTermDisease = form.HasLongTermDisease,
                    LongTermDiseasesDescription = form.LongTermDiseasesDescription,
                    MedicalAllergies = form.MedicalAllergies,
                    PersonId = person.Id,
                    SurgeriesDescription = form.SurgeriesDescription
                };
            }

            return null;
        }

        public async Task UpdateDiseaseRecordsFormAsync(string mobile, DiseaseRecordsFormDTO form)
        {
            var person = await _dbContext.Persons.FirstOrDefaultAsync(x => x.Mobile == mobile);

            if (person == null) throw new AwroNoreException(NewResource.UserNotFound);

            var currentForm = await _dbContext.DiseaseRecordsForms.FirstOrDefaultAsync(X => X.PersonId == person.Id);

            if(currentForm == null)
            {
                currentForm = new DiseaseRecordsForm
                {
                    PersonId = person.Id,
                    Age = form.Age,
                    DoYouSmoke = form.DoYouSmoke,
                    DrugsYouUsed = form.DrugsYouUsed,
                    HadSurgery = form.HadSurgery,
                    HasLongTermDisease = form.HasLongTermDisease,
                    LongTermDiseasesDescription = form.LongTermDiseasesDescription,
                    MedicalAllergies = form.MedicalAllergies,
                    SurgeriesDescription = form.SurgeriesDescription
                };

                await _dbContext.DiseaseRecordsForms.AddAsync(currentForm);

                await _dbContext.SaveChangesAsync();
            }
            else
            {
                currentForm.Age = form.Age;
                currentForm.DoYouSmoke = form.DoYouSmoke;
                currentForm.DrugsYouUsed = form.DrugsYouUsed;
                currentForm.HadSurgery = form.HadSurgery;
                currentForm.HasLongTermDisease = form.HasLongTermDisease;
                currentForm.LongTermDiseasesDescription = form.LongTermDiseasesDescription;
                currentForm.MedicalAllergies = form.MedicalAllergies;
                currentForm.SurgeriesDescription = form.SurgeriesDescription;

                _dbContext.DiseaseRecordsForms.Attach(currentForm);

                _dbContext.Entry(currentForm).State = EntityState.Modified;

                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
