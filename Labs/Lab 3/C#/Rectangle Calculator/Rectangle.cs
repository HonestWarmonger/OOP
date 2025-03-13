using System;

namespace Lab1_3_Rectangles
{
    public class Rectangle
    {
        private double x1, y1;
        private double x2, y2;

        //Конструктор за замовчуванням
        public Rectangle()
        {
            x1 = 0.0;
            y1 = 0.0;
            x2 = 1.0;
            y2 = 1.0;
        }

        //Конструктор з параметрами
        public Rectangle(double x1Val, double y1Val,
                         double x2Val, double y2Val)
        {
            x1 = x1Val;
            y1 = y1Val;
            x2 = x2Val;
            y2 = y2Val;
        }

        //Конструктор копіювання
        public Rectangle(Rectangle other)
        {
            x1 = other.x1;
            y1 = other.y1;
            x2 = other.x2;
            y2 = other.y2;
        }

        //Перевантаження методів
        //Площа без параметрів
        public double Area()
        {
            double width = Math.Abs(x2 - x1);
            double height = Math.Abs(y2 - y1);
            return width * height;
        }

        //Площа з масштабом scale
        public double Area(double scale)
        {
            //Якщо масштабуємо кожну сторону на scale,
            //площа змінюється у (scale^2) разів.
            double baseArea = this.Area();
            return baseArea * (scale * scale);
        }

        //Периметр
        public double Perimeter()
        {
            double width = Math.Abs(x2 - x1);
            double height = Math.Abs(y2 - y1);
            return 2.0 * (width + height);
        }

        //Гетери
        public double GetX1() { return x1; }
        public double GetY1() { return y1; }
        public double GetX2() { return x2; }
        public double GetY2() { return y2; }

        //Перевантаження операторів
        //Оператор віднімання
        public static Rectangle operator -(Rectangle r1, Rectangle r2)
        {
            return new Rectangle(
                r1.x1 - r2.x1,
                r1.y1 - r2.y1,
                r1.x2 - r2.x2,
                r1.y2 - r2.y2
            );
        }

        //Оператор ділення
        public static Rectangle operator /(Rectangle r, double val)
        {
            //Не перевіряємо val на 0
            return new Rectangle(
                r.x1 / val,
                r.y1 / val,
                r.x2 / val,
                r.y2 / val
            );
        }
    }
}