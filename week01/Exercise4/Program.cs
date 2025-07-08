using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int inputNumber = -1;

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        while (inputNumber != 0)
        {
            Console.Write("Enter number: ");
            string inputText = Console.ReadLine();

            if (int.TryParse(inputText, out inputNumber))
            {
                if (inputNumber != 0)
                {
                    numbers.Add(inputNumber);
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a whole number.");
            }
        }

        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }
        Console.WriteLine($"The sum is: {sum}");

        if (numbers.Count > 0)
        {
            double average = (double)sum / numbers.Count;
            Console.WriteLine($"The average is: {average}");
        }
        else
        {
            Console.WriteLine("No numbers were entered to calculate an average.");
        }

        if (numbers.Count > 0)
        {
            int largestNumber = numbers[0]; 
            foreach (int number in numbers)
            {
                if (number > largestNumber)
                {
                    largestNumber = number;
                }
            }
            Console.WriteLine($"The largest number is: {largestNumber}");
        }
        else
        {
            Console.WriteLine("No numbers were entered to find the largest number.");
        }

        Console.WriteLine("Program finished.");
    }
}