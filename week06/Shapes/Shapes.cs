using System;
using System.Collections.Generic;

public  class Shapes
{
    private string _color;

    public string Color
    {
        get { return _color; }
        set { _color = value; }
    }

    public Shapes(string color)
    {
        _color = color;
    }
    
    public string GetColor()
    {
        return _color;
    }
    public void SetColor(string color)
    {
        _color = color;
    }
    public virtual double GetArea()
    {
        return 0;
    }
}