#include "Text.h"
#include <sstream>
#include <algorithm>
#include <cctype>

std::string Text::NormalizeSpaces(const std::string& s) const {
    std::ostringstream out;
    bool prevSpace = false;
    for (char ch : s) {
        if (std::isspace(static_cast<unsigned char>(ch))) {
            if (!prevSpace) { out << ' '; }
            prevSpace = true;
        }
        else {
            out << ch;
            prevSpace = false;
        }
    }
    return out.str();
}

std::string Text::Trim(const std::string& s) const {
    size_t start = 0, end = s.size();
    while (start < end && std::isspace(static_cast<unsigned char>(s[start]))) ++start;
    while (end > start && std::isspace(static_cast<unsigned char>(s[end - 1]))) --end;
    return s.substr(start, end - start);
}

void Text::AddRow(const Row& r) { rows.push_back(r); }

bool Text::RemoveRow(size_t index) {
    if (index >= rows.size()) return false;
    rows.erase(rows.begin() + index);
    return true;
}

void Text::Clear() { rows.clear(); }

size_t Text::ShortestRowLength() const {
    if (rows.empty()) return 0;
    size_t mn = rows.front().Length();
    for (const auto& r : rows) mn = std::min(mn, r.Length());
    return mn;
}

double Text::ConsonantPercentage() const {
    size_t totalLetters = 0, consonants = 0;
    for (const auto& r : rows) {
        const std::string& s = r.Get();
        totalLetters += std::count_if(s.begin(), s.end(), ::isalpha);
        consonants += Row::CountConsonants(s);
    }
    return totalLetters ? (100.0 * consonants / totalLetters) : 0.0;
}