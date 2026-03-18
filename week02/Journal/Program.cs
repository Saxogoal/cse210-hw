using System;
using System.Collections.Generic;
using System.IO;

// Exceeding requirements:
// Added a search feature that allows the user to find journal entries
// by typing a keyword. The program searches both prompts and answers.

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        
        int choice = 0;

        while (choice != 6)
        {
            Console.WriteLine("\n--- Journal Menu ---");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save journal");
            Console.WriteLine("4. Load journal");
            Console.WriteLine("5. Exit");
            Console.WriteLine("6. Search entries");

            choice = GetMenuChoice();

            if (choice == 1)
            {
                string prompt = promptGenerator.WritePrompt();

                Console.WriteLine($"\n{prompt}");
                Console.Write("> ");
                string answer = Console.ReadLine();

                Entry entry = new Entry(prompt, answer);
                journal.AddEntry(entry);
            }
            else if (choice == 2)
            {
                journal.DisplayAll();
            }
            else if (choice == 3)
            {
                Console.Write("Enter filename to save: ");
                string filename = Console.ReadLine();

                journal.Save(filename);
            }
            else if (choice == 4)
            {
                Console.Write("Enter filename to load: ");
                string filename = Console.ReadLine();

                journal.Load(filename);
            }
            else if (choice == 5)
            {
                Console.WriteLine("Exiting the journal. Goodbye!");
            }
            else if (choice == 6)
            {
                Console.Write("Enter keyword to search: ");
                string keyword = Console.ReadLine();

                journal.Search(keyword);
            }
        }
    }


    static int GetMenuChoice()
    {
        int choice;
        while (true)
        {
            Console.Write("Select an option (1-6): ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out choice) && choice >= 1 && choice <= 6)
            {
                return choice;
            }

            Console.WriteLine("Invalid input.");
        }
    }
}