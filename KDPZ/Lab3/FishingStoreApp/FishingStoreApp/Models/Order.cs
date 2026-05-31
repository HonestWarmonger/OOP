using System.Collections.Generic;
using System.Linq;

namespace FishingStoreApp.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public Customer Client { get; set; }
        public Dictionary<Product, int> Items { get; set; } = new Dictionary<Product, int>();
        public string Status { get; set; } = "New";

        public decimal TotalPrice
        {
            get { return Items.Sum(item => item.Key.Price * item.Value); }
        }

        public Order(int orderId, Customer client)
        {
            OrderId = orderId;
            Client = client;
        }
    }
}