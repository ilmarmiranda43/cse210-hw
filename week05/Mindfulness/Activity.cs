using System;
using System.Threading;

public abstract class Activity
{
    private readonly string _name;
    private readonly string _description;
    private int _durationSeconds;

    protected Activity(string name, string description)
    {
        _name = name;
        _description = description;
        _durationSeconds = 0;
    }

    public void Run()
    {
        Console.Clear();
        StartMessage();
        PrepareToBegin();
        PerformActivity();
        EndMessage();
    }

    protected abstract void PerformActivity();

    protected int GetDurationSeconds() => _durationSeconds;

    private void StartMessage()
    {
        Console.WriteLine($"Welcome to the {_name}.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();

        _durationSeconds = ReadPositiveInt("How long, in seconds, would you like for your session? ");
        Console.WriteLine();
    }

    private void PrepareToBegin()
    {
        Console.WriteLine("Get ready...");
        ShowSpinner(3);
        Console.WriteLine();
    }

    private void EndMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!!");
        ShowSpinner(3);
        Console.WriteLine();
        Console.WriteLine($"You have completed another {_durationSeconds} seconds of the {_name}.");
        ShowSpinner(4);
    }

    protected void ShowSpinner(int seconds)
    {
        string[] frames = { "|", "/", "-", "\\" };
        DateTime end = DateTime.Now.AddSeconds(seconds);
        int i = 0;

        while (DateTime.Now < end)
        {
            Console.Write(frames[i % frames.Length]);
            Thread.Sleep(200);
            Console.Write("\b \b");
            i++;
        }
    }

    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i >= 1; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    protected static int ReadPositiveInt(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine()?.Trim() ?? "";

            if (int.TryParse(input, out int value) && value > 0)
                return value;

            Console.WriteLine("Please enter a whole number greater than 0.");
        }
    }
}
