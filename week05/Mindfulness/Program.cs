using System;
using System.Collections.Generic;
using System.Threading;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Mindfulness Program!");
            Console.WriteLine("1. Start Breathing Activity");
            Console.WriteLine("2. Start Reflection Activity");
            Console.WriteLine("3. Start Listing Activity");
            Console.WriteLine("4. Exit");
            Console.Write("Select an option: ");

            string input = Console.ReadLine();

            MindfulnessActivity activity = null;

            switch (input)
            {
                case "1":
                    activity = new BreathingActivity();
                    break;
                case "2":
                    activity = new ReflectionActivity();
                    break;
                case "3":
                    activity = new ListingActivity();
                    break;
                case "4":
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid input. Try again.");
                    Thread.Sleep(2000);
                    continue;
            }

            activity.Run();
        }
    }
}
 