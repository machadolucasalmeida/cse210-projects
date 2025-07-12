using System;

class Program
{
    static void Main(string[] args)
    {

        Journal myJournal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        int userChoiceInt = 0;


        do
        {
            Console.WriteLine("\nWelcome to the Journal program!");
            Console.WriteLine("Please, select an option: ");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");

            do
            {
                Console.Write("What would you like to do? ");
                string userInput = Console.ReadLine();

                if (int.TryParse(userInput, out userChoiceInt) && userChoiceInt >= 1 && userChoiceInt <= 5)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 5.");
                }
            } while (true);

            switch (userChoiceInt)
            {
                case 1:
                    Console.WriteLine("\n--- Write new Entry ---");
                    string randomPrompt = promptGenerator.GetPrompt();
                    Console.WriteLine($"Prompt: {randomPrompt}");

                    Console.WriteLine("Your Entry: ");
                    string userEntry = Console.ReadLine();

                    string currentDate = DateTime.Now.ToShortDateString();

                    Entry newEntry = new Entry(randomPrompt, userEntry, currentDate);
                    myJournal.AddEntry(newEntry);

                    Console.WriteLine("Entry added successfully!");

                    break;
                case 2:
                    Console.WriteLine("You chose to Display.");

                    myJournal.DisplayAll();

                    break;
                case 3:
                    Console.WriteLine("You chose to Load from file.");
                    Console.WriteLine("Enter filename to load from (e.g., myjournal.txt)");

                    string loadFileName = Console.ReadLine();
                    myJournal.LoadFromFile(loadFileName);

                    break;
                case 4:
                    Console.WriteLine("You chose to Save to file.");
                    Console.WriteLine("Enter filename to save to (e.g., myjournal.txt)");
                    string saveToFile = Console.ReadLine();

                    myJournal.SaveToFile(saveToFile);
                    break;
                case 5:
                    Console.WriteLine("Exiting the program. Goodbye!");
                    break;
            }

        } while (userChoiceInt != 5);
    }
}