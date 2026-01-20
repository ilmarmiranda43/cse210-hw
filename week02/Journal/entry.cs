using System;

public class Entry
{
    // private fields (underscoreCamelCase)
    private string _date;
    private string _time;
    private string _promptText;
    private string _entryText;
    private string _mood;
    private string _tags;

    // public properties (PascalCase)
    public string Date { get => _date; set => _date = value; }
    public string Time { get => _time; set => _time = value; }
    public string PromptText { get => _promptText; set => _promptText = value; }
    public string EntryText { get => _entryText; set => _entryText = value; }
    public string Mood { get => _mood; set => _mood = value; }
    public string Tags { get => _tags; set => _tags = value; }

    public Entry()
    {
        _date = DateTime.Now.ToShortDateString();
        _time = DateTime.Now.ToString("HH:mm");
        _mood = "";
        _tags = "";
    }

    public int WordCount()
    {
        if (string.IsNullOrWhiteSpace(_entryText)) return 0;
        return _entryText.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length;
    }

    public void Display()
    {
        Console.WriteLine($"{_date} {_time}: {_promptText}");
        if (!string.IsNullOrWhiteSpace(_mood))
            Console.WriteLine($"Mood: {_mood}");
        if (!string.IsNullOrWhiteSpace(_tags))
            Console.WriteLine($"Tags: {_tags}");
        Console.WriteLine(_entryText);
        Console.WriteLine($"(Words: {WordCount()})");
    }
}
