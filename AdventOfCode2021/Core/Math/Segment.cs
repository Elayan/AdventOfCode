namespace AdventOfCode2021.Core.Math
{
    public class Segment
    {
        public Coord PointA { get; set; }
        public Coord PointB { get; set; }

        public bool IsDiagonal => PointA.X != PointB.X && PointA.Y != PointB.Y;
        public bool IsHorizontal => PointA.Y == PointB.Y;
        public bool IsVertical => PointA.X == PointB.X;
    }
}