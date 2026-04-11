using System;

class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string shortName, string description, int points, int target, int bonus)
        : base(shortName, description, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
    }

    public ChecklistGoal(string shortName, string description, int points, int target, int bonus, int amountCompleted)
        : base(shortName, description, points)
    {
        _target = target;
        _bonus = bonus;
        _amountCompleted = amountCompleted;
    }

    public override int RecordEvent()
    {
        if (IsComplete())
        {
            Console.WriteLine("This goal is already complete!");
            return 0;
        }

        _amountCompleted++;

        if (IsComplete())
        {
            Console.WriteLine($"🎉 Congratulations! You completed the checklist goal and earned a bonus of {_bonus} points!");
            return GetPoints() + _bonus;
        }

        return GetPoints();
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    public override string GetDetails()
    {
        string checkbox = IsComplete() ? "[X]" : "[ ]";
        return $"{checkbox} {GetShortName()} ({GetDescription()}) -- Completed {_amountCompleted}/{_target} times";
    }

    public override string GetString()
    {
        return $"ChecklistGoal:{GetShortName()}:{GetDescription()}:{GetPoints()}:{_target}:{_bonus}:{_amountCompleted}";
    }
}