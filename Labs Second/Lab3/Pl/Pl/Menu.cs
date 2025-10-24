using System;
using System.Collections.Generic;
using DAL;
using DAL.Data;
using DAL.Entities;
using BLL;

namespace PL
{
    public static class Menu
    {
        public static void MainMenu()
        {
            var ctx = new EntityContext(new JsonProvider<MyString>());
            var service = new EntityService(ctx);
            var path = "strings" + ctx.Ext;

            var data = new List<MyString>
            {
                new("Hello world"),
                new("C# serialization"),
                new("Lab work 3.3"),
                new("Visual Studio"),
                new("Student project")
            };

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== ЛР 3.3 (варiант 11) ===");
                Console.WriteLine("1) Зберегти об'єкти у файл");
                Console.WriteLine("2) Прочитати з файлу");
                Console.WriteLine("3) Знайти пiдрядок");
                Console.WriteLine("4) Вставити пiдрядок");
                Console.WriteLine("5) Замiнити пiдрядок");
                Console.WriteLine("0) Вихiд");
                Console.Write("Обери: ");
                var k = Console.ReadLine();

                if (k == "1")
                {
                    service.Save(path, data);
                    Pause("Збережено у " + path);
                }
                else if (k == "2")
                {
                    var list = service.Load(path);
                    Console.WriteLine("Прочитано:");
                    list.ForEach(s => Console.WriteLine(" - " + s));
                    Pause();
                }
                else if (k == "3")
                {
                    Console.Write("Введи пiдрядок для пошуку: ");
                    string sub = Console.ReadLine() ?? "";
                    foreach (var s in data)
                        Console.WriteLine($"{s.Value} → позицiя {s.FindSubstring(sub)}");
                    Pause();
                }
                else if (k == "4")
                {
                    Console.Write("Пiдрядок для вставки: ");
                    string sub = Console.ReadLine() ?? "";
                    Console.Write("Позицiя (число): ");
                    int pos = int.TryParse(Console.ReadLine(), out int p) ? p : 0;
                    data = service.InsertAll(data, pos, sub);
                    Pause("Вставлено!");
                }
                else if (k == "5")
                {
                    Console.Write("Що замiнити: ");
                    string oldSub = Console.ReadLine() ?? "";
                    Console.Write("На що: ");
                    string newSub = Console.ReadLine() ?? "";
                    data = service.ReplaceAll(data, oldSub, newSub);
                    Pause("Замiнено!");
                }
                else if (k == "0") break;
            }
        }

        static void Pause(string msg = "")
        {
            Console.WriteLine(msg);
            Console.WriteLine("Натисни Enter...");
            Console.ReadLine();
        }
    }
}
