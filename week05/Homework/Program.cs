using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.Clear();
        Console.WriteLine("Homework Tracker\n");

        var activities = new List<Assignment>
        {
            new Assignment("Ilmar Miranda", "Calculus"),
            new MathAssignment("Ilmar Miranda", "Trigonometry", "5.3", "1-4, 7, 12"),
            new WritingAssignment("Ilmar Miranda", "Friendship", "Eternal Friendship")
        };

        foreach (var item in activities)
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine(item.GetSummary());

            if (item is MathAssignment math)
            {
                Console.WriteLine(math.GetHomeworkList());
            }
            else if (item is WritingAssignment writing)
            {
                Console.WriteLine(writing.GetWritingInformation());
            }
        }

        Console.WriteLine("--------------------------------");
        Console.WriteLine("\nPress Enter to exit...");
        Console.ReadLine();
    }
}
