namespace DAL;

public record ImageDb(string Url, string Alt)
{
    public ImageDb() : this("", "") { }
}