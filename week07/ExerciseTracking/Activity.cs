public abstract class Activity
{
    private DateTime _date = DateTime.Now;
    private int _time = 0;

    public Activity(int time)
    {
        _time = time;
        _date = DateTime.Now;
    }

    public DateTime Date => _date;
    public int Time => _time;

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public string GetSummary()
    {
        return $"{Date:dd MMM yyyy} {GetType().Name} ({Time} min): Distance {GetDistance()} km, Speed: {GetSpeed():F2} kph, Pace: {GetPace():F2} min per km";
    }
}