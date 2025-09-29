using System;
using Lab31V11.Domain;
using Lab31V11.IO;
using Lab31V11.UI;

namespace Lab31V11
{
    internal class Program
    {
        private static readonly Student[] _students = new Student[256];
        private static readonly Seller[] _sellers = new Seller[64];
        private static readonly Gardener[] _gardeners = new Gardener[64];

        private static int _studentCount, _sellerCount, _gardenerCount;

        static void Main()
        {
            var path = "data_v11.txt";
            var ds = new TextFileDataSource(path);

            // Якщо файлу немає — згенеруємо демо-данi i збережемо
            if (!System.IO.File.Exists(path))
            {
                Seed();
                ds.SaveAll(_students, _studentCount, _sellers, _sellerCount, _gardeners, _gardenerCount);
            }

            // Почистимо i завантажимо з файлу
            Array.Clear(_students, 0, _students.Length);
            Array.Clear(_sellers, 0, _sellers.Length);
            Array.Clear(_gardeners, 0, _gardeners.Length);
            _studentCount = _sellerCount = _gardenerCount = 0;

            ds.LoadAll(_students, out _studentCount, _sellers, out _sellerCount, _gardeners, out _gardenerCount);

            ConsoleMenu.PrintHeader("ЛР 3.1 – варiант 11 (Student/Seller/Gardener, файл I/O)");
            ConsoleMenu.ShowTarget(_students, _studentCount);

            Console.WriteLine("Натиснiть будь-яку клавiшу для виходу...");
            Console.ReadKey(true);
        }

        private static void Seed()
        {
            // Декiлька студентiв, серед них — 3 курс чоловiки у гуртожитку
            _students[_studentCount++] = MakeStudent("Andriy", "Kravets", "KB0311", 3, Gender.Male, dorm: "5-412");
            _students[_studentCount++] = MakeStudent("Oleh", "Marchenko", "KB0312", 3, Gender.Male, dorm: "2-118");
            _students[_studentCount++] = MakeStudent("Denys", "Hnatyk", "KB0210", 2, Gender.Male, city: "Kyiv");
            _students[_studentCount++] = MakeStudent("Ihor", "Stepanov", "KB0301", 3, Gender.Male, city: "Lviv");
            _students[_studentCount++] = MakeStudent("Iryna", "Melnyk", "KB0107", 1, Gender.Female, dorm: "1-217");

            _sellers[_sellerCount++] = new Seller("Serhii", "Prodan", "Grocery-7");
            _gardeners[_gardenerCount++] = new Gardener("Petro", "Sadovyi", "Campus North");
        }

        private static Student MakeStudent(string fn, string ln, string id, int course, Gender g, string dorm = null, string city = null)
        {
            var s = new Student(fn, ln, id, course, g);
            if (!string.IsNullOrWhiteSpace(dorm))
            {
                var p = dorm.Split('-');
                int dormNo = int.Parse(p[0]);
                var room = p.Length > 1 ? p[1] : "";
                s.SetDorm(dormNo, room);
            }
            else s.SetCity(city ?? "");
            return s;
        }
    }
}
