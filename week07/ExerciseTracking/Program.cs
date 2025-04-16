using System;

class Program
{
    static void Main(string[] args)
    {
        Activity running = new Running(4.0, 32);
        Activity cycling = new Cycling(26.0, 40);
        Activity swimming = new Swimming(37, 35);

        Console.WriteLine(running.GetSummary());
        Console.WriteLine(cycling.GetSummary());
        Console.WriteLine(swimming.GetSummary());
    }
}