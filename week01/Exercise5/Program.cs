using System;

class Program
{
    public static void Main(string[] args)
    {
        DisplayWelcome();

        string userName = PromptUserName();

        int favoriteNumber = PromptUserNumber();

        int squaredNumber = SquareNumber(favoriteNumber);

        DisplayResult(userName, squaredNumber);
    }
    public static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the program!");
    }
    public static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        return name;
    }
    public static int PromptUserNumber()
    {
        int number;
        while (true) 
        {
            Console.Write("Please enter your favorite number: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out number))
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a whole number.");
            }
        }
        return number;
    }

    public static int SquareNumber(int number)
    {
        return number * number;
    }

    public static void DisplayResult(string userName, int squaredNumber)
    {
        Console.WriteLine($"{userName}, the square of your number is {squaredNumber}");
    }
}