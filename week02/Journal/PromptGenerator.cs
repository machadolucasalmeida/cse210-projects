using System;
using System.Collections.Generic;

class PromptGenerator()
{
    private Random _random = new Random();
    private List<string> _prompts = new List<string>()
    { "What is one new thing I learned today?", "How did I challenge myself today?", "What is something I'm grateful for that happened today?", "In what way did I make a positive impact on someone else's day?", "What is a small victory I celebrated today?", "Who was the most interesting person I interacted with today?", "What was the best part of my day?", "How did I see the hand of the Lord in my life today?", "What was the strongest emotion I felt today?", "If I had one thing I could do over today, what would it be?"};

    public string GetPrompt()
    {
        int sortedNumber = _random.Next(0, _prompts.Count);

        return _prompts[sortedNumber];
    }

}