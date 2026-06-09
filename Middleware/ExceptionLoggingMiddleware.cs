using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace SimpleExceptionLogger.Middleware
{
    /// <summary>
    /// STEPS - Testing Version 1.0.2
    /// Create an API Key from https://www.nuget.org/
    /// dotnet build -c Release
    /// dotnet pack -c Release
    /// API KEY - oy2bnq6fjlvmerip7hcag7wgpvfu7qfepdr5nffqiy33rm
    /// dotnet nuget push "C:\Pallavi_Koenig\Full Stack React Application Development with .NET 8\React Lab\SimpleExceptionLogger_NuGetPackage\bin\Release\SimpleExceptionLogger.1.0.2.nupkg" --api-key oy2bnq6fjlvmerip7hcag7wgpvfu7qfepdr5nffqiy33rm --source https://api.nuget.org/v3/index.json
    /// </summary>
    public class ExceptionLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionLoggingMiddleware> _logger;

        public ExceptionLoggingMiddleware(RequestDelegate next, ILogger<ExceptionLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "Unhandled exception caught by middleware for request {Method} {Path}",
                    context.Request.Method, context.Request.Path);

                // Optionally: set a safe response body
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "text/plain; charset=utf-8";
                await context.Response.WriteAsync("An internal server error occurred.again and again");
            }
        }
    }
}
