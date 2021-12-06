using System;
using AdventOfCode2021.Helpers;

namespace AdventOfCode2021.Days
{
    public static class Day1
    {
        public static void SonarSweep()
        {
            var scan = FileReader.ReadIntegersFromFile("day1");

            var increaseCounter = 0;
            for (var i = 0; i < scan.Length - 1; i++)
            {
                if (scan[i + 1] > scan[i])
                    increaseCounter++;
            }

            Console.WriteLine($"[#01a] Sonar Sweep - Increase count = {increaseCounter}");
        }
    }
}