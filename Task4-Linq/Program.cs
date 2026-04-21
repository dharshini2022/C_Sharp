using System;

class Student
{
    public string Name { get;set;}
    public int Mark { get;set;}
    public int Age { get;set;}
}

class Program
{
    static void Main()
    {
        List<Student> students = new List<Student>
        {
            new Student { Name = "Name1", Mark = 85, Age = 20 },
            new Student { Name = "Name2", Mark = 45, Age = 21 },
            new Student { Name = "Name3", Mark = 75, Age = 19 },
            new Student { Name = "Name4", Mark = 90, Age = 22 },
            new Student { Name = "Name5", Mark = 60, Age = 20 }
        };

        Console.Write("Enter Mark threshold: ");
        int threshold = int.Parse(Console.ReadLine());

        var result = students
                        .Where(s => s.Mark > threshold && s.Age > 20)        
                        .OrderBy(s => s.Name);                 

        Console.WriteLine("\nFiltered & Sorted Students:");

        if (!result.Any())
        {
            Console.WriteLine("No students found.");
        }
        else
        {
            foreach (var student in result)
            {
                Console.WriteLine($"Name: {student.Name}, Mark: {student.Mark}, Age: {student.Age}");
            }
        }
    }
}