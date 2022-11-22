namespace Api.Models;

public record ImageModel
{
    public string Url { get; set; } = string.Empty;

    public string Alt { get; set; } = string.Empty;
}