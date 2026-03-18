using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
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
    
    public void Save(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {

                outputFile.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Answer}");
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

        string[] lines = File.ReadAllLines(filename);
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

        Console.WriteLine($"Journal loaded from {filename}"); 
    }

    public void Search(string keyword)
        {
            bool found = false;

            foreach (Entry entry in _entries)
            {
                if (entry.Prompt.ToLower().Contains(keyword.ToLower()) ||
                    entry.Answer.ToLower().Contains(keyword.ToLower()))
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
