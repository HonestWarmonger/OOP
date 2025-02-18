#include <iostream>
#include <string>
#include "DigitString.h"

int main()
{
    //Виклик конструктора за замовчуванням
    DigitString dsDefault;
    std::cout << "dsDefault (конструктор за замовчуванням):\n";
    std::cout << "  Поточний рядок: \"" << dsDefault.getValue() << "\"\n";
    std::cout << "  Довжина: " << dsDefault.getLength() << "\n\n";

    //Виклик конструктора з параметром
    std::cout << "Введіть рядок (цифрові символи): ";
    std::string input;
    std::cin >> input;
    DigitString dsParam(input);

    std::cout << "\nСтворили dsParam (конструктор з параметрами):\n";
    std::cout << "  Рядок: \"" << dsParam.getValue() << "\"\n";
    std::cout << "  Довжина: " << dsParam.getLength() << "\n";

    //Видаляємо 5
    dsParam.removeChar5();
    std::cout << "  Після видалення '5': \"" << dsParam.getValue() << "\"\n";
    std::cout << "  Нова довжина: " << dsParam.getLength() << "\n\n";

    //Конструктор копіювання
    DigitString dsCopy = dsParam;
    std::cout << "dsCopy (конструктор копіювання з dsParam):\n";
    std::cout << "  Рядок: \"" << dsCopy.getValue() << "\"\n";
    std::cout << "  Довжина: " << dsCopy.getLength() << "\n";


    return 0;
}