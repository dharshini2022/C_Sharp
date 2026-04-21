using Task10_Mini_Microservice.server.Data;
using Task10_Mini_Microservice.server.Models;

public class DbLoggerService
{
    private readonly AppDbContext _context;

    public DbLoggerService(AppDbContext context)
    {
        _context = context;
    }

    public async Task LogAsync(string level, string message, string? exception = null)
    {
        var log = new LogEntry
        {
            Level = level,
            Message = message,
            Exception = exception,
            Timestamp = DateTime.Now
        };

        _context.Logs.Add(log);
        await _context.SaveChangesAsync();
    }
}