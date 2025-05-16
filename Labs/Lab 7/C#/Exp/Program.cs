using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var list = new List<Expression>
        {
            new Expression(2, 3, 4, 1),
            new Expression(1, 1, 4, 2),
            new Expression(0, 2, 8, 1)
        };

        foreach (var expr in list)
        {
            try
            {
                double result = expr.Calculate();
                Console.WriteLine($"{expr} => {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{expr} => Помилка: {ex.Message}");
            }
        }
    }
}
