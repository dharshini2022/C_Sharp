using System;
using ReflectionRunner.Attributes;

namespace ReflectionRunner.Tasks
{
    public class Task1
    {
        [Runnable]
        public void Execute()
        {
            Console.WriteLine("Task1 Executed");
        }

        public void Ignore()
        {
            Console.WriteLine("This method ignored");
        }
    }
}