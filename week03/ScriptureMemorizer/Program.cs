using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main()
    {

        /*
            Exceeding requirements:
             - Menu system + difficulty selection (words hidden per round)
             - Choose random OR pick scripture
             - Session summary (rounds, total words, completed or quit)

        */

        List<Scripture> library = BuildScriptureLibrary();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("=====================================");
            Console.WriteLine("   Scripture Memorizer (W03 Project) ");
            Console.WriteLine("=====================================");
            Console.WriteLine("1) Start (Random Scripture)");
            Console.WriteLine("2) Start (Choose Scripture)");
            Console.WriteLine("3) Difficulty");
            Console.WriteLine("4) Exit");
            Console.WriteLine("-------------------------------------");

            int choice = ReadInt("Choose an option: ", 1, 4);

            if (choice == 4) break;

            if (choice == 3)
            {
                DifficultySettings.ChangeDifficultyMenu();
                continue;
            }

            Scripture selected = (choice == 1)
                ? PickRandomScripture(library)
                : PickScriptureFromMenu(library);

            RunMemorizer(selected);
        }

        Console.Clear();
        Console.WriteLine("Bye! 👋");
    }

    static void RunMemorizer(Scripture scriptureTemplate)
    {
        Scripture scripture = scriptureTemplate.Clone();

        int rounds = 0;

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.WriteLine($"Difficulty: {DifficultySettings.Name} | Hide per round: {DifficultySettings.WordsToHide}");
            Console.WriteLine($"Round: {rounds}");
            Console.WriteLine("-------------------------------------");
            Console.Write("Press ENTER to hide words, type 'quit' to stop: ");

            string input = Console.ReadLine() ?? "";

            if (input.Trim().Equals("quit", StringComparison.OrdinalIgnoreCase))
            {
                ShowSessionSummary(scripture, rounds, wasCompleted: false);
                return;
            }

            rounds++;

            scripture.HideRandomWords(DifficultySettings.WordsToHide);

            if (scripture.IsCompletelyHidden())
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine();
                ShowSessionSummary(scripture, rounds, wasCompleted: true);
                return;
            }
        }
    }

    static void ShowSessionSummary(Scripture scripture, int rounds, bool wasCompleted)
    {
        Console.WriteLine("-------------------------------------");
        Console.WriteLine(wasCompleted
            ? "✅ Completed! All words are hidden."
            : "🛑 Stopped by user.");

        Console.WriteLine($"Rounds played: {rounds}");
        Console.WriteLine($"Total words: {scripture.TotalWords}");
        Console.WriteLine("Press ENTER to return to the menu...");
        Console.ReadLine();
    }

    static Scripture PickRandomScripture(List<Scripture> library)
    {
        Random rnd = new Random();
        return library[rnd.Next(library.Count)];
    }

    static Scripture PickScriptureFromMenu(List<Scripture> library)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Choose a scripture:");
            Console.WriteLine("-------------------------------------");

            for (int i = 0; i < library.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {library[i].ReferenceText}");
            }
            Console.WriteLine($"{library.Count + 1}) Back");

            int choice = ReadInt("Option: ", 1, library.Count + 1);

            if (choice == library.Count + 1)
                return PickRandomScripture(library); 

            return library[choice - 1];
        }
    }

    static int ReadInt(string prompt, int min, int max)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine() ?? "";

            if (int.TryParse(input, out int value) && value >= min && value <= max)
                return value;

            Console.WriteLine($"Please enter a number between {min} and {max}.");
        }
    }

    static List<Scripture> BuildScriptureLibrary()
    {
        
        return new List<Scripture>
        {
            new Scripture(
                new Reference("John", 21, 10),
                "Jesus saith unto them, Bring of the fish which ye have now caught. "
            ),

            new Scripture(
                new Reference("Exodus", 33, 11),
                "And the Lord spake unto Moses face to face, as a man speaketh unto his friend. \n" +
                "And he turned again into the camp: but his servant Joshua, the son of Nun, a young man, \n" + 
                "departed not out of the tabernacle should not perish, but have everlasting life."
            ),

            new Scripture(
                new Reference("Mosiah", 2, 17),
                "And behold, I tell you these things that ye may learn wisdom; \n" +
                "that ye may learn that when ye are in the service of your fellow \n" +
                "beings ye are only in the service of your God."
            )
        };
    }
}

public static class DifficultySettings
{
    // Padrão
    public static string Name { get; private set; } = "Normal";
    public static int WordsToHide { get; private set; } = 3;

    public static void ChangeDifficultyMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Choose difficulty:");
            Console.WriteLine("1) Easy   (hide 1 word per round)");
            Console.WriteLine("2) Normal (hide 3 words per round)");
            Console.WriteLine("3) Hard   (hide 5 words per round)");
            Console.WriteLine("4) Back");
            Console.WriteLine("-------------------------------------");

            string input = Console.ReadLine() ?? "";

            if (input == "4") return;

            if (input == "1")
            {
                Name = "Easy";
                WordsToHide = 1;
                return;
            }

            if (input == "2")
            {
                Name = "Normal";
                WordsToHide = 3;
                return;
            }

            if (input == "3")
            {
                Name = "Hard";
                WordsToHide = 5;
                return;
            }

            Console.WriteLine("Invalid option. Press ENTER and try again...");
            Console.ReadLine();
        }
    }
}