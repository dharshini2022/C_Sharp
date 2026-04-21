using System.Net;
using System.Text.Json;

namespace Task10_Mini_Microservice.server.Middleware
{
    public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task InvokeAsync(HttpContext context, DbLoggerService dbLogger)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unhandled Exception");
            await dbLogger.LogAsync("ERROR", ex.Message, ex.StackTrace);

            context.Response.StatusCode = 500;
            await context.Response.WriteAsJsonAsync(new
            {
                message = ex.Message,
                status = 500
            });
        }
    }
}
}