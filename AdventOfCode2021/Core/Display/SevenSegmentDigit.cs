using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021.Core.Display
{
    public class SevenSegmentDigit
    {
        public SevenSegmentDigit(string signals)
        {
            foreach (char c in signals)
                Segments[c] = true;
        }

        public Dictionary<char, bool> Segments { get; } = new Dictionary<char, bool>()
                                                          {
                                                            { 'a', false },
                                                            { 'b', false },
                                                            { 'c', false },
                                                            { 'd', false },
                                                            { 'e', false },
                                                            { 'f', false },
                                                            { 'g', false },
                                                          };

        public List<char> VisibleSegments => Segments.Where(s => s.Value).Select(s => s.Key).ToList();
        public int VisibleSegmentCount => Segments.Count(s => s.Value);

        public override string ToString()
        {
            return string.Join("", Segments.Where(s => s.Value).Select(s => s.Key));
        }

        public override bool Equals(object obj)
        {
            var other = obj as SevenSegmentDigit;
            if (other == null)
                return false;

            var visibles = VisibleSegments;
            var otherVisibles = other.VisibleSegments;
            if (visibles.Count != otherVisibles.Count)
                return false;

            for (int i = 0; i < visibles.Count; i++)
                if (otherVisibles[i] != visibles[i])
                    return false;

            return true;
        }
    }
}
