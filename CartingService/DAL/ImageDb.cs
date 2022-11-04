namespace DAL;

public record ImageDb
{
    public string Url { get; set; } = string.Empty;

    public string Alt { get; set; } = string.Empty;
}