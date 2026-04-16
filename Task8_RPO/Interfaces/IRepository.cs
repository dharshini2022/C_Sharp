using System;
namespace Task8_RPO.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void AddStudent(T student);
        List<T> GetAll();
        T GetByRollNo(int rollNo);
        void Update(T student);
        bool Delete(int rollNo);
    }
}

