namespace Domain.Commands;

public record UpdateAllItemOccurencesCommand(Guid Id, string Name, string Description, string Image)
{
    public UpdateAllItemOccurencesCommand() : this(default, "", "", "") { }
}
