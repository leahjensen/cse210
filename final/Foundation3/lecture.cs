using System;

public class Lecture : Event
{
    public string Speaker { get; }
    public int Capacity { get; }

    public Lecture(string title, string description, DateTime date, string time, Address address, string speaker, int capacity)
        : base(title, description, date, time, address)
    {
        Speaker = speaker;
        Capacity = capacity;
    }

    public override string GetFullDetails()
    {
        return $"{GetStandardDetails()}, Speaker: {Speaker}, Capacity: {Capacity}";
    }

    public override string GetShortDescription()
    {
        return $"{Title} - {Date.ToShortDateString()}: Lecture by {Speaker}";
    }
}
