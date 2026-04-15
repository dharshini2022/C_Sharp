using System;
using System.Globalization;

class Program{
    static long Factorial(int num)
    {
        if(num == 0 || num == 1)
        {
            return 1;
        }

        return num * Factorial(num - 1);
    }
    static void Main(){
        Console.WriteLine("Enter a positive Integer:");
        int num;
        bool isValid = int.TryParse(Console.ReadLine(), out num);

        if (!isValid || num < 0)
        {
            Console.WriteLine("Enter a positive number");
            return;
        }
        Console.WriteLine($"Factorial of {num} is {Factorial(num)}");

    }
}