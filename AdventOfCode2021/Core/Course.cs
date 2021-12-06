using System.Collections.Generic;
using JetBrains.Annotations;

namespace AdventOfCode2021.Core
{
    public class Course
    {
        public List<Instruction> Instructions { get; } = new List<Instruction>();

        [NotNull, Pure]
        public Location SimulateCourse([NotNull] Location start)
        {
            var finish = new Location(start);
            foreach (var instruction in Instructions)
                instruction.Apply(finish);
            return finish;
        }
    }
}