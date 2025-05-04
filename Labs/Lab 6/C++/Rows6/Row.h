#pragma once
#include <string>
#include "IWhitespaceCleaner.h"

class Row {
    std::string data;
public:
    explicit Row(std::string text = "") : data(std::move(text)) {}
    const std::string& Get() const { return data; }
    void Set(const std::string& txt) { data = txt; }
    size_t Length() const { return data.length(); }

    // Підрахунок приголосних (латиниця + укр.)
    static size_t CountConsonants(const std::string& str);
}