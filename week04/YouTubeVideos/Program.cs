using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Create a list to store videos
        List<Video> videos = new List<Video>();

        // Video 1
        Video video1 = new Video("Introduction to C#", "CodeAcademy", 600);
        video1.AddComment(new Comment("Alice", "Great tutorial!"));
        video1.AddComment(new Comment("Bob", "Very informative."));
        video1.AddComment(new Comment("Charlie", "I learned a lot, thanks!"));

        // Video 2
        Video video2 = new Video("Understanding Object-Oriented Programming", "Tech Guru", 750);
        video2.AddComment(new Comment("Dave", "OOP concepts are finally making sense."));
        video2.AddComment(new Comment("Eve", "Good examples!"));
        video2.AddComment(new Comment("Frank", "Well explained."));

        // Video 3
        Video video3 = new Video("Advanced C# LINQ Techniques", "Dev Master", 900);
        video3.AddComment(new Comment("Grace", "LINQ is so powerful!"));
        video3.AddComment(new Comment("Hank", "Can you do one on async programming?"));
        video3.AddComment(new Comment("Ivy", "Thanks for the tips!"));

        // Add videos to list
        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        // Display each video with its comments
        foreach (var video in videos)
        {
            video.Display();
        }
    }
}

// Comment Class
class Comment
{
    public string Commenter { get; private set; }
    public string Text { get; private set; }

    public Comment(string commenter, string text)
    {
        Commenter = commenter;
        Text = text;
    }

    public void Display()
    {
        Console.WriteLine($"- {Commenter}: {Text}");
    }
}

// Video Class
class Video
{
    public string Title { get; private set; }
    public string Author { get; private set; }
    public int Length { get; private set; } // in seconds
    private List<Comment> comments;

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return comments.Count;
    }

    public void Display()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Length: {Length} seconds");
        Console.WriteLine($"Comments ({GetCommentCount()}):");
        foreach (var comment in comments)
        {
            comment.Display();
        }
        Console.WriteLine(new string('-', 40)); // Separator for clarity
    }
}
