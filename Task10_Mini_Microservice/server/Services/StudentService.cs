using Task10_Mini_Microservice.server.Data;
using Task10_Mini_Microservice.server.Models;
using Task10_Mini_Microservice.server.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Task10_Mini_Microservice.server.Services
{
    public class StudentService : IStudentService
    {
        private readonly AppDbContext _context;

        public StudentService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Student>> GetAllAsync()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Student?> GetByrollNoAsync(int rollNo)
        {
            return await _context.Students.FindAsync(rollNo);
        }

        public async Task<Student> AddAsync(Student Student)
        {
            _context.Students.Add(Student);
            await _context.SaveChangesAsync();
            return Student;
        }

        public async Task<bool> UpdateAsync(int rollNo, Student Student)
        {
            var existing = await _context.Students.FindAsync(rollNo);
            if (existing == null) return false;

            existing.Name = Student.Name;
            existing.classSection = Student.classSection;
            existing.markPercentage = Student.markPercentage;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int rollNo)
        {
            var Student = await _context.Students.FindAsync(rollNo);
            if (Student == null) return false;

            _context.Students.Remove(Student);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}