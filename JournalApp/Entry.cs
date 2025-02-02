public class Entry
{
    public string Prompt { get; }
    public string Response { get; }
    public int Rating { get; }

    public Entry(string prompt, string response, int rating)
    {
        Prompt = prompt;
        Response = response;
        Rating = rating;
    }

    public override string ToString()
    {
        return $"Prompt: {Prompt}\nResponse: {Response}\nRating: {Rating}/5\n";
    }
}
