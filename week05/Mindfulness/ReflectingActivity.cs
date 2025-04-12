public class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you feel after this experience?",
        "What did you learn about yourself?",
        "How can you apply this experience to your future?"
    };

    public ReflectingActivity() : base("Reflecting", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();
        int duration = GetDuration();
        Console.WriteLine("Get ready...");
        ShowSpinner(30);

        string prompt = GetRandomPrompt();
        Console.WriteLine($"\n{prompt}\n");
        ShowSpinner(30);

        Console.WriteLine("\nWhen you have something in mind, press enter to continue...");
        Console.ReadLine();
        Console.WriteLine("\nNow ponder on each of the following questions as they related to this experience.");
        ShowSpinner(50);
        Console.WriteLine("\nYou may begin in: ");
        ShowCountDown(5);

        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(duration);

        while (DateTime.Now < futureTime)
        {
            string question = GetRandomQuestion();
            Console.WriteLine(question);
            ShowSpinner(100);
        }

        DisplayEndingMessage();
    }

    private string GetRandomPrompt()
    {
        Random rand = new Random();
        return _prompts[rand.Next(_prompts.Count)];
    }

    private string GetRandomQuestion()
    {
        Random rand = new Random();
        return _questions[rand.Next(_questions.Count)];
    }
}