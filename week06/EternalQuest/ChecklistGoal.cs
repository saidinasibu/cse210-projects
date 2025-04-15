class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public int Bonus => _bonus;
    public int AmountCompleted => _amountCompleted;

    public ChecklistGoal(string name, string description, int points, int target, int bonus)
        : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _amountCompleted = 0;
    }

    public override void RecordEvent()
    {
        _amountCompleted++;
    }

    public override bool IsComplete() => _amountCompleted >= _target;

    public override string GetDetailsString()
    {
        return $"[{(IsComplete() ? "X" : " ")}] {ShortName} - {Description} (Completed {_amountCompleted}/{_target})";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal|{ShortName}|{Description}|{Points}|{_amountCompleted}|{_target}|{_bonus}";
    }
}