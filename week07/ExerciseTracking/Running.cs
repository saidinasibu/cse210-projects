public class Running : Activity
{
    private double _distance;

    public Running(double distance, int time) : base(time)
    {
        _distance = distance;
    }

    public override double GetDistance() => _distance;

    public override double GetSpeed() => (_distance / Time) * 60;

    public override double GetPace() => Time / _distance;
}