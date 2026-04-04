using System;

// CREATIVITY:
// 1. The menu loops continuously, allowing the user to do multiple activities
//    in one session instead of the program ending after one activity.
// 2. The program keeps track of how many times each activity was performed
//    and displays a session summary when the user chooses to quit.

class Program
{
    static void Main(string[] args)
    {
        // Activity counters for session tracking
        int breathingCount = 0;
        int reflectionCount = 0;
        int listingCount = 0;

        Console.WriteLine("Welcome to the Mindfulness Activities!");
        Console.WriteLine();

        bool running = true;
        while (running)
        {
            Console.WriteLine("Please select an activity:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");
            Console.Write("Enter the number of your choice: ");
            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    BreathingActivity breathingActivity = new BreathingActivity();
                    breathingActivity.Run();
                    breathingCount++;
                    break;
                case "2":
                    ReflectionActivity reflectionActivity = new ReflectionActivity();
                    reflectionActivity.Run();
                    reflectionCount++;
                    break;
                case "3":
                    ListingActivity listingActivity = new ListingActivity();
                    listingActivity.Run();
                    listingCount++;
                    break;
                case "4":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please select a valid activity.");
                    Console.WriteLine();
                    break;
            }
        }

        // Session summary
        Console.WriteLine("Session Summary:");
        Console.WriteLine($"  Breathing Activity: {breathingCount} time(s)");
        Console.WriteLine($"  Reflection Activity: {reflectionCount} time(s)");
        Console.WriteLine($"  Listing Activity: {listingCount} time(s)");
        Console.WriteLine();
        Console.WriteLine("Thank you for participating in the Mindfulness Activities. Have a great day!");
    }
}