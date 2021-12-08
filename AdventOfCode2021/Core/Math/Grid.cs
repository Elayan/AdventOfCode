using System;

namespace AdventOfCode2021.Core.Math
{
    public class Grid
    {
        private int MinX { get; }
        private int MaxX { get; }
        private int Width => MaxX - MinX + 1;

        private int MinY { get; }
        private int MaxY { get; }
        private int Height => MaxY - MinY + 1;

        private readonly int[][] _values;

        public Grid(int minX, int maxX, int minY, int maxY, int defaultValue = 0)
        {
            MinX = minX;
            MaxX = maxX;
            MinY = minY;
            MaxY = maxY;

            _values = new int[Height][];
            for (var i = 0; i < Height; i++)
            {
                _values[i] = new int[Width];
                for (var j = 0; j < Width; j++)
                    _values[i][j] = defaultValue;
            }
        }

        private int Get(int x, int y)
        {
            return _values[y - MinY][x - MinX];
        }

        private void Set(int x, int y, int value)
        {
            _values[y - MinY][x - MinX] = value;
        }

        public void Increment(Segment segment)
        {
            if (segment.IsVertical)
            {
                var ya = segment.PointA.Y;
                var yb = segment.PointB.Y;
                if (ya < yb)
                {
                    for(var y = ya; y <= yb; y++)
                        Increment(segment.PointA.X, y);
                }
                else
                {
                    for(var y = yb; y <= ya; y++)
                        Increment(segment.PointA.X, y);
                }
            }
            else if (segment.IsHorizontal)
            {
                var xa = segment.PointA.X;
                var xb = segment.PointB.X;
                if (xa < xb)
                {
                    for(var x = xa; x <= xb; x++)
                        Increment(x, segment.PointA.Y);
                }
                else
                {
                    for(var x = xb; x <= xa; x++)
                        Increment(x, segment.PointA.Y);
                }
            }
            else throw new NotImplementedException("I don't know how to draw a diagonal segment.");
        }

        private void Increment(int x, int y)
        {
            _values[y - MinY][x - MinX]++;
        }

        public int CountValuesHigherThan(int value)
        {
            var count = 0;
            for (var i = 0; i < Height; i++)
            {
                for (var j = 0; j < Width; j++)
                {
                    if (_values[i][j] > value)
                        count++;
                }
            }
            return count;
        }
    }
}