using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    public List<string> _answers;
    int _date;
    
    public Journal()
    {
        _answers = new List<string>();
        _date = DateTime.Now.Day;
    }
    
    public void DisplayAnswer()
    {
        if (_answers.Count == 0)
        {
            Console.WriteLine("No entries in this journal yet.");
            return;
        }
        
        Console.WriteLine($"\n--- Journal Entries (Day {_date}) ---");
        for (int i = 0; i < _answers.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_answers[i]}");
        }
        Console.WriteLine();
    }
    
    public void Save(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_date);
            foreach (string answer in _answers)
            {
                outputFile.WriteLine(answer);
            }
        }
        Console.WriteLine($"Journal saved to {filename}");
    }
    
    public void Load(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine($"File {filename} not found.");
            return;
        }
        
        _answers.Clear();
        using (StreamReader inputFile = new StreamReader(filename))
        {
            string line = inputFile.ReadLine();
            if (int.TryParse(line, out int date))
            {
                _date = date;
            }
            
            while ((line = inputFile.ReadLine()) != null)
            {
                _answers.Add(line);
            }
        }
        Console.WriteLine($"Journal loaded from {filename}");
    }
}

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

class Program
{
    static void Main()
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        
        bool running = true;
        while (running)
        {
            Console.WriteLine("\n--- Journal Menu ---");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save journal");
            Console.WriteLine("4. Load journal");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");
            
            string choice = Console.ReadLine();
            
            switch (choice)
            {
                case "1":
                    string prompt = promptGenerator.WritePrompt();
                    Console.WriteLine($"\n{prompt}");
                    Console.Write("Your answer: ");
                    string answer = Console.ReadLine();
                    journal._answers.Add($"{prompt}\n{answer}");
                    Console.WriteLine("Entry added.");
                    break;
                    
                case "2":
                    journal.DisplayAnswer();
                    break;
                    
                case "3":
                    Console.Write("Enter filename to save: ");
                    string saveFile = Console.ReadLine();
                    journal.Save(saveFile);
                    break;
                    
                case "4":
                    Console.Write("Enter filename to load: ");
                    string loadFile = Console.ReadLine();
                    journal.Load(loadFile);
                    break;
                    
                case "5":
                    running = false;
                    Console.WriteLine("Goodbye!");
                    break;
                    
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}