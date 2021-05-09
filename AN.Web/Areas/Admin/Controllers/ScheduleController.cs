using AN.Core.Domain;
using AN.Core.Enums;
using AN.Core.MyExceptions;
using AN.Core.Resources.EntitiesResources;
using AN.DAL;
using AN.Web.App_Code;
using AN.Web.AppCode.Extensions;
using AN.Web.Areas.Admin.Models;
using AN.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace AN.Web.Areas.Admin.Controllers
{

    public class ScheduleController : AdminController
    {
        private readonly BanobatDbContext _dbContext;
        private readonly ICommonUtils _commonUtils;
        public ScheduleController(BanobatDbContext dbContext, ICommonUtils commonUtils)
        {
            _dbContext = dbContext;
            _commonUtils = commonUtils;
        }

        [HttpGet]
        public IActionResult VocationDays()
        {
            return View(new VocationDayViewModel());
        }       

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddVocationDay(VocationDayViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var appointments = _dbContext.Appointments.ToList()
                                 .Count(x => x.Status == AppointmentStatus.Pending &&
                                             x.Start_DateTime >= DateTime.Now &&
                                             x.Start_DateTime.ToShortDateString() == model.Date);
                    if (appointments >= 1)
                    {
                        throw new HavePendingAppointmentsException();
                    }

                    var date = DateTime.Parse(model.Date);

                    _dbContext.VocationDays.Add(new VocationDay
                    {
                        Date = date,
                        DayOfWeek = date.DayOfWeek.ToString(),
                        Description = model.Description,
                        CreatedAt = DateTime.Now,
                    });

                    _dbContext.SaveChanges();
                    TempData.Put("message", new MVCResultModel { status = MVCResultStatus.success, message = Messages.ItemAddedSuccessFully });
                    return RedirectToAction("VocationDays", "Schedule", new { area = "Admin" });
                }
            }
            catch (HavePendingAppointmentsException)
            {
                TempData.Put("message", new MVCResultModel { status = MVCResultStatus.danger, message = Messages.PendingTurnsExistInDate });
            }
            catch (FormatException)
            {
                TempData.Put("message", new MVCResultModel { status = MVCResultStatus.danger, message = Messages.PleaseEnterValidDate });
            }
            catch
            {
                TempData.Put("message", new MVCResultModel { status = MVCResultStatus.danger, message = Messages.AnErrorOccuredWhileAddingItem });
            }

            return RedirectToAction("VocationDays", "Schedule", new { area = "Admin" });
        }

        [HttpGet]
        public IActionResult EditVocationDay(int? id)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));

            var vocationDay = _dbContext.VocationDays.SingleOrDefault(x => x.Id == id);
            if (vocationDay == null)
            {
                throw new EntityNotFoundException();
            }
            return View(new VocationDayViewModel
            {
                Id = vocationDay.Id,
                Date = vocationDay.Date.ToShortDateString(),
                Description = vocationDay.Description
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditVocationDay(VocationDayViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {                   
                    var vocationDay = _dbContext.VocationDays.SingleOrDefault(x => x.Id == model.Id);
                    _dbContext.Entry(vocationDay).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    vocationDay.Date = DateTime.Parse(model.Date);
                    vocationDay.Description = model.Description;
                    vocationDay.UpdatedAt = DateTime.Now;
                    _dbContext.SaveChanges();
                    TempData.Put("message", new MVCResultModel { status = MVCResultStatus.success, message = Messages.ItemUpdatedSuccessFully });
                    return RedirectToAction("VocationDays", "Schedule", new { area = "Admin" });
                }
            }
            catch (FormatException)
            {
                TempData.Put("message", new MVCResultModel { status = MVCResultStatus.danger, message = Messages.PleaseEnterValidDate });
            }
            catch (Exception)
            {
                TempData.Put("message", new MVCResultModel { status = MVCResultStatus.danger, message = Messages.AnErrorOccuredWhileUpdateItem });
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteVocationDay(int? id)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));
            try
            {
                var vocationDay = _dbContext.VocationDays.SingleOrDefault(x => x.Id == id);
                _dbContext.VocationDays.Remove(vocationDay);
                _dbContext.SaveChanges();

                TempData.Put("message", new MVCResultModel { status = MVCResultStatus.success, message = Messages.ItemDeletedSuccessFully });
                return RedirectToAction("VocationDays", "Schedule", new { area = "Admin" });
            }
            catch (Exception)
            {
                TempData.Put("message", new MVCResultModel { status = MVCResultStatus.danger, message = Messages.AnErrorOccuredWhileDeleteItem });
                return RedirectToAction("VocationDays", "Schedule", new { area = "Admin" });
            }
        }
    }
}