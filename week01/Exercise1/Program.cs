using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your first name?. ");
        string first_name = Console.ReadLine();
        
        Console.WriteLine(first_name);

        Console.Write("What is your last name? ");
        string last_name = Console.ReadLine();

        Console.WriteLine($"Your name is {last_name} {first_name} {first_name} ");
    }
}