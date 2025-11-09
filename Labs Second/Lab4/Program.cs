using System;

namespace Lab34.Var11
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("=== Делегати ===");

            CountLowerDelegate viaAnonymous = delegate (string text)
            {
                if (string.IsNullOrEmpty(text)) return 0;
                int count = 0;
                foreach (char c in text)
                    if (char.IsLower(c)) count++;
                return count;
            };

            CountLowerDelegate viaLambda = text =>
                string.IsNullOrEmpty(text) ? 0 : text.Count(char.IsLower);

            string example = "MetalScape Project";
            Console.WriteLine($"[Anon] Кількість малих літер у \"{example}\" = {viaAnonymous(example)}");
            Console.WriteLine($"[Lambda] Кількість малих літер у \"{example}\" = {viaLambda(example)}");

            Console.WriteLine("\n=== Події ===");

            var car = new Machine(maxSpeed: 120);

            car.SpeedExceeded += msg => Console.WriteLine("[Подія] " + msg);

            car.Start();
            car.Accelerate(40);
            car.Accelerate(50);
            car.Accelerate(60);
            car.Stop();
        }
    }
}