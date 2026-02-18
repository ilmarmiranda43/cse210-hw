using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Activity> activities = new List<Activity>();

        activities.Add(new Running(new DateTime(2022, 11, 3), 30, 4.8));   // 4.8 km
        activities.Add(new Cycling(new DateTime(2022, 11, 3), 45, 18.5));  // 18.5 kph
        activities.Add(new Swimming(new DateTime(2022, 11, 3), 25, 30));   // 30 laps

        foreach (Activity a in activities)
        {
            Console.WriteLine(a.GetSummary());
        }
    }
}
