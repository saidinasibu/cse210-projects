public class Video
{
    private string _title = "";
    private string _author = "";
    private int _length = 0;
    private List<Comment> _comments;

    public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _length = length;
        _comments = new List<Comment>();
    }
    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }
    public void Display()
    {
        Console.WriteLine($"Title: {_title}\nChannel: {_author}\nLength: {_length} seconds\nNumber of comments: {_comments.Count}\n");

        if (_comments.Count > 0)
        {
            Console.WriteLine("Comments:");
            foreach (Comment comment in _comments)
            {
                Console.WriteLine(comment.Display());
            }
        }
        Console.WriteLine("---------------------");
    }
}