using System;
using System.Threading;

namespace ProducerConsumerLock
{
    class Program
    {
        private const int Steps = 1000;
        private const int Capacity = 100;
        private static int _count = 50;
        private static int _step;

        static readonly object _locker = new object();


        private static readonly AutoResetEvent Production =
            new AutoResetEvent(false);

        private static readonly AutoResetEvent Consumption =
            new AutoResetEvent(false);

        private static void Producer()
        {
            while (_step < Steps - 1)
            {
                lock (_locker)
                {
                    if (_count < Capacity)
                    {
                        Console.WriteLine(
                            $"Step {++_step}: Producing one item, {++_count} items in buffer.");
                        Console.Out.Flush();
                        Production.Set();
                    }
                }

                if (_count == Capacity) Consumption.WaitOne();
            }
        }

        private static void Consumer()
        {
            while (_step < Steps - 1)
            {
                lock (_locker)
                {
                    if (_count > 0)
                    {
                        Console.WriteLine(
                            $"Step {++_step}: Consuming one item, {--_count} items in buffer.");
                        Console.Out.Flush();
                        Consumption.Set();
                    }
                }

                if (_count == 0) Production.WaitOne();
            }
        }

        static void Main(string[] args)
        {
            var producer = new Thread(Producer);
            var consumer = new Thread(Consumer);
            producer.Start();
            consumer.Start();
        }
    }
}