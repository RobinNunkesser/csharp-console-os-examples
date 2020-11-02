using System;
using System.Threading;

namespace Threads
{
    class Program
    {
        private const int NumberOfThreads = 10;

        static void StaticMethod(object threadId)
        {
            Console.WriteLine($"Hello World. Greetings from thread {threadId}");    
        }

        private static void Main(string[] args)
        {
            for (var i = 0; i < NumberOfThreads; i++)
            {
                Console.WriteLine($"Main here. Creating thread {i}");
                var newThread = new Thread(StaticMethod);
                newThread.Start(i);
            }
        }
    }
}
