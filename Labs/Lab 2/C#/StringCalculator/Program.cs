using System;
using DigitStringLib;

namespace DigitStringConsole
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            //Конструктор за замовчуванням
            DigitString dsDefault = new DigitString();
            Console.WriteLine("dsDefault (конструктор за замовчуванням):");
            Console.WriteLine($"  Рядок: \"{dsDefault.GetValue()}\"");
            Console.WriteLine($"  Довжина: {dsDefault.GetLength()}\n");

            //Конструктор з параметром
            Console.WriteLine("Введіть рядок (цифрові символи): ");
            string input = Console.ReadLine();

            DigitString dsParam = new DigitString(input);
            Console.WriteLine("\ndsParam (конструктор з параметрами):");
            Console.WriteLine($"  Рядок: \"{dsParam.GetValue()}\"");
            Console.WriteLine($"  Довжина: {dsParam.GetLength()}");

            //Видаляємо 5
            dsParam.RemoveChar5();
            Console.WriteLine($"  Після видалення '5': \"{dsParam.GetValue()}\"");
            Console.WriteLine($"  Нова довжина: {dsParam.GetLength()}\n");

            //Конструктор копіювання
            DigitString dsCopy = new DigitString(dsParam);
            Console.WriteLine("dsCopy (конструктор копіювання з dsParam):");
            Console.WriteLine($"  Рядок: \"{dsCopy.GetValue()}\"");
            Console.WriteLine($"  Довжина: {dsCopy.GetLength()}");

            Console.WriteLine("\nНатисніть будь-яку клавішу для завершення...");
            Console.ReadKey();
        }
    }
}