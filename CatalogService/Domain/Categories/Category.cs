namespace Domain.Categories;

public record Category(Guid Id, string Name, string ImageUrl, Guid? ParentId)
{
    public Category() : this(default, "", default, default) { }
}