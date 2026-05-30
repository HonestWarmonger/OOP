using System;
using System.Collections.Generic;
using System.Linq;

namespace FishingStoreApp.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public Customer Customer { get; set; }
        public Dictionary<Product, int> Items { get; private set; }
        public string Status { get; set; }

        public Order(int orderId, Customer customer)
        {
            OrderId = orderId;
            Customer = customer;
            Items = new Dictionary<Product, int>();
            Status = "New";
        }

        public void AddItem(Product product, int quantity)
        {
            if (Items.ContainsKey(product))
                Items[product] += quantity;
            else
                Items.Add(product, quantity);
        }

        public decimal TotalPrice => Items.Sum(item => item.Key.Price * item.Value);

        public void PrintReceipt()
        {
            Console.WriteLine($"\n--- ЧЕК ЗАМОВЛЕННЯ №{OrderId} ---");
            Console.WriteLine($"Клієнт: {Customer.FullName}");
            Console.WriteLine($"Статус: {Status}");
            Console.WriteLine("Товари у кошику:");
            foreach (var item in Items)
            {
                decimal positionTotal = item.Key.Price * item.Value;
                Console.WriteLine($"- {item.Key.Name} | {item.Value} шт. х {item.Key.Price} грн = {positionTotal} грн");
            }
            Console.WriteLine("................................");
            Console.WriteLine($"ЗАГАЛЬНА СУМА ДО СПЛАТИ: {TotalPrice} грн");
            Console.WriteLine("--------------------------------\n");
        }
    }
}