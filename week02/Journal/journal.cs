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
        if (!filename.EndsWith(".txt"))
            filename += ".txt";

        using (StreamWriter outPutFile = new StreamWriter(filename))
        {
            foreach (Entry en in _entries)
                outPutFile.WriteLine($"{en._date}|{en._promptText}|{en._entryText}");
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
            e._date = parts[0];
            e._promptText = parts[1];
            e._entryText = parts[2];
            _entries.Add(e);
        }
    }
}
