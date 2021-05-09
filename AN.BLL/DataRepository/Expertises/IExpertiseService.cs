using AN.Core.Domain;
using AN.Core.Enums;
using AN.Core.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AN.BLL.DataRepository.Expertises
{
    public partial interface IExpertiseService
    {
        Task<DataTablesPagedResults<ExpertiseListViewModel>> GetDataTableAsync(DataTablesParameters table, ExpertiseFilterViewModel filters, Lang lng = Lang.KU);

        Task<List<SelectListItem>> GetCatrgoriesSelectListAsync(Lang lang = Lang.KU);

        ExpertiseCategory GetExpertiseCategoryById(int id);

        Task<Expertise> GetByIdAsync(int id);

        Expertise GetExpertiseById(int id);

        IEnumerable<ExpertiseCategory> GetAllExpertiseCategories();

        IEnumerable<Expertise> GetAllExpertises();

        IQueryable<Expertise> AllExpertisesTable();

        IList<Expertise> GetExpertisesForCategory(int categoryId);

        void InsertExpertiseCategory(ExpertiseCategory expertiseCategory);

        void UpdateExpertiseCategory(ExpertiseCategory expertiseCategory);

        void DeleteExpertiseCategory(ExpertiseCategory expertiseCategory);

        void InsertExpertise(Expertise expertise);

        void UpdateExpertise(Expertise expertise);

        void DeleteExpertise(Expertise expertise);
    }
}
