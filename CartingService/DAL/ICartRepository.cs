namespace DAL;

public interface ICartRepository
{
    void Create(CartDb cart);
    
    CartDb Get(string id);
    
    void Update(CartDb cart);
}
