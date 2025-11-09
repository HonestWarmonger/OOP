using System;

namespace Lab34.Var11
{
    public class Machine
    {
        private int _speed;
        public int MaxSpeed { get; }

        public delegate void SpeedExceededHandler(string message);
        public event SpeedExceededHandler? SpeedExceeded;

        public Machine(int maxSpeed)
        {
            if (maxSpeed <= 0)
                throw new ArgumentOutOfRangeException(nameof(maxSpeed), "Максимальна швидкість має бути > 0");
            MaxSpeed = maxSpeed;
            _speed = 0;
        }

        public void Start()
        {
            _speed = 0;
            Console.WriteLine("Машина запущена. Швидкість: 0 км/год");
        }

        public void Accelerate(int delta)
        {
            if (delta <= 0) return;
            _speed += delta;
            Console.WriteLine($"Розгін: +{delta} км/год → {_speed} км/год");

            if (_speed > MaxSpeed)
                SpeedExceeded?.Invoke($"⚠️ Перевищено максимально допустиму швидкість! ({_speed} > {MaxSpeed})");
        }

        public void Stop()
        {
            _speed = 0;
            Console.WriteLine("Машина зупинилась.");
        }
    }
}