using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals; // List to hold all goal objects
    private int _score;        // User's current score
    private int _level;        // Gamification: User's level
    private int _pointsToNextLevel; // Gamification: Points needed for next level

    // Constructor
    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
        _level = 1;
        _pointsToNextLevel = 1000; // Initial points to reach Level 2
    }

    // Display the current score and level
    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"\n--- Player Info ---");
        Console.WriteLine($"Current Score: {_score} points");
        Console.WriteLine($"Current Level: {_level}");
        if (_level < 10) // Example cap for levels for simplicity
        {
            Console.WriteLine($"Points to next level: {_pointsToNextLevel - _score} (Target: {_pointsToNextLevel})");
        }
        else
        {
            Console.WriteLine("You've reached the highest level!");
        }
        Console.WriteLine($"-------------------\n");
    }

    // Create a new goal based on user input
    public void CreateGoal()
    {
        Console.WriteLine("\nSelect the type of Goal to create:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Enter your choice: ");
        string choice = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, description, points));
                break;
            case "2":
                _goals.Add(new EternalGoal(name, description, points));
                break;
            case "3":
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("What is the bonus for accomplishing it that many times? ");
                int bonus = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                break;
            default:
                Console.WriteLine("Invalid goal type. Goal not created.");
                break;
        }
        Console.WriteLine("Goal created successfully!");
    }

    // List all goals with their details
    public void ListGoalDetails()
    {
        Console.WriteLine("\n--- Your Goals ---");
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals created yet.");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
        Console.WriteLine("------------------\n");
    }

    // Record an event for a chosen goal
    public void RecordEvent()
    {
        Console.WriteLine("\n--- Your Goals ---");
        ListGoalDetails(); // Show the list of goals for selection

        if (_goals.Count == 0)
        {
            return; // No goals to record events for
        }

        Console.Write("Which goal did you accomplish? (Enter the number) ");
        int goalIndex = int.Parse(Console.ReadLine()) - 1;

        if (goalIndex >= 0 && goalIndex < _goals.Count)
        {
            int pointsEarned = _goals[goalIndex].RecordEvent();
            _score += pointsEarned;
            CheckForLevelUp(); // Check if leveling up occurred
        }
        else
        {
            Console.WriteLine("Invalid goal number.");
        }
    }

    // Gamification: Check and handle level up
    private void CheckForLevelUp()
    {
        while (_score >= _pointsToNextLevel)
        {
            _level++;
            Console.WriteLine($"\n*** LEVEL UP! You reached Level {_level}! ***");
            // Increase points needed for next level, e.g., by 50%
            _pointsToNextLevel = (int)(_pointsToNextLevel * 1.5);
            // Optionally add a bonus when leveling up
            _score += 100; // Small bonus for leveling up
            Console.WriteLine($"You received 100 bonus points for leveling up! Your new score is {_score}.");
        }
    }

    // Save goals and score to a file
    public void SaveGoals()
    {
        Console.Write("Enter the filename to save goals (e.g., mygoals.txt): ");
        string filename = Console.ReadLine();

        try
        {
            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                // Save score and level info on the first line
                outputFile.WriteLine($"{_score},{_level},{_pointsToNextLevel}");

                // Save each goal's string representation
                foreach (Goal goal in _goals)
                {
                    outputFile.WriteLine(goal.GetStringRepresentation());
                }
            }
            Console.WriteLine($"\nGoals saved to {filename} successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while saving goals: {ex.Message}");
        }
    }

    // Load goals and score from a file
    public void LoadGoals()
    {
        Console.Write("Enter the filename to load goals from (e.g., mygoals.txt): ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine($"\nError: File '{filename}' not found.");
            return;
        }

        try
        {
            _goals.Clear(); // Clear current goals before loading new ones

            using (StreamReader inputFile = new StreamReader(filename))
            {
                // Read score and level info from the first line
                string scoreLine = inputFile.ReadLine();
                if (scoreLine != null)
                {
                    string[] scoreParts = scoreLine.Split(',');
                    if (scoreParts.Length == 3)
                    {
                        _score = int.Parse(scoreParts[0]);
                        _level = int.Parse(scoreParts[1]);
                        _pointsToNextLevel = int.Parse(scoreParts[2]);
                    }
                }

                string line;
                while ((line = inputFile.ReadLine()) != null)
                {
                    string[] parts = line.Split(':'); // Splits "GoalType:data,data,data"
                    string goalType = parts[0];
                    string[] goalData = parts[1].Split(','); // Splits "data,data,data"

                    switch (goalType)
                    {
                        case "SimpleGoal":
                            // SimpleGoal:name,description,points,isComplete
                            string sName = goalData[0];
                            string sDesc = goalData[1];
                            int sPoints = int.Parse(goalData[2]);
                            bool sIsComplete = bool.Parse(goalData[3]);
                            _goals.Add(new SimpleGoal(sName, sDesc, sPoints, sIsComplete));
                            break;
                        case "EternalGoal":
                            // EternalGoal:name,description,points
                            string eName = goalData[0];
                            string eDesc = goalData[1];
                            int ePoints = int.Parse(goalData[2]);
                            _goals.Add(new EternalGoal(eName, eDesc, ePoints, 0)); // 0 for currentCount as it's not applicable
                            break;
                        case "ChecklistGoal":
                            // ChecklistGoal:name,description,points,amountCompleted,target,bonus
                            string cName = goalData[0];
                            string cDesc = goalData[1];
                            int cPoints = int.Parse(goalData[2]);
                            int cAmountCompleted = int.Parse(goalData[3]);
                            int cTarget = int.Parse(goalData[4]);
                            int cBonus = int.Parse(goalData[5]);
                            _goals.Add(new ChecklistGoal(cName, cDesc, cPoints, cAmountCompleted, cTarget, cBonus));
                            break;
                        default:
                            Console.WriteLine($"Unknown goal type found: {goalType}");
                            break;
                    }
                }
            }
            Console.WriteLine($"\nGoals loaded from {filename} successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while loading goals: {ex.Message}");
        }
    }
}