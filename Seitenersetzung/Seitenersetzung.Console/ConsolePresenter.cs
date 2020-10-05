using System.Collections.Generic;
using System.Linq;
using Seitenersetzung.Core;

namespace Seitenersetzung.Console
{
    public class ConsolePresenter
    {
        public List<(string value, int left, int top)> Present(
            List<SimulationResult> entity)
        {
            var result = new List<(string value, int left, int top)>();
            var frames = entity.First().Frames.Length;
            for (var i = 0; i < entity.Count; i++)
            {
                if (i > 0)
                    result.Add((entity[i].Element.ToString(), i * 4 + 1, 1));
                for (var j = 0; j < frames; j++)
                {
                    var frame = entity[i].Frames[j];
                    var frameString =
                        frame == int.MaxValue ? "-" : frame.ToString();
                    result.Add(($"{frameString} |", i * 4 + 1, j + 3));
                    var frameInformation = entity[i].FrameInformation[j];
                    var frameInformationString =
                        frameInformation == int.MaxValue
                            ? "-"
                            : frameInformation.ToString();
                    result.Add(($"{frameInformationString} |", i * 4 + 1,
                        j + frames + 4));
                }

                var additionalInformation = entity[i].AdditionalInfo;
                if (additionalInformation != null)
                    result.Add(($"{additionalInformation} |", i * 4 + 1,
                        frames * 2 + 5));
            }

            result.Add(($"Einlagerungen: {entity.Last().Count}", 0,
                frames * 2 + 7));

            return result;
        }
    }
}