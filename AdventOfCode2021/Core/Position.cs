namespace AdventOfCode2021.Core
{
    public class Location
    {
        public int Depth { get; set; }
        public int HorizontalPosition { get; set; }
        
        public Location() { }
        public Location(Location copy)
        {
            Depth = copy.Depth;
            HorizontalPosition = copy.HorizontalPosition;
        }
    }
}