using System;
using System.Collections.Generic;

public class Video
{
    private readonly string _title;
    private readonly string _author;
    private readonly int _lengthSeconds;

    private readonly List<Comment> _comments = new();

    public Video(string title, string author, int lengthSeconds)
    {
        _title = title ?? "";
        _author = author ?? "";
        _lengthSeconds = lengthSeconds < 0 ? 0 : lengthSeconds;
    }

    public string Title => _title;
    public string Author => _author;
    public int LengthSeconds => _lengthSeconds;

    public void AddComment(string userName, string message)
    {
        _comments.Add(new Comment(userName, message));
    }

    public int GetNumberOfComments() => _comments.Count;

    public IReadOnlyList<Comment> GetComments() => _comments;

    public IEnumerable<Comment> Comments()
    {
        foreach (var c in _comments)
        {
            yield return c;
        }
    }

    public override string ToString()
    {
        return $"{_title} | by {_author} | {_lengthSeconds}s | Comments: {GetNumberOfComments()}";
    }
}
