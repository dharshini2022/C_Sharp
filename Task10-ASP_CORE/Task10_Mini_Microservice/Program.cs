using Task10_Mini_Microservice.server.Data;
using Task10_Mini_Microservice.server.Services;
using Task10_Mini_Microservice.server.Services.Interfaces;
using Task10_Mini_Microservice.server.Middleware;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddLogging();
builder.Services.AddScoped<DbLoggerService>();


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=students.db"));

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddScoped<IStudentService, StudentService>();

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();
app.UseMiddleware<RequestLoggingMiddleware>();

app.UseSwagger();
app.UseSwaggerUI();


app.UseAuthorization();
app.MapControllers();

using(var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();
}

app.Run();