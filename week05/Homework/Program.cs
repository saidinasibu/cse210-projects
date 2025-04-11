using System;

class Program
{
    static void Main(string[] args)
    {

        Assignment a1 = new Assignment("Tonga Mpemba", "Division");
        Console.WriteLine(a1.GetSummary());


        MathAssignment a2 = new MathAssignment("Alfani Nfwamba", "Multiplications", "7.3", "9-11");
        Console.WriteLine(a2.GetSummary());
        Console.WriteLine(a2.GetHomeworkList());

        WritingAssignment a3 = new WritingAssignment("Nancy Makanda", "African History", "The Causes of Drc War ");
        Console.WriteLine(a3.GetSummary());
        Console.WriteLine(a3.GetWritingInformation());
    }
}