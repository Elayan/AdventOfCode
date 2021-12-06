using System;

namespace AdventOfCode2021.Core
{
    public class Instruction
    {
        public Direction Direction { get; set; }
        public int Value { get; set; }

        public void Apply(Location location)
        {
            switch (Direction)
            {
                // "forward X" increases the horizontal position by X units
                case Direction.forward:
                    location.HorizontalPosition += Value;
                    break;
                // "down X" increases the depth by X units.
                case Direction.down:
                    location.Depth += Value;
                    break;
                // "up X" decreases the depth by X units.
                case Direction.up:
                    location.Depth -= Value;
                    break;
                default:
                    throw new NotImplementedException($"No Instruction application defined for Direction {Direction}");
            }
        }
    }
}