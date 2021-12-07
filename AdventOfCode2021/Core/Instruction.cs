using System;

namespace AdventOfCode2021.Core
{
    public class Instruction
    {
        public Direction Direction { get; set; }
        public int Value { get; set; }

        public void Apply(Location location, bool useAim = true)
        {
            switch (Direction)
            {
                // == FORWARD X ==
                // Increases the horizontal position by X units
                // With aim, also  increases your depth by your aim multiplied by X
                case Direction.forward:
                    location.HorizontalPosition += Value;
                    if (useAim)
                        location.Depth += location.Aim * Value;
                    break;

                // == DOWN X ==
                // NO AIM:   increases the depth by X units.
                // WITH AIM: increases your aim by X units.
                case Direction.down:
                    if (useAim)
                        location.Aim += Value;
                    else location.Depth += Value;
                    break;

                // == UP X ==
                // NO AIM:   decreases the depth by X units.
                // WITH AIM: decreases your aim by X units.
                case Direction.up:
                    if (useAim)
                        location.Aim -= Value;
                    else location.Depth -= Value;
                    break;

                default:
                    throw new NotImplementedException($"No Instruction application defined for Direction {Direction}");
            }
        }
    }
}