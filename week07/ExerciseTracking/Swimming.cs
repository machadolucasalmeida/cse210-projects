using System;

public class Swimming : Activity
{
    private int _numberOfLaps; // Specific attribute for swimming
    private const double LapLengthMeters = 50; // Length of one lap in meters

    public Swimming(DateTime date, int durationMinutes, int numberOfLaps)
        : base(date, durationMinutes)
    {
        _numberOfLaps = numberOfLaps;
    }

    public override double GetDistance()
    {
        return (_numberOfLaps * LapLengthMeters) / 1000;
    }

    public override double GetSpeed()
    {
        double distanceKm = GetDistance(); 
        if (DurationMinutes == 0) return 0; // Avoid division by zero
        return (distanceKm / DurationMinutes) * 60;
    }

    // Override GetPace: minutes / distance
    public override double GetPace()
    {
        double distanceKm = GetDistance(); 
        if (distanceKm == 0) return 0; // Avoid division by zero
        return DurationMinutes / distanceKm;
    }
}