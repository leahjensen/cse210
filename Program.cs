using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Journal journal = new Journal();
        string fileName = "journal.json";

        while (true)
        {
            Console.WriteLine("1. Add Entry");
            Console.WriteLine("2. View Entries");
            Console.WriteLine("3. Save & Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.Write("Enter a prompt: ");
                string prompt = Console.ReadLine() ?? "";

                Console.Write("Enter your response: ");
                string response = Console.ReadLine() ?? "";

                Console.Write("Enter rating (1-5): ");
                if (int.TryParse(Console.ReadLine(), out int rating) && rating >= 1 && rating <= 5)
                {
                    Entry entry = new Entry(prompt, response, rating);
                    journal.AddEntry(entry);
                }
                else
                {
                    Console.WriteLine("Invalid rating. Please enter a number between 1 and 5.");
                }
            }
            else if (choice == "2")
            {
                journal.DisplayEntries();
            }
            else if (choice == "3")
            {
                FileHandler.SaveJournal(fileName, journal.Entries);
                Console.WriteLine("Journal saved. Exiting...");
                break;
            }
            else
            {
                Console.WriteLine("Invalid option. Try again.");
            }
        }
    }
}
