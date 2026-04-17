using ReflectionRunner.Services;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Execution Started...\n");
        Runner runner = new Runner();
        runner.Execute();
        Console.WriteLine("\nExecution Completed...");
    }
}