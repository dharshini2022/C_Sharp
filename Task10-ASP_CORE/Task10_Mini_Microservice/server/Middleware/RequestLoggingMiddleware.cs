using Task10_Mini_Microservice.server.Services;
using System.Diagnostics;

namespace Task10_Mini_Microservice.server.Middleware
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;

        public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, DbLoggerService dbLogger)
        {
            var path = context.Request.Path.ToString();
            if (!path.StartsWith("/api"))
            {
                await _next(context);
                return;
            }

            var method = context.Request.Method;
            var stopwatch = Stopwatch.StartNew();

            try
            {
                var requestMessage = $"Request: {method} {path}";
                _logger.LogInformation(requestMessage);
                await dbLogger.LogAsync("INFO", requestMessage);

                await _next(context);

                stopwatch.Stop();

                var responseMessage = $"Response: {context.Response.StatusCode} ({stopwatch.ElapsedMilliseconds} ms)";
                _logger.LogInformation(responseMessage);
                await dbLogger.LogAsync("INFO", responseMessage);
            }
            catch (Exception ex)
            {
                stopwatch.Stop();
                _logger.LogError(ex, "Request failed");

                try
                {
                    await dbLogger.LogAsync("ERROR", ex.Message, ex.StackTrace);
                }
                catch (Exception logEx)
                {
                    _logger.LogError(logEx, "Failed to write log to database");
                }

                throw; 
            }
        }
    }
}