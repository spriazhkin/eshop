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

    public IList<CartDb> GetCartsWithItem(Guid itemId)
    {
        using var db = new LiteDatabase(_connectionString);
        var col = db.GetCollection<CartDb>(CollectionName);
        return col.Include(c => c.Items).Query().Where(c => c.Items.Select(i => i.Id).Any(id => id == itemId)).ToList();//.Any(i => i.Id == itemId)).ToList();//.Find(c => c.Items.Any(i => i.Id == itemId)).ToList();
    }

    public void Update(IList<CartDb> carts)
    {
        using var db = new LiteDatabase(_connectionString);
        var col = db.GetCollection<CartDb>(CollectionName);
        col.Update(carts);
    }
}
