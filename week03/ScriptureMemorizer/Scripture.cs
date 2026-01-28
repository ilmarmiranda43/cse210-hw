using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        _random = new Random();

        //split text to different words
        string[] parts = text.Split(' ');
        foreach (string part in parts)
        {
            _words.Add(new Word(part));
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        // Exceed requirement: choose only from words not yet hidden
        List<int> visibleIndexes = new List<int>();

        for (int i = 0; i < _words.Count; i++)
        {
            //if word is not hidden, add the word to visible list
            if (!_words[i].IsHidden())
            {
                visibleIndexes.Add(i);
            }
        }

        int hideCount = Math.Min(numberToHide, visibleIndexes.Count);

        //picks a a random visible word and hide it
        for (int i = 0; i < hideCount; i++)
        {
            int pick = _random.Next(visibleIndexes.Count);
            int wordIndex = visibleIndexes[pick];

            _words[wordIndex].Hide();

            // Remove so we don't pick the same word again this round
            visibleIndexes.RemoveAt(pick);
        }
    }

    public string GetDisplayText()
    {
        List<string> output = new List<string>();

        foreach (Word w in _words)
        {
            output.Add(w.GetDisplayText());
        }

        return $"{_reference.GetDisplayText()} : \n{string.Join(" ", output)}";
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word w in _words)
        {
            if (!w.IsHidden())
            {
                return false;
            }
        }

        return true;
    }
}