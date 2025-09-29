using System;
using Lab31V11.Domain;

namespace Lab31V11.UI
{
    public static class ConsoleMenu
    {
        public static void PrintHeader(string title)
        {
            Console.WriteLine(new string('=', 60));
            Console.WriteLine(title);
            Console.WriteLine(new string('=', 60));
        }

        public static void ShowTarget(Student[] students, int count)
        {
            // Рахуємо студентiв-чоловiкiв 3-го курсу, що проживають у гуртожитку
            int n = 0;
            for (int i = 0; i < count; i++)
            {
                var s = students[i];
                if (s != null &&
                    s.Course == 3 &&
                    s.Gender == Gender.Male &&
                    s.LivesInDorm)
                {
                    n++;
                }
            }

            Console.WriteLine($"Кiлькiсть студентiв-чоловiкiв 3-го курсу, що живуть у гуртожитку: {n}\n");

            for (int i = 0; i < count; i++)
            {
                var s = students[i];
                if (s != null &&
                    s.Course == 3 &&
                    s.Gender == Gender.Male &&
                    s.LivesInDorm)
                {
                    Console.WriteLine($"- {s.FullName} | ID: {s.StudentId} | Гурт.: {s.DormNumber}, кiмн. {s.DormRoom}");
                }
            }
            Console.WriteLine();
        }
    }
}
