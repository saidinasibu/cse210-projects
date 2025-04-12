public class Activity
{
    private string _name = "";
    private string _description = "";
    private int _duration = 0;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
        _duration = 0;
    }

    public Activity(int duration)
    {
        _duration = duration;
    }

    public void DisplayStartingMessage()
    {
        Console.WriteLine($"Welcome to the {_name} Activity");
        Console.WriteLine($"{_description}");
        Console.Write("How long, in seconds, would you like for your session? ");
        _duration = int.Parse(Console.ReadLine());

    }
    public void DisplayEndingMessage()
    {
        Console.WriteLine("Well done!");
        Console.WriteLine($"You have completed another {_duration} seconds of {_name} Activity");
    }
    public void ShowSpinner(int seconds)
    {
        string[] spinner = { "/", "-", "\\", "|" };
        int spinnerIndex = 0;

        for (int i = 0; i < seconds; i++)
        {
            Console.Write(spinner[spinnerIndex]);
            Thread.Sleep(100);
            Console.Write("\b \b");

            spinnerIndex = (spinnerIndex + 1) % spinner.Length;
        }

        Console.Write(" \b");
    }
    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    public int GetDuration()
    {
        return _duration;
    }


}