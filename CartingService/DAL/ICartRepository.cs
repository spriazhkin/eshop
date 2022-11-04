namespace DAL;

public interface ICartRepository
{
    void Create(CartDb cart);
    
    CartDb Get(Guid id);
    
    void Update(CartDb cart);
}
