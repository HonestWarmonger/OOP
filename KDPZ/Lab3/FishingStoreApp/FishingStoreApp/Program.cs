using System;
using FishingStoreApp.Models;
using FishingStoreApp.Services;

namespace FishingStoreApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            InventoryService inventory = new InventoryService();
            OrderService orderService = new OrderService(inventory);

            inventory.AddProduct(new Product(1, "Спінінг Shimano", "Вудилища", 1500.00m, 5));
            inventory.AddProduct(new Product(2, "Котушка Daiwa", "Котушки", 1200.00m, 3));
            inventory.AddProduct(new Product(3, "Волосінь Flurocarbon", "Аксесуари", 200.00m, 10));

            bool isRunning = true;

            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("=== СИСТЕМА АВТОМАТИЗАЦІЇ РИБОЛОВНОГО МАГАЗИНУ ===");
                Console.WriteLine("1 - Переглянути каталог товарів");
                Console.WriteLine("2 - Оформити нове замовлення");
                Console.WriteLine("0 - Вийти з програми");
                Console.Write("Оберіть дію: ");

                string choice = Console.ReadLine() ?? "";

                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        inventory.PrintCatalog();
                        Console.WriteLine("Натисніть Enter, щоб повернутися...");
                        Console.ReadLine();
                        break;

                    case "2":
                        Console.Clear();
                        Console.Write("Введіть ім'я клієнта: ");
                        string customerName = Console.ReadLine() ?? "Гість";

                        Customer currentCustomer = new Customer(new Random().Next(100, 999), customerName);
                        Order currentOrder = orderService.CreateOrder(currentCustomer);

                        bool isOrdering = true;

                        while (isOrdering)
                        {
                            Console.WriteLine("\n--- Кошик покупок ---");
                            inventory.PrintCatalog();
                            Console.Write("Введіть ID товару (або '0' щоб перейти до оплати): ");

                            string inputId = Console.ReadLine() ?? "";

                            if (inputId == "0")
                            {
                                isOrdering = false;
                                Console.Clear();
                                orderService.Checkout(currentOrder);
                            }
                            else if (int.TryParse(inputId, out int productId))
                            {
                                Console.Write("Введіть необхідну кількість: ");
                                if (int.TryParse(Console.ReadLine() ?? "0", out int quantity))
                                {
                                    bool success = orderService.TryAddProductToOrder(currentOrder, productId, quantity);
                                    if (success) Console.WriteLine("Товар успішно додано!");
                                    else Console.WriteLine("Помилка: Недостатньо товару на складі або невірний ID.");
                                }
                            }
                        }
                        Console.WriteLine("\nНатисніть Enter, щоб повернутися в меню...");
                        Console.ReadLine();
                        break;

                    case "0":
                        isRunning = false;
                        Console.WriteLine("\nДо побачення!");
                        break;
                }
            }
        }
    }
}