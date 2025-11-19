using System;
using StudentSystem.BLL;
using StudentSystem.Core;

namespace StudentSystem.PL
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            StudentService service = new StudentService();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== СИСТЕМА СТУДЕНТІВ ===");
                Console.WriteLine("1. Показати всіх студентів");
                Console.WriteLine("2. Додати студента");
                Console.WriteLine("3. Чоловіки 3-го курсу в гуртожитку");
                Console.WriteLine("4. Переселити студента");
                Console.WriteLine("5. Чи вміє студент спати стоячи?");
                Console.WriteLine("0. Вихід");
                Console.Write("\nВаш вибір > ");

                switch (Console.ReadLine())
                {
                    case "1": ShowAll(service); break;
                    case "2": AddNew(service); break;
                    case "3":
                        Console.WriteLine($"\nЗнайдено: {service.CountMale3rdYearInDorm()}");
                        Console.ReadKey();
                        break;
                    case "4": Relocate(service); break;
                    case "5": CheckAbility(service); break;
                    case "0": return;
                }
            }
        }

        static void ShowAll(StudentService service)
        {
            var list = service.GetAll();
            Console.WriteLine("\n--- Список студентів ---");
            foreach (var s in list)
            {

                Console.WriteLine(s.ToString());
            }
            Console.ReadKey();
        }

        static void AddNew(StudentService service)
        {
            var s = new Student();

            Console.Write("\nПрізвище: "); s.LastName = Console.ReadLine();
            Console.Write("Ім'я: "); s.FirstName = Console.ReadLine();
            Console.Write("Квиток: "); s.StudentTicketId = Console.ReadLine();
            Console.Write("Курс (1-6): "); s.Course = int.Parse(Console.ReadLine());

            Console.Write("Стать (0-Ч, 1-Ж): ");
            s.Gender = (Gender)int.Parse(Console.ReadLine());

            Console.Write("В гуртожитку? (y/n): ");
            if (Console.ReadLine() == "y")
            {
                Console.Write("Номер кімнати: ");
                s.Residence = Console.ReadLine();
            }

            service.AddStudent(s);
            Console.WriteLine("Студента додано.");
        }

        static void Relocate(StudentService service)
        {
            Console.Write("\nВведіть квиток: "); string id = Console.ReadLine();
            Console.Write("Нова кімната: "); string room = Console.ReadLine();

            if (service.RelocateStudent(id, room)) Console.WriteLine("Успішно!");
            else Console.WriteLine("Студента не знайдено.");
            Console.ReadKey();
        }

        static void CheckAbility(StudentService service)
        {
            Console.WriteLine("\n--- Перевірка Сну Стоячи ---");
            Console.Write("Введіть квиток студента: ");
            string id = Console.ReadLine();

            var student = service.FindStudent(id);
            if (student != null)
            {

                Console.WriteLine($"\n{student.Sleep()}");
            }
            else
            {
                Console.WriteLine("\nСтудента не знайдено.");
            }
            Console.ReadKey();
        }
    }
}