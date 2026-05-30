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

        public bool CheckAvailability(int productId, int requiredQuantity)
        {
            var product = _warehouse.FirstOrDefault(p => p.Id == productId);
            if (product != null && product.QuantityInStock >= requiredQuantity)
            {
                return true;
            }
            return false;
        }

        public void ReduceStock(int productId, int quantityToReduce)
        {
            var product = _warehouse.FirstOrDefault(p => p.Id == productId);
            if (product != null)
            {
                product.QuantityInStock -= quantityToReduce;
            }
        }

        public Product GetProductById(int productId)
        {
            return _warehouse.FirstOrDefault(p => p.Id == productId);
        }

        // НОВИЙ МЕТОД: Для виведення каталогу в інтерактивному меню
        public void PrintCatalog()
        {
            Console.WriteLine("\n=== КАТАЛОГ ТОВАРІВ НА СКЛАДІ ===");
            foreach (var product in _warehouse)
            {
                Console.WriteLine($"[ID: {product.Id}] {product.Name} | {product.Category} | Ціна: {product.Price} грн | В наявності: {product.QuantityInStock} шт.");
            }
            Console.WriteLine("=================================\n");
        }
    }
}