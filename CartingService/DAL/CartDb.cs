namespace DAL;

public record CartDb(string Id, List<CartItemDb> Items)
{
    public CartDb() : this("", []) { }
}
