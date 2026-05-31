using System;
using System.IO;
using Xunit;
using FishingStoreApp.Models;
using FishingStoreApp.Services;

namespace FishingStoreApp.Tests
{
    // Допоміжний клас для тестування файлів
    public class ReceiptLogger
    {
        public void SaveReceipt(string filePath, string content)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentException("Шлях до файлу не може бути порожнім!");
            }
            File.WriteAllText(filePath, content);
        }
    }

    public class FishingStoreTests
    {
        // 1. БІЗНЕС-ЛОГІКА (Позитивний сценарій)
        [Fact]
        public void TryAddProductToOrder_SufficientStock_ReturnsTrueAndAddsItem()
        {
            // Arrange
            var inventory = new InventoryService();
            inventory.AddProduct(new Product(1, "Спінінг Shimano", "Вудилища", 1500m, 5));
            var orderService = new OrderService(inventory);
            var order = orderService.CreateOrder(new Customer(1, "Тестовий Клієнт"));

            // Act
            bool result = orderService.TryAddProductToOrder(order, 1, 2);

            // Assert
            Assert.True(result);
            Assert.Single(order.Items);
        }

        // 2. БІЗНЕС-ЛОГІКА (Негативний сценарій)
        [Fact]
        public void TryAddProductToOrder_InsufficientStock_ReturnsFalseAndDoesNotAdd()
        {
            // Arrange
            var inventory = new InventoryService();
            inventory.AddProduct(new Product(1, "Котушка Daiwa", "Котушки", 1200m, 2));
            var orderService = new OrderService(inventory);
            var order = orderService.CreateOrder(new Customer(1, "Тестовий Клієнт"));

            // Act
            bool result = orderService.TryAddProductToOrder(order, 1, 5);

            // Assert
            Assert.False(result);
            Assert.Empty(order.Items);
        }

        // 3. ДОПОМІЖНЕ ЗАВДАННЯ (Позитивний сценарій)
        [Fact]
        public void SaveReceipt_ValidPath_CreatesFile()
        {
            // Arrange
            var logger = new ReceiptLogger();
            string testFilePath = "test_receipt.txt";
            string content = "Сума чеку: 1500 грн";

            // Act
            logger.SaveReceipt(testFilePath, content);

            // Assert
            Assert.True(File.Exists(testFilePath));

            // Cleanup
            if (File.Exists(testFilePath))
            {
                File.Delete(testFilePath);
            }
        }

        // 4. ДОПОМІЖНЕ ЗАВДАННЯ (Негативний сценарій)
        [Fact]
        public void SaveReceipt_EmptyPath_ThrowsArgumentException()
        {
            // Arrange
            var logger = new ReceiptLogger();
            string invalidPath = "";
            string content = "Сума чеку: 1500 грн";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => logger.SaveReceipt(invalidPath, content));
        }
    }
}