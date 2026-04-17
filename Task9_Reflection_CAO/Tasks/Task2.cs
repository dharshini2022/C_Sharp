using System;
using ReflectionRunner.Attributes;

namespace ReflectionRunner.Tasks
{
    public class Task2
    {
        [Runnable]
        public static void Start()
        {
            Console.WriteLine("Task2 Executred");
        }
    }
}