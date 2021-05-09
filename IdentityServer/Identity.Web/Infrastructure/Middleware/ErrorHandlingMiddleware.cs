using Identity.Core.Enums;
using Identity.Core.Exceptions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace Identity.Web.Infrastructure.Middleware
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

            var message = "Unknown error occurred in identity server, please try again!";

            var exType = exception.GetType();

            if (exType == typeof(AwronoreIdentityException) || exType.IsSubclassOf(typeof(AwronoreIdentityException)))
            {
                message = exception.Message;
                statusCode = (int)(exception as AwronoreIdentityException).ErrorCode;               
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
                        foreach (SqlError error in innerExp.Errors)
                        {
                            message = GetSqlExceptionMessage(error.Number);
                            if (error.Number == 547)
                            {
                                statusCode = (int)AwronoreIdentityErrorCode.DeleteUsedItem;
                                message = "This item is used. You can not delete it";
                            }
                            else if (error.Number == 2601)
                            {
                            }
                        }
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

            context.Response.StatusCode = statusCode;

            await context.Response.WriteAsync(message);
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
                    error = "ForeignKey Violation.";
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
