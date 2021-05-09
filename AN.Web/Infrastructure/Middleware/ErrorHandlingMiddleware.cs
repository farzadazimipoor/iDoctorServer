using AN.Core.Enums;
using AN.Core.Exceptions;
using AN.Web.AppCode.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace AN.Web.Infrastructure.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IHostingEnvironment _env;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;
        public ErrorHandlingMiddleware(RequestDelegate next, IHostingEnvironment env, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _env = env;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                await HandleExceptionAsync(context, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var statusCode = (int)HttpStatusCode.InternalServerError;

            var message = Core.Resources.Global.Global.Err_ErrorOccured;

            var exType = exception.GetType();

            if (exType == typeof(AwroNoreException) || exType.IsSubclassOf(typeof(AwroNoreException)))
            {
                message = exception.Message;
                statusCode = (int)(exception as AwroNoreException).ErrorCode;

                //if(exType == typeof(AccessDeniedException))
                //{
                //    statusCode = (int)HttpStatusCode.Forbidden;
                //}
            }
            else if (exType == typeof(ArgumentNullException))
            {
                statusCode = (int)HttpStatusCode.BadRequest;

                message = (exception as ArgumentNullException).ParamName;
            }
            else if (exType == typeof(NullReferenceException))
            {
                message = exception.Message;
            }
            else if (exType == typeof(DbUpdateException))
            {
                var innerExceptionType = exception.InnerException.GetType();

                if (innerExceptionType == typeof(SqlException))
                {
                    if (exception.InnerException is SqlException innerExp)
                    {
                        if (innerExp.Number == 547)
                        {
                            statusCode = (int)AwroNoreErrorCode.DeleteUsedItem;
                        }
                        else
                        {
                            statusCode = (int)AwroNoreErrorCode.DatabaseConnectionError;
                        }

                        message = GetSqlExceptionMessage(innerExp.Number);                        
                    }
                }
                else if (innerExceptionType == typeof(SqlTypeException))
                {
                    if (exception.InnerException is SqlTypeException innerExp)
                    {
                        message = innerExp.Message;
                    }
                }
            }
            else if (exception is DivideByZeroException)
            {
                message = "Divide By Zero Exception Occured.";
            }
            else if (exception is IOException)
            {

            }
            else
            {

            }

            if (!context.Session.IsAvailable)
            {
                context.Response.Redirect("/Account/Logout");
            }
            else
            {
                if (context.Request.IsAjaxRequest())
                {
                    context.Response.ContentType = "application/json";

                    context.Response.StatusCode = statusCode;

                    await context.Response.WriteAsync(message);
                }
                else
                {
                    if (context.Request.Path.StartsWithSegments("/api"))
                    {
                        // Because of dart http problem we should only return standdard http status codes >100 <599
                        if (statusCode >= 700) statusCode = 501;

                        context.Response.ContentType = "application/json; charset=utf-8";

                        context.Response.StatusCode = statusCode;

                        await context.Response.WriteAsync(JsonConvert.SerializeObject(new { message }));
                    }
                    else
                    {
                        throw new AwroNoreException(message);
                    }
                }
            }
        }

        private static string GetSqlExceptionMessage(int number)
        {
            string error = "An error occurred.";

            switch (number)
            {
                case 4060:
                    // Invalid Database
                    error = "Invalid Database.";
                    break;
                case 18456:
                    // Login Failed
                    error = "Login Failed.";
                    break;
                case 547:
                    // ForeignKey Violation
                    error = "ForeignKey Violation. This item is used, you can not delete it.";
                    break;
                case 2627:
                    // Unique Index/Constriant Violation
                    error = "Unique Index/Constriant Violation.";
                    break;
                case 2601:
                    // Unique Index/Constriant Violation
                    error = "Unique Index/Constriant Violation.";
                    break;
                default:
                    // throw a general DAL Exception
                    break;
            }

            return error;
        }
    }
}
