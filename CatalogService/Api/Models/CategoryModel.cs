namespace Api.Models;

public record CategoryModel(string Id, List<ItemModel> Items)
{
    public CategoryModel() : this("", default) { }
}
