using System;

// CREATIVITY - EXCEEDS CORE REQUIREMENTS:
// 1. Leveling system — the player levels up every 1000 points,
//    displaying a congratulatory message when they reach a new level.
// 2. Negative goals — a new goal type that deducts points when recorded,
//    helping users track bad habits they want to break.
// 3. The menu loops continuously and only exits when the user chooses to quit.

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}