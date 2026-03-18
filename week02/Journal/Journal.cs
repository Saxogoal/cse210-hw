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