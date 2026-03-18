using System;
using System.Collections.Generic;
using System.IO;

public class Entry
{
    private string _date;
    private string _promptText;
    private string _entryText;

    // Properties
    public string Date => _date;
    public string PromptText => _promptText;
    public string EntryText => _entryText;

    public Entry(string promptText, string entryText)
    {
        _date = DateTime.Now.ToString("yyyy-MM-dd");
        _promptText = promptText;
        _entryText = entryText;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_promptText}");
        Console.WriteLine($"Answer: {_entryText}");
    }

    public void SetDate(string date)
    {
        _date = date;
    }
}