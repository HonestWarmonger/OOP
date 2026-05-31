using System;
using System.Collections.Generic;
using System.Linq;
using FishingStoreApp.Models;

namespace FishingStoreApp.Services
{
    public class InventoryService
    {
        private List<Product> _warehouse = new List<Product>();

        public void AddProduct(Product product)
        {
            _warehouse.Add(product);
        }

        public void PrintCatalog()
        {
            Console.WriteLine("Каталог товарів:");
            foreach (var p in _warehouse)
            {
                Console.WriteLine($"ID: {p.Id} | {p.Name} | {p.Category} | Ціна: {p.Price} грн | На складі: {p.QuantityInStock} шт.");
            }
        }

        // Додано знак питання (Product?), щоб прибрати жовте попередження CS8632
        public Product? GetProductById(int productId)
        {
            return _warehouse.FirstOrDefault(p => p.Id == productId);
        }

        public bool ReduceStock(int productId, int quantity)
        {
            var product = GetProductById(productId);
            if (product != null && product.QuantityInStock >= quantity)
            {
                product.QuantityInStock -= quantity;
                return true;
            }
            return false;
        }
    }
}