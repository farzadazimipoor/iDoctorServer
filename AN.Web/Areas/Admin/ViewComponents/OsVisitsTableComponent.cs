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
    public class OsVisitsTableComponent : ViewComponent
    {
        private readonly BanobatDbContext _dbContext;
        public OsVisitsTableComponent(BanobatDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var otv = new List<OsVisitsTableViewModel>();
            var tottal = _dbContext.Statisticses.Count();
            otv.AddRange(_dbContext.Statisticses.GroupBy(ua => new { ua.UserOs }).OrderByDescending(g => g.Count()).Select(g => new OsVisitsTableViewModel() { OsName = g.Key.UserOs, OsViewCount = g.Count(), TottalVisits = tottal }).ToList());

            return View(otv);
        }
    }
}