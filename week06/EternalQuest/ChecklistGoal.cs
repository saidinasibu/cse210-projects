class CheckListGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public CheckListGoal(string name, string description, string points, int target, int bonus) : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _amountCompleted = 0;
    }

    public void SetAmount(int ammount)
    {
        _amountCompleted = ammount;
    }
    public int GetTotalPoints()
    {
        int total = Convert.ToInt32(GetPoints());
        total += _bonus;
        return total;
    }
    public override void RecordEvent()
    {
        _amountCompleted++;

        if (IsComplete())
        {
            string totalPoints = Convert.ToString(GetTotalPoints());
            SetPoints(totalPoints);
            Console.WriteLine($"congratulation you have earned {totalPoints} points!");
        }
    }
    public override bool IsComplete()
    {
        bool complete = false;
        if (_amountCompleted == _target)
        {
            complete = true;
        }
        return complete;
    }
    public override string GetStringRepresentation()
    {
        string text = $"CheckListGoal:{base.GetName()}-{base.GetDescription()}-{base.GetPoints()}-{_bonus}-{_target}-{_amountCompleted}";
        return text;
    }
    public override string GetDetailsString()
    {
        string complete = " ";
        bool isComplete = IsComplete();
        if (isComplete == true) { complete = "x"; }
        string text = $"[{complete}] {base.GetName()} ({base.GetDescription()}) -- Currently completed {_amountCompleted}/{_target}.";
        return text;
    }
}