namespace Seitenersetzung.Core
{
    public abstract class ForwardDistanceStrategy : DistanceStrategy
    {
        protected ForwardDistanceStrategy(int[] requests, int memorySize) :
            base(requests, memorySize)
        {
        }

        protected override void UpdateForNewRequest()
        {
            for (var i = 0; i < FrameInformation.Length; i++)
                if (FrameInformation[i] != GetInitialFrameInformationValue())
                    FrameInformation[i]--;
        }
    }
}