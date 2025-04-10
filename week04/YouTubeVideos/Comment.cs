public class Comment
{
    private string _name = "";
    private string _text = "";

    public Comment(string name, string text)
    {
        _name = name;
        _text = text;
    }

    public string Display()
    {
        string comment;
        comment = ($"\nName: {_name}\nComment: {_text}\n");

        return comment;
    }
}