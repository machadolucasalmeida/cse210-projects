using System;

class Program
{
    static void Main(string[] args)
    {
        Reference reference1 = new Reference("Alma", 7, 11);
        Scripture scripture1 = new Scripture(reference1, "And he shall go forth, suffering pains and afflictions and temptations of every kind; and this that the word might be fulfilled which saith he will take upon him the pains and the sicknesses of his people.");

        Reference reference2 = new Reference("2 Nephi", 32, 6, 8);
        Scripture scripture2 = new Scripture(reference2, "Behold, this is the doctrine of Christ, and there will be no more doctrine given until after he shall manifest himself unto you in the flesh. And when he shall manifest himself unto you in the flesh, the things which he shall say unto you shall ye observe to do.");

        Scripture currentScripture = scripture2;

        string userInput = "";

        while (userInput.ToLower() != "quit" && !currentScripture.IsCompletelyHidden())
        {
            try
            {
                Console.Clear();
            }
            catch (System.IO.IOException ex)
            {
                Console.WriteLine($"Could not clear console: {ex.Message}. Displaying new content below.");
                Console.WriteLine("------------------------------------------------------------------");
            }


            Console.WriteLine(currentScripture.GetDisplayText());

            Console.WriteLine("\nPress Enter to hide words, or type 'quit' to exit.");
            userInput = Console.ReadLine();

            if (userInput.ToLower() != "quit")
            {
                currentScripture.HiddenRandomWords(3);
            }
        }

        try
        {
            Console.Clear();
        }
        catch (System.IO.IOException ex)
        {
            Console.WriteLine($"Could not clear console: {ex.Message}. Displaying final content below.");
            Console.WriteLine("------------------------------------------------------------------");
        }
        Console.WriteLine(currentScripture.GetDisplayText());
        Console.WriteLine("\nAll Words are hidden or you chose to quit. Program ended.");
        Thread.Sleep(2000);
    }
}