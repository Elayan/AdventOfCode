using System.Collections.Generic;

namespace AdventOfCode2021.Core.Display
{
    public class SevenSegmentDisplay
    {
        public SevenSegmentDisplay(List<string> scrambledDigits, List<string> outputs)
        {
            foreach (var signals in scrambledDigits)
                ScambledDigits.Add(new SevenSegmentDigit(signals));
            foreach (var signals in outputs)
                ScrambledOutputs.Add(new SevenSegmentDigit(signals));
        }

        public List<SevenSegmentDigit> ScambledDigits { get; } = new List<SevenSegmentDigit>();
        public List<SevenSegmentDigit> ScrambledOutputs { get; } = new List<SevenSegmentDigit>();
    }
}
