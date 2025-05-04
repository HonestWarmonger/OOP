#include "Row.h"
#include <cctype>
#include <unordered_set>

size_t Row::CountConsonants(const std::string& str) {
    static const std::unordered_set<char> vowels =
    { 'a','e','i','o','u',
     'A','E','I','O','U',
     'а','е','є','и','і','о','у','ю','я',
     'А','Е','Є','И','І','О','У','Ю','Я' };
    size_t cnt = 0;
    for (char ch : str) {
        if (std::isalpha(static_cast<unsigned char>(ch)) && !vowels.count(ch))
            ++cnt;
    }
    return cnt;
}