using System;

public abstract class Event
{
    public string Title { get; }
    public string Description { get; }
    public DateTime Date { get; }
    public string Time { get; }
    public Address EventAddress { get; }

    public Event(string title, string description, DateTime date, string time, Address address)
    {
        Title = title;
        Description = description;
        Date = date;
        Time = time;
        EventAddress = address;
    }

    public string GetStandardDetails()
    {
        return $"{Title}: {Description}, {Date.ToShortDateString()} at {Time}, {EventAddress}";
    }

    public abstract string GetFullDetails();
    public abstract string GetShortDescription();
}
