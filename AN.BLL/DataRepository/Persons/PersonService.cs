using AN.Core.Data;
using AN.Core.Domain;
using AN.Core.Enums;
using AN.Core.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AN.BLL.DataRepository.Persons
{
    public class PersonService : IPersonService
    {
        private readonly IRepository<Person> _personRepository;
        private readonly IRepository<HospitalPersons> _hospitalPersonsRepository;
        private readonly IRepository<ClinicPersons> _clinicPersonsRepository;
        private readonly IRepository<ShiftCenterPersons> _shiftCenterPersonsRepository;
        public PersonService(IRepository<Person> personRepository,
                             IRepository<HospitalPersons> hospitalPersonsRepository,
                             IRepository<ClinicPersons> clinicPersonsRepository,
                             IRepository<ShiftCenterPersons> shiftCenterPersonsRepository)
        {
            _personRepository = personRepository;
            _hospitalPersonsRepository = hospitalPersonsRepository;
            _clinicPersonsRepository = clinicPersonsRepository;
            _shiftCenterPersonsRepository = shiftCenterPersonsRepository;
        }

        public async Task<DataTablesPagedResults<PersonListViewModel>> GetDataTableAsync(DataTablesParameters table, PersonFilterViewModel filters, Lang lng = Lang.KU)
        {
            IQueryable<Person> query = _personRepository.Table;

            query = query.Where(x => x.IsEmployee == filters.IsEmployee);

            if (!string.IsNullOrEmpty(filters.FilterString))
            {
                var mobileWithoutZero = "";
                var isNumeric = double.TryParse(filters.FilterString, out _);
                if (isNumeric)
                {
                    if (filters.FilterString.Length > 10)
                    {
                        mobileWithoutZero = filters.FilterString.Substring(filters.FilterString.Length - 10);
                    }
                }
                query = query.Where(x => x.FullName.Contains(filters.FilterString) || 
                                         x.FullName_Ku.Contains(filters.FilterString) || 
                                         x.FullName_Ar.Contains(filters.FilterString) ||
                                         x.Mobile.Contains(filters.FilterString) ||
                                         (!string.IsNullOrEmpty(mobileWithoutZero) && x.Mobile.Contains(mobileWithoutZero)));
            }

            if (filters.Gender != null)
            {
                query = query.Where(x => x.Gender == filters.Gender);
            }

            if (table.Order != null && table.Order.Any())
            {
                var orderIndex = table.Order[0].Column;
                var orderDir = table.Order[0].Dir;

                if (orderIndex == 2)
                {
                    if (orderDir == DataTablesOrderDir.DESC)
                    {
                        query = query.OrderByDescending(x => lng == Lang.KU ? x.FullName_Ku : lng == Lang.AR ? x.FullName_Ar : x.FullName);
                    }
                    else
                    {
                        query = query.OrderBy(x => lng == Lang.KU ? x.FullName_Ku : lng == Lang.AR ? x.FullName_Ar : x.FullName);
                    }
                }
                else if (orderIndex == 3)
                {
                    if (orderDir == DataTablesOrderDir.DESC)
                    {
                        query = query.OrderByDescending(x => x.Mobile);
                    }
                    else
                    {
                        query = query.OrderBy(x => x.Mobile);
                    }
                }
                else if (orderIndex == 4)
                {
                    if (orderDir == DataTablesOrderDir.DESC)
                    {
                        query = query.OrderByDescending(x => x.Gender);
                    }
                    else
                    {
                        query = query.OrderBy(x => x.Gender);
                    }
                }
                else if (orderIndex == 5)
                {
                    query = orderDir == DataTablesOrderDir.DESC ? query.OrderByDescending(x => x.IsEmployee) : query.OrderBy(x => x.IsEmployee);
                }
            }
            else
            {
                query = query.OrderBy(x => lng == Lang.KU ? x.FullName_Ku : lng == Lang.AR ? x.FullName_Ar : x.FullName);
            }

            var size = await query.CountAsync();

            var items = await query
                .AsNoTracking()
                .Skip((table.Start / table.Length) * table.Length)
                .Take(table.Length)
                .Select(x => new PersonListViewModel
                {
                    Id = x.Id,
                    Name = lng == Lang.KU ? x.FullName_Ku : lng == Lang.AR ? x.FullName_Ar : x.FullName,
                    Mobile = x.Mobile,
                    Gender = x.Gender == Gender.Male ? AN.Core.Resources.Global.Global.Male : AN.Core.Resources.Global.Global.FeMale,
                    IsEmployee = x.IsEmployee ? AN.Core.Resources.Global.Global.Yes : AN.Core.Resources.Global.Global.No,
                    Avatar = x.RealAvatar
                })
                .ToListAsync();

            return new DataTablesPagedResults<PersonListViewModel>
            {
                Items = items,
                TotalSize = size
            };
        }

        public async Task<List<SelectListItem>> GetSelectListAsync(Lang lng)
        {
            var result = await _personRepository.Table.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = lng == Lang.KU ? x.FullName_Ku : lng == Lang.AR ? x.FullName_Ar : x.FullName

            }).ToListAsync();

            return result;
        }

        public async Task<Person> GetByIdAsync(int id)
        {
            return await _personRepository.GetByIdAsync(id);
        }


        #region Get All Users
        public IQueryable<Person> GetAll()
        {
            var query = from u in _personRepository.Table
                        where u.IsDeleted == false && u.IsApproved == true
                        select u;
            return query;
        }

        /// <summary>
        /// get all users with doctor role
        /// </summary>
        /// <returns></returns>
        public async Task<IQueryable<Person>> GetAllUserDoctorsAsync()
        {
            return GetAll().Where(x => x.IsEmployee == true);
        }

        #endregion


        #region Get All Users For Hospital
        public IQueryable<Person> GetAllForHospital(int hospitalId)
        {
            var query = from hu in _hospitalPersonsRepository.Table
                        where hu.HospitalId == hospitalId &&
                              hu.Person.IsApproved == true &&
                              hu.Person.IsDeleted == false
                        select hu.Person;

            return query;
        }

        public IQueryable<Person> GetAllForHospital(int hospitalId, int page, int recordsPerPage, out int totalCount, string searchString)
        {
            var query = GetAllForHospital(hospitalId).Where(x => x.FirstName.Contains(searchString) ||
                                                                 x.SecondName.Contains(searchString) ||
                                                                 x.ThirdName.Contains(searchString) ||
                                                                 x.Mobile.Contains(searchString));
            totalCount = query.Count();
            return query.OrderBy(row => row.Id).Skip(page * recordsPerPage).Take(recordsPerPage);
        }


        public IQueryable<Person> GetAllForHospital(int hospitalId, int page, int recordsPerPage, out int totalCount)
        {
            totalCount = GetAllForHospital(hospitalId).Count();
            return GetAllForHospital(hospitalId).OrderBy(row => row.Id).Skip(page * recordsPerPage).Take(recordsPerPage);
        }

        #endregion


        #region Get All Users For Clinic
        /// <summary>
        /// get all users for clinic
        /// </summary>
        /// <param name="policlinic"></param>
        /// <returns></returns>
        public IQueryable<Person> GetAllForClinic(int clinicId)
        {
            var query = from cu in _clinicPersonsRepository.Table
                        where cu.Clinic_Id == clinicId &&
                              cu.Person.IsApproved == true &&
                              cu.Person.IsDeleted == false
                        select cu.Person;
            return query;
        }

        public async Task<IQueryable<Person>> GetAllUserDoctorsForClinicAsync(int clinicId)
        {
            //var doctorRole = await RolesManager.FindByNameAsync(UsersRoleName.Doctor.ToString());

            var query = from u in GetAllForClinic(clinicId)
                        where u.IsEmployee == true
                        select u;

            return query;
        }

        #endregion


        #region Get Users For Polyclinic
        public IQueryable<Person> GetAllForPoliClinic(int policlinicId)
        {
            var query = from cu in _shiftCenterPersonsRepository.Table
                        where cu.ShiftCenterId == policlinicId &&
                              cu.Person.IsApproved == true &&
                              cu.Person.IsDeleted == false
                        select cu.Person;
            return query;
        }

        public async Task<IQueryable<Person>> GetAllUserDoctorsForPolyClinicAsync(int polyclinicId)
        {
            var query = from u in GetAllForPoliClinic(polyclinicId)
                        where u.IsEmployee == true
                        select u;
            return query;
        }

        #endregion       

        public Person GetById(int id)
        {
            return _personRepository.GetById(id);
        }

        public async Task<Person> FindByUniqueIdAsync(string uniqueId)
        {
            if (string.IsNullOrEmpty(uniqueId)) throw new ArgumentNullException(uniqueId);

            var result = await _personRepository.Table.FirstOrDefaultAsync(x => x.UniqueId == uniqueId);

            return result;
        }

        public async Task<Person> FindByMobileOrUniqueIdAsync(string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
            {
                return null;
            }

            var mobileWithoutZero = "";
            if (searchString.Length > 10)
            {
                mobileWithoutZero = searchString.Substring(searchString.Length - 10);
            }

            var result = await _personRepository.Table.FirstOrDefaultAsync(x => (x.UniqueId != null && x.UniqueId.Contains(searchString)) ||
                                                                                 x.Mobile.Contains(searchString) ||
                                                                                 x.FullName.Contains(searchString) ||
                                                                                 x.FullName_Ar.Contains(searchString) ||
                                                                                 x.FullName_Ku.Contains(searchString) ||
                                                                                 (!string.IsNullOrEmpty(mobileWithoutZero) && x.Mobile.Contains(mobileWithoutZero)));

            return result;
        }

        public virtual async Task<int> GetAllPersonsCountAsync()
        {
            return await _personRepository.Table.Where(x => x.IsApproved && !x.IsDeleted).CountAsync();
        }

        public async Task<Person> GetPersonByMobileAsync(string mobile)
        {
            if (string.IsNullOrEmpty(mobile)) return null;

            var user = await _personRepository.Table.FirstOrDefaultAsync(x => x.Mobile == mobile);

            return user;
        }

        public void InsertNewPerson(Person user)
        {
            _personRepository.Insert(user);
        }

        public void UpdatePerson(Person user)
        {
            _personRepository.Update(user);
        }

        public Person GetByUserName(string userName)
        {
            if (string.IsNullOrEmpty(userName)) return null;

            var user = _personRepository.Table.FirstOrDefault(x => x.Mobile == userName);

            return user;
        }

        public async Task<bool> IsExistUniqueIdAsync(string uniqueId)
        {
            var exist = await _personRepository.Table.AnyAsync(x => x.UniqueId == uniqueId);

            return exist;
        }

        public async Task<string> GenerateUniqueIdAsync()
        {
            var trackingNumber = string.Empty;
            do
            {
                trackingNumber = GetUniqueKey();
            } while ((await IsExistUniqueIdAsync(trackingNumber)) || trackingNumber.Length != 5);

            return trackingNumber;
        }

        public async Task InsertPatientAsync(Person patient)
        {
            await _personRepository.InsertAsync(patient);
        }

        public void UpdatePatient(Person patient)
        {
            _personRepository.Update(patient);
        }

        private string GetUniqueKey()
        {
            var crypto = new RNGCryptoServiceProvider();
            const int size = 5;
            const string a = "1234567890";
            var chars = a.ToCharArray();
            var data = new byte[1];
            crypto.GetNonZeroBytes(data);
            data = new byte[size];
            crypto.GetNonZeroBytes(data);
            var result = new StringBuilder(size);
            foreach (var b in data)
            {
                result.Append(chars[b % (chars.Length - 1)]);
            }
            return result.ToString();
        }
    }
}
