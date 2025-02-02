using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class FileHandler
{
    public static void SaveJournal(string filename, List<Entry> entries)
    {
        string json = JsonSerializer.Serialize(entries);
        File.WriteAllText(filename, json);
    }

    public static List<Entry> LoadJournal(string filename)
    {
        if (!File.Exists(filename))
            return new List<Entry>();

        string json = File.ReadAllText(filename);
        return JsonSerializer.Deserialize<List<Entry>>(json) ?? new List<Entry>();
    }
}
