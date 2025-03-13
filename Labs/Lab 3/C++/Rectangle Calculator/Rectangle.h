#ifndef RECTANGLE_H
#define RECTANGLE_H

class Rectangle
{
private:
    double x1, y1;  //Координати першої вершини
    double x2, y2;  //Координати протилежної вершини

public:
    //Конструктор за замовчуванням
    Rectangle();

    //Конструктор з параметрами
    Rectangle(double x1Val, double y1Val, double x2Val, double y2Val);

    //Конструктор копіювання
    Rectangle(const Rectangle& other);

    //Перевантаження методів
    //Площа без параметрів
    double area() const;

    //Площа з масштабом
    double area(double scale) const;

    //Периметр
    double perimeter() const;

    //Гетери
    double getX1() const;
    double getY1() const;
    double getX2() const;
    double getY2() const;

    //Перевантаження операторів
    //Оператор віднімання (покомпонентне)
    Rectangle operator-(const Rectangle& rhs) const;

    //Оператор ділення на число
    Rectangle operator/(double val) const;
};

#endif