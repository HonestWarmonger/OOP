#include <iostream>
#include <memory>
#include "RowLib.h"

// демонстраційний метод поза класами
void demonstrate(const Rows& obj) {
    std::cout << "New length: " << obj.getLength() << "\n";
    std::cout << "Processed string: " << obj.increase() << "\n";
}

int main() {
    std::cout << "Enter string: ";
    std::string input;
    std::getline(std::cin, input);

    std::unique_ptr<Rows> arr[2];
    arr[0] = std::make_unique<Numbers>(input);
    arr[1] = std::make_unique<Symbols>(input);

    std::cout << "\n-- Numbers --\n";
    demonstrate(*arr[0]);

    std::cout << "\n-- Symbols --\n";
    demonstrate(*arr[1]);

    return 0;
}