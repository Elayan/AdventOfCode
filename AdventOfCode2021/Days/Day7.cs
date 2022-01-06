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
        public static void AlignCrabs_Linear()
        {
            var crabPositions = FileReader.ReadIntegerListFromFile("day7");
            var costByAlignPos = ComputeAlignmentCosts_Linear(crabPositions);
            Console.WriteLine($"[#07a] Linear crab alignment : cheaper move cost = {costByAlignPos.Values.Min()}");
        }

        private static Dictionary<int, int> ComputeAlignmentCosts_Linear(int[] crabPositions)
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

        public static void AlignCrabs_Gradual()
        {
            var crabPositions = FileReader.ReadIntegerListFromFile("day7");
            var costByAlignPos = ComputeAlignmentCosts_Gradual(crabPositions);
            Console.WriteLine($"[#07b] Gradual crab alignment : cheaper move cost = {costByAlignPos.Min(c => c.Value)}");
        }

        private static Dictionary<int, long> ComputeAlignmentCosts_Gradual(int[] crabPositions)
        {
            var minPos = crabPositions.Min();
            var maxPos = crabPositions.Max();
            var crabCountAtPos = new int[maxPos + 1];
            for (var i = 0; i <= maxPos; i++)
                crabCountAtPos[i] = crabPositions.Count(cp => cp == i);

            var costByAlignPos = new Dictionary<int, long>();
            for (var i = minPos; i <= maxPos; i++)
            {                
                long totalCost = 0;
                for (var j = 0; j <= maxPos; j++)
                {
                    if (j != i && crabCountAtPos[j] != 0)
                    {
                        var cost = crabCountAtPos[j] * SumIntsUpTo(Math.Abs(j - i));
                        totalCost += cost;
                    }
                }

                costByAlignPos.Add(i, totalCost);
            }

            return costByAlignPos;
        }

        private static long SumIntsUpTo(int value)
        {
            long sum = 0;
            for (var v = value; v > 0; v--)
                sum += v;
            return sum;
        }
    }
}