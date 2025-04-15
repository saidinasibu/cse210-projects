public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, string points) : base(name, description, points)
    {
    }

    public override void RecordEvent()
    {
    }
    public override bool IsComplete()
    {
        return false;
    }
    public override string GetStringRepresentation()
    {
        string text = $"EternalGoal:{base.GetName()}-{base.GetDescription()}-{base.GetPoints()}";
        return text;
    }
}