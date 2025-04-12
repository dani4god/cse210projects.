using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        int choice = -1;

        while (choice != 0)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Eternal Quest Program!");
            Console.WriteLine($"Current Score: {manager.TotalScore} | Level: {manager.Level} - Title: {manager.Title}");

            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Goal Event");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Load Goals");
            Console.WriteLine("0. Exit");
            Console.Write("Select an option: ");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1: manager.CreateGoal(); break;
                case 2: manager.DisplayGoals(); break;
                case 3: manager.RecordEvent(); break;
                case 4: manager.SaveGoals(); break;
                case 5: manager.LoadGoals(); break;
                case 0: Console.WriteLine("Goodbye!"); break;
                default: Console.WriteLine("Invalid choice!"); break;
            }

            Console.WriteLine("\nPress Enter to continue...");
            Console.ReadLine();
        }
    }
}
 