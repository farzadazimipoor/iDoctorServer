using AN.Core.Domain;
using AN.Core.Enums;
using AN.Core.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AN.BLL.DataRepository.Persons
{
    public partial interface IPersonService
    {
        Task<DataTablesPagedResults<PersonListViewModel>> GetDataTableAsync(DataTablesParameters table, PersonFilterViewModel filters, Lang lng = Lang.KU);

        Task<List<SelectListItem>> GetSelectListAsync(Lang lng);

        Task<Person> GetByIdAsync(int id);

        IQueryable<Person> GetAll();

        IQueryable<Person> GetAllForHospital(int hospitalId);

        IQueryable<Person> GetAllForHospital(int hospitalId, int page, int recordsPerPage, out int totalCount, string searchString);

        IQueryable<Person> GetAllForHospital(int hospitalId, int page, int recordsPerPage, out int totalCount);

        Task<IQueryable<Person>> GetAllUserDoctorsAsync();

        IQueryable<Person> GetAllForClinic(int clinicId);

        IQueryable<Person> GetAllForPoliClinic(int policlinicId);

        Task<IQueryable<Person>> GetAllUserDoctorsForClinicAsync(int clinicId);

        Task<IQueryable<Person>> GetAllUserDoctorsForPolyClinicAsync(int polyclinicId);

        Task<int> GetAllPersonsCountAsync();    
        
        Task<Person> GetPersonByMobileAsync(string mobile);

        Person GetById(int id);     

        void InsertNewPerson(Person user);

        void UpdatePerson(Person user);

        Person GetByUserName(string userName);

        Task<Person> FindByUniqueIdAsync(string uniqueId);

        Task<Person> FindByMobileOrUniqueIdAsync(string searchString);

        Task<bool> IsExistUniqueIdAsync(string uniqueId);

        Task<string> GenerateUniqueIdAsync();
    }
}
