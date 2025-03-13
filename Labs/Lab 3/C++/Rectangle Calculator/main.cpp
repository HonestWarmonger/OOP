#include <iostream>
#include "Rectangle.h"

using namespace std;

//Допоміжна функція для виводу інформації
void showRectangleInfo(const string& name, const Rectangle& r)
{
    cout << name << ":\n";
    cout << "  Координати: (" << r.getX1() << ", " << r.getY1() << ") "
        << "та (" << r.getX2() << ", " << r.getY2() << ")\n";
    cout << "  Площа = " << r.area()
        << ", Периметр = " << r.perimeter() << endl;
}

int main()
{
    //Створюємо три об'єкти Q1, Q2, Q3
    Rectangle Q1;
    Rectangle Q2(2.0, 2.0, 6.0, 5.0); //Параметричний
    Rectangle Q3(Q2);             //Копія Q2

    cout << "Початкові прямокутники:\n";
    showRectangleInfo("Q1", Q1);
    showRectangleInfo("Q2", Q2);
    showRectangleInfo("Q3", Q3);
    cout << endl;

    //Зменшити Q2 в 2 рази
    Q2 = Q2 / 2.0;
    cout << "Після зменшення Q2 у 2 рази:\n";
    showRectangleInfo("Q2", Q2);
    cout << endl;

    //Відняти Q2 від Q3
    Q3 = Q3 - Q2;
    cout << "Після віднімання Q2 від Q3:\n";
    showRectangleInfo("Q3", Q3);
    cout << endl;

    //Помістити результат у Q1
    Q1 = Rectangle(Q3);
    cout << "Після \"поміщення\" Q3 у Q1:\n";
    showRectangleInfo("Q1", Q1);
    showRectangleInfo("Q2", Q2);
    showRectangleInfo("Q3", Q3);
    cout << endl;

    //Демонстрація перевантажених методів area()
    double normalArea = Q1.area();          //Без параметрів
    double scaledArea = Q1.area(0.5);       //area з scale=0.5

    cout << "Поточна площа Q1: " << normalArea << endl;
    cout << "Площа Q1 при scale=0.5: " << scaledArea << endl;

    return 0;
}