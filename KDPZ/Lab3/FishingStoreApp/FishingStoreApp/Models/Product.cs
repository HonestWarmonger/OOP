using System;

namespace FishingStoreApp.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public int QuantityInStock { get; set; }

        public Product(int id, string name, string category, decimal price, int quantityInStock)
        {
            Id = id;
            Name = name;
            Category = category;
            Price = price;
            QuantityInStock = quantityInStock;
        }
    }
}