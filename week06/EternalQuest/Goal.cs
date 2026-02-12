using System;

public abstract class Goal
{
    private string _shortName;
    private string _description;
    private int _points;
    protected bool _isComplete;

    protected Goal(string shortName, string description, int points)
    {
        _shortName = shortName;
        _description = description;
        _points = points;
        _isComplete = false;
    }

    public string GetName() => _shortName;
    public string GetDescription() => _description;
    public int GetPoints() => _points;

    public virtual bool IsComplete() => _isComplete;

    public abstract int RecordEvent();

    public virtual string GetDetailsString()
    {
        string checkbox = IsComplete() ? "[X]" : "[ ]";
        return $"{checkbox} {_shortName} ({_description})";
    }

    public abstract string GetStringRepresentation();
}
