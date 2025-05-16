using System;

class Program
{
    static void Main()
    {
        // Створюємо таблицю з 3 студентів
        StudentTable table = new StudentTable(3);

        // Додаємо студентів через індексатор
        table[0] = new Student("Петро", "Панченко", "Олексійович");
        table[1] = new Student("Іван", "Іваненко", "Іванович");
        table[2] = new Student("Олена", "Петренко", "Сергіївна");

        // Виводимо всіх студентів
        for (int i = 0; i < table.Count; i++)
        {
            Console.WriteLine($"Студент {i + 1}: {table[i]}");
        }

        // Виводимо кількість студентів
        Console.WriteLine($"Кількість студентів у таблиці: {table.Count}");
    }
}
