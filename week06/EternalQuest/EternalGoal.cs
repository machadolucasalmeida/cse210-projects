using System;

public class EternalGoal : Goal
{
    // Constructor for creating a new EternalGoal
    public EternalGoal(string name, string description, int points) : base(name, description, points)
    {
        // No specific member variables for EternalGoal beyond the base Goal properties
    }

    // Constructor for loading an EternalGoal from file (no specific state to load for this type)
    public EternalGoal(string name, string description, int points, int currentCount) : base(name, description, points)
    {
        // _currentCount is not used directly in EternalGoal's state, but included for consistency
        // with how other goal types might be loaded, even if it's discarded or ignored here.
        // For EternalGoal, the important part is just the name, description, and points.
    }

    // Override RecordEvent: always gives points and prints a message
    public override int RecordEvent()
    {
        Console.WriteLine($"\nWell done! You have recorded '{_shortName}' and earned {_points} points!");
        return _points;
    }

    // Override GetDetailsString: no completion status for eternal goals
    public override string GetDetailsString()
    {
        return $"[ ] {_shortName} ({_description})"; // Still shows [] as it's never "complete"
    }

    // Override GetStringRepresentation for saving/loading
    public override string GetStringRepresentation()
    {
        // Format: EternalGoal:name,description,points
        return $"EternalGoal:{_shortName},{_description},{_points}";
    }
}