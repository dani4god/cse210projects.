using System;

class Program
{
    static void Main()
    {
        string playAgain = "yes";
        while (playAgain.ToLower() == "yes")
        {
            Random random = new Random();
            int magicNumber = random.Next(1, 101);
            int guess = -1;
            int attempts = 0;
Console.WriteLine("welcome to the 'guess my number game!");
            Console.WriteLine("I have picked a number between 1 and 100, try to guess it.");
            while (guess != magicNumber)
            {
                Console.Write("What is your guess ");
                string input = Console.ReadLine();
                if (! int.TryParse(input, out guess))
                {
Console.WriteLine("invalid input");
                    continue;
                }
                attempts++;
                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("lower");
                }
                else
                {
                    Console.WriteLine($"You guesed it in {attempts} attempts!");                    
                }
                               
            }
            Console.Write("Do you want to play again?");
            playAgain = Console.ReadLine();
        }
        Console.WriteLine("Thanks for playing! goodbye.");
    }
}