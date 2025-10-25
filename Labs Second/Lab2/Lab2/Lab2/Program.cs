using System;
using System.Collections.Generic;
using Lab32_Var11.Domain;
using Lab32_Var11.Collections;

namespace Lab32_Var11
{
    internal class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Лаба 3.2 — Варіант 11 (Рядок)\n");

            var s1 = new MyString("Hello World");
            var s2 = new MyString("C# is cool");
            var s3 = new MyString("Programming");
            var s4 = new MyString("Lab work");
            var s5 = new MyString("OOP");

            var list = new List<MyString> { s1, s2, s3 };
            Console.WriteLine("List<MyString> початково:"); Print(list);

            list.Add(s4);
            list.Insert(1, s5);
            Console.WriteLine("\nList після Add + Insert:"); Print(list);

            Console.WriteLine($"\n{s1} містить 'World'? {s1.Contains("World")}");

            s2.Insert(3, " language");
            Console.WriteLine($"Після вставки: {s2}");

            s3.Replace("ming", "mer");
            Console.WriteLine($"Після заміни: {s3}");

            MyString[] array = { s1, s2, s3, s4, s5 };
            Console.WriteLine("\nМасив рядків:"); Print(array);

            var tree = new BinarySearchTree<MyString>();
            foreach (var s in array) tree.Add(s);

            Console.WriteLine("\nBST PostOrder (Left -> Right -> Node):");
            foreach (var s in tree) Console.WriteLine(s);

            Console.WriteLine("\nГотово. Натисніть клавішу...");
            Console.ReadKey();
        }

        static void Print(IEnumerable<MyString> seq)
        {
            foreach (var s in seq) Console.WriteLine(s);
        }
    }
}