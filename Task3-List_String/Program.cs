using System;

class Program
{
    static void Main()
    {
        List<String> Tasks = new List<string>();
        int option = -1;

        while(option != 4)
        {
            Console.WriteLine("\n---------------------Enter-------------------------");
            Console.WriteLine("1 - add task to list");
            Console.WriteLine("2 - remove task from list");
            Console.WriteLine("3 - print all tasks");
            Console.WriteLine("4 - exit");
            bool isValid = int.TryParse(Console.ReadLine(), out option);

            if (!isValid)
            {
                Console.WriteLine("Invalid input");
                continue;
            }

            if(option == 1)
            {
                Console.Write("Enter new tasks:");
                String newTask = Console.ReadLine()?.Trim();
                Tasks.Add(newTask);
                Console.WriteLine($"{newTask} added successfully");
            }else if(option == 2)
            {
                Console.Write("Enter a task to remove:");
                String removeTask = Console.ReadLine()?.Trim();
                if (Tasks.Remove(removeTask))
                {
                    Console.WriteLine($"{removeTask} removed successfully");
                }
                else
                {
                    Console.WriteLine("No Tasks found");
                }
                
            }else if(option == 3)
            {
                Console.WriteLine("Task list:");
                foreach(String task in Tasks)
                {
                    Console.WriteLine(task.ToUpper());
                }
            }
            else if(option == 4)
            {
                Console.WriteLine("Exiting the Program...");
            }
            else
            {
                Console.WriteLine("Invalid Entry");
            }

        }
    }
}