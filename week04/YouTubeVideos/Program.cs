using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("Learning C#", "John Rockfeller", 300);
        video1.AddComment(new Comment("Alice", "Great video!"));
        video1.AddComment(new Comment("Bob", "Very informative."));
        video1.AddComment(new Comment("Julian","I have a question about the code."));

        Video video2 = new Video("Advanced C# Concepts", "Jane Junior", 450);
        video2.AddComment(new Comment("Charlie", "I have a question."));
        video2.AddComment(new Comment("Eve", "This was a bit too advanced for me."));
        video2.AddComment(new Comment("Frank", "Can you make a follow-up video on this topic?"));

        Video video3 = new Video("C# Best Practices", "Emily Expert", 600);
        video3.AddComment(new Comment("Dave", "Very helpful!"));
        video3.AddComment(new Comment("Grace", "I have a question about best practices."));
        video3.AddComment(new Comment("Heidi", "Thanks for sharing your expertise!"));

        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);
        
        foreach (Video video in videos)
        {
            video.DisplayVideoDetails();
        }
    }
}