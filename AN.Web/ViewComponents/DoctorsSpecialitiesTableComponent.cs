using AN.Core.Enums;
using AN.Core.MyExceptions;
using AN.DAL;
using AN.Web.Helper;
using AN.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AN.Web.ViewComponents
{
    [Area("")]
    public class DoctorsSpecialitiesTableComponent : ViewComponent
    {
        private readonly BanobatDbContext _dbContext;
        public DoctorsSpecialitiesTableComponent(BanobatDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        Lang Lng => CultureHelper.Lang;

        public async Task<IViewComponentResult> InvokeAsync(int doctorId)
        {
            var doctor = await _dbContext.ServiceSupplies.FindAsync(doctorId);

            if (doctor == null) throw new EntityNotFoundException();

            var currentExpertises = new List<SpecialityViewModel>();

            if (doctor.ServiceSupplyInfo != null)
            {
                currentExpertises = (from de in doctor.DoctorExpertises
                                     select new SpecialityViewModel
                                     {
                                         PolyclinicId = doctor.ShiftCenterId,
                                         expertiseId = de.Expertise.Id,
                                         Category = Lng == Lang.KU ? de.Expertise?.ExpertiseCategory?.Name_Ku : Lng == Lang.AR ? de.Expertise?.ExpertiseCategory?.Name_Ar : de.Expertise?.ExpertiseCategory?.Name,
                                         Expertise = Lng == Lang.KU ? de.Expertise?.Name_Ku : Lng == Lang.AR ? de.Expertise?.Name_Ar : de.Expertise?.Name,                                        
                                         doctorId = de.ServiceSupplyId
                                     }
                                    ).Distinct().ToList();
            }
            return View(currentExpertises);
        }
    }
}
