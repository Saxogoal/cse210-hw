using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries in this journal yet.");
            return;
        }

        foreach (Entry entry in _entries)
        {
            entry.Display();
        }

        Console.WriteLine();
    }
    
    public void SaveToFile(string file)
    {
        using (StreamWriter outputFile = new StreamWriter(file))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine($"{entry.Date}|{entry.PromptText}|{entry.EntryText}");
            }
        }

        Console.WriteLine($"Journal saved to {file}");
    }
    
    public void LoadFromFile(string file)
    {
        if (!File.Exists(file))
        {
            Console.WriteLine($"File {file} not found.");
            return;
        }

        string[] lines = File.ReadAllLines(file);
        _entries.Clear();
        
        foreach (string line in lines)
        {
            string[] parts = line.Split('|');

            if (parts.Length == 3)
            {
                Entry entry = new Entry(parts[1], parts[2]);
                entry.SetDate(parts[0]);

                _entries.Add(entry);
            }
        }

        Console.WriteLine($"Journal loaded from {file}");
    }

    // ✅ Search feature (kept)
    public void Search(string keyword)
    {
        bool found = false;

        foreach (Entry entry in _entries)
        {
            if (entry.PromptText.ToLower().Contains(keyword.ToLower()) ||
                entry.EntryText.ToLower().Contains(keyword.ToLower()))
            {
                entry.Display();
                Console.WriteLine();
                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine("No matching entries found.");
        }
    }
}