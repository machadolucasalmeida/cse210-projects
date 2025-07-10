using System;

class Program
{
    static void Main(string[] args)
    {
        // ... (rest of your code before the do-while) ...

        int userChoiceInt = 0; // Initialize outside the outer loop

        // Outer loop to keep the program running until 'Quit' is selected
        do
        {
            Console.WriteLine("\nWelcome to the Journal program!"); // Added newline for clarity
            Console.WriteLine("Please, select an option: "); // Corrected typo
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");

            // Inner loop for input validation
            do
            {
                Console.Write("What would you like to do? ");
                string userInput = Console.ReadLine();

                if (int.TryParse(userInput, out userChoiceInt) && userChoiceInt >= 1 && userChoiceInt <= 5)
                {
                    break; // Exit inner loop
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 5.");
                }
            } while (true); // Inner loop continues until valid input (1-5)

            // Now handle the valid choice from the inner loop
            switch (userChoiceInt)
            {
                case 1:
                    Console.WriteLine("You chose to Write.");
                    // Call your actual Write method here
                    break;
                case 2:
                    Console.WriteLine("You chose to Display.");
                    // Call your actual Display method here
                    break;
                case 3:
                    Console.WriteLine("You chose to Load.");
                    // Call your actual Load method here
                    break;
                case 4:
                    Console.WriteLine("You chose to Save.");
                    // Call your actual Save method here
                    break;
                case 5:
                    Console.WriteLine("Exiting the program. Goodbye!");
                    // No break needed here, as the outer loop condition will handle termination
                    break; // Still good practice to include it for the switch
            }

        } while (userChoiceInt != 5); // Outer loop continues as long as user didn't choose 'Quit'
    }
}