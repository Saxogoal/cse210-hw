using System;
using System.Collections.Generic;
using System.ComponentModel;

public class Goal
{
    private string _shortName;
    private string _description;
    private int _points;

    public string ShortName
    {
        get {return _shortName}
        set {_shortName = value}
    }
    public Goal(string _shortName, string _description, int _points)
    {
        _shortName = _shortName;
        _description = description;
        _points = _points;
    }
    public void RecordEvent()
    {

    }
    public bool IsComplete()
    {
        
    }
    public string GetDetails()
    {
        
    }
    public string GetString()
    {
        
    }
}