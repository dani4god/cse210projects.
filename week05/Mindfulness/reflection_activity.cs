using System;
using System.Collections.Generic;
using System.Threading;

public class ReflectionActivity : MindfulnessActivity
{
    private List<string> prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times?",
        "What did you learn about yourself?",
        "How can you keep this in mind in the future?"
    };

    protected override string GetDescription()
    {
        return "This activity helps you reflect on times you've shown strength or resilience.";
    }

    protected override void DoActivity()
    {
        Random rnd = new Random();
        string prompt = prompts[rnd.Next(prompts.Count)];
        Console.WriteLine($"\n{prompt}");
        ShowSpinner(3);

        int interval = 5;
        int elapsed = 0;

        while (elapsed < Duration)
        {
            string question = questions[rnd.Next(questions.Count)];
            Console.WriteLine($"> {question}");
            ShowSpinner(interval);
            elapsed += interval;
        }
    }
}
