using System;
using System.Linq;
using AdventOfCode2021.Core.Math;
using AdventOfCode2021.Helpers;

namespace AdventOfCode2021.Days
{
    public static class Day5
    {
        public static void ComputePartialVenture()
        {
            var segments = FileReader.ReadSegmentsFromFile("day5");
            var grid = CreateGridBigEnoughForSegments(segments);
            var nonDiagonals = segments.Where(s => s.IsHorizontal || s.IsVertical).ToList();
            foreach (var nonDiagonal in nonDiagonals)
                grid.Increment(nonDiagonal);
            var highWindPointCount = grid.CountValuesHigherThan(1);
            Console.WriteLine($"[#05a] Partial Thermal Venture : points with at least two crosswinds = {highWindPointCount}");
        }

        public static void ComputeFullVenture()
        {
            var segments = FileReader.ReadSegmentsFromFile("day5");
            var grid = CreateGridBigEnoughForSegments(segments);
            foreach (var segment in segments)
                grid.Increment(segment);
            var highWindPointCount = grid.CountValuesHigherThan(1);
            Console.WriteLine($"[#05b] Full Thermal Venture : points with at least two crosswinds = {highWindPointCount}");
        }

        private static Grid CreateGridBigEnoughForSegments(Segment[] segments)
        {
            var minX = segments[0].PointA.X;
            var maxX = segments[0].PointA.X;
            var minY = segments[0].PointA.Y;
            var maxY = segments[0].PointA.Y;
            foreach (var segment in segments)
            {
                if (segment.PointA.X < minX)
                    minX = segment.PointA.X;
                if (segment.PointA.X > maxX)
                    maxX = segment.PointA.X;
                if (segment.PointA.Y < minY)
                    minY = segment.PointA.Y;
                if (segment.PointA.Y > maxY)
                    maxY = segment.PointA.Y;
                if (segment.PointB.X < minX)
                    minX = segment.PointB.X;
                if (segment.PointB.X > maxX)
                    maxX = segment.PointB.X;
                if (segment.PointB.Y < minY)
                    minY = segment.PointB.Y;
                if (segment.PointB.Y > maxY)
                    maxY = segment.PointB.Y;
            }
            return new Grid(minX, maxX, minY, maxY);
        }
    }
}