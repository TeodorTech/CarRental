﻿namespace CarRental.Api
{
    public class Middleware
    {
        private readonly RequestDelegate _next;

        private readonly ILogger<Middleware> _logger;

        public Middleware(RequestDelegate next, ILogger<Middleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            
            _logger.LogInformation("Request Sent");

            await _next.Invoke(httpContext);

            
            _logger.LogInformation("Response Sent");

        }
    }

    
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMyMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Middleware>();
        }
    }
}

