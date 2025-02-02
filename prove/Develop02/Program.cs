using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<string> entries = new List<string>();
    private List<string> prompts = new List<string>
    {
        "What was the best part of your day?",
        "What did you learn today?",
        "Describe a moment you felt grateful for.",
        "What challenges did you overcome today?",
        "If you could relive one moment from today, what would it be?"
    };

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(prompts.Count);
        return prompts[index];
    }

    public void AddEntry(string response)
    {
        string entry = $"{DateTime.Now}: {response}";
        entries.Add(entry);
    }

    public void DisplayEntries()
    {
        if (entries.Count == 0)
        {
            Console.WriteLine("No entries found.");
            return;
        }

        foreach (var entry in entries)
        {
            Console.WriteLine(entry);
        }
    }

    public void SaveToFile(string filename)
    {
        File.WriteAllLines(filename, entries);
    }

    public void LoadFromFile(string filename)
    {
        if (File.Exists(filename))
        {
            entries = new List<string>(File.ReadAllLines(filename));
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}

class Program
{
    static void Main()
    {
        Journal journal = new Journal();
        journal.LoadFromFile("journal.txt");

        // Display a random prompt
        Console.WriteLine("Today's prompt: ");
        Console.WriteLine(journal.GetRandomPrompt());
        
        Console.WriteLine("\nPlease enter your response: ");
        string response = Console.ReadLine();

        // Add the entry to the journal
        journal.AddEntry(response);

        // Display all journal entries
        Console.WriteLine("\nAll journal entries:");
        journal.DisplayEntries();

        // Save the entries to a file
        journal.SaveToFile("journal.txt");
    }
}
