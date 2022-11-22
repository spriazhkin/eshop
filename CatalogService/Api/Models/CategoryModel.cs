namespace Api.Models;

public record CategoryModel(Guid Id, string Name, string ImageUrl, Guid? ParentId)
{
}
