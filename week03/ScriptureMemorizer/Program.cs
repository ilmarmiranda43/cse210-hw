using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        /*
         * Exceeding requirements:
         * 1) The program works with a library of scriptures and selects one at random each run.
         * 2) When hiding words, it selects only from words that are not already hidden (stretch challenge).
         */

        List<Scripture> library = new List<Scripture>()
        {
            new Scripture(
                new Reference("John", 3, 16),
                "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."
            ),
            new Scripture(
                new Reference("Proverbs", 3, 5, 6),
                "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths."
            ),
            new Scripture(
                new Reference("2 Nephi", 2, 25),
                "Adam fell that men might be; and men are, that they might have joy."
            )
        };

        Random random = new Random();
        Scripture scripture = library[random.Next(library.Count)];

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.Write("Press Enter to continue or type 'quit' to finish: ");

            string input = Console.ReadLine();

            if (input != null && input.Trim().ToLower() == "quit")
            {
                break;
            }

            // hide 3 words at a time
            scripture.HideRandomWords(3);

            if (scripture.IsCompletelyHidden())
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine();
                break;
            }
        }
    }
}