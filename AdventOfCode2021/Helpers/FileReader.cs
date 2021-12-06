using System;
using System.Collections.Generic;
using System.IO;
using JetBrains.Annotations;

namespace AdventOfCode2021.Helpers
{
    public static class FileReader
    {
        [NotNull]
        public static int[] ReadIntegersFromFile([NotNull] string filename)
        {
            var path = $"data/{filename}.txt";
            if (!File.Exists(path))
            {
                Console.WriteLine($"File not found at {path}.");
                return new int[0];
            }

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
    }
}