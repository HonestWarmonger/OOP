#include <iostream>
#include <string>
#include "Mrow.h"

int main()
{
    setlocale(LC_ALL, ""); // Для відображення українських символів

    std::string inputStr;
    std::cout << "Введіть рядок(цифри): ";
    std::cin >> inputStr;

    // Створюємо об’єкт класу DigitString
    DigitString ds(inputStr);

    // Виводимо рядок
    std::cout << "Введено: " << ds.getValue() << "\n";

    // Обчислюємо довжину і виводимо
    std::cout << "Довжина: " << ds.getLength() << "\n";

    // Викликаємо метод removeChar5()
    ds.removeChar5();

    // Знову виводимо рядок і його довжину
    std::cout << "\nБез 5:\n";
    std::cout << "Рядок: " << ds.getValue() << "\n";
    std::cout << "Довжина: " << ds.getLength() << "\n";

    return 0;
}