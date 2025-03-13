#include "Rectangle.h"
#include <cmath>

//Конструктор за замовчуванням
Rectangle::Rectangle()
    : x1(0.0), y1(0.0), x2(1.0), y2(1.0)
{
}

//Конструктор з параметрами
Rectangle::Rectangle(double x1Val, double y1Val,
    double x2Val, double y2Val)
    : x1(x1Val), y1(y1Val), x2(x2Val), y2(y2Val)
{
}

//Конструктор копіювання
Rectangle::Rectangle(const Rectangle& other)
{
    x1 = other.x1;
    y1 = other.y1;
    x2 = other.x2;
    y2 = other.y2;
}

double Rectangle::area() const
{
    double width = std::fabs(x2 - x1);
    double height = std::fabs(y2 - y1);
    return width * height;
}

double Rectangle::area(double scale) const
{

    double baseArea = this->area();
    return baseArea * (scale * scale);
}

double Rectangle::perimeter() const
{
    double width = std::fabs(x2 - x1);
    double height = std::fabs(y2 - y1);
    return 2.0 * (width + height);
}

//Гетери
double Rectangle::getX1() const { return x1; }
double Rectangle::getY1() const { return y1; }
double Rectangle::getX2() const { return x2; }
double Rectangle::getY2() const { return y2; }

//Оператор віднімання
Rectangle Rectangle::operator-(const Rectangle& rhs) const
{
    return Rectangle(
        x1 - rhs.x1,
        y1 - rhs.y1,
        x2 - rhs.x2,
        y2 - rhs.y2
    );
}

/ Оператор ділення
Rectangle Rectangle::operator/(double val) const
{

    return Rectangle(
        x1 / val,
        y1 / val,
        x2 / val,
        y2 / val
    );
}