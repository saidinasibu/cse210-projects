using System;

class Program
{
    static void Main(string[] args)
    {
        Activity running = new Running(4.0, 35);
        Activity cycling = new Cycling(25.0, 50);
        Activity swimming = new Swimming(35, 30);

        Console.WriteLine(running.GetSummary());
        Console.WriteLine(cycling.GetSummary());
        Console.WriteLine(swimming.GetSummary());
    }
}