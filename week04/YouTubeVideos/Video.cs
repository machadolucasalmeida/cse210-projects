using System.Collections.Generic;

public class Video
{
    public string _title;
    public string _author;
    public int _lengthInSeconds; 
    public List<Comment> _comments;

    public Video(string title, string author, int lengthInSeconds)
    {
        _title = title;
        _author = author;
        _lengthInSeconds = lengthInSeconds;
        _comments = new List<Comment>(); 
    }

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return _comments.Count;
    }
    public void DisplayVideoDetails()
    {
        Console.WriteLine($"--- Video Details ---");
        Console.WriteLine($"Title: {_title}");
        Console.WriteLine($"Author: {_author}");
        Console.WriteLine($"Length: {_lengthInSeconds} seconds");
        Console.WriteLine($"Number of Comments: {GetNumberOfComments()}");
        Console.WriteLine("Comments:");

        if (_comments.Count == 0)
        {
            Console.WriteLine("    No comments yet.");
        }
        else
        {
            foreach (Comment comment in _comments)
            {
                comment.DisplayComment();
            }
        }
        Console.WriteLine(); 
    }
}