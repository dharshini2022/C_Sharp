using System;
using Task8_RPO.Interfaces;
using Task8_RPO.Models;
using Task8_RPO.Repositories;

class Program
{
    static void Main(string[] args)
    {
        IRepository<Student> repo = new InMemoryRepository<Student>();

        while (true)
        {
            Console.WriteLine("\n------Enter-------");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Get all students");
            Console.WriteLine("3. Get a Student by roll no");
            Console.WriteLine("4. Update a Student details");
            Console.WriteLine("5. Delete a student");

            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                {
                    Console.Write("Enter roll no:");
                    int rollNo = int.Parse(Console.ReadLine());

                    Console.Write("Enter Name:");
                    string name = Console.ReadLine();

                    Console.Write("Enter class and section:");
                    string classSection = Console.ReadLine();

                    Console.Write("Enter marks:");
                    double markPercentage = double.Parse(Console.ReadLine());

                    repo.AddStudent(new Student
                    {
                        rollNo = rollNo,
                        Name = name,
                        classSection = classSection,
                        markPercentage = markPercentage
                    });

                    Console.WriteLine("Student Added");
                    break;
                }

                case 2:
                {
                    foreach (var s in repo.GetAll())
                    {
                        Console.WriteLine($"{s.rollNo} - {s.Name} - {s.classSection} - {s.markPercentage}");
                    }
                    break;
                }

                case 3:
                {
                    Console.Write("Enter roll no:");
                    int rollNo = int.Parse(Console.ReadLine());

                    var student = repo.GetByRollNo(rollNo);

                    if (student != null)
                        Console.WriteLine($"{student.rollNo} - {student.Name}");
                    else
                        Console.WriteLine("Not found");

                    break;
                }

                case 4:
                {
                    Console.Write("Enter roll no:");
                    int rollNo = int.Parse(Console.ReadLine());

                    Console.Write("Enter new Name:");
                    string name = Console.ReadLine();

                    Console.Write("Enter new class:");
                    string classSection = Console.ReadLine();

                    Console.Write("Enter new marks:");
                    double markPercentage = double.Parse(Console.ReadLine());

                    repo.Update(new Student
                    {
                        rollNo = rollNo,
                        Name = name,
                        classSection = classSection,
                        markPercentage = markPercentage
                    });

                    Console.WriteLine("Updated");
                    break;
                }

                case 5:
                {
                    Console.Write("Enter roll no:");
                    int rollNo = int.Parse(Console.ReadLine());

                    bool deleted = repo.Delete(rollNo);
                    if (deleted)
                    {
                      Console.WriteLine("Deleted");      
                    }else{
                        Console.WriteLine("No Records found!");
                    }
                    break;
                }

                default:
                    return;
            }
        }
    }
}