class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points)
        : base(name, description, points)
    {

    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override void RecordEvent()
    {
        if (!_isComplete)
        {
            _isComplete = true;
        }
    }


    public override string GetStringRepresentation()
    {
        return $"SimpleGoal|{ShortName}|{Description}|{Points}|{_isComplete}";
    }

    public override string GetDetailsString()
    {
        return $"[{(_isComplete ? "X" : " ")}] {ShortName} - {Description}";
    }
}