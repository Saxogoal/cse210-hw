using System;

class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing", "This activity will help you relax by guiding you through slow breathing. Clear your mind and focus on your breath.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        DateTime startTime = DateTime.Now;
        while ((DateTime.Now - startTime).TotalSeconds < GetDuration())
        {
            Console.WriteLine("Breathe in...");
            ShowCountdown(4);
            Console.WriteLine();
            Console.WriteLine("Hold...");
            ShowCountdown(7);
            Console.WriteLine();
            Console.WriteLine("Breathe out...");
            ShowCountdown(8);
            Console.WriteLine();
        }

        DisplayEndingMessage();
    }
}