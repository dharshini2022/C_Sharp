using Xunit;
using Microsoft.EntityFrameworkCore;
using Task10_Mini_Microservice.server.Data;
using Task10_Mini_Microservice.server.Services;
using Task10_Mini_Microservice.server.Models;
using Microsoft.Extensions.Logging;
using Moq;

public class StudentServiceTests
{
    private AppDbContext GetDbContext()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        return new AppDbContext(options);
    }

    private StudentService GetService(AppDbContext context)
    {
        var logger = new Mock<ILogger<StudentService>>();
        return new StudentService(context, logger.Object);
    }

    [Fact]
    public async Task AddStudent_ShouldAddStudent()
    {
        var context = GetDbContext();
        var service = GetService(context);

        var student = new Student { Name = "Test", classSection = "A", markPercentage = 90 };

        var result = await service.AddAsync(student);

        Assert.NotNull(result);
        Assert.Equal(1, context.Students.Count());
    }

    [Fact]
    public async Task GetStudent_ShouldReturnStudent()
    {
        var context = GetDbContext();
        var service = GetService(context);

        var student = new Student { rollNo = 1, Name = "Test", classSection = "A", markPercentage = 90 };
        context.Students.Add(student);
        await context.SaveChangesAsync();

        var result = await service.GetByrollNoAsync(1);

        Assert.NotNull(result);
        Assert.Equal("Test", result.Name);
    }
}