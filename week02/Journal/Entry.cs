using System;

public class Entry
{
    public string _promptText;
    public string _entryText;
    public string _date;

    public Entry(string prompt, string entry, string date)
    {
        _date = date;
        _entryText = entry;
        _promptText = prompt;
    }
    public void Display()
    {
        Console.WriteLine($"Date: {_date} - Prompt: {_promptText}");
        Console.WriteLine($"Entry: {_entryText}");
        Console.WriteLine();
    }
     
}