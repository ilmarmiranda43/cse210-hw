using System;

class Program
{
    static void Main(string[] args)
        {
            Random randomGenerator = new Random();
            string answer;

            do
            {
                int magicNumber = randomGenerator.Next(1, 101);
                int guessNumber = -1;
                int attempts = 0;

                while (guessNumber != magicNumber)
                {
                    Console.Write("What is your guess? ");
                    guessNumber = int.Parse(Console.ReadLine());

                    attempts++;

                    if (guessNumber < magicNumber)
                    {
                        Console.WriteLine("Higher");
                    }
                    else if (guessNumber > magicNumber)
                    {
                        Console.WriteLine("Lower");
                    }
                    else
                    {
                        Console.WriteLine($"You guessed it! The Magic Number is: {magicNumber}");
                        Console.WriteLine($"Number of attempts: {attempts}");
                    }
                }

                Console.Write("Do you want to play again? (YES or NO): ");
                answer = Console.ReadLine().ToUpper();

            } while (answer == "YES");

            Console.WriteLine("Thanks for playing!");
        }

}