using System;
using System.Collections.Generic;
using System.Threading;

public class ListingActivity : MindfulnessActivity
{
    private List<string> prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who have you helped this week?",
        "Who are some of your personal heroes?"
    };

    protected override string GetDescription()
    {
        return "This activity helps you reflect on the good things in your life.";
    }

    protected override void DoActivity()
    {
        Random rnd = new Random();
        string prompt = prompts[rnd.Next(prompts.Count)];
        Console.WriteLine($"\n{prompt}");
        Countdown(5);

        List<string> items = new List<string>();
        DateTime startTime = DateTime.Now;

        while ((DateTime.Now - startTime).TotalSeconds < Duration)
        {
            Console.Write("> ");
            string input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
                items.Add(input);
        }

        Console.WriteLine($"\nYou listed {items.Count} items. Great job!");
    }
}
