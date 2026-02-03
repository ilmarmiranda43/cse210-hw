using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {

        List<Video> videos = CreateSampleVideos();

        Console.WriteLine("=== Video Library ===\n");

        foreach (Video video in videos)
        {
            DisplayVideo(video);
            Console.WriteLine(new string('-', 45));
        }
    }

    private static List<Video> CreateSampleVideos()
    {
        Video video1 = new Video("C# Basics Explained", "CodeLearner", 180);
        video1.AddComment("Alice", "This explanation was very clear.");
        video1.AddComment("Brian", "I finally understand abstraction now.");
        video1.AddComment("Clara", "Great example using separate classes.");

        Video video2 = new Video("Understanding Lists in C#", "DevAcademy", 240);
        video2.AddComment("Daniel", "The foreach loop example helped a lot.");
        video2.AddComment("Emma", "Simple and easy to follow.");
        video2.AddComment("Frank", "Perfect for beginners.");

        Video video3 = new Video("Object-Oriented Design Tips", "SoftwareMentor", 300);
        video3.AddComment("Grace", "I like how responsibilities are separated.");
        video3.AddComment("Henry", "Good reminder about encapsulation.");
        video3.AddComment("Isabella", "Very useful for this week's assignment.");

        return new List<Video> { video1, video2, video3 };
    }

    private static void DisplayVideo(Video video)
    {
        Console.WriteLine(video.ToString());
        Console.WriteLine("Comments:");
        
        foreach (Comment comment in video.Comments())
        {
            Console.WriteLine(comment.ToString());
        }
    }
}
