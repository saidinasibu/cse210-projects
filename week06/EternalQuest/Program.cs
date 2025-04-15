

/*Requirements Exceeded:
 -> I added a "Compare" function as option 6 in the main menu. It allows users to compare two files by displaying their scores and providing a motivational message.*/

using System;
using System.Numerics;
class Program
{
    static void Main(string[] args)
    {
        string fileName1="Goals.txt";
        Console.Clear();
        GoalManager goalManager = new GoalManager();

        string option= "";
        while (option != "6")
        { 
            goalManager.Start();
            option= Console.ReadLine();
            if (option =="1")
            {
                string typeOption;
               
                goalManager.DisplayPlayerInfo();
                typeOption= Console.ReadLine();

                if (typeOption =="1")
                {
                    goalManager.CreateGoal("simple");         
                }
                 if (typeOption =="2")
                {
                    goalManager.CreateGoal("eternal"); 
                }
                 if (typeOption =="3")
                {
                    goalManager.CreateGoal("checklist");
                }
            }
            if (option =="2")
            {
                Console.WriteLine("\nThe Goals are:");
                goalManager.ListGoalDetails();
            }
            if (option =="3")
            {
                Console.Write($"\n Type your goals file(default:{fileName1}): ");
                string filename = Console.ReadLine();
                if (filename == ""){filename = fileName1;}
                goalManager.SaveGoals(filename);
                Console.Clear();
            }
            if (option =="4")
            {
                Console.Write($"\n Type your goals file(default:{fileName1}): ");
                string filename = Console.ReadLine();
                if (filename == ""){filename = fileName1;}
                goalManager.LoadGoals(filename);
                Console.Clear();          
            }    
            if (option =="5")
            {
                goalManager.ListGoalNames();
                goalManager.RecordEvent();
            }
            if (option =="6")
            {
                Console.Clear();  

                Console.Write($"\n Enter your First file's name (default:{fileName1}): ");
                string filename = Console.ReadLine();
                if (filename != ""){fileName1 = filename ;}
                                
                Console.Write($"\n Enter your Secong file's name : ");
                String fileName2 = Console.ReadLine();
                
                goalManager.LoadGoals(fileName1);                        
                Console.WriteLine($"\n_____________ FILE NUMBER ONE: '{fileName1}'__________");
                Console.WriteLine("The Goals are:");
                goalManager.ListGoalDetails();
                int score1 = goalManager.GetScore();
                Console.WriteLine($"\t You Got {score1} Points");
                GoalManager goalManager2=new GoalManager();
                goalManager2.LoadGoals(fileName2);
                Console.WriteLine($"\n____________FILE NUMBER TWO : '{fileName2}'_______________");
                Console.WriteLine("The Goals are:");
                goalManager2.ListGoalDetails();
                int score2 = goalManager2.GetScore();
                Console.WriteLine($"\t You Got {score2} Points");
                Console.WriteLine($"\n_______________________________________________\n");

                Console.WriteLine($"Comparing first File({fileName1}) to the second one({fileName2})");
                if (score2 > score1)
                {
                    Console.WriteLine($"***** You're performing excellently, and your progress is evident {score2 - score1} Points! *****\n");
                }
                if (score2 == score1)
                {
                    Console.WriteLine($" You're doing an outstanding job, and your growth is impressive!");
                }
                if (score2 < score1 * 1.1) 
                {
                    Console.WriteLine($"PLEASE GO CHECK YOUR GOALS :(\n");
                }
            }
            if (option =="7")
            {
                Console.WriteLine("Good bye!!!");
                break;
            }
        }    
    }
}