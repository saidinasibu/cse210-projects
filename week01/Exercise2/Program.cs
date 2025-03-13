using System;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("what is your grade percentage? ");

        string grade_unswer = Console.ReadLine();
        int grade_percent = int.Parse(grade_unswer);

        String grade_letter = "";
        if(grade_percent >= 90)
        {
            grade_letter = "A";
        }
        else if (grade_percent >= 80)
        {
            grade_letter = "B";
        }
        else if (grade_percent >= 70)
        {
            grade_letter = "C";
        }
        else if (grade_percent >=60)
        {
            grade_letter = "D";
        }
        else 
        {
            grade_letter = "F";
        }
        Console.WriteLine($"Your grade is: {grade_letter}");
        if (grade_percent >=70)
        {
            Console.WriteLine("Congratulations, you passed!");
        }
        else
        {
            Console.WriteLine("Good luck for the next time!");
        }



    }
}