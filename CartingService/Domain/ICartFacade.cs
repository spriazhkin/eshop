using Domain.Commands;

namespace Domain;

public interface ICartFacade
{
    Cart Get(string id);

    void AddItem(AddItemCommand command);

    void RemoveItem(RemoveItemCommand command);

    void Create(Cart cart);
    
    void Update(Cart cart);

    void UpdateAllItemOccurences(UpdateAllItemOccurencesCommand command);
}