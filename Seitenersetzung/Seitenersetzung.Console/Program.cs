using Seitenersetzung.Core;

namespace Seitenersetzung.Console
{
    internal class Program
    {
        private static readonly int[] ReferenceRequests =
        {
            1, 2, 3, 4, 1, 2, 5, 1, 2, 3, 4, 5
        };

        private static readonly int MemorySize = 4;

        private static void Main(string[] args)
        {
            PageReplacementStrategy strategy =
                new Optimal(ReferenceRequests, MemorySize);
            var result = strategy.Simulate();
            var output = new ConsolePresenter().Present(result);
            foreach (var (value, left, top) in output)
            {
                System.Console.SetCursorPosition(left, top);
                System.Console.Write(value);
            }

            /*var latex = new LatexPresenter().Present(result);
            System.Console.WriteLine();
            foreach (var line in latex) System.Console.WriteLine(line);*/
        }
    }
}