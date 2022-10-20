namespace DAL.Tests.Integration;

public class CartRepositoryTests
{
    private const string DbDirectory = @"C:\Temp";
    private const string DbFile = @$"{DbDirectory}\CartRepositoryTests.db";
    private readonly Guid _id = Guid.NewGuid();

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
        var cart = new CartDb() { Id = _id };

        var repo = new CartRepository(DbFile);

        repo.Create(cart);
        var actual = repo.Get(_id);

        Assert.NotNull(actual);
    }

    [Fact(DisplayName = "Able to create and get cart with data")]
    public void TestCreateGetAllProperties()
    {
        var cartItem = new CartItemDb()
        {
            Id = 1,
            Name = "name1",
            Price = 10,
            Image = new() { Url = "testurl", Alt = "image" },
            Quantity = 5
        };
        var cart = new CartDb() { Id = _id, Items = new() { cartItem } };

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
        var cartItem = new CartItemDb()
        {
            Id = 1,
            Name = "name1",
            Price = 10,
            Image = new() { Url = "testurl", Alt = "image" },
            Quantity = 5
        };
        var cart = new CartDb() { Id = _id, Items = new() { cartItem } };

        var updatedItem = new CartItemDb()
        {
            Id = 1,
            Name = "name2",
            Price = 20,
            Image = new() { Url = "testur2", Alt = "image2" },
            Quantity = 10
        };
        var updatedCart = cart with { Items = new() { updatedItem } };

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
