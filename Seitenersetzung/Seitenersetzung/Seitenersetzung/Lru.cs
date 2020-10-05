namespace Seitenersetzung
{
    public class Lru : BackwardDistanceStrategy
    {
        public Lru(int[] requests, int memorySize) : base(requests, memorySize)
        {
        }

        protected override void UpdateAfterHit(int index, int element)
        {
            UpdateAfterReplacement(index, element);
        }
    }
}