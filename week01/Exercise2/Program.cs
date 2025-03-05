using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter your grade percentage: ");
        int grade = int.Parse(Console.ReadLine());
        string letter = "";
        string sign = "";
        if (grade >= 90)
        {
            letter = "A";
        }
        else if (grade >= 80)
        {
            letter = "B";
        }
        else if (grade >= 70)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }
        int lastdigit = grade % 10;
        if (lastdigit >= 7)
        {
            sign = "+";
        }
        else if (lastdigit < 3)
        {
            sign = "-";
        }
        if (letter == "A" && sign == "+")
        {
            sign = "";
        }
        Console.WriteLine($"Your grade is {letter}{sign} ");
        if (grade >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course. ");
        }
        else
        {
            Console.WriteLine("Keep trying! You can improve next time");
        }
    }

}