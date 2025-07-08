using System;

class Program
{
    static void Main(string[] args)
    {
        float grade = 0;
        char letter = ' ';
        Console.Write("Enter your grade percentage: ");
        try
        {
            grade = float.Parse(Console.ReadLine());
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid string format. Please, type in numbers."); 
        }
        

        if (grade >= 90)
        {
            letter = 'A';
        }
        else if (grade >= 80)
        {
            letter = 'B';
        }
        else if (grade >= 70)
        {
            letter = 'C';
        }
        else if (grade >= 60)
        {
            letter = 'D';
        }
        else if (grade < 60)
        {
            letter = 'F';
        }
        else
        {
            Console.WriteLine("Sorry, i didn't understand your grade!");
        }

        if (grade >= 70)
        {
            Console.WriteLine($"Congrats, your grade is {letter} and you passed!!!");
        }
        else
        {
            Console.WriteLine($"Sorry, your grade is {letter} and you didn't pass \nBetter luck next time!");
        }

    }
}