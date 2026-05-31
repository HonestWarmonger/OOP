using System;
using FishingStoreApp.Models;

namespace FishingStoreApp.Services
{
    public class OrderService
    {
        private InventoryService _inventory;

        public OrderService(InventoryService inventory)
        {
            _inventory = inventory;
        }

        public Order CreateOrder(Customer customer)
        {
            return new Order(new Random().Next(1000, 9999), customer);
        }

        public bool TryAddProductToOrder(Order order, int productId, int quantity)
        {
            var product = _inventory.GetProductById(productId);
            if (product != null && product.QuantityInStock >= quantity)
            {
                if (order.Items.ContainsKey(product))
                    order.Items[product] += quantity;
                else
                    order.Items.Add(product, quantity);

                return true;
            }
            return false;
        }

        public void Checkout(Order order)
        {
            order.Status = "Completed";
            Console.WriteLine($"\n--- ЧЕК ЗАМОВЛЕННЯ №{order.OrderId} ---");
            Console.WriteLine($"Клієнт: {order.Client.FullName}");
            foreach (var item in order.Items)
            {
                _inventory.ReduceStock(item.Key.Id, item.Value); // Списання
                Console.WriteLine($"{item.Key.Name} x {item.Value} шт. = {item.Key.Price * item.Value} грн");
            }
            Console.WriteLine($"ЗАГАЛЬНА СУМА: {order.TotalPrice} грн");
            Console.WriteLine("-----------------------------");
        }
    }
}