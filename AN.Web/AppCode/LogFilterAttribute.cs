using AN.Core.Domain;
using AN.Core.DTO.Doctors;
using AN.DAL;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace AN.Web.AppCode
{
    public class LogFilterAttribute : IAsyncActionFilter
    {
        private readonly BanobatDbContext _dbContext;
        public LogFilterAttribute(BanobatDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (context.ActionDescriptor is ControllerActionDescriptor controllerActionDescriptor)
            {
                var actionName = controllerActionDescriptor.ActionName;
                if (actionName == "DoctorsListPaging")
                {
                    if (context.ActionArguments.TryGetValue("pageIndex", out object page) && page is int pageNumber)
                    {
                        if (pageNumber == 0)
                        {
                            if (context.ActionArguments.TryGetValue("filterModel", out object value) && value is DoctorFilterDTO filterModel)
                            {
                                var ipAddress = context.HttpContext.Connection.RemoteIpAddress;

                                var controllerName = controllerActionDescriptor.ControllerName;

                                var eventLog = new EventLog
                                {
                                    Controller = controllerName,
                                    Action = actionName,
                                    IP = ipAddress.ToString(),
                                    Parameters = JsonConvert.SerializeObject(filterModel),
                                    Date = DateTime.Now,
                                    CreatedAt = DateTime.Now
                                };

                                await _dbContext.EventLogs.AddAsync(eventLog);

                                await _dbContext.SaveChangesAsync();
                            }
                        }
                    }
                }
            }

            await next();
        }
    }
}
