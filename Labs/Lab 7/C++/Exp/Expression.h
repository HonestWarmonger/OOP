#pragma once
#include <string>

class Expression {
private:
    double a, b, c, d;

public:
    Expression(double a, double b, double c, double d);
    double calculate() const;
    std::string toString() const;
};
