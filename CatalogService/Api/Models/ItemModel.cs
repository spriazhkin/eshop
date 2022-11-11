namespace Api.Models;

public record ItemModel(Guid Id, string Name, string Description, string Image,
    Guid CategoryId, decimal Price, int Amount)
{
}
