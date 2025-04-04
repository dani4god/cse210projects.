using System;
using System.Threading;

public abstract class MindfulnessActivity
{
    protected int Duration;

    public void Run()
    {
        StartMessage();
        DoActivity();
        EndMessage();
    }

    protected void StartMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {GetType().Name}.");
        Console.WriteLine(GetDescription());
        Console.Write("Enter the duration of the activity (in seconds): ");
        Duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Prepare to begin...");
        ShowSpinner(3);
    }

    protected void EndMessage()
    {
        Console.WriteLine("\nWell done!");
        ShowSpinner(2);
        Console.WriteLine($"You have completed the {GetType().Name} for {Duration} seconds.");
        ShowSpinner(2);
    }

    protected void ShowSpinner(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write(".");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }

    protected void Countdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i + " ");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }

    protected abstract void DoActivity();
    protected abstract string GetDescription();
}
