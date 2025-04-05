using System;

public class Wedding : Event
{
    public string RSVPEmail { get; }

    public Wedding(string title, string description, DateTime date, string time, Address address, string rsvpEmail)
        : base(title, description, date, time, address)
    {
        RSVPEmail = rsvpEmail;
    }

    public override string GetFullDetails()
    {
        return $"{GetStandardDetails()}, RSVP at: {RSVPEmail}";
    }

    public override string GetShortDescription()
    {
        return $"{Title} - {Date.ToShortDateString()}: Wedding";
    }
}
