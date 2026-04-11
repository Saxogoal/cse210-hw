using System;

class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string shortName, string description, int points) 
        : base(shortName, description, points)
    {
        _isComplete = false;
    }

    public SimpleGoal(string shortName, string description, int points, bool isComplete)
        : base(shortName, description, points)
    {
        _isComplete = isComplete;
    }

    public override int RecordEvent()
    {
        if (_isComplete)
        {
            Console.WriteLine("This goal is already complete!");
            return 0;
        }

        _isComplete = true;
        return GetPoints();
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetString()
    {
        return $"SimpleGoal:{GetShortName()}:{GetDescription()}:{GetPoints()}:{_isComplete}";
    }
}