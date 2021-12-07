namespace AdventOfCode2021.Core.Course
{
    public class Location
    {
        public int Depth { get; set; }
        public int HorizontalPosition { get; set; }
        public int Aim { get; set; }
        
        public Location() { }
        public Location(Location copy)
        {
            Depth = copy.Depth;
            HorizontalPosition = copy.HorizontalPosition;
            Aim = copy.Aim;
        }
    }
}