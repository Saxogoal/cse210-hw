using System;
using System.Collections.Generic;
using System.IO;

// Creativity/Exceeds Requirements:
// 1. The program supports multiple scriptures sequentially,
//    moving from one to the next automatically when all words are hidden.
// 2. The user can type "quit" at any time to exit the program early.
// 3. Each time a word is hidden it hides a number of underscores that
//    matches the exact length of the hidden word, making it more
//    challenging and realistic for memorization.
// 4. The program clears the console each iteration for a clean
//    and distraction free memorization experience.

class Program
{
    static void Main()
    {
        // Create scripture references
        Reference ref1 = new Reference("John", 3, 16);
        Reference ref2 = new Reference("Proverbs", 3, 5, 6);

        // Create scriptures
        Scripture scripture1 = new Scripture(ref1, "For God so loved the world that he gave his only begotten Son");
        Scripture scripture2 = new Scripture(ref2, "Trust in the Lord with all thine heart and lean not unto thine own understanding In all thy ways acknowledge him and he shall direct thy paths");

        Scripture[] scriptures = { scripture1, scripture2 };

        foreach (Scripture scripture in scriptures)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());

            while (true)
            {
                Console.WriteLine("\nPress Enter to hide a word or type 'quit' to exit...");
                string input = Console.ReadLine();

                if (input?.ToLower() == "quit")
                {
                    Console.WriteLine("Goodbye!");
                    return;
                }

                scripture.HideRandomWords(1);

                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());

                if (scripture.IsCompletelyHidden())
                {
                    Console.WriteLine("\nAll words are hidden! Great job memorizing this scripture!");
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    break;
                }
            }
        }

        Console.WriteLine("\nYou have memorized all scriptures! Amazing work!");
    }
}