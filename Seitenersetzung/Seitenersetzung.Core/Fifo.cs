namespace Seitenersetzung.Core
{
    public class Fifo : BackwardDistanceStrategy
    {
        public Fifo(int[] requests, int memorySize) : base(requests, memorySize)
        {
        }
    }
}