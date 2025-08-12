using System;
using System.Globalization; 

public abstract class Activity
{
    private DateTime _date;
    private int _durationMinutes;

    public Activity(DateTime date, int durationMinutes)
    {
        _date = date;
        _durationMinutes = durationMinutes;
    }

    public DateTime Date => _date;
    public int DurationMinutes => _durationMinutes;

    public abstract double GetDistance(); 
    public abstract double GetSpeed();   
    public abstract double GetPace();     

    public virtual string GetSummary()
    {
        // Format date as "DD Mon YYYY" e.g., "03 Nov 2022"
        string formattedDate = _date.ToString("dd MMM yyyy", CultureInfo.InvariantCulture);

        // Access overridden methods dynamically (polymorphism)
        double distance = GetDistance();
        double speed = GetSpeed();
        double pace = GetPace();

        return $"{formattedDate} {GetType().Name} ({_durationMinutes} min): " +
               $"Distance {distance:F2} km, Speed: {speed:F2} kph, Pace: {pace:F2} min per km";
    }
}