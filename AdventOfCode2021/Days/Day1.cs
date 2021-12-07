using System;
using System.Collections.Generic;
using AdventOfCode2021.Helpers;
using JetBrains.Annotations;

namespace AdventOfCode2021.Days
{
    /// <summary>
    /// https://adventofcode.com/2021/day/1
    /// </summary>
    public static class Day1
    {
        public static void SonarSweep()
        {
            var scan = FileReader.ReadIntegersFromFile("day1");
            Console.WriteLine($"[#01a] Sonar Sweep - Increase count = {CountIncreases(scan)}");
        }

        public static void SonarSweep_Windowed()
        {
            var scan = FileReader.ReadIntegersFromFile("day1");
            var windowedScan = PerformWindow(scan);
            Console.WriteLine($"[#01b] Windowed Sonar Sweep - Increase count = {CountIncreases(windowedScan)}");
        }

        private static int CountIncreases(int[] scan)
        {
            var increaseCounter = 0;

            for (var i = 0; i < scan.Length - 1; i++)
            {
                if (scan[i + 1] > scan[i])
                    increaseCounter++;
            }

            return increaseCounter;
        }

        private static int[] PerformWindow([NotNull] int[] scan)
        {
            var windowingScan = new List<int>();
            for (var i = 0; i < scan.Length - 2; i++)
                windowingScan.Add(scan[i] + scan[i + 1] + scan[i + 2]);
            return windowingScan.ToArray();
        }
    }
}