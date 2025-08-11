using System;

public class SimpleGoal : Goal
{
    private bool _isComplete; // Specific to SimpleGoal: its completion status

    // Constructor for creating a new SimpleGoal
    public SimpleGoal(string name, string description, int points) : base(name, description, points)
    {
        _isComplete = false; // A new simple goal is always incomplete by default
    }

    // Constructor for loading a SimpleGoal from file
    public SimpleGoal(string name, string description, int points, bool isComplete) : base(name, description, points)
    {
        _isComplete = isComplete;
    }

    // Override RecordEvent: marks goal complete and returns points if not already complete
    public override int RecordEvent()
    {
        if (!_isComplete)
        {
            _isComplete = true;
            Console.WriteLine($"\nCongratulations! You have completed '{_shortName}' and earned {_points} points!");
            return _points;
        }
        else
        {
            Console.WriteLine($"\nYou have already completed '{_shortName}'. No new points awarded.");
            return 0;
        }
    }

    // Override GetDetailsString: shows completion status
    public override string GetDetailsString()
    {
        string checkbox = _isComplete ? "[X]" : "[ ]";
        return $"{checkbox} {_shortName} ({_description})";
    }

    // Override GetStringRepresentation for saving/loading
    public override string GetStringRepresentation()
    {
        // Format: SimpleGoal:name,description,points,isComplete
        return $"SimpleGoal:{_shortName},{_description},{_points},{_isComplete}";
    }
}