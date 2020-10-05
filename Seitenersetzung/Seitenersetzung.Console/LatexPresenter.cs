using System.Collections.Generic;
using System.Linq;

namespace Seitenersetzung.Console
{
    public class LatexPresenter
    {
        public List<string> Present(List<SimulationResult> entity)
        {
            var result = new List<string>();
            var frames = entity.First().Frames.Length;
            for (var i = 0; i < frames; i++)
                result.Add($"\\cellcolor{{hshlmblue}}&Kachel {i + 1}");
            for (var i = 0; i < frames; i++)
                result.Add($"\\cellcolor{{hshlmblue}}&Kachel {i + 1}");
            for (var i = 1; i < entity.Count; i++)
            for (var j = 0; j < frames; j++)
            {
                var frame = entity[i].Frames[j];
                var frameString = frame == int.MaxValue
                    ? "&\\sol{$\\infty$}"
                    : $"&\\sol{{{frame}}}";
                result[j] = result[j] + frameString;
                var frameInformation = entity[i].FrameInformation[j];
                var frameInformationString = frameInformation == int.MaxValue
                    ? "&\\sol{$\\infty$}"
                    : $"&\\sol{{{frameInformation}}}";
                result[j + frames] =
                    result[j + frames] + frameInformationString;
            }

            for (var i = 0; i < frames * 2; i++)
                result[i] = result[i] + "\\tabularnewline";

            return result;
        }
    }
}