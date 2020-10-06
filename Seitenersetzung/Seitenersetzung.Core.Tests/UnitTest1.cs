using System.Linq;
using NUnit.Framework;

namespace Seitenersetzung.Core.Tests
{
    public class Tests
    {
        private readonly int[] ReferenceRequests =
{
            1, 2, 3, 4, 1, 2, 5, 1, 2, 3, 4, 5
        };

        private readonly int MemorySize = 3;


        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestOptimal()
        {
            var strategy = new Optimal(ReferenceRequests, MemorySize);
            var result = strategy.Simulate();
            Assert.AreEqual(7, result.Last().Count);
        }

        [Test]
        public void TestLRU()
        {
            var strategy = new Lru(ReferenceRequests, MemorySize);
            var result = strategy.Simulate();
            Assert.AreEqual(10, result.Last().Count);
        }

        [Test]
        public void TestFIFO()
        {
            var strategy = new Fifo(ReferenceRequests, MemorySize);
            var result = strategy.Simulate();
            Assert.AreEqual(9, result.Last().Count);
        }

        [Test]
        public void TestClock()
        {
            var strategy = new Clock(ReferenceRequests, MemorySize);
            var result = strategy.Simulate();
            Assert.AreEqual(10, result.Last().Count);
        }

    }
}