#pragma once
#include <string>

class IWhitespaceCleaner {
public:
    virtual std::string NormalizeSpaces(const std::string& s) const = 0;
    virtual std::string Trim(const std::string& s) const = 0;
    virtual ~IWhitespaceCleaner() = default;
}