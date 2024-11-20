using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace TodoApplikasjonAPIDelTo.Middleware
{
    // Middleware to log incoming requests and outgoing responses
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next; // Represents the next middleware in the pipeline
        private readonly ILogger<LoggingMiddleware> _logger; // Logger for logging request and response details

        // Constructor that initializes the middleware with the next delegate and logger
        public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
        {
            _next = next; // Assigns the next middleware in the pipeline
            _logger = logger; // Assigns the logger
        }

        // Method invoked for each HTTP request passing through the middleware
        public async Task InvokeAsync(HttpContext context)
        {
            // Logs the HTTP method and path of the incoming request
            _logger.LogInformation($"[{DateTime.Now}] HTTP : {context.Request.Method} {context.Request.Path}");

            // Passes the request to the next middleware in the pipeline
            await _next(context);

            // Logs the status code of the outgoing response
            _logger.LogInformation($"[{DateTime.Now}] Response status code: {context.Response.StatusCode}");
        }
    }
}

