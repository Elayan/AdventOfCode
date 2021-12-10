using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode2021.Core.Bingo;
using AdventOfCode2021.Core.Course;
using AdventOfCode2021.Core.Math;
using JetBrains.Annotations;
using Grid = AdventOfCode2021.Core.Bingo.Grid;

namespace AdventOfCode2021.Helpers
{
    public static class FileReader
    {
        [NotNull]
        public static int[] ReadIntegersFromFile([NotNull] string filename)
        {
            if (!Validate(filename, out var path))
                return new int[0];
            
            var ints = new List<int>();
            using (var sr = new StreamReader(path))
            {
                while (sr.Peek() >= 0)
                {
                    var line = sr.ReadLine();
                    if (!int.TryParse(line, out var parsed))
                    {
                        Console.WriteLine($"Line '{line}' could not be parsed as int.");
                        return new int[0];
                    }
                    
                    ints.Add(parsed);
                }
            }

            return ints.ToArray();
        }

        [NotNull]
        public static int[] ReadIntegerListFromFile([NotNull] string filename)
        {
            if (!Validate(filename, out var path))
                return new int[0];

            using (var sr = new StreamReader(path))
            {
                var line = sr.ReadLine();
                if (line == null)
                {
                    Console.WriteLine("Empty line couldn't be read as int list.");
                    return null;
                }

                return line.Split(',').Select(int.Parse).ToArray();
            }
        }

        [NotNull]
        public static string[] ReadStringsFromFile([NotNull] string filename)
        {
            if (!Validate(filename, out var path))
                return new string[0];

            var strings = new List<string>();
            using (var sr = new StreamReader(path))
            {
                while (sr.Peek() >= 0)
                {
                    strings.Add(sr.ReadLine());
                }
            }

            return strings.ToArray();
        }

        [NotNull]
        public static string[] ReadBinariesFromFile([NotNull] string filename)
        {
            var strings = ReadStringsFromFile(filename);

            foreach (var str in strings)
            {
                // if it contains anything else but 0 and 1, then it's not a binary
                if (str.Except("0").Except("1").Any())
                {
                    Console.WriteLine($"Line '{str}' couldn't be read as binary.");
                    return new string[0];
                }
            }

            return strings;
        }

        [CanBeNull]
        public static Course ReadCourseFromFile([NotNull] string filename)
        {
            if (!Validate(filename, out var path))
                return null;

            var course = new Course();
            using (var sr = new StreamReader(path))
            {
                while (sr.Peek() >= 0)
                {
                    var line = sr.ReadLine();
                    if (line == null)
                    {
                        Console.WriteLine("Empty line couldn't be read as Instruction.");
                        return null;
                    }
                    
                    var parts = line.Split(' ');
                    if (parts.Length != 2)
                    {
                        Console.WriteLine($"Line '{line}' requires exactly two parts to be read as Instruction (found {parts.Length}).");
                        return null;
                    }

                    if (!Enum.TryParse<Direction>(parts[0], out var direction))
                    {
                        Console.WriteLine($"Part '{parts[0]}' couldn't be read as Direction.");
                        return null;
                    }

                    if (!int.TryParse(parts[1], out var value))
                    {
                        Console.WriteLine($"Part '{parts[1]}' couldn't be read as int.");
                        return null;
                    }

                    course.Instructions.Add(new Instruction
                                            {
                                                Direction = direction,
                                                Value = value
                                            });
                }
            }
            return course;
        }

        public static Bingo ReadBingoFromFile(string filename)
        {
            if (!Validate(filename, out var path))
                return null;

            var bingo = new Bingo();
            using (var sr = new StreamReader(path))
            {
                // first line is the sequence
                var line = sr.ReadLine();
                if (line == null)
                {
                    Console.WriteLine("First line couldn't be read.");
                    return null;
                }

                var strSequence = line.Split(',');
                if (strSequence.Length == 0)
                {
                    Console.WriteLine("Bingo's sequence contains no value.");
                    return null;
                }

                bingo.Sequence.AddRange(strSequence.Select(int.Parse));

                // skip this line
                sr.ReadLine();

                // following lines are grids
                while (sr.Peek() >= 0)
                {
                    var gridParts = new List<List<int>>();
                    line = sr.ReadLine();
                    while (!string.IsNullOrEmpty(line))
                    {
                        var parts = line.Split(' ').Where(s => s.Length > 0).Select(int.Parse);
                        gridParts.Add(new List<int>(parts));
                        line = sr.ReadLine();
                    }

                    var size = gridParts.Count;
                    var grid = new Grid(size, size, 0);
                    for (var r = 0; r < size; r++)
                        for (var c = 0; c < size; c++)
                            grid.SetValue(r, c, gridParts[r][c]);
                    bingo.Grids.Add(grid);
                }

                return bingo;
            }
        }

        public static Segment[] ReadSegmentsFromFile(string filename)
        {
            if (!Validate(filename, out var path))
                return new Segment[0];

            var segments = new List<Segment>();
            using (var sr = new StreamReader(path))
            {
                while (sr.Peek() >= 0)
                {
                    var line = sr.ReadLine();
                    if (string.IsNullOrEmpty(line))
                    {
                        Console.WriteLine("Failed reading segments.");
                        return new Segment[0];
                    }

                    var points = line.Split(' ');
                    if (points.Length != 3)
                    {
                        Console.WriteLine($"Line '{line}' couldn't be read as 'point -> point'.");
                        return new Segment[0];
                    }

                    var xCoords = points[0].Split(',');
                    var yCoords = points[2].Split(',');
                    if (xCoords.Length != 2 || yCoords.Length != 2)
                    {
                        Console.WriteLine($"Line '{line}' couldn't be read as 'point -> point'.");
                        return new Segment[0];
                    }

                    segments.Add(new Segment
                    (
                        new Coord
                        {
                            X = int.Parse(xCoords[0]),
                            Y = int.Parse(xCoords[1])
                        },
                        new Coord
                        {
                            X = int.Parse(yCoords[0]),
                            Y = int.Parse(yCoords[1])
                        }
                    ));
                }

                return segments.ToArray();
            }
        }

        private static bool Validate(string filename, out string path)
        {
            path = $"data/{filename}.txt";
            if (File.Exists(path))
                return true;

            Console.WriteLine($"File not found at {path}.");
            return false;
        }
    }
}