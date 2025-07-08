using System;

class Program
{
    static void Main(string[] args)
    {
       Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 101);

        int guess = -1; 
        int guessCount = 0; 

        Console.WriteLine("Welcome to the Guess My Number game!");
        Console.WriteLine("I have picked a magic number between 1 and 100. Can you guess it?");

        while (guess != magicNumber)
        {
            Console.Write("What is your guess? ");
            string guessText = Console.ReadLine();

            if (!int.TryParse(guessText, out guess))
            {
                Console.WriteLine("Invalid input. Please enter a whole number.");
                continue;
            }

            guessCount++;

            if (guess < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else if (guess > magicNumber)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it!");
                Console.WriteLine($"It took you {guessCount} guesses.");
            }
        }

        Console.WriteLine("Thanks for playing!");
    }
}