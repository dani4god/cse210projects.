using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter your first name");
        string firstname = Console.ReadLine();
        Console.WriteLine("Enter your last name");
        string lastname = Console.ReadLine();
        Console.WriteLine($"Your name is {lastname}, {firstname} {lastname}");

    }
}