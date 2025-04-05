using System;
using System.Collections.Generic;

class Comment
{
    public string Name { get; set; }
    public string Text { get; set; }

    public Comment(string name, string text)
    {
        Name = name;
        Text = text;
    }

    public override string ToString()
    {
        return $"{Name}: {Text}";
    }
}

class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set; }
    private List<Comment> Comments { get; set; }

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        Comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return Comments.Count;
    }

    public void DisplayVideoInfo()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Length: {Length} seconds");
        Console.WriteLine($"Number of Comments: {GetCommentCount()}");
        
        Console.WriteLine("Comments:");
        if (Comments.Count == 0)
        {
            Console.WriteLine("- No comments yet.");
        }
        else
        {
            foreach (var comment in Comments)
            {
                Console.WriteLine($"- {comment}");
            }
        }
        Console.WriteLine();
    }
}

class Program
{
    static void Main()
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("Intro to Graphic Design", "Leah Loranger", 300);
        video1.AddComment(new Comment("Shelly", "Great video!"));
        video1.AddComment(new Comment("Steve", "Very helpful, thanks!"));
        video1.AddComment(new Comment("Sheri", "I learned a lot!"));
        
        Video video2 = new Video("Tutorial on Sewing", "Jane Smith", 600);
        video2.AddComment(new Comment("David", "Awesome explanation!"));
        video2.AddComment(new Comment("Emily", "Best tutorial ever!"));
        video2.AddComment(new Comment("Scott", "Keep up the good work!"));
        
        Video video3 = new Video("Cooking Lessons", "Sarah Roberts", 450);
        video3.AddComment(new Comment("Paige", "Very clear instructions!"));
        video3.AddComment(new Comment("Ethan", "Love the food!"));
        video3.AddComment(new Comment("Emma", "Very well explained!"));

        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        foreach (var video in videos)
        {
            video.DisplayVideoInfo();
        }
    }
}
