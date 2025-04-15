using System.IO;
public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score;
    public GoalManager()
    {
        _goals.Clear();
        _score = 0;
    }
    public void SetScore(int score)
    {
        _score = score;
    }
    public int GetScore()
    {
        return _score;
    }
    public void Start()
    {
        Console.WriteLine($"\n### You have {_score} points ###\n");
        Console.WriteLine("Menu Options:");
        Console.WriteLine("   1. Create a new Goal");
        Console.WriteLine("   2. List Goals");
        Console.WriteLine("   3. Save Goals");
        Console.WriteLine("   4. Load Gols");
        Console.WriteLine("   5. Record Event");
        Console.WriteLine("   6. File Compararison");
        Console.WriteLine("   7. Quit");
        Console.Write("Enter your choice? ");
    }
    public void DisplayPlayerInfo()
    {
        Console.WriteLine("\nThe type of Goals are:");
        Console.WriteLine("   1. Simple Goal");
        Console.WriteLine("   2. Eternal Goal");
        Console.WriteLine("   3. Checklist Goal");
        Console.Write("Select which Goal you'd like to create? ");
    }
    public void ListGoalNames()
    {
        int index = 0;
        foreach (Goal goal in _goals)
        {
            index += 1;
            Console.WriteLine($"{index}. {goal.GetName()}");
        }
    }
    public void ListGoalDetails()
    {
        foreach (Goal goal in _goals)
        {
            Console.WriteLine(goal.GetDetailsString());
        }
    }
    public void CreateGoal(string goalType)
    {
        Console.Write("\nWhat is the name of your goal? ");
        string goalName = Console.ReadLine();
        Console.Write("What is the short description of it? ");
        string goalDescription = Console.ReadLine();
        Console.Write("What is the ammount of points associated whit the goal? ");
        string goalPoints = Console.ReadLine();

        if (goalType == "simple")
        {
            SimpleGoal simple = new SimpleGoal(goalName, goalDescription, goalPoints);
            _goals.Add(simple);
        }
        if (goalType == "eternal")
        {
            EternalGoal eternal = new EternalGoal(goalName, goalDescription, goalPoints);
            _goals.Add(eternal);
        }
        if (goalType == "checklist")
        {
            Console.Write("How many times does this goal need to be acomplished for a bonus? ");
            int target = Convert.ToInt32(Console.ReadLine());

            Console.Write("How is the bonus for acomplishing it that many times? ");
            int bonus = Convert.ToInt32(Console.ReadLine());

            CheckListGoal checklist = new CheckListGoal(goalName, goalDescription, goalPoints, target, bonus);
            _goals.Add(checklist);
        }
    }
    public void RecordEvent()
    {
        Console.Write("Which Goal do you want to acomplish? ");
        int index = Convert.ToInt32(Console.ReadLine());

        if (index <= _goals.Count())
        {
            index -= 1;
            _goals[index].RecordEvent();

            if (_goals[index].IsComplete())
            {
                int points = Convert.ToInt32(_goals[index].GetPoints());
                Console.WriteLine($"Now you have {_score + points} points");
            }
            _score += Convert.ToInt32(_goals[index].GetPoints());
        }
    }
    public void SaveGoals(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine($"Score:{_score}");

            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
    }
    public void LoadGoals(string filename)
    {
        _goals.Clear();

        string[] lines = System.IO.File.ReadAllLines(filename);

        foreach (string line in lines)
        {
            string[] parts = line.Split("~");
            string[] heading = parts[0].Split(":");
            string goalType = heading[0];
            if (goalType == "Score")
            {
                string scoreText = heading[1];
                int score = Convert.ToInt32(scoreText);
                _score = score;
            }
            else
            {
                string goalName = heading[1];
                string goalDescription = parts[1];
                string goalPoints = parts[2];

                if (goalType == "SimpleGoal")
                {
                    string completed = parts[3];
                    SimpleGoal simple = new SimpleGoal(goalName, goalDescription, goalPoints);
                    if (parts[3] == "True")
                    {
                        simple.RecordEvent();
                    }

                    _goals.Add(simple);
                }
                if (goalType == "EternalGoal")
                {
                    EternalGoal eternal = new EternalGoal(goalName, goalDescription, goalPoints);

                    _goals.Add(eternal);
                }
                if (goalType == "CheckListGoal")
                {
                    int target = Convert.ToInt32(parts[4]);

                    int bonus = Convert.ToInt32(parts[3]);

                    CheckListGoal checklist = new CheckListGoal(goalName, goalDescription, goalPoints, target, bonus);
                    checklist.SetAmount(Convert.ToInt32(parts[5]));
                    _goals.Add(checklist);
                }
            }
        }
    }
}