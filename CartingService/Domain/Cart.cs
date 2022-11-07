namespace Domain;

public record Cart(string Id, List<CartItem> Items)
{
    public Cart() : this("", default) { }
}
