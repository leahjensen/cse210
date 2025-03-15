using System;
using System.Collections.Generic;
using System.IO;

abstract class Goal
{
    public string Name { get; protected set; }
    public int Points { get; protected set; }
    public bool IsComplete { get; protected set; }

    public Goal(string name, int points)
    {
        Name = name;
        Points = points;
    }
    public abstract int RecordEvent();
    public abstract string GetStatus();
}

class SimpleGoal : Goal
{
    public SimpleGoal(string name, int points) : base(name, points) { }
    public override int RecordEvent()
    {
        IsComplete = true;
        return Points;
    }
    public override string GetStatus() => IsComplete ? "[X]" : "[ ]";
}

class EternalGoal : Goal
{
    public EternalGoal(string name, int points) : base(name, points) { }
    public override int RecordEvent() => Points;
    public override string GetStatus() => "[∞]";
}

class ChecklistGoal : Goal
{
    private int target;
    private int progress;
    private int bonus;

    public ChecklistGoal(string name, int points, int target, int bonus) : base(name, points)
    {
        this.target = target;
        this.bonus = bonus;
    }
    public override int RecordEvent()
    {
        progress++;
        if (progress >= target)
        {
            IsComplete = true;
            return Points + bonus;
        }
        return Points;
    }
    public override string GetStatus() => IsComplete ? "[X] Completed!" : $"[{progress}/{target}]";
}

class EternalQuest
{
    private List<Goal> goals = new List<Goal>();
    private int score;

    public void AddGoal(Goal goal) => goals.Add(goal);
    public void RecordEvent(int index) => score += goals[index].RecordEvent();
    public void ShowGoals()
    {
        for (int i = 0; i < goals.Count; i++)
            Console.WriteLine($"{i + 1}. {goals[i].GetStatus()} {goals[i].Name}");
    }
    public void ShowScore() => Console.WriteLine($"Score: {score}");
    public void Save() => File.WriteAllText("save.txt", string.Join("\n", goals));
    public void Load()
    {
        if (File.Exists("save.txt"))
        {
            foreach (var line in File.ReadAllLines("save.txt")) goals.Add(new SimpleGoal(line, 0));
        }
    }
}

class Program
{
    static void Main()
    {
        EternalQuest quest = new EternalQuest();
        quest.AddGoal(new SimpleGoal("Run a Marathon", 1000));
        quest.AddGoal(new EternalGoal("Read Scriptures", 100));
        quest.AddGoal(new ChecklistGoal("Attend Temple", 50, 10, 500));

        while (true)
        {
            Console.WriteLine("1. View Goals\n2. Record Event\n3. Show Score\n4. Exit");
            switch (Console.ReadLine())
            {
                case "1": quest.ShowGoals(); break;
                case "2": Console.Write("Enter goal #: "); quest.RecordEvent(int.Parse(Console.ReadLine()) - 1); break;
                case "3": quest.ShowScore(); break;
                case "4": return;
            }
        }
    }
}
