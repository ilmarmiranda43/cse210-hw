using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private readonly List<string> _prompts = new()
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    private readonly Random _rng = new();

    public ListingActivity()
        : base(
            "Listing Activity",
            "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    { }

    protected override void PerformActivity()
    {
        string prompt = _prompts[_rng.Next(_prompts.Count)];

        Console.WriteLine("List as many responses you can to the following prompt:");
        Console.WriteLine($"--- {prompt} ---");
        Console.WriteLine();
        Console.Write("You may begin in: ");
        ShowCountdown(5);
        Console.WriteLine();

        int duration = GetDurationSeconds();
        DateTime end = DateTime.Now.AddSeconds(duration);

        List<string> items = new();

        while (DateTime.Now < end)
        {
            Console.Write("> ");
            string entry = Console.ReadLine() ?? "";
            if (!string.IsNullOrWhiteSpace(entry))
                items.Add(entry.Trim());
        }

        Console.WriteLine();
        Console.WriteLine($"You listed {items.Count} items!");
    }
}
