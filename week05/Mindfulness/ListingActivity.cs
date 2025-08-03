public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    private Random _random = new Random();
    private int _itemCount;

    public ListingActivity()
    {
        _name = "Listing Activity";
        _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
    }

    public override void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine();
        Console.WriteLine("List as many responses you can to the following prompt:");
        DisplayPrompt();
        Console.Write("You may begin in: ");
        ShowCountdown(5);
        Console.WriteLine();

        _itemCount = 0;
        DateTime startTime = DateTime.Now;
        while ((DateTime.Now - startTime).TotalSeconds < _duration)
        {
            Console.Write("> ");
            Console.ReadLine(); // User enters an item
            _itemCount++;
        }

        Console.WriteLine($"You listed {_itemCount} items!");

        DisplayEndingMessage();
    }

    private void DisplayPrompt()
    {
        int index = _random.Next(_prompts.Count);
        Console.WriteLine($"--- {_prompts[index]} ---");
    }
}