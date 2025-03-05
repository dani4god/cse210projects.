using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

class Program
{
    static void Main()
    {
        List<int> numbers = new List<int>();
        Console.WriteLine("Enter a list of numbers, type 0 when finished");
        while(true)
        {
            Console.Write("Enter Number");
            string input = Console.ReadLine();
            int num;
            if (!int.TryParse(input, out num))
            {
Console.WriteLine("Invalid input!");
                continue;                
            }
            
            if (num == 0)
            {
                break;
            }    
            numbers.Add(num);            
        }
        if (numbers.Count == 0)
        {
            Console.WriteLine("No numbers were entered");
            return;
        }
        int sum = numbers.Sum();
        double average = numbers.Average();
        int maxNumber = numbers.Max();
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is {maxNumber}");

        int? smallestPositive = numbers.Where(n => n > 0).DefaultIfEmpty().Min();
        if (smallestPositive > 0)
        {
            Console.WriteLine($"The smallest positive number is: {smallestPositive}");
            numbers.Sort();
            Console.WriteLine("The sorted list is:");
            foreach (int number in numbers)
            {
Console.WriteLine(number);
            }
        }
        
    }
}