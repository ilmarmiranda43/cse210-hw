using System;

public class Cycling : Activity
{
    private double _speedKph;

    public Cycling(DateTime date, int minutes, double speedKph)
        : base(date, minutes)
    {
        _speedKph = speedKph;
    }

    public override double GetSpeed() => _speedKph;

    public override double GetDistance()
    {
        
        double hours = GetMinutes() / 60.0;
        return GetSpeed() * hours;
    }

    public override double GetPace()
    {
        
        return 60.0 / GetSpeed();
    }
}
