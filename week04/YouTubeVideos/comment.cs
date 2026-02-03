using System;

public class Comment
{
    private readonly string _userName;
    private readonly string _message;

    public Comment(string userName, string message)
    {
        _userName = userName ?? "";
        _message = message ?? "";
    }

    public string UserName => _userName;
    public string Message => _message;

    public override string ToString()
    {
        return $"- {_userName}: {_message}";
    }
}
