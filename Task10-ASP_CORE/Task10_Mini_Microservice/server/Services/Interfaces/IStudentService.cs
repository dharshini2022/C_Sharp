using Task10_Mini_Microservice.server.Models;

namespace Task10_Mini_Microservice.server.Services.Interfaces
{
    public interface IStudentService
    {
        Task<List<Student>> GetAllAsync();
        Task<Student?> GetByrollNoAsync(int rollNo);
        Task<Student> AddAsync(Student student);
        Task<bool> UpdateAsync(int rollNo, Student student);
        Task<bool> DeleteAsync(int rollNo);
    }
}