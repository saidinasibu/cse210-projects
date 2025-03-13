using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int magic_number = randomGenerator.Next(1, 101);
        int guess_number = -3;

        while (guess_number != magic_number)
        {
            Console.Write("What is your guess? ");
            guess_number = int.Parse(Console.ReadLine());

            if (magic_number > guess_number)
            {
                Console.WriteLine("Higher");
            }
            else if (magic_number < guess_number)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }
    }
}


}