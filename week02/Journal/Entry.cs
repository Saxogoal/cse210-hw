using System;
using System.Collections.Generic;
using System.IO;

public class Entry
{
    private string _date;
    private string _prompt;
    private string _answer;

    // Properties (controlled access)
    public string Date => _date;
    public string Prompt => _prompt;
    public string Answer => _answer;

    public Entry(string prompt, string answer)
    {
        _date = DateTime.Now.ToString("yyyy-MM-dd");
        _prompt = prompt;
        _answer = answer;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_prompt}");
        Console.WriteLine($"Answer: {_answer}");
    }
    public void SetDate(string date)
    {
        _date = date;
    }
}