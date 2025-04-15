using System.Diagnostics;
using System.Dynamic;
public abstract class Goal
{
    private string _shortName;
    private string _description;
    private string _points;

    public Goal(string name, string description, string points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }
    public string GetName()
    {
        return _shortName;
    }
    public string GetDescription()
    {
        return _description;
    }
    public string GetPoints()
    {
        return _points;
    }
    public void SetPoints(string points)
    {
        _points = points;
    }
    public abstract void RecordEvent();

    public abstract bool IsComplete();

    public abstract string GetStringRepresentation();

    public virtual string GetDetailsString()
    {
        string complete = " ";
        bool isComplete = IsComplete();
        if (isComplete == true) { complete = "x"; }
        string text = $"[{complete}] {_shortName} ({_description}) ";
        return text;
    }
}