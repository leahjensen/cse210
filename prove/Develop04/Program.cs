using System;
using System.Collections.Generic;
using System.Threading;

abstract class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void StartActivity()
    {
        Console.WriteLine($"\nStarting {_name}...");
        Console.WriteLine(_description);
        Console.Write("Enter duration in seconds: ");
        _duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Prepare to begin...");
        ShowAnimation(3);
    }

    public void EndActivity()
    {
        Console.WriteLine("\nGood job! Activity complete.");
        ShowAnimation(3);
    }

    protected void ShowAnimation(int seconds)
    {
        string[] spinner = { "|", "/", "-", "\\" };
        for (int i = 0; i < seconds * 4; i++)
        {
            Console.Write(spinner[i % 4] + "\b");
            Thread.Sleep(250);
        }
    }

    public abstract void PerformActivity();
}

class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity", "Relax by following breathing exercises.") { }

    public override void PerformActivity()
    {
        StartActivity();
        for (int i = 0; i < _duration / 6; i++)
        {
            Console.WriteLine("\nBreathe in...");
            ShowAnimation(3);
            Console.WriteLine("\nBreathe out...");
            ShowAnimation(3);
        }
        EndActivity();
    }
}

class ListingActivity : Activity
{
    private List<string> _responses = new List<string>();

    public ListingActivity() : base("Listing Activity", "List as many things as you can related to a prompt.") { }

    public override void PerformActivity()
    {
        StartActivity();
        Console.WriteLine("\nList things that make you happy:");
        Console.WriteLine("You have a few seconds to think...");
        ShowAnimation(3);

        Console.WriteLine("\nStart listing (press Enter after each item, type 'done' to finish):");
        string response;
        do
        {
            response = Console.ReadLine();
            if (response.ToLower() != "done")
            {
                _responses.Add(response);
            }
        } while (response.ToLower() != "done");

        Console.WriteLine($"\nYou listed {_responses.Count} items!");
        EndActivity();
    }
}

class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time you overcame a challenge.",
        "Think of a time when you helped someone in need.",
        "Think of a time you achieved something great."
    };

    public ReflectingActivity() : base("Reflecting Activity", "Think about meaningful experiences in your life.") { }

    public override void PerformActivity()
    {
        StartActivity();
        Random rand = new Random();
        Console.WriteLine($"\n{_prompts[rand.Next(_prompts.Count)]}");
        Console.WriteLine("Reflect on this for a few moments...");
        ShowAnimation(_duration);
        EndActivity();
    }
}

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\nChoose an activity:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Listing Activity");
            Console.WriteLine("3. Reflecting Activity");
            Console.WriteLine("4. Exit");
            Console.Write("Enter choice: ");

            string choice = Console.ReadLine();
            Activity activity = null;

            switch (choice)
            {
                case "1":
                    activity = new BreathingActivity();
                    break;
                case "2":
                    activity = new ListingActivity();
                    break;
                case "3":
                    activity = new ReflectingActivity();
                    break;
                case "4":
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice, try again.");
                    continue;
            }

            activity.PerformActivity();
        }
    }
}