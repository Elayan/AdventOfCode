using System;
using System.Collections.Generic;
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
    }
}