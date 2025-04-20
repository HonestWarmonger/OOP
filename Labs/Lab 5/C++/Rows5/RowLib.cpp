#include "RowLib.h"
#include <algorithm>  // for std::count

int Numbers::getLength() const {
    return static_cast<int>(str.length() * 2);
}

std::string Numbers::increase() const {
    std::string res;
    for (char c : str) {
        res += c;
        res += c;
    }
    return res;
}

int Symbols::getLength() const {
    // кожен 'k' додає ще одну позицію
    return static_cast<int>(str.length() + std::count(str.begin(), str.end(), 'k'));
}

std::string Symbols::increase() const {
    std::string res;
    for (char c : str) {
        res += c;
        if (c == 'k') {
            res += 'k';
        }
    }
    return res;
}