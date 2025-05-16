#include "Expression.h"
#include <cmath>
#include <stdexcept>
#include <sstream>

Expression::Expression(double a, double b, double c, double d) : a(a), b(b), c(c), d(d) {}

double Expression::calculate() const {
    double numerator = (4 * b - c) * a;
    double denominator = b + c / d - 1;

    if (numerator <= 0) throw std::domain_error("Логарифм від <= 0");
    if (denominator == 0) throw std::runtime_error("Ділення на нуль");

    return log10(numerator) / denominator;
}

std::string Expression::toString() const {
    std::ostringstream oss;
    oss << "a=" << a << " b=" << b << " c=" << c << " d=" << d;
    return oss.str();
}
