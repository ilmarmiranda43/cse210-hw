public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry) => _entries.Add(newEntry);

    public void DisplayAll()
    {
        foreach (Entry en in _entries)
            en.Display();
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter outPutFile = new StreamWriter(filename))
        {
            foreach (Entry en in _entries)
                outPutFile.WriteLine($"{en.Date}|{en.Time}|{en.PromptText}|{en.EntryText}|{en.Mood}|{en.Tags}");
        }
    }

    public void LoadFromFile(string filename)
    {
        _entries.Clear();
        string[] lines = File.ReadAllLines(filename);

        foreach (string line in lines)
        {
            string[] parts = line.Split('|');
            if (parts.Length < 3) continue;

            Entry e = new Entry();
            e.Date = parts[0];
            e.Time = parts[1];
            e.PromptText = parts[2];
            e.EntryText = parts[3];
            e.Mood = parts[4];
            e.Tags = parts[5];
            _entries.Add(e);

        }
    }

    public void Search(string keyword)
    {
        if (string.IsNullOrWhiteSpace(keyword))
        {
            Console.WriteLine("Type a keyword to search.");
            return;
        }

        int found = 0;
        foreach (var e in _entries)
        {
            if ((e.EntryText ?? "").Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                (e.PromptText ?? "").Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                (e.Tags ?? "").Contains(keyword, StringComparison.OrdinalIgnoreCase))
            {
                e.Display();
                Console.WriteLine();
                found++;
            }
        }

        Console.WriteLine($"Found: {found}");
    }

    public void ShowStats()
    {
        Console.WriteLine($"Total entries: {_entries.Count}");

        int totalWords = 0;
        foreach (var e in _entries)
        {
            totalWords += e.WordCount();
        }

        Console.WriteLine($"Total words: {totalWords}");
    }


}
