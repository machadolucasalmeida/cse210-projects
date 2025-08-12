using System;

// Derived class for Cycling activity
public class Cycling : Activity
{
    private double _speedKph; // Specific attribute for cycling

    public Cycling(DateTime date, int durationMinutes, double speedKph)
        : base(date, durationMinutes)
    {
        _speedKph = speedKph;
    }

    public override double GetDistance()
    {
        return (_speedKph * DurationMinutes) / 60;
    }

    public override double GetSpeed()
    {
        return _speedKph;
    }

    public override double GetPace()
    {
        if (_speedKph == 0) return 0; // Avoid division by zero
        return 60 / _speedKph;
    }
}