using System;

// CREATIVITY: Negative goals deduct points when recorded.
// This helps users track bad habits they want to break.
class NegativeGoal : Goal
{
    public NegativeGoal(string shortName, string description, int points)
        : base(shortName, description, points)
    {
    }

    public override int RecordEvent()
    {
        return -GetPoints();
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetDetails()
    {
        return $"[✗] {GetShortName()} ({GetDescription()}) -- -{GetPoints()} points";
    }

    public override string GetString()
    {
        return $"NegativeGoal:{GetShortName()}:{GetDescription()}:{GetPoints()}";
    }
}