using System;
class Program
{
    static void Main()
    {
        DisplayWelcome();

        string username = PromptUserName();
        int favoriteNumber = PromptUserNumber();
        int squaredNumber = SquareNumber(favoriteNumber);

        DisplayResult(username, squaredNumber);
    }
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the program!");
    }
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        return Console.ReadLine();
    }
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number ");
        return
int.Parse(Console.ReadLine());
    }
    static int SquareNumber(int number)
    {
        return number * number;
    }
    static void DisplayResult(string name, int SquaredNumber)
    {
        Console.WriteLine($"{name}, the square of your number is {SquaredNumber}");
    }
}