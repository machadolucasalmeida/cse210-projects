public abstract class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity()
    {
        _name = "Generic Activity";
        _description = "This is a generic mindfulness activity.";
    }

    protected void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
        Console.Write("How long, in seconds, would you like for your session? ");
        _duration = int.Parse(Console.ReadLine());
        Console.Clear();
        Console.WriteLine("Prepare to begin...");
        ShowSpinner(5);
    }

    protected void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!!");
        ShowSpinner(3);
        Console.WriteLine();
        Console.WriteLine($"You have completed the {_name} for {_duration} seconds.");
        ShowSpinner(5);
    }

    protected void ShowSpinner(int seconds)
    {
        List<string> spinnerFrames = new List<string> { "|", "/", "-", "\\" };
        DateTime startTime = DateTime.Now;
        int i = 0;
        while ((DateTime.Now - startTime).TotalSeconds < seconds)
        {
            Console.Write(spinnerFrames[i]);
            Thread.Sleep(250);
            Console.Write("\b \b"); // Erase the spinner character
            i = (i + 1) % spinnerFrames.Count;
        }
    }

    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b"); // Erase the countdown number
            if (i < 10) // Erase an extra character for single digits
            {
                Console.Write("\b \b");
            }
        }
    }

    public abstract void Run();
}