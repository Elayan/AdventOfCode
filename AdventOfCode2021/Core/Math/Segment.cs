using SysMath = System.Math;

namespace AdventOfCode2021.Core.Math
{
    public class Segment
    {
        public Segment(Coord pointA, Coord pointB)
        {
            if (pointA.Y < pointB.Y || pointA.Y == pointB.Y && pointA.X < pointB.X)
            {
                PointA = pointA;
                PointB = pointB;
            }
            else
            {
                PointB = pointA;
                PointA = pointB;
            }
        }

        public Coord PointA { get; }
        public Coord PointB { get; }

        public bool IsRightDiagonal => PointA.Y - PointB.Y == PointA.X - PointB.X;
        public bool IsLeftDiagonal => PointA.Y - PointB.Y == -1 * (PointA.X - PointB.X);
        
        public bool IsHorizontal => PointA.Y == PointB.Y;
        public bool IsVertical => PointA.X == PointB.X;
    }
}