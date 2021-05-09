using AN.DAL;
using AN.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AN.Web.Areas.Admin.ViewComponents
{
    [Area("Admin")]
    public class VocationDaysTableComponent : ViewComponent
    {
        private readonly BanobatDbContext _dbContext;
        public VocationDaysTableComponent(BanobatDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var vocations = _dbContext.VocationDays.ToList().Select(x => new VocationDayViewModel
            {
                Id = x.Id,
                Date = x.Date.ToShortDateString(),
                Description = x.Description
            }).OrderBy(x => x.Date);

            return View(vocations);
        }
    }
}