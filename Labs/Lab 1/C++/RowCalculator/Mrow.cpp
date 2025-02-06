#include "Mrow.h"
#include <algorithm> // для std::remove

// Ініціалізуємо поле value отриманим рядком
DigitString::DigitString(std::string str) : value(str)
{
}

// Повертаємо довжину рядка
int DigitString::getLength()
{
    return value.size();
}

// Видаляємо 5
void DigitString::removeChar5()
{
    // Зсуваєво 5 в кінець, та видаляємо
    value.erase(std::remove(value.begin(), value.end(), '5'), value.end());
}

// Гетер повертає поточне значення
std::string DigitString::getValue()
{
    return value;
}

// Сетер встановлює нове значення
void DigitString::setValue(std::string newVal)
{
    value = newVal;
}