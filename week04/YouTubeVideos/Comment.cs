public class Comment
{
    public string _commenterName;
    public string _commentText;
    public Comment(string commenterName, string commentText)
    {
        _commenterName = commenterName;
        _commentText = commentText;
    }
    public void DisplayComment()
    {
        Console.WriteLine($"    Name: {_commenterName}");
        Console.WriteLine($"    Comment: \"{_commentText}\"");
    }
}