using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

            // TO TEST: uncomment this and comment following line
            //var shorter = new int[4] { 0, 1, 1, 3 };//crabPositions.Take(2).ToArray();
            //Console.WriteLine($"DEBUG CRABPOS: {string.Join(",", shorter)}");
            //var costByAlignPos = ComputeAlignmentCosts_Gradual(shorter);

            var costByAlignPos = ComputeAlignmentCosts_Gradual(crabPositions);
            var minCost = costByAlignPos.Min(c => c.Value);
            Console.WriteLine($"[#07b] Gradual crab alignment : cheaper move cost = {minCost} (pos {costByAlignPos.First(c => c.Value == minCost).Key})");
        }

        private static Dictionary<int, long> ComputeAlignmentCosts_Gradual(int[] crabPositions)
        {
            var minPos = crabPositions.Min();
            var maxPos = crabPositions.Max();
            var crabCountAtPos = new int[maxPos + 1];
            for (var i = 0; i <= maxPos; i++)
                crabCountAtPos[i] = crabPositions.Count(cp => cp == i);

            //Console.WriteLine($"DEBUG COUNT POS: {string.Join(", ", crabCountAtPos)}");

            var costByAlignPos = new Dictionary<int, long>();
            for (var i = minPos; i <= maxPos; i++)
            {
                //var sb = new StringBuilder($"DEBUG [{i}]:{Environment.NewLine}");
                
                var totalCost = 0;
                for (var j = 0; j <= maxPos; j++)
                {
                    if (j != i && crabCountAtPos[j] != 0)
                    {
                        var cost = crabCountAtPos[j] * SumIntsUpTo(Math.Abs(j - i));
                        totalCost += cost;
                        //sb.Append($"-{j}- cost (x{crabCountAtPos[j]}) = {cost} (TOTAL = {totalCost}){Environment.NewLine}");
                    }
                }

                //Console.WriteLine(sb.ToString());
                costByAlignPos.Add(i, totalCost);
            }

            //Console.WriteLine($"DEBUG COSTS:{Environment.NewLine}{string.Join(Environment.NewLine, costByAlignPos.Select(c => $"[{c.Key}] {c.Value}"))}");
            return costByAlignPos;
        }

        private static int SumIntsUpTo(int value)
        {
            var sum = 0;
            for (var v = value; v > 0; v--)
                sum += v;
            return sum;
        }
    }
}