using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Journal
{
    private List<JournalEntry> entries = new List<JournalEntry>();
    private List<string> prompts = new List<string>
    {
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "Who was the most interesting person I interacted with today?",
        "If I had one thing I could do over today, what would it be?"
    };

    public void AddEntry(string response)
    {
        var randomPrompt = prompts[new Random().Next(prompts.Count)];
        var date = DateTime.Now.ToString("yyyy-MM-dd");
        var entry = new JournalEntry(randomPrompt, response, date);
        entries.Add(entry);
    }

    public void DisplayEntries()
    {
        foreach (var entry in entries)
        {
            Console.WriteLine($"Date: {entry.Date}");
            Console.WriteLine($"Prompt: {entry.Prompt}");
            Console.WriteLine($"Response: {entry.Response}");
            Console.WriteLine();
        }
    }

    public void SaveToFile(string filename)
    {
        var lines = entries.Select(e => $"{e.Date}|{e.Prompt}|{e.Response}").ToList();
        File.WriteAllLines(filename, lines);
    }

    public void LoadFromFile(string filename)
    {
        if (File.Exists(filename))
        {
            var lines = File.ReadAllLines(filename);
            foreach (var line in lines)
            {
                var parts = line.Split('|');
                var entry = new JournalEntry(parts[1], parts[2], parts[0]);
                entries.Add(entry);
            }
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}
