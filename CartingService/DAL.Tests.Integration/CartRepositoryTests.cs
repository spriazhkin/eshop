namespace DAL.Tests.Integration;

public class CartRepositoryTests
{
    private const string DbDirectory = @"C:\Temp";
    private const string DbFile = @$"{DbDirectory}\CartRepositoryTests.db";
    private readonly string _id = "id1";
    private readonly Guid _itemId = new("7b2d0724-5951-455c-9753-6ab46bb9cd5b");

    public CartRepositoryTests()
    {
        if (!Directory.Exists(DbDirectory))
        {
            Directory.CreateDirectory(DbDirectory);
        }
        if (File.Exists(DbFile))
        {
            File.Delete(DbFile);
        }
    }

    [Fact(DisplayName = "Able to create and get cart")]
    public void TestCreateGet()
    {
        var cart = new CartDb(_id, new());

        var repo = new CartRepository(DbFile);

        repo.Create(cart);
        var actual = repo.Get(_id);

        Assert.NotNull(actual);
    }

    [Fact(DisplayName = "Able to create and get cart with data")]
    public void TestCreateGetAllProperties()
    {
        var cartItem = new CartItemDb(_itemId, "name1", 10, 5, new() { Url = "testurl", Alt = "image" });
        var cart = new CartDb(_id, new() { cartItem });

        var repo = new CartRepository(DbFile);

        repo.Create(cart);
        var actual = repo.Get(_id);
        var actualItem = actual.Items[0];

        Assert.NotNull(actual);
        Assert.Single(actual.Items);
        Assert.Equal(cartItem, actualItem);
    }

    [Fact(DisplayName = "Able to update single item")]
    public void TestUpdateSingleItem()
    {
        var cartItem = new CartItemDb(_itemId, "name1", 10, 5, new() { Url = "testurl", Alt = "image" });
        var cart = new CartDb(_id, new() { cartItem });

        var updatedItem = new CartItemDb(_itemId, "name2", 20, 10, new() { Url = "testurl2", Alt = "image2" });
        var updatedCart = new CartDb(_id, new() { updatedItem });

        var repo = new CartRepository(DbFile);

        repo.Create(cart);
        repo.Update(updatedCart);
        var actual = repo.Get(_id);
        var actualItem = actual.Items[0];

        Assert.NotNull(actual);
        Assert.Single(actual.Items);
        Assert.Equal(updatedItem, actualItem);
        Assert.NotEqual(cartItem, actualItem);
    }
}
