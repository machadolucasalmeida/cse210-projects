using System;

public class Running : Activity
{
    private double _distanceKm; 

    public Running(DateTime date, int durationMinutes, double distanceKm)
        : base(date, durationMinutes)
    {
        _distanceKm = distanceKm;
    }

    public override double GetDistance()
    {
        return _distanceKm;
    }

    public override double GetSpeed()
    {
        if (DurationMinutes == 0) return 0; // Avoid division by zero
        return (_distanceKm / DurationMinutes) * 60;
    }
    
    public override double GetPace()
    {
        if (_distanceKm == 0) return 0; // Avoid division by zero
        return DurationMinutes / _distanceKm;
    }
}