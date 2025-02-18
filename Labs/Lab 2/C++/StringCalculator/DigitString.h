#ifndef DIGITSTRING_H
#define DIGITSTRING_H

#include <string>

class DigitString
{
private:
    std::string value;

public:
    //Конструктор за замовчуванням
    DigitString();

    //Конструктор з параметром
    DigitString(const std::string& initialValue);

    //Конструктор копіювання
    DigitString(const DigitString& other);

    //Деструктор
    ~DigitString();

    int getLength() const;

    void removeChar5();

    std::string getValue() const;
};

#endif