using System;
using FishingStoreApp.Models;

namespace FishingStoreApp.Services
{
    public class OrderService
    {
        private InventoryService _inventoryService;
        private int _orderCounter = 1;

        public OrderService(InventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        public Order CreateOrder(Customer customer)
        {
            return new Order(_orderCounter++, customer);
        }

        public bool TryAddProductToOrder(Order order, int productId, int quantity)
        {
            if (_inventoryService.CheckAvailability(productId, quantity))
            {
                Product product = _inventoryService.GetProductById(productId);
                order.AddItem(product, quantity);
                Console.WriteLine($"[Успіх]: Додано в кошик: {product.Name} ({quantity} шт.)");
                return true;
            }
            else
            {
                Product product = _inventoryService.GetProductById(productId);
                string productName = product != null ? product.Name : $"з ID {productId}";
                Console.WriteLine($"[Помилка]: Відмова! Недостатньо товару '{productName}' на складі.");
                return false;
            }
        }

        public void Checkout(Order order)
        {
            if (order.Items.Count == 0)
            {
                Console.WriteLine("\n[Увага]: Замовлення порожнє. Оформлення скасовано.");
                order.Status = "Cancelled";
                return;
            }

            foreach (var item in order.Items)
            {
                _inventoryService.ReduceStock(item.Key.Id, item.Value);
            }

            order.Status = "Completed";
            Console.WriteLine($"\n[Каса]: Замовлення №{order.OrderId} успішно проведено!");
            order.PrintReceipt();
        }
    }
}