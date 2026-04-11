using System;
using System.Collections.Generic;
using System.IO;

class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine();
            DisplayPlayerInfo();
            Console.WriteLine();
            Console.WriteLine("Menu:");
            Console.WriteLine("  1. Create a new goal");
            Console.WriteLine("  2. List goals");
            Console.WriteLine("  3. Record an event");
            Console.WriteLine("  4. Save goals");
            Console.WriteLine("  5. Load goals");
            Console.WriteLine("  6. Quit");
            Console.Write("Select an option: ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoalDetails();
                    break;
                case "3":
                    RecordEvent();
                    break;
                case "4":
                    SaveGoals();
                    break;
                case "5":
                    LoadGoals();
                    break;
                case "6":
                    running = false;
                    Console.WriteLine("Goodbye! Keep up the great work on your Eternal Quest!");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        int level = _score / 1000 + 1;
        int nextLevel = level * 1000;
        Console.WriteLine($"⭐ Score: {_score} points | Level {level} | Next level at {nextLevel} points");
    }

    public void ListGoalNames()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"  {i + 1}. {_goals[i].GetShortName()}");
        }
    }

    public void ListGoalDetails()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals yet. Create one first!");
            return;
        }

        Console.WriteLine("Your Goals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"  {i + 1}. {_goals[i].GetDetails()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("Goal types:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.WriteLine("  4. Negative Goal");
        Console.Write("Select goal type: ");
        string type = Console.ReadLine();

        Console.Write("Enter the goal name: ");
        string name = Console.ReadLine();

        Console.Write("Enter the goal description: ");
        string description = Console.ReadLine();

        Console.Write("Enter the point value: ");
        int points = int.Parse(Console.ReadLine());

        switch (type)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, description, points));
                Console.WriteLine($"✅ Simple goal '{name}' created!");
                break;
            case "2":
                _goals.Add(new EternalGoal(name, description, points));
                Console.WriteLine($"✅ Eternal goal '{name}' created!");
                break;
            case "3":
                Console.Write("Enter the target number of completions: ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("Enter the bonus points: ");
                int bonus = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                Console.WriteLine($"✅ Checklist goal '{name}' created!");
                break;
            case "4":
                _goals.Add(new NegativeGoal(name, description, points));
                Console.WriteLine($"✅ Negative goal '{name}' created!");
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                break;
        }
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals yet. Create one first!");
            return;
        }

        Console.WriteLine("Which goal did you accomplish?");
        ListGoalNames();
        Console.Write("Select a goal number: ");

        if (!int.TryParse(Console.ReadLine(), out int index) || index < 1 || index > _goals.Count)
        {
            Console.WriteLine("Invalid selection.");
            return;
        }

        Goal selectedGoal = _goals[index - 1];
        int pointsEarned = selectedGoal.RecordEvent();

        if (pointsEarned > 0)
        {
            _score += pointsEarned;
            Console.WriteLine($"🎯 You earned {pointsEarned} points for '{selectedGoal.GetShortName()}'!");
        }
        else if (pointsEarned < 0)
        {
            _score += pointsEarned;
            if (_score < 0) _score = 0;
            Console.WriteLine($"📉 You lost {Math.Abs(pointsEarned)} points for '{selectedGoal.GetShortName()}'.");
        }

        // CREATIVITY: Check for level up
        int level = _score / 1000 + 1;
        Console.WriteLine($"⭐ Current score: {_score} | Level {level}");
    }

    public void SaveGoals()
    {
        Console.Write("Enter the filename to save to: ");
        string filename = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetString());
            }
        }

        Console.WriteLine($"✅ Goals saved to {filename}!");
    }

    public void LoadGoals()
    {
        Console.Write("Enter the filename to load from: ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        _goals.Clear();

        string[] lines = File.ReadAllLines(filename);
        _score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(":");

            switch (parts[0])
            {
                case "SimpleGoal":
                    _goals.Add(new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]), bool.Parse(parts[4])));
                    break;
                case "EternalGoal":
                    _goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3])));
                    break;
                case "ChecklistGoal":
                    _goals.Add(new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5]), int.Parse(parts[6])));
                    break;
                case "NegativeGoal":
                    _goals.Add(new NegativeGoal(parts[1], parts[2], int.Parse(parts[3])));
                    break;
            }
        }

        Console.WriteLine($"✅ Goals loaded from {filename}!");
    }
}