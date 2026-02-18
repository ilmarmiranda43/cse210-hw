using System;

public class Running : Activity
{
    private double _distanceKm;

    public Running(DateTime date, int minutes, double distanceKm)
        : base(date, minutes)
    {
        _distanceKm = distanceKm;
    }

    public override double GetDistance() => _distanceKm;

    public override double GetSpeed()
    {
        // kph = (distance / minutes) * 60
        return (GetDistance() / GetMinutes()) * 60.0;
    }

    public override double GetPace()
    {
        // min per km = minutes / distance
        return GetMinutes() / GetDistance();
    }
}
