using System;
using System.Collections.Generic;
using System.IO;

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