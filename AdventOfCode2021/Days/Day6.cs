using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode2021.Helpers;

namespace AdventOfCode2021.Days
{
    /// <summary>
    /// https://adventofcode.com/2021/day/6
    /// </summary>
    public class Day6
    {
        public static void SimulateLanternFishes()
        {
            var fishInitialLives = FileReader.ReadIntegerListFromFile("day6");
            var fishFinalLives = SimulateDays(fishInitialLives, 80, 6, 8);
            Console.WriteLine($"[#06a] Lantern Fishes : fishes after 80 days = {fishFinalLives.Count}");
        }

        private static List<int> SimulateDays(int[] initialLives, int simulationDays, int resetCycleValue, int spawnCycleValue)
        {
            var finalLives = new List<int>(initialLives);
            for (var d = 0; d < simulationDays; d++)
            {
                var spawns = new List<int>();
                for (var i = 0; i < finalLives.Count; i++)
                {
                    finalLives[i]--;
                    if (finalLives[i] < 0)
                    {
                        spawns.Add(spawnCycleValue);
                        finalLives[i] = resetCycleValue;
                    }
                }
                finalLives.AddRange(spawns);
            }
            return finalLives;
        }

        public static void SimulateLanternFishes_Grouped()
        {
            var fishInitialLives = FileReader.ReadIntegerListFromFile("day6");
            var fishFinalLives = SimulateDays_Grouped(fishInitialLives, 80, 6, 8);
            Console.WriteLine($"[#06a][control] Lantern Fishes : fishes after 80 days = {fishFinalLives}");
            fishFinalLives = SimulateDays_Grouped(fishInitialLives, 256, 6, 8);
            Console.WriteLine($"[#06b] Lantern Fishes : fishes after 256 days = {fishFinalLives}");
        }

        private static long SimulateDays_Grouped(int[] fishInitialLives, int simulationDays, int resetValue, int spawnValue)
        {
            // compute initial groups
            var groups = new long[spawnValue + 1];
            for (var i = 0; i <= spawnValue; i++)
                groups[i] = fishInitialLives.Count(f => f == i);

            for (var d = 0; d < simulationDays; d++)
            {
                var resultGroups = new long[spawnValue + 1];
                // all fishes with 1+ cycle day just decrease
                for (var l = 1; l <= spawnValue; l++)
                    resultGroups[l - 1] = groups[l];
                // fishes with 0 cycle day produce babies and reset
                resultGroups[spawnValue] = groups[0];
                resultGroups[resetValue] += groups[0];
                // save progress
                groups = resultGroups;
            }

            return groups.Sum();
        }
    }
}