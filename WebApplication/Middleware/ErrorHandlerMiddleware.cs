namespace WebApplication.Middleware
{
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;

    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger logger;

        public ErrorHandlerMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            this.next = next;
            logger = loggerFactory.CreateLogger<ErrorHandlerMiddleware>();
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception e)
            {
                await HandleExceptionAsync(context, e);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var result = CreateRepsonse(context);
            LogError(exception);

            return context.Response.WriteAsync(result);
        }

        private void LogError(Exception exception)
        {
            logger.LogError(exception, "Error");
        }

        private static string CreateRepsonse(HttpContext context)
        {
            var result = JsonConvert.SerializeObject("Unexpected error occurred");
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
            return result;
        }
    }
}
