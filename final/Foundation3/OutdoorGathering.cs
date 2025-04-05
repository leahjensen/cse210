using System;

public class OutdoorGathering : Event
{
    public string WeatherForecast { get; }

    public OutdoorGathering(string title, string description, DateTime date, string time, Address address, string weatherForecast)
        : base(title, description, date, time, address)
    {
        WeatherForecast = weatherForecast;
    }

    public override string GetFullDetails()
    {
        return $"{GetStandardDetails()}, Weather Forecast: {WeatherForecast}";
    }

    public override string GetShortDescription()
    {
        return $"{Title} - {Date.ToShortDateString()}: Outdoor Gathering";
    }
}
