using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();

        PromptGenerator promptGen = new PromptGenerator();
        promptGen._prompts.Add("Who was the most interesting person I interacted with today?");
        promptGen._prompts.Add("What was the best part of my day?");
        promptGen._prompts.Add("How did I see the hand of the lord in my life today?");
        promptGen._prompts.Add("What was the strongest emotion I felt today?");
        promptGen._prompts.Add("If I had one thing I could do over today, what would it be?");

        string choice = "";

        while (choice != "5")
        {
            Console.WriteLine("\nWelcome to the Journal Program!");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");

            Console.Write("What would you like to do? ");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string prompt = promptGen.GetRandomPrompt();
                    Console.WriteLine(prompt);
                    Console.Write("Write your entry: ");
                    string text = Console.ReadLine();

                    Entry entry = new Entry();
                    entry._promptText = prompt;
                    entry._entryText = text;

                    journal.AddEntry(entry);
                    break;

                case "2":
                    journal.DisplayAll();
                    break;

                case "3":
                    Console.Write("Filename to load: ");
                    journal.LoadFromFile(Console.ReadLine());
                    break;

                case "4":
                    Console.Write("Filename to save: ");
                    journal.SaveToFile(Console.ReadLine());
                    break;

                case "5":
                    Console.WriteLine("Do have a great day!");
                    break;

                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
    }
}
