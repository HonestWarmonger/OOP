using System;
using RowLib;

class Program
{
    static void Demonstrate(Riadky obj)
    {
        Console.WriteLine("New length: " + obj.GetLength());
        Console.WriteLine("Processed string: " + obj.Increase());
    }

    static void Main()
    {
        Console.Write("Enter string: ");
        string input = Console.ReadLine();

        Rows[] arr = {
            new Numbers(input),
            new Symbols(input)
        };

        Console.WriteLine("\n-- Numbers --");
        Demonstrate(arr[0]);

        Console.WriteLine("\n-- Symbols --");
        Demonstrate(arr[1]);
    }
}