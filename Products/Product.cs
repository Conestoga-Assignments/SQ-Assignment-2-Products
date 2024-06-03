using System;
using System.Diagnostics;

namespace Products
{
	public class Product
	{
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        public Product(int productId, string productName, decimal price, int stock)
        {
            if (productId < 1 || productId > 1000) throw new ArgumentOutOfRangeException(nameof(productId));
            if (price < 1 || price > 5000) throw new ArgumentOutOfRangeException(nameof(price));
            if (stock < 1 || stock > 1000) throw new ArgumentOutOfRangeException(nameof(stock));

            if (string.IsNullOrWhiteSpace(productName)) throw new ArgumentException("Product name cannot be null or empty");
            if (productName.Length < 3 || productName.Length > 15) throw new ArgumentException("Product name must be between 3 and 10 characters");

            ProductID = productId;
            ProductName = productName;
            Price = price;
            Stock = stock;
        }

        public void IncrementStock()
        {
            Stock += 1;
        }

        public void DecrementStock()
        {
            Stock -= 1;
        }
    }
}

