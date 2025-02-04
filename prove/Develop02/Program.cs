using System;
using System.Collections.Generic;
using System.IO;

public class Entry
{
    public DateTime Date { get; }
    public string Prompt { get; }
    public string Response { get; }

    public Entry(string prompt, string response)
    {
        Date = DateTime.Now;
        Prompt = prompt;
        Response = response;
    }

    public override string ToString()
    {
        return $"{Date}|{Prompt}|{Response}";
    }

    public static Entry FromString(string data)
    {
        var parts = data.Split('|');
        if (parts.Length == 3)
        {
            return new Entry(parts[1], parts[2]) { Date = DateTime.Parse(parts[0]) };
        }
        return null;
    }
}

public class Journal
{
    private List<Entry> _entries = new List<Entry>();
    private List<string> _prompts = new List<string>
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
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }

    public void AddEntry(string prompt, string response)
    {
        _entries.Add(new Entry(prompt, response));
    }

    public void ShowEntries()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No journal entries yet.");
            return;
        }

        foreach (var entry in _entries)
        {
            Console.WriteLine($"{entry.Date}: {entry.Prompt} - {entry.Response}");
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var entry in _entries)
            {
                writer.WriteLine(entry.ToString());
            }
        }
    }

    public void LoadFromFile(string filename)
    {
        if (File.Exists(filename))
        {
            foreach (var line in File.ReadAllLines(filename))
            {
                Entry entry = Entry.FromString(line);
                if (entry != null)
                {
                    _entries.Add(entry);
                }
            }
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
        string prompt = journal.GetRandomPrompt();
        Console.WriteLine(prompt);
        
        Console.WriteLine("\nWrite your response:");
        string response = Console.ReadLine();

        journal.AddEntry(prompt, response);

        Console.WriteLine("\nYour journal entries:");
        journal.ShowEntries();

        journal.SaveToFile("journal.txt");
    }
}