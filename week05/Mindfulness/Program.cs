using System;

// Exceeding Requirements:
// I added a logging feature that saves each completed activity (date/time, activity name, and duration in seconds)
// to a file named "log.txt".

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflection activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine()?.Trim() ?? "";

            Activity activity = choice switch
            {
                "1" => new BreathingActivity(),
                "2" => new ReflectionActivity(),
                "3" => new ListingActivity(),
                "4" => null,
                _ => new InvalidActivityChoice()
            };

            if (activity is null) break;

            if (activity is InvalidActivityChoice)
            {
                Console.WriteLine("\nInvalid option. Press Enter to try again...");
                Console.ReadLine();
                continue;
            }

            activity.Run();
        }
    }

    private sealed class InvalidActivityChoice : Activity
    {
        public InvalidActivityChoice()
            : base("Invalid", "Invalid") { }
        protected override void PerformActivity() { }
    }
}
