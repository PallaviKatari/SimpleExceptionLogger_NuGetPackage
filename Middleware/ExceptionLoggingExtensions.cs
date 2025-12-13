using Microsoft.AspNetCore.Builder;

namespace SimpleExceptionLogger.Middleware
{
    public static class ExceptionLoggingExtensions
    {
        /// <summary>
        /// Registers the ExceptionLoggingMiddleware in the pipeline.
        /// </summary>
        public static IApplicationBuilder UseSimpleExceptionLogger(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ExceptionLoggingMiddleware>();
        }
    }
}
