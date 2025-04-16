public class Cycling : Activity
{
    private double _distance;

    public Cycling(double distance, int time) : base(time)
    {
        _distance = distance;
    }

    public override double GetDistance() => _distance;

    public override double GetSpeed() => (_distance / Time) * 60;

    public override double GetPace() => Time / _distance;
}