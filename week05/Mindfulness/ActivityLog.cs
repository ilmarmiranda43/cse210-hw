using System;
using System.IO;

public static class ActivityLog
{
    private const string FileName = "log.txt";

    public static void Write(string activityName, int durationSeconds)
    {
        string line = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | {activityName} | {durationSeconds}s";
        File.AppendAllText(FileName, line + Environment.NewLine);
    }
}
