public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random = new Random();


    public int TotalWords => _words.Count;


    public string ReferenceText => _reference.GetDisplayText();


    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();


        // Simple split by spaces
        string[] parts = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        foreach (string part in parts)
            _words.Add(new Word(part));
    }


    public void HideRandomWords(int numberToHide)
    {
        // Stretch: select only visible words
        List<int> visibleIndexes = new List<int>();
        for (int i = 0; i < _words.Count; i++)
        {
            if (!_words[i].IsHidden())
                visibleIndexes.Add(i);
        }


        if (visibleIndexes.Count == 0) return;


        int toHide = Math.Min(numberToHide, visibleIndexes.Count);


        for (int i = 0; i < toHide; i++)
        {
            int pickIndex = _random.Next(visibleIndexes.Count);
            int wordIndex = visibleIndexes[pickIndex];


            _words[wordIndex].Hide();
            visibleIndexes.RemoveAt(pickIndex); // avoid repeats
        }
    }


    public string GetDisplayText()
    {
        string refText = _reference.GetDisplayText();
        string body = string.Join(" ", _words.Select(w => w.GetDisplayText()));
        return $"{refText} - {body}";
    }


    public bool IsCompletelyHidden()
    {
        return _words.All(w => w.IsHidden());
    }


    public Scripture Clone()
    {
        // Reference is immutable enough for this project; copy words
        // Rebuild scripture from displayed original words (keeping punctuation)
        // Better approach: clone the list of Word directly.
        Scripture clone = new Scripture(_reference, string.Join(" ", _words.Select(w => w.GetDisplayText().Replace("_", ""))));
        // The above line is not ideal for preserving hidden state, so we overwrite:
        clone._words = _words.Select(w => w.Clone()).ToList();
        return clone;
    }
}