public class Word
{
    private string _text;
    private bool _isHidden;


    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }


    public void Hide() => _isHidden = true;
    public bool IsHidden() => _isHidden;


    public string GetDisplayText()
    {
        if (!_isHidden) return _text;


        // Keep same length (underscores)
        return new string('_', _text.Length);
    }


    public Word Clone()
    {
        Word copy = new Word(_text);
        if (_isHidden) copy.Hide();
        return copy;
    }
}