using System;

namespace Lab1_3_Rectangles
{
    class Program
    {
        static void Main(string[] args)
        {
            //Створюємо три об'єкти Q1, Q2, Q3
            Rectangle Q1 = new Rectangle();                //За замовчуванням
            Rectangle Q2 = new Rectangle(2, 2, 6, 5);      //З параметрами
            Rectangle Q3 = new Rectangle(Q2);             //Копія Q2

            Console.WriteLine("Початкові прямокутники:");
            ShowRectangleInfo("Q1", Q1);
            ShowRectangleInfo("Q2", Q2);
            ShowRectangleInfo("Q3", Q3);
            Console.WriteLine();

            //Зменшити Q2 в 2 рази
            Q2 = Q2 / 2.0;  //Використання оператора
            Console.WriteLine("Після зменшення Q2 у 2 рази:");
            ShowRectangleInfo("Q2", Q2);
            Console.WriteLine();

            //Відняти Q2 від Q3
            Q3 = Q3 - Q2; //Використання оператора -
            Console.WriteLine("Після віднімання Q2 від Q3:");
            ShowRectangleInfo("Q3", Q3);
            Console.WriteLine();

            //Помістити Q3 у Q1
            Q1 = new Rectangle(Q3);
            Console.WriteLine("Після \"поміщення\" Q3 у Q1:");
            ShowRectangleInfo("Q1", Q1);
            ShowRectangleInfo("Q2", Q2);
            ShowRectangleInfo("Q3", Q3);
            Console.WriteLine();

            //Демонстрація перевантажених методів Area()
            double normalArea = Q1.Area();
            double scaledArea = Q1.Area(0.5);
            Console.WriteLine($"Поточна площа Q1 = {normalArea}");
            Console.WriteLine($"Площа Q1 при scale=0.5 = {scaledArea}");

            Console.ReadLine();
        }

        static void ShowRectangleInfo(string name, Rectangle r)
        {
            Console.WriteLine($"{name}:");
            Console.WriteLine($"  Координати: (x1={r.GetX1()}, y1={r.GetY1()}) " +
                              $"та (x2={r.GetX2()}, y2={r.GetY2()})");
            Console.WriteLine($"  Площа = {r.Area()}, Периметр = {r.Perimeter()}");
        }
    }
}