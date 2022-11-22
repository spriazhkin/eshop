using LiteDB;

namespace DAL;

public class CartRepository : ICartRepository
{
    private const string CollectionName = "carts";
    private readonly string _connectionString;

    public CartRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public CartDb Get(string id)
    {
        using var db = new LiteDatabase(_connectionString);
        var col = db.GetCollection<CartDb>(CollectionName);
        return col.FindById(id);
    }

    public void Update(CartDb cart)
    {
        using var db = new LiteDatabase(_connectionString);
        var col = db.GetCollection<CartDb>(CollectionName);
        col.Update(cart);
    }

    public void Create(CartDb cart)
    {
        using var db = new LiteDatabase(_connectionString);
        var col = db.GetCollection<CartDb>(CollectionName);
        col.Insert(cart);
    }
}
