using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2021.Core.Display
{
    public class SevenSegmentDisplay
    {
        public SevenSegmentDisplay(List<string> scrambledDigits, List<string> outputs)
        {
            foreach (var signals in scrambledDigits)
                ScrambledDigits.Add(new SevenSegmentDigit(signals));
            foreach (var signals in outputs)
                Outputs.Add(new SevenSegmentDigit(signals));
        }

        public List<SevenSegmentDigit> ScrambledDigits { get; } = new List<SevenSegmentDigit>();
        public Dictionary<int, SevenSegmentDigit> Digits { get; } = new Dictionary<int, SevenSegmentDigit>();

        public List<SevenSegmentDigit> Outputs { get; } = new List<SevenSegmentDigit>();

        public override string ToString()
        {
            var sb = new StringBuilder();
            if (Digits.Count < 10)
                sb.Append(string.Join(" ", ScrambledDigits));
            else sb.Append(string.Join(" ", Digits.OrderBy(d => d.Key).Select(d => $"[{d.Key}]{d.Value}")));

            sb.Append(" | ");
            sb.Append(string.Join(" ", Outputs));
            return sb.ToString();
        }

        public void Unscramble()
        {
            // we can easily find 1, 4, 7 and 8
            Digits.Add(1, ScrambledDigits.First(d => d.VisibleSegmentCount == 2));
            Digits.Add(4, ScrambledDigits.First(d => d.VisibleSegmentCount == 4));
            Digits.Add(7, ScrambledDigits.First(d => d.VisibleSegmentCount == 3));
            Digits.Add(8, ScrambledDigits.First(d => d.VisibleSegmentCount == 7));

            // 2,3,5 have 5 signals
            var fives = ScrambledDigits.Where(d => d.VisibleSegmentCount == 5).ToList();
            // 3 has both 1's signals
            Digits.Add(3, fives.First(d => d.VisibleSegments.Intersect(Digits[1].VisibleSegments).Count() == 2));
            fives.Remove(Digits[3]);

            // 0,6,9 have 6 signals
            var sixes = ScrambledDigits.Where(d => d.VisibleSegmentCount == 6).ToList();
            // 9 contains all 4's signals
            Digits.Add(9, sixes.First(d => d.VisibleSegments.Intersect(Digits[4].VisibleSegments).Count() == 4));
            sixes.Remove(Digits[9]);
            // 0 contains all 7's signals
            Digits.Add(0, sixes.First(d => d.VisibleSegments.Intersect(Digits[7].VisibleSegments).Count() == 3));
            sixes.Remove(Digits[0]);
            // 6 is the remaining with 6 signals
            Digits.Add(6, sixes.First());

            // 9 contains all 5's signals
            Digits.Add(5, fives.First(d => d.VisibleSegments.Intersect(Digits[9].VisibleSegments).Count() == 5));
            fives.Remove(Digits[5]);
            // 2 is the remaining with 5 signals
            Digits.Add(2, fives.First());
        }

        public int DecodeOutput()
        {
            if (Digits.Count < 10)
            {
                Console.WriteLine($"Impossible to decode without unscrambling digits first! (unscrambled digits count = {Digits.Count})");
                return -1;
            }

            int decodedOutput = 0;
            foreach(var output in Outputs)
            {
                var decoded = Digits.First(d => d.Value.Equals(output)).Key;
                decodedOutput = decodedOutput * 10 + decoded;
            }

            return decodedOutput;
        }
    }
}
