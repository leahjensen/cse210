using System;

public class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();

        while (true)
        {
            Console.WriteLine("Journal Application Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display journal entries");
            Console.WriteLine("3. Save journal to a file");
            Console.WriteLine("4. Load journal from a file");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option (1-5): ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("You will be given a random prompt.");
                    Console.WriteLine("Please respond to the prompt below:");
                    var prompt = journal.GetRandomPrompt();
                    Console.WriteLine(prompt);
                    Console.Write("Your response: ");
                    var response = Console.ReadLine();
                    journal.AddEntry(response);
                    Console.WriteLine("Your entry has been saved.");
                    break;
                case "2":
                    Console.WriteLine("Displaying all journal entries:");
                    journal.DisplayEntries();
                    break;
                case "3":
                    Console.Write("Enter a filename to save the journal: ");
                    var saveFilename = Console.ReadLine();
                    journal.SaveToFile(saveFilename);
                    Console.WriteLine("Journal saved successfully.");
                    break;
                case "4":
                    Console.Write("Enter the filename to load the journal from: ");
                    var loadFilename = Console.ReadLine();
                    journal.LoadFromFile(loadFilename);
                    Console.WriteLine("Journal loaded successfully.");
                    break;
                case "5":
                    Console.WriteLine("Exiting the journal application.");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine(); // For better readability
        }
    }
}
