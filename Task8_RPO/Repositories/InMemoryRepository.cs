using System;
using System.Collections.Generic;
using System.Linq;
using Task8_RPO.Interfaces;
using Task8_RPO.Models;

namespace Task8_RPO.Repositories
{
    public class InMemoryRepository<T> : IRepository<T> where T : class, IEntity
    {
        private List<T> _students = new List<T>();

        public void AddStudent(T student)
        {
            _students.Add(student);
        }

        public List<T> GetAll()
        {
            return _students;
        }

        public T GetByRollNo(int rollNo)
        {
            return _students.FirstOrDefault(s => s.rollNo == rollNo);
        }

        public void Update(T student)
        {
            var oldRecord = GetByRollNo(student.rollNo);
            if(oldRecord != null)
            {
                int idx = _students.IndexOf(oldRecord);
                _students[idx] = student;
            }
            else
            {
                _students.Add(student);
            }
        }

        public bool Delete(int rollNo)
        {
            var student = GetByRollNo(rollNo);
            if( student != null)
            {
                _students.Remove(student);
                return true;
            }

            return false;
        }
    }
}