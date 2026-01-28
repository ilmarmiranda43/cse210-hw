using System;

public class Reference
{
    private string _book;
    private int _chapter;

    // For single verse
    private int _verse;

    // For verse range
    private int _startVerse;
    private int _endVerse;

 
    public Reference()
    {
        _book = "";
        _chapter = 0;
        _verse = 0;
        _startVerse = 0;
        _endVerse = 0;
    }

    // Single verse: "John 3:16"
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;

        _startVerse = 0;
        _endVerse = 0;
    }

    // Verse range: "Proverbs 3:5-6"
    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = endVerse;

        _verse = 0;
    }

    public string GetDisplayText()
    {
        //multiple verse
        if (_endVerse > 0)
        {
            return $"{_book} {_chapter}:{_startVerse}-{_endVerse}";
        }

        // single verse
        return $"{_book} {_chapter}:{_verse}";
    }
}