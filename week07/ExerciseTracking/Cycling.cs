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
        // distance = speed * hours
        double hours = GetMinutes() / 60.0;
        return GetSpeed() * hours;
    }

    public override double GetPace()
    {
        // pace = 60 / speed  (min per km)
        return 60.0 / GetSpeed();
    }
}
