public class Swimming : Activity
{
    private int _laps;

    public Swimming(int laps, int time) : base(time)
    {
        _laps = laps;
    }

    public override double GetDistance() => _laps * 50 / 1000.0;

    public override double GetSpeed() => (GetDistance() / Time) * 60;

    public override double GetPace() => Time / GetDistance();
}