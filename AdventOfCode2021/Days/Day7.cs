using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode2021.Helpers;

namespace AdventOfCode2021.Days
{
    /// <summary>
    /// https://adventofcode.com/2021/day/7
    /// </summary>
    public static class Day7
    {
        public static void AlignCrabs()
        {
            var crabPositions = FileReader.ReadIntegerListFromFile("day7");
            var costByAlignPos = ComputeAllAlignmentCosts(crabPositions);
            Console.WriteLine($"[#07a] Crabs alignment : cheaper move cost = {costByAlignPos.Values.Min()}.");
        }

        private static Dictionary<int, int> ComputeAllAlignmentCosts(int[] crabPositions)
        {
            var maxPos = crabPositions.Max();
            var crabCountAtPos = new int[maxPos + 1];
            for (var i = 0; i <= maxPos; i++)
                crabCountAtPos[i] = crabPositions.Count(cp => cp == i);

            var costByAlignPos = new Dictionary<int, int>();
            for (var i = 0; i <= maxPos; i++)
            {
                if (crabCountAtPos[i] == 0)
                    continue;

                var totalCost = 0;
                for (var j = 0; j <= maxPos; j++)
                    totalCost += crabCountAtPos[j] * Math.Abs(j - i);
                
                costByAlignPos.Add(i, totalCost);
            }

            return costByAlignPos;
        }
    }
}