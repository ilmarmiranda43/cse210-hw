using System;

public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(
        string shortName,
        string description,
        int points,
        int bonus,
        int target,
        int amountCompleted = 0,
        bool isComplete = false
    ) : base(shortName, description, points)
    {
        _bonus = bonus;
        _target = target;
        _amountCompleted = amountCompleted;
        _isComplete = isComplete;
    }

    public override int RecordEvent()
    {
        if (_isComplete)
        {
            return 0;
        }

        _amountCompleted++;

        int earned = GetPoints();

        if (_amountCompleted >= _target)
        {
            _isComplete = true;
            earned += _bonus;
        }

        return earned;
    }

    public override string GetDetailsString()
    {
        string checkbox = IsComplete() ? "[X]" : "[ ]";
        return $"{checkbox} {GetName()} ({GetDescription()}) -- Completed {_amountCompleted}/{_target} times";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{GetName()},{GetDescription()},{GetPoints()},{_bonus},{_target},{_amountCompleted},{IsComplete()}";
    }
}
