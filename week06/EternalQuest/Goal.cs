using System;
public abstract class Goal
{
    protected string _shortName;
    protected string _description;
    protected int _points;

    // Constructor to initialize common goal properties
    public Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    // Public method to get the short name of the goal
    public string GetShortName()
    {
        return _shortName;
    }

    // Public method to get the description of the goal
    public string GetDescription()
    {
        return _description;
    }

    // Public method to get the points associated with the goal
    public int GetPoints()
    {
        return _points;
    }

    // Abstract method to be overridden by derived classes for recording an event
    public abstract int RecordEvent(); // Returns points earned

    // Virtual method for getting detailed string representation.
    // It's virtual so derived classes can override it, but a default is provided.
    public virtual string GetDetailsString()
    {
        return $"{_shortName} ({_description})";
    }

    // Abstract method to be overridden by derived classes for saving/loading
    public abstract string GetStringRepresentation();
}