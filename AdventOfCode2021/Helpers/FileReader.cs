using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode2021.Core;
using JetBrains.Annotations;

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