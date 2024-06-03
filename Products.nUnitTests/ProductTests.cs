namespace Products.nUnitTests;

public class Tests
{
    private Product _product;

    //[Test]
    [TestCase(0)]
    [TestCase(100)]
    [TestCase(1011)]
    public void ProductIDIsInRange(int productID)
    {
        if (productID < 1 || productID > 1000)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Product(productID, "Test Product", 100.00m, 10));
        }
        else
        {
            var product = new Product(productID, "Test Product", 100.00m, 10);
            Assert.That(product.ProductID, Is.InRange(1, 1000));
        }
    }

    [TestCase(0)]
    [TestCase(100.00)]
    [TestCase(5011.00)]
    public void PriceIsInRange(decimal price)
    {
        if (price < 1 || price > 5000) {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Product(100, "Test Product", price, 10));
        } else {
            var product = new Product(100, "Test Product", price, 10);
            Assert.That(product.Price, Is.InRange(1, 5000));
        }
    }

    [TestCase(0)]
    [TestCase(100)]
    [TestCase(1011)]
    public void StockIsInRange(int stock)
    {
        if (stock < 1 || stock > 1000) {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Product(100, "Test Product", 100.00m, stock));
        } else {
            var product = new Product(100, "Test Product", 100.00m, stock);
            Assert.That(product.Stock, Is.InRange(1, 1000));
        }
    }

    [TestCase("")]
    [TestCase("Test Product")]
    [TestCase("this is a  very long sentence used as a name")]
    public void ProductNameIsValid(string name)
    {
        if (string.IsNullOrWhiteSpace(name) || name.Length < 3 || name.Length > 15) {
            Assert.Throws<ArgumentException>(() => new Product(1, name, 100.00m, 10));
        } else {
            var product = new Product(1, name, 100.00m, 10);
            Assert.That(product.ProductName, Is.EqualTo(name));
        }
    }

    [TestCase(0)]
    [TestCase(1)]
    [TestCase(5)]
    public void IncrementStockByValidAmount_IncreasesStock(int increment)
    {
        // Arrange
        var product = new Product(1, "ValidName", 100.00m, 10);

        // Act
        for (int i = 0; i < increment; i++)
        {
            product.IncrementStock();
        }

        // Assert
        Assert.That(product.Stock, Is.EqualTo(10 + increment));
    }

    [TestCase(0)]
    [TestCase(1)]
    [TestCase(5)]
    public void DecrementStockByValidAmount_DecreasesStock(int decrement)
    {
        // Arrange
        var product = new Product(1, "ValidName", 100.00m, 10);

        // Act
        for (int i = 0; i < decrement; i++)
        {
            product.DecrementStock();
        }

        // Assert
        Assert.That(product.Stock, Is.EqualTo(10 - decrement));
    }
}
