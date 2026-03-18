using System;
using System.Collections.Generic;
using System.IO;
public class PromptGenerator
{
    public List<string> _prompts;
    private Random _random;
    
    public PromptGenerator()
    {
        _prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "What am I grateful for today?"
        };
        _random = new Random();
    }
    
    public string WritePrompt()
    {
        int index = _random.Next(_prompts.Count);
        return _prompts[index];
    }
}
