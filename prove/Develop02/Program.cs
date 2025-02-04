using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<string> entries = new List<string>();
    private List<string> prompts = new List<string>
    {
        "What made you smile today?",
        "What is something new you discovered?",
        "Write about a moment that made you feel appreciated.",
        "Describe a challenge you tackled today.",
        "If you could revisit one part of today, what would it be?"
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

    public void ShowEntries()
    {
        if (entries.Count == 0)
        {
            Console.WriteLine("No journal entries yet.");
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
            Console.WriteLine("No saved journal found.");
        }
    }
}

class Program
{
    static void Main()
    {
        Journal journal = new Journal();
        journal.LoadFromFile("journal.txt");

        Console.WriteLine("Here’s a journal prompt for you:");
        Console.WriteLine(journal.GetRandomPrompt());
        
        Console.WriteLine("\nWrite your response:");
        string response = Console.ReadLine();

        journal.AddEntry(response);

        Console.WriteLine("\nYour journal entries:");
        journal.ShowEntries();

        journal.SaveToFile("journal.txt");
    }
}
