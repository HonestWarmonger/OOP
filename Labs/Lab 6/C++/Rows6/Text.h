#pragma once
#include <vector>
#include "Row.h"

class Text : public IWhitespaceCleaner {
    std::vector<Row> rows;
public:
    // --- IWhitespaceCleaner ---
    std::string NormalizeSpaces(const std::string& s) const override;
    std::string Trim(const std::string& s) const override;

    // --- керування рядками ---
    void AddRow(const Row& r);
    bool RemoveRow(size_t index);
    void Clear();

    // --- статистика ---
    size_t ShortestRowLength() const;
    double ConsonantPercentage() const;
}