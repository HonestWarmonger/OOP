#include <iostream>
#include <vector>
#include "Expression.h"

int main() {
    std::vector<Expression> arr = {
        Expression(2, 3, 4, 1),
        Expression(1, 1, 4, 2),
        Expression(0, 2, 8, 1)
    };

    for (auto& expr : arr) {
        try {
            double result = expr.calculate();
            std::cout << expr.toString() << " => " << result << std::endl;
        }
        catch (const std::exception& ex) {
            std::cout << expr.toString() << " => Помилка: " << ex.what() << std::endl;
        }
    }

    return 0;
}
