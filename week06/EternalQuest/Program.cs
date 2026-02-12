using System;

class Program
{
    static void Main(string[] args)
    {
        // EXCEEDING REQUIREMENTS:
        // 1) Added a simple Level system (Level increases every 1000 points and is shown with the score).
        // 2) Added an activity log saved to "activity_log.txt" (date/time, goal name, points earned, total score).
        // (The assignment asks to describe what you did to exceed requirements in a comment here.)
        // Source requirement: Week06 Develop - "Report on what you have done to exceed requirements by adding a description of it in a comment in the Program.cs file."
        // :contentReference[oaicite:2]{index=2}

        GoalManager manager = new GoalManager();
        manager.Start();
    }
}
