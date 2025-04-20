#ifndef ROWLIB_H
#define ROWLIB_H

#include <string>

class Rows {
protected:
    std::string str;
public:
    Rows(const std::string& s) : str(s) {}
    virtual ~Rows() {}
    virtual int getLength() const = 0;
    virtual std::string increase() const = 0;
};

class Numbers : public Rows {
public:
    Numbers(const std::string& s) : Rows(s) {}
    int getLength() const override;
    std::string increase() const override;
};

class Symbols : public Rows {
public:
    Symbols(const std::string& s) : Rows(s) {}
    int getLength() const override;
    std::string increase() const override;
};

#endif // RIADKYLIB_H