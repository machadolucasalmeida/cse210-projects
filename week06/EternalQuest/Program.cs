using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager goalManager = new GoalManager();
        string choice = "";

        // Creativity / Exceeding Requirements:
        // - Added a simple leveling system based on total score.
        // - Points needed for the next level increase progressively.
        // - Small bonus points awarded upon leveling up.
        // - Cleaned up user interface with clear prompts and feedback.

        while (choice != "6")
        {
            goalManager.DisplayPlayerInfo(); // Always show score/level at the top
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Record Event");
            Console.WriteLine("  4. Save Goals");
            Console.WriteLine("  5. Load Goals");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    goalManager.CreateGoal();
                    break;
                case "2":
                    goalManager.ListGoalDetails();
                    break;
                case "3":
                    goalManager.RecordEvent();
                    break;
                case "4":
                    goalManager.SaveGoals();
                    break;
                case "5":
                    goalManager.LoadGoals();
                    break;
                case "6":
                    Console.WriteLine("\nExiting the Eternal Quest program. Goodbye!");
                    break;
                default:
                    Console.WriteLine("\nInvalid option. Please enter a number between 1 and 6.");
                    break;
            }
            // Add a pause for better user experience after an action, unless quitting
            if (choice != "6")
            {
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear(); // Clear console for cleaner display
            }
        }
    }
}