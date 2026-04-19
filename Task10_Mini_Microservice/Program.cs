using Task10_Mini_Microservice.server.Data;
using Task10_Mini_Microservice.server.Services;
using Task10_Mini_Microservice.server.Services.Interfaces;
using Task10_Mini_Microservice.server.Middleware;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("StudentDb"));

builder.Services.AddScoped<IStudentService, StudentService>();

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

app.UseSwagger();
app.UseSwaggerUI();


app.UseAuthorization();
app.MapControllers();

app.Run();