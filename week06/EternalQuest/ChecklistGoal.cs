using System;

public class ChecklistGoal : Goal
{
    private int _amountCompleted; // How many times the goal has been done
    private int _target;          // How many times it needs to be done
    private int _bonus;           // Bonus points for completing the target

    // Constructor for creating a new ChecklistGoal
    public ChecklistGoal(string name, string description, int points, int target, int bonus) : base(name, description, points)
    {
        _amountCompleted = 0; // Starts at 0
        _target = target;
        _bonus = bonus;
    }

    // Constructor for loading a ChecklistGoal from file
    public ChecklistGoal(string name, string description, int points, int amountCompleted, int target, int bonus) : base(name, description, points)
    {
        _amountCompleted = amountCompleted;
        _target = target;
        _bonus = bonus;
    }

    // Override RecordEvent: increments count, gives points, and bonus if target met
    public override int RecordEvent()
    {
        if (_amountCompleted < _target)
        {
            _amountCompleted++;
            int earnedPoints = _points;
            Console.WriteLine($"\nCongratulations! You have recorded '{_shortName}' and earned {_points} points!");

            if (_amountCompleted == _target)
            {
                earnedPoints += _bonus;
                Console.WriteLine($"You have completed '{_shortName}'! You earned a bonus of {_bonus} points!");
            }
            return earnedPoints;
        }
        else
        {
            Console.WriteLine($"\nYou have already completed '{_shortName}'. No new points awarded.");
            return 0;
        }
    }

    // Override GetDetailsString: shows progress and completion status
    public override string GetDetailsString()
    {
        string checkbox = _amountCompleted == _target ? "[X]" : "[ ]";
        return $"{checkbox} {_shortName} ({_description}) -- Currently completed: {_amountCompleted}/{_target}";
    }

    // Override GetStringRepresentation for saving/loading
    public override string GetStringRepresentation()
    {
        // Format: ChecklistGoal:name,description,points,amountCompleted,target,bonus
        return $"ChecklistGoal:{_shortName},{_description},{_points},{_amountCompleted},{_target},{_bonus}";
    }
}