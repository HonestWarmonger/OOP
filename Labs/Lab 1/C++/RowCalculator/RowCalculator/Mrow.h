#ifndef MROW_H
#define MROW_H

#include <string>

class DigitString
{
private:
    std::string value; // Зберігаємо рядок

public:
    // Конструктор із початковим рядком
    DigitString(std::string str);

    // Обчислення довжини рядка
    int getLength();

    // Видалення 5 із рядка
    void removeChar5();

    // Гетер
    std::string getValue();

    // Сетер
    void setValue(std::string newVal);
};

#endif