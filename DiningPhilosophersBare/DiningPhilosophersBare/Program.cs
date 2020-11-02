using System;
using System.Linq;
using System.Threading;

namespace DiningPhilosophersBare
{
    class Program
    {
        private const int NumPhilosophers = 5;

        private enum Philosopher
        {
            Think,
            Wait,
            Eat
        };

        private static int[] _philosophers;
        private static readonly int[] Forks = new int[NumPhilosophers];

        private static void DoPhilosophy(object id)
        {
            while (true)
            {
                _philosophers[(int) id] = (int) Philosopher.Think;
                Console.WriteLine($"Philosoph {(int) id + 1} denkt.");
                while (Forks[(int) id] != 0)
                    _philosophers[(int) id] = (int) Philosopher.Wait;
                Console.WriteLine(
                    $"Philosoph {(int) id + 1} nimmt linke Gabel.");
                Forks[(int) id] = (int) id;
                while (Forks[((int) id + 1) % NumPhilosophers] != 0)
                    _philosophers[(int) id] = (int) Philosopher.Wait;
                Console.WriteLine(
                    $"Philosoph {(int) id + 1} nimmt rechte Gabel.");
                Forks[((int) id + 1) % NumPhilosophers] = -(int) id;
                Console.WriteLine($"Philosoph {(int) id + 1} isst.");
                _philosophers[(int) id] = (int) Philosopher.Eat;
                Console.WriteLine(
                    $"Philosoph {(int) id + 1} legt linke Gabel zurück.");
                Forks[(int) id] = 0;
                Console.WriteLine(
                    $"Philosoph {(int) id + 1} legt rechte Gabel zurück.");
                Forks[((int) id + 1) % NumPhilosophers] = 0;
            }
        }

        private static void Main(string[] args)
        {
            _philosophers =
                (from i in Enumerable.Range(0, NumPhilosophers)
                    select (int) Philosopher.Wait).ToArray();

            for (var i = 0; i < NumPhilosophers; i++)
            {
                var newThread = new Thread(DoPhilosophy);
                newThread.Start(i);
            }
        }
    }
}