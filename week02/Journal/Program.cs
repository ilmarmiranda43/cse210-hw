using System;

class Program
{
    static void Main(string[] args)
    {
        /*
         * Exceeding Requirements (Creativity):
         * 1) Added saving/loading in CSV format that opens in Excel, with correct handling of commas and quotation marks.
         * 2) Added extra fields per entry (Time, Mood, Tags) + word count display.
         * 3) Added helpful features: Stats (total entries/words) and Search by keyword/tags to make journaling easier.
         */

        Journal journal = new Journal();

        PromptGenerator promptGen = new PromptGenerator();
        
        string choice = "";

        while (choice != "7")
        {
            Console.WriteLine("\nWelcome to the Journal Program!");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load (.txt or .csv)");
            Console.WriteLine("4. Save (.txt or .csv)");
            Console.WriteLine("5. Search");
            Console.WriteLine("6. Stats");
            Console.WriteLine("7. Quit");

            Console.Write("What would you like to do? ");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string prompt = promptGen.GetRandomPrompt();
                    Console.WriteLine(prompt);

                    Console.WriteLine("\n--- Optional Details ---");
                    Console.Write("How are you feeling today? (Happy, Sad, Tired, Calm, Grateful, etc — press Enter to skip): ");
                    string mood = Console.ReadLine();

                    Console.WriteLine("\n--- Optional Details ---");
                    Console.Write("Add tags for this entry (comma-separated, e.g., school, family, goals — press Enter to skip): ");
                    string tags = Console.ReadLine();

                    Console.Write("Write your entry: ");
                    string text = Console.ReadLine();

                    Entry entry = new Entry();
                    entry.PromptText = prompt;
                    entry.EntryText = text;
                    entry.Mood = mood;
                    entry.Tags = tags;
                    journal.AddEntry(entry);

                    break;

                case "2":
                    journal.DisplayAll();
                    break;

                case "3":
                    Console.Write("Filename to load (example: journal.csv or journal.txt): ");
                    journal.LoadFromFile(Console.ReadLine());
                    break;

                case "4":
                    Console.Write("Filename to save (example: journal.csv or journal.txt): ");
                    journal.SaveToFile(Console.ReadLine());
                    break;

                case "5":
                    Console.Write("Keyword to search: ");
                    journal.Search(Console.ReadLine());
                    break;

                case "6":
                    journal.ShowStats();
                    break;

                case "7":
                    Console.WriteLine("Have a great day!");
                    break;

                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
    }
}
