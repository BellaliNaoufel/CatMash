using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatMash.Api.Middlewares
{
    /// <summary>
    /// HttpExceptionMiddleware Class
    /// </summary>
    public class HttpExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<HttpExceptionMiddleware> _logger;

        public HttpExceptionMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _logger = loggerFactory?.CreateLogger<HttpExceptionMiddleware>() ?? throw new ArgumentNullException(nameof(loggerFactory));
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (System.Exception ex)
            {
                _logger.LogError($"Technical exception was throw \nMessage : {ex.Message} \nInnerException : {ex.InnerException} \nStackTrace {ex.StackTrace}");
                httpContext.Response.Clear();
                httpContext.Response.StatusCode = 500;
                httpContext.Response.ContentType = @"text/plain";
                await httpContext.Response.WriteAsync($"Technical exception was throw \nMessage : {ex.Message} \nInnerException : {ex.InnerException} \nStackTrace {ex.StackTrace}");

                return;
            }
        }
    }

    public static class HttpExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseHttpExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<HttpExceptionMiddleware>();
        }
    }
}
