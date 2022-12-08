namespace DAL;

public interface ICartRepository
{
    void Create(CartDb cart);
    
    CartDb Get(string id);
    
    IList<CartDb> GetCartsWithItem(Guid itemId);
    
    void Update(CartDb cart);
    
    void Update(IList<CartDb> carts);
}
