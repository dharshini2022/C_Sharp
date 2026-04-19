using System;

public delegate void ThresholdDelegate(int count);

class Counter
{
    int count = 0;
    int threshold;

    public event ThresholdDelegate ThresholdReached;

    public Counter(int threshold)
    {
        this.threshold = threshold;
    }

    public void Increment()
    {
        count++;
        Console.WriteLine("Count: " + count);
        if(count == threshold)
        {
            ThresholdReached?.Invoke(count);
        }
    }
}

class Handler
{
    public void displayThresholdMsg(int count)
    {
        Console.WriteLine($"Threshold reached at {count}");
    }

    public void consoleLog(int count)
    {
        Console.WriteLine($"Counter hit limit: {count}");
    }

    public void TakeAction(int count)
    {
        Console.WriteLine("Action...");
    }

    // Invalid Delegate handler.
    // public int countReturn(int count)
    // {
    //     Console.WriteLine("Invalid Delegate HAndler");
    //     return count;
    // }
}

class Program
{
    static void Main()
    {
        Counter counter = new Counter(5);
        Handler handler = new Handler();

        counter.ThresholdReached += handler.displayThresholdMsg;
        counter.ThresholdReached += handler.consoleLog;
        counter.ThresholdReached += handler.TakeAction;
        // counter.ThresholdReached += handler.countReturn;

        for(int i = 0; i < 7; ++i)
        {
            counter.Increment();
            System.Threading.Thread.Sleep(1000);
        }
    }
}