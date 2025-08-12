using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Fitness Activity Tracker 🏋️‍♀️");
        Console.WriteLine("-----------------------------");

        // Create instances of each activity type
        Running run1 = new Running(new DateTime(2023, 11, 3), 30, 4.8); 
        Cycling cycle1 = new Cycling(new DateTime(2023, 11, 4), 45, 25.0); 
        Swimming swim1 = new Swimming(new DateTime(2023, 11, 5), 20, 40); 

        List<Activity> activities = new List<Activity>
        {
            run1,
            cycle1,
            swim1
        };

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }

        Console.WriteLine("\nProgram finished. Press any key to exit.");
        Console.ReadKey();
    }
}