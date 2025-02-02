using System;
using System.Collections.Generic;

public class Journal
{
    public List<Entry> Entries { get; private set; } = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        Entries.Add(entry);
    }

    public void DisplayEntries()
    {
        foreach (var entry in Entries)
        {
            Console.WriteLine(entry);
        }
    }
}
