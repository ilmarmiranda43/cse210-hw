public class WritingAssignment : Assignment
{
    private readonly string _title;

    public WritingAssignment(string studentName, string topic, string title)
        : base(studentName, topic)
    {
        _title = string.IsNullOrWhiteSpace(title) ? "Untitled" : title.Trim();
    }

    public string GetWritingInformation() => $"\"{_title}\" by {GetStudentName()}";

    // (opcional) deixa seu output mais “personal”
    public override string GetSummary() => $"{GetStudentName()} - {GetTopic()} (Writing)";
}
