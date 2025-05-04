#include <iostream>
#include "Text.h"

int main() {
    Text txt;
    txt.AddRow(Row("  Hello,    world!  "));
    txt.AddRow(Row("C++   is   fun"));
    txt.AddRow(Row("   Kyiv  is   beautiful   "));

    std::cout << "Shortest row length: "
        << txt.ShortestRowLength() << "\n";
    std::cout << "Consonant %: "
        << txt.ConsonantPercentage() << "\n";

    // Нормалізуємо пробіли у першому рядку
    std::string cleaned = txt.NormalizeSpaces(
        txt.Trim(txt.NormalizeSpaces(txt.NormalizeSpaces("  Hello,    world!  "))));
    std::cout << "Cleaned: [" << cleaned << "]\n";
}