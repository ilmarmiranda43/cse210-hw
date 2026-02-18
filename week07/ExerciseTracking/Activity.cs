using System;

public abstract class Activity
{
    private DateTime _date;
    private int _minutes;

    protected Activity(DateTime date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    protected int GetMinutes() => _minutes;
    
    public abstract double GetDistance(); // km
    public abstract double GetSpeed();    // kph
    public abstract double GetPace();     // min per km

    public virtual string GetSummary()
    {
        string dateText = _date.ToString("dd MMM yyyy");
        string name = GetType().Name;

        double distance = GetDistance();
        double speed = GetSpeed();
        double pace = GetPace();

        return $"{dateText} {name} ({_minutes} min) - " +
               $"Distance {distance:0.0} km, Speed {speed:0.0} kph, Pace: {pace:0.00} min per km";
    }
}
