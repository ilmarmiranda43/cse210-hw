using System;

public class Assignment
{
    private readonly string _studentName;
    private readonly string _topic;

    public Assignment(string studentName, string topic)
    {
        _studentName = string.IsNullOrWhiteSpace(studentName) ? "Unknown Student" : studentName.Trim();
        _topic = string.IsNullOrWhiteSpace(topic) ? "General Topic" : topic.Trim();
    }

    protected string StudentName => _studentName;
    protected string Topic => _topic;

    public string GetStudentName() => _studentName;
    public string GetTopic() => _topic;

    public virtual string GetSummary() => $"{_studentName} - {_topic}";
}
