using System;

namespace DigitStringApp
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Введіть рядок (цифрові символи): ");
            string inputStr = Console.ReadLine();

            // Створюємо об’єкт класу DigitString
            DigitString ds = new DigitString(inputStr);

            // Виводимо початковий рядок
            Console.WriteLine($"Ви ввели: {ds.GetValue()}");

            // Обчислюємо довжину
            Console.WriteLine($"Довжина рядка: {ds.GetLength()}");

            // Видаляємо 5
            ds.RemoveChar5();

            // Знову виводимо результат
            Console.WriteLine("\nПісля видалення '5':");
            Console.WriteLine($"Рядок: {ds.GetValue()}");
            Console.WriteLine($"Довжина рядка: {ds.GetLength()}");

            Console.ReadKey();
        }
    }
}