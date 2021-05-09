using AN.Core.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

namespace AN.WebAPI.Infrastructure.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;
        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
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
                _logger.LogTrace(ex, ex.Message);

                await HandleExceptionAsync(context, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var statusCode = (int)HttpStatusCode.InternalServerError;

            var message = "Unknown error occured";

            if (exception is AwroNoreException)
            {
                statusCode = (int)(exception as AwroNoreException).ErrorCode;
                message = exception.Message;
            }
            else if (exception is ArgumentNullException)
            {
                statusCode = (int)HttpStatusCode.BadRequest;
            }

            context.Response.StatusCode = statusCode;

            await context.Response.WriteAsync(message);
        }
    }
}
