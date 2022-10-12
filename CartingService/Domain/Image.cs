namespace Domain;

public record Image
{
    public string Url { get; set; } = string.Empty;

    public string Alt { get; set; } = string.Empty;
}