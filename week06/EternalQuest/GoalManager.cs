public class GoalManager
{
    private List<Goal> goals = new List<Goal>();
    private int playerScore = 0;

    public void Start()
    {
        bool quit = false;
        while (!quit)
        {
            Console.Clear();
            Console.WriteLine("Goal Manager Menu:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.Write("Choose an option: ");

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoals();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    quit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
            if (!quit) Console.ReadLine();
        }
    }

    private void CreateGoal()
    {
        Console.Clear();
        Console.WriteLine("Create New Goal:");
        Console.WriteLine("1. Eternal Goal");
        Console.WriteLine("2. Checklist Goal");
        Console.WriteLine("3. Simple Goal");
        Console.Write("Choose an option: ");
        string goalType = Console.ReadLine();

        Console.Write("Enter short name for the goal: ");
        string name = Console.ReadLine();

        Console.Write("Enter description for the goal: ");
        string description = Console.ReadLine();

        Console.Write("Enter points for the goal: ");
        int points = int.Parse(Console.ReadLine());

        Goal newGoal = null;

        if (goalType == "1")
        {
            newGoal = new EternalGoal(name, description, points);
        }
        else if (goalType == "2")
        {
            Console.Write("Enter the target amount for the checklist goal: ");
            int target = int.Parse(Console.ReadLine());

            Console.Write("Enter the bonus for the checklist goal: ");
            int bonus = int.Parse(Console.ReadLine());

            newGoal = new ChecklistGoal(name, description, points, target, bonus);
        }
        else if (goalType == "3")
        {
            newGoal = new SimpleGoal(name, description, points);
        }

        if (newGoal != null)
        {
            goals.Add(newGoal);
            Console.WriteLine("Goal created successfully!");
        }
        else
        {
            Console.WriteLine("Invalid goal type.");
        }

        Console.WriteLine("Press Enter to continue...");
    }

    private void ListGoals()
    {
        Console.Clear();
        Console.WriteLine("Goals List:");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].GetDetailsString()}");
        }
        Console.WriteLine($"Total Points: {playerScore}");
        Console.WriteLine("Press Enter to continue...");
    }

    private void SaveGoals()
    {
        Console.Clear();
        Console.WriteLine("Enter the name of the file to save the goals (e.g., 'mygoals.txt'):");
        string fileName = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(fileName))
        {
            writer.WriteLine($"Total Points: {playerScore}");
            foreach (var goal in goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine($"Goals saved successfully to {fileName}!");
        Console.WriteLine("Press Enter to continue...");
    }

    private void LoadGoals()
    {
        Console.Clear();
        Console.WriteLine("Enter the name of the file to load goals from (e.g., 'mygoals.txt'):");
        string fileName = Console.ReadLine();

        if (File.Exists(fileName))
        {
            goals.Clear();
            using (StreamReader reader = new StreamReader(fileName))
            {
                string firstLine = reader.ReadLine();
                if (firstLine.StartsWith("Total Points:"))
                {
                    playerScore = int.Parse(firstLine.Split(':')[1].Trim());
                }

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split('|');
                    if (parts[0] == "EternalGoal")
                    {
                        goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3])));
                    }
                    else if (parts[0] == "ChecklistGoal")
                    {
                        goals.Add(new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5])));
                    }
                    else if (parts[0] == "SimpleGoal")
                    {
                        goals.Add(new SimpleGoal(parts[1], parts[2], int.Parse(parts[3])));
                    }
                }
            }
            Console.WriteLine("Goals loaded successfully!");
        }
        else
        {
            Console.WriteLine("No saved goals found.");
        }

        Console.WriteLine("Press Enter to continue...");
    }

    private void RecordEvent()
    {
        Console.Clear();
        Console.WriteLine("Record Event:");

        List<Goal> uncompletedGoals = new List<Goal>();
        for (int i = 0; i < goals.Count; i++)
        {
            if (!goals[i].IsComplete())
            {
                uncompletedGoals.Add(goals[i]);
                Console.WriteLine($"{uncompletedGoals.Count}. {goals[i].ShortName}");
            }
        }

        if (uncompletedGoals.Count == 0)
        {
            Console.WriteLine("All goals are completed!");
            Console.WriteLine("Press Enter to continue...");
            return;
        }

        Console.Write("Enter the number of the goal you completed: ");
        int choice = int.Parse(Console.ReadLine());

        if (choice >= 1 && choice <= uncompletedGoals.Count)
        {
            var goal = uncompletedGoals[choice - 1];
            goal.RecordEvent();
            Console.WriteLine($"Event recorded for goal: {goal.ShortName}");

            if (goal is ChecklistGoal checklistGoal)
            {
                playerScore += checklistGoal.Points;

                if (checklistGoal.IsComplete())
                {
                    playerScore += checklistGoal.Bonus;
                    Console.WriteLine($"All tasks completed! Bonus of {checklistGoal.Bonus} points added.");
                }
            }
            else
            {
                playerScore += goal.Points;
                Console.WriteLine($"Goal completed! {goal.Points} points added.");
            }
        }
        else
        {
            Console.WriteLine("Invalid selection.");
        }

        Console.WriteLine("Press Enter to continue...");
    }
}