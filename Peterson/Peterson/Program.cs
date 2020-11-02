using System;
using System.Threading;

namespace Peterson
{
    class Program
    {
        private static int _turn; // Gibt an, wer gerade an der Reihe ist
        private static readonly bool[] Interested = new bool[2];
        private static int _myself;

        private static void Enter_region(int process)
        {
            Console.WriteLine($"Thread {process} wants to enter critical region.");
            var other = 1 - process; // Der andere Prozess
            Interested[process] = true; // Interesse zeigen
            _turn = other; // Flag setzen
            while (Interested[other]  && _turn == other) {
                Console.Write($".{process}");
            }; // Aktives Warten
            Console.WriteLine();
        }

        private static void Leave_region(int process) // Prozess, der die kritische Region verlässt
        {
            Interested[process] = false; // Zeigt den Ausstieg aus dem kritischen Bereich an
        }

        private static void StaticMethod(object threadId)
        {
            Enter_region((int) threadId);
            Console.WriteLine($"Thread {threadId} entered critical region.");
            _myself = (int) threadId;
            Console.WriteLine($"Variable myself should have value {threadId}, actual value is: {_myself}");
            Leave_region((int) threadId);
        }

        private static void Main(string[] args)
        {
            for (var i = 0; i < 2; i++)
            {
                var newThread = new Thread(StaticMethod);
                newThread.Start(i);
            }
        }
    }
}
