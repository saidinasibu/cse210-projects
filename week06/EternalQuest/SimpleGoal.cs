class SimpleGoal : Goal
{
    private bool _iscomplete;

    public SimpleGoal(string name, string description, string points) : base(name, description, points)
    {
        _iscomplete = false;
    }

    public override void RecordEvent()
    {
        _iscomplete = true;
    }
    public override bool IsComplete()
    {
        return _iscomplete;
    }
    public override string GetStringRepresentation()
    {
        string text = $"SimpleGoal:{base.GetName()}-{base.GetDescription()}-{base.GetPoints()}-{IsComplete()}";
        return text;
    }
}