#include "DigitString.h"
#include <algorithm>

//Конструктор за замовчуванням
DigitString::DigitString()
    : value("")
{

}

//Конструктор з параметром
DigitString::DigitString(const std::string& initialValue)
    : value(initialValue)
{

}

//Конструктор копіювання
DigitString::DigitString(const DigitString& other)
    : value(other.value)
{

}

//Деструктор
DigitString::~DigitString()
{

}

int DigitString::getLength() const
{
    return static_cast<int>(value.size());
}

void DigitString::removeChar5()
{
    value.erase(std::remove(value.begin(), value.end(), '5'), value.end());
}

// Повернути поточний рядок
std::string DigitString::getValue() const
{
    return value;
}