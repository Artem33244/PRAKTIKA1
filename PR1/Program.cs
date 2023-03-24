using System.Linq;
using System;

namespace PR1
{
    class Car
    {
        public int MaxSpeed { get; set; }
        public string Name { get; set; }

        public Car(int maxSpeed, string name)
        {
            MaxSpeed = maxSpeed;
            Name = name;
        }

        public double CalculateTime(double distance)
        {
            return Math.Ceiling(distance / MaxSpeed * 60);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int numRacers = 4;

            int[] speeds = new int[numRacers];
            string[] names = new string[numRacers];

            for (int i = 0; i < numRacers; i++)
            {
                speeds[i] = rnd.Next(100, 180);
                names[i] = "Автомобиль-" + rnd.Next(0, 99);
            }

            Car[] cars = new Car[numRacers];
            for (int i = 0; i < numRacers; i++)
            {
                cars[i] = new Car(speeds[i], names[i]);
            }

            double[] times = new double[numRacers];
            for (int i = 0; i < numRacers; i++)
            {
                times[i] = cars[i].CalculateTime(100);
            }

            int winnerIndex = Array.IndexOf(times, times.Min());
            string winnerName = cars[winnerIndex].Name;

            Console.WriteLine("Гоночки\nЗаезд на 100Км");
            Console.WriteLine($"\tПобедитель: \"{winnerName}\"");
            for (int i = 0; i < numRacers; i++)
            {
                Console.WriteLine($"{cars[i].Name}, \tV = {cars[i].MaxSpeed} Км/ч, t = {times[i]} м.");
            }

            Console.ReadKey(true);
        }
    }
}