using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    private int _level = 1;
    private const int PointsPerLevel = 1000;

    private const string ActivityLogFile = "activity_log.txt";

    public void Start()
    {
        while (true)
        {
            Console.Clear();
            DisplayPlayerInfo();
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine()?.Trim() ?? "";

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoalDetails();
                    Pause();
                    break;
                case "3":
                    SaveGoals();
                    Pause();
                    break;
                case "4":
                    LoadGoals();
                    Pause();
                    break;
                case "5":
                    RecordEvent();
                    Pause();
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Invalid option.");
                    Pause();
                    break;
            }
        }
    }

    private void DisplayPlayerInfo()
    {
        UpdateLevelFromScore();
        Console.WriteLine($"You have {_score} points. (Level {_level})");
    }

    private void UpdateLevelFromScore()
    {
        _level = Math.Max(1, (_score / PointsPerLevel) + 1);
    }

    private void CreateGoal()
    {
        Console.Clear();
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");

        string type = Console.ReadLine()?.Trim() ?? "";

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine() ?? "";

        Console.Write("What is a short description of it? ");
        string desc = Console.ReadLine() ?? "";

        int points = ReadInt("What is the amount of points associated with this goal? ");

        if (type == "1")
        {
            _goals.Add(new SimpleGoal(name, desc, points));
        }
        else if (type == "2")
        {
            _goals.Add(new EternalGoal(name, desc, points));
        }
        else if (type == "3")
        {
            int target = ReadInt("How many times does this goal need to be accomplished for a bonus? ");
            int bonus = ReadInt("What is the bonus for accomplishing it that many times? ");
            _goals.Add(new ChecklistGoal(name, desc, points, bonus, target));
        }
        else
        {
            Console.WriteLine("Invalid goal type.");
        }
    }

    private void ListGoalDetails()
    {
        Console.Clear();
        Console.WriteLine("Your Goals are:");

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }

        if (_goals.Count == 0)
        {
            Console.WriteLine("(No goals created yet)");
        }
    }

    private void RecordEvent()
    {
        Console.Clear();

        if (_goals.Count == 0)
        {
            Console.WriteLine("You have no goals to record yet.");
            return;
        }

        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetName()}");
        }

        int idx = ReadInt("Which goal did you accomplish? ") - 1;
        if (idx < 0 || idx >= _goals.Count)
        {
            Console.WriteLine("Invalid goal number.");
            return;
        }

        Goal goal = _goals[idx];
        int earned = goal.RecordEvent();

        if (earned <= 0)
        {
            Console.WriteLine("No points earned (goal may already be completed).");
            AppendToLog(goal.GetName(), 0);
            return;
        }

        _score += earned;
        UpdateLevelFromScore();

        Console.WriteLine($"Congratulations! You have earned {earned} points!");
        Console.WriteLine($"You now have {_score} points. (Level {_level})");

        AppendToLog(goal.GetName(), earned);
    }

    private void SaveGoals()
    {
        Console.Clear();
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine() ?? "goals.txt";

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);

            foreach (Goal g in _goals)
            {
                outputFile.WriteLine(g.GetStringRepresentation());
            }
        }

        Console.WriteLine($"Saved to {filename}");
    }

    private void LoadGoals()
    {
        Console.Clear();
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine() ?? "goals.txt";

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        string[] lines = File.ReadAllLines(filename);

        _goals.Clear();
        _score = 0;

        if (lines.Length == 0)
        {
            Console.WriteLine("File is empty.");
            return;
        }

        if (!int.TryParse(lines[0].Trim(), out _score))
        {
            _score = 0;
        }

        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i].Trim();
            if (string.IsNullOrWhiteSpace(line)) continue;

            string[] parts = line.Split(':', 2);
            if (parts.Length != 2) continue;

            string type = parts[0];
            string data = parts[1];

            string[] fields = data.Split(',');

            try
            {
                if (type == "SimpleGoal")
                {
                    string name = fields[0];
                    string desc = fields[1];
                    int points = int.Parse(fields[2]);
                    bool complete = bool.Parse(fields[3]);
                    _goals.Add(new SimpleGoal(name, desc, points, complete));
                }
                else if (type == "EternalGoal")
                {
                    string name = fields[0];
                    string desc = fields[1];
                    int points = int.Parse(fields[2]);
                    _goals.Add(new EternalGoal(name, desc, points));
                }
                else if (type == "ChecklistGoal")
                {
                    string name = fields[0];
                    string desc = fields[1];
                    int points = int.Parse(fields[2]);
                    int bonus = int.Parse(fields[3]);
                    int target = int.Parse(fields[4]);
                    int amount = int.Parse(fields[5]);
                    bool complete = bool.Parse(fields[6]);

                    _goals.Add(new ChecklistGoal(name, desc, points, bonus, target, amount, complete));
                }
            }
            catch
            {
                
            }
        }

        UpdateLevelFromScore();
        Console.WriteLine($"Loaded from {filename}");
    }

    private static int ReadInt(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine() ?? "";
            if (int.TryParse(input.Trim(), out int value))
                return value;

            Console.WriteLine("Please enter a valid integer.");
        }
    }

    private static void Pause()
    {
        Console.WriteLine();
        Console.Write("Press Enter to continue...");
        Console.ReadLine();
    }

    private void AppendToLog(string goalName, int pointsEarned)
    {
        try
        {
            string line = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | Goal: {goalName} | Earned: {pointsEarned} | Total: {_score}";
            File.AppendAllLines(ActivityLogFile, new[] { line });
        }
        catch
        {
            
        }
    }
}
