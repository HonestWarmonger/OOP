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

            // 1. Ініціалізація системи та наповнення складу початковими даними
            InventoryService inventory = new InventoryService();
            OrderService orderService = new OrderService(inventory);

            inventory.AddProduct(new Product(1, "Спінінг Shimano", "Вудилища", 1500.00m, 5));
            inventory.AddProduct(new Product(2, "Котушка Daiwa", "Котушки", 1200.00m, 3));
            inventory.AddProduct(new Product(3, "Волосінь Flurocarbon", "Аксесуари", 200.00m, 1));
            inventory.AddProduct(new Product(4, "Воблер Rapala", "Приманки", 350.00m, 10));

            Console.WriteLine("=== СИСТЕМА АВТОМАТИЗАЦІЇ РИБОЛОВНОГО МАГАЗИНУ ===");

            // Змінна для контролю головного циклу програми
            bool isRunning = true;

            // Головний цикл взаємодії з користувачем
            while (isRunning)
            {
                Console.WriteLine("\nГОЛОВНЕ МЕНЮ:");
                Console.WriteLine("1 - Переглянути каталог товарів");
                Console.WriteLine("2 - Оформити нове замовлення");
                Console.WriteLine("0 - Вийти з програми");
                Console.Write("Оберіть дію: ");

                string choice = Console.ReadLine();

                // Обробка вибору користувача за допомогою switch-case
                switch (choice)
                {
                    case "1":
                        // Виклик методу для друку доступних товарів
                        inventory.PrintCatalog();
                        break;

                    case "2":
                        // Сценарій оформлення нового замовлення
                        Console.Write("\nВведіть ім'я клієнта: ");
                        string customerName = Console.ReadLine();

                        // Створюємо нового клієнта (ID генеруємо випадково для прикладу)
                        Customer currentCustomer = new Customer(new Random().Next(100, 999), customerName);
                        Order currentOrder = orderService.CreateOrder(currentCustomer);

                        bool isOrdering = true;

                        // Внутрішній цикл для додавання товарів у кошик
                        while (isOrdering)
                        {
                            Console.Write("\nВведіть ID товару для покупки (або '0' щоб перейти до оплати): ");
                            string inputId = Console.ReadLine();

                            if (inputId == "0")
                            {
                                // Завершення вибору товарів та перехід до розрахунку
                                isOrdering = false;
                                orderService.Checkout(currentOrder);
                            }
                            else if (int.TryParse(inputId, out int productId))
                            {
                                Console.Write("Введіть необхідну кількість: ");
                                if (int.TryParse(Console.ReadLine(), out int quantity))
                                {
                                    // Спроба додати товар у кошик (з перевіркою залишків)
                                    orderService.TryAddProductToOrder(currentOrder, productId, quantity);
                                }
                                else
                                {
                                    Console.WriteLine("Помилка: Введено некоректну кількість.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Помилка: Введено некоректний ID.");
                            }
                        }
                        break;

                    case "0":
                        // Вихід з програми
                        isRunning = false;
                        Console.WriteLine("\nРоботу системи завершено. До побачення!");
                        break;

                    default:
                        // Обробка неправильного вводу в меню
                        Console.WriteLine("\nПомилка: Невідома команда. Будь ласка, оберіть 1, 2 або 0.");
                        break;
                }
            }
        }
    }
}