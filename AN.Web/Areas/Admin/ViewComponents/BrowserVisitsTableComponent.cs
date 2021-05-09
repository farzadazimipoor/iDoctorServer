using AN.DAL;
using AN.Web.Areas.Admin.Models;
using AN.Web.Helper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AN.Web.Areas.Admin.ViewComponents
{
    [Area("Admin")]
    public class BrowserVisitsTableComponent : ViewComponent
    {
        private readonly BanobatDbContext _dbContext;
        public BrowserVisitsTableComponent(BanobatDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var btv = new List<BrowserVisitsTableViewModel>();
            var tottal = _dbContext.Statisticses.Count();
            btv.AddRange(_dbContext.Statisticses
                           .GroupBy(ua => new { ua.UserAgent })
                           .OrderByDescending(g => g.Count())
                           .Select(g => new BrowserVisitsTableViewModel() { BrowserName = g.Key.UserAgent == "InternetExplorer" ? "internet-explorer" : g.Key.UserAgent, BrowserViewCount = g.Count(), TottalVisits = tottal }).ToList());

            return View(btv);
        }
    }
}