public class MathAssignment : Assignment
{
    private readonly string _section;
    private readonly string _problems;

    public MathAssignment(string studentName, string topic, string section, string problems)
        : base(studentName, topic)
    {
        _section = string.IsNullOrWhiteSpace(section) ? "N/A" : section.Trim();
        _problems = string.IsNullOrWhiteSpace(problems) ? "N/A" : problems.Trim();
    }

    public string GetHomeworkList() => $"Section {_section} | Problems: {_problems}";

    // (opcional) deixa seu output diferente sem quebrar requisito
    public override string GetSummary() => $"{GetStudentName()} - {GetTopic()} (Math)";
}
