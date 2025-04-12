public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {

    }
    public void Run()
    {
        DisplayStartingMessage();

        int i = 3;
        int duration = GetDuration();

        Console.WriteLine("Get ready...");
        ShowSpinner(30);

        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(duration);

        while (DateTime.Now < futureTime)
        {
            Console.WriteLine("Breathe in...");
            ShowCountDown(i);


            Console.WriteLine("Now breathe out...");
            ShowCountDown(i);

            i++;
        }

        DisplayEndingMessage();
    }
}