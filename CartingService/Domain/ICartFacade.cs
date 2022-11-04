namespace Domain;

public interface ICartFacade
{
    Cart Get(Guid id);

    void Create(Cart cart);
    
    void Update(Cart cart);
}