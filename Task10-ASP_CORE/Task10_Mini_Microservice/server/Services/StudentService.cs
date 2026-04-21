using Task10_Mini_Microservice.server.Data;
using Task10_Mini_Microservice.server.Models;
using Task10_Mini_Microservice.server.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Task10_Mini_Microservice.server.Services
{
    public class StudentService : IStudentService
    {
        private readonly AppDbContext _context;
        private readonly ILogger<StudentService> _logger;

        public StudentService(AppDbContext context, ILogger<StudentService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<List<Student>> GetAllAsync()
        {
            _logger.LogInformation("Fetching all students");
            return await _context.Students.ToListAsync();
        }

        public async Task<Student?> GetByrollNoAsync(int rollNo)
        {
            _logger.LogInformation($"Fetching student {rollNo}");
            return await _context.Students.FindAsync(rollNo);
        }

        public async Task<Student> AddAsync(Student Student)
        {
            _logger.LogInformation("Adding new student");
            _context.Students.Add(Student);
            await _context.SaveChangesAsync();
            return Student;
        }

        public async Task<bool> UpdateAsync(int rollNo, Student Student)
        {
            var existing = await _context.Students.FindAsync(rollNo);
            if (existing == null)
            {
                _logger.LogWarning($"Student {rollNo} not found");
                return false;
            }

            existing.Name = Student.Name;
            existing.classSection = Student.classSection;
            existing.markPercentage = Student.markPercentage;

            await _context.SaveChangesAsync();
            _logger.LogInformation($"Student {rollNo} updated successfully");
            return true;
        }

        public async Task<bool> DeleteAsync(int rollNo)
        {
            var Student = await _context.Students.FindAsync(rollNo);
            if (Student == null)
            {
                _logger.LogWarning($"Student {rollNo} not found");
                return false;
            }

            _context.Students.Remove(Student);
            _logger.LogInformation($"Student {rollNo} removed successfully");
            await _context.SaveChangesAsync();
            return true;
        }
    }
}