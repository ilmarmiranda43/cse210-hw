using System;

public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base(
            "Breathing Activity",
            "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    { }

    protected override void PerformActivity()
    {
        int duration = GetDurationSeconds();
        
        DateTime end = DateTime.Now.AddSeconds(duration);

        while (DateTime.Now < end)
        {
            Console.Write("\nBreathe in... ");
            ShowCountdown(4);

            if (DateTime.Now >= end) break;

            Console.Write("\nBreathe out... ");
            ShowCountdown(4);
        }

        Console.WriteLine();
    }
}
