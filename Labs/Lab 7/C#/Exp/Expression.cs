using System;

public class Expression
{
    public double A { get; set; }
    public double B { get; set; }
    public double C { get; set; }
    public double D { get; set; }

    public Expression(double a, double b, double c, double d)
    {
        A = a; B = b; C = c; D = d;
    }

    public double Calculate()
    {
        double numerator = (4 * B - C) * A;
        double denominator = B + C / D - 1;

        if (numerator <= 0)
            throw new ArgumentException("Логарифм від <= 0");

        if (denominator == 0)
            throw new DivideByZeroException("Ділення на нуль");

        return Math.Log10(numerator) / denominator;
    }

    public override string ToString()
    {
        return $"a={A} b={B} c={C} d={D}";
    }
}
