using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode2021.Helpers;

namespace AdventOfCode2021.Days
{
    /// <summary>
    /// https://adventofcode.com/2021/day/3
    /// </summary>
    public static class Day3
    {
        public static void DecodeBinaryPowerConsumption()
        {
            var binaries = FileReader.ReadBinariesFromFile("day3");
            if (binaries.Length == 0)
                return;

            var gamma = ComputeGamma(binaries);
            // Epsilon could be computed, but it's also simply gamma's reverse
            var epsilon = ReverseBinary(gamma);

            var gammaDec = Convert.ToInt32(gamma, 2);
            var epsilonDec = Convert.ToInt32(epsilon, 2);
            Console.WriteLine($"[#03a] Decode binary power : gamma * epsilon = {gamma} x {epsilon} = {gammaDec} x {epsilonDec} = {gammaDec * epsilonDec}");
        }

        public static void DecodeBinaryLifeSupport()
        {
            var binaries = FileReader.ReadBinariesFromFile("day3");
            if (binaries.Length == 0)
                return;

            var oxygen = ScrapeFilter(binaries, true, '1');
            var co2 = ScrapeFilter(binaries, false, '0');

            var oxygenDec = Convert.ToInt32(oxygen, 2);
            var co2Dec = Convert.ToInt32(co2, 2);
            Console.WriteLine($"[#03b] Decode binary life : oxygen * CO2 = {oxygen} x {co2} = {oxygenDec} x {co2Dec} = {oxygenDec * co2Dec}");
        }

        private static string ReverseBinary(string binary)
        {
            var reverse = new char[binary.Length];
            for (var i = 0; i < reverse.Length; i++)
                reverse[i] = binary[i] == '0' ? '1' : '0';
            return new string(reverse);
        }

        /// <summary>
        /// Gamma rate is computed from a binary set: for each index, the most common value is the one set to gamma at the same index
        /// </summary>
        private static string ComputeGamma(string[] binaries)
        {
            var binaryLength = binaries.First().Length;
            var gamma = new char[binaryLength];
            for (var i = 0; i < binaryLength; i++)
            {
                var ones = binaries.Count(b => b[i] == '1');
                var zeros = binaries.Count(b => b[i] == '0');
                gamma[i] = ones > zeros ? '1' : '0';
            }
            return new string(gamma);
        }

        /// <summary>
        /// Filter by removing all binaries that doesn't match criteria bit by bit, until there's one left.
        /// </summary>
        /// <param name="mostCommonMode">If TRUE, criteria is the most common bit. If FALSE, it's the less common.</param>
        /// <param name="defaultIfEqualCount">Which bit value to use if there's equal count of the two</param>
        private static string ScrapeFilter(string[] binaries, bool mostCommonMode, char defaultIfEqualCount)
        {
            var leftBinaries = new List<string>(binaries);
            var binLength = binaries.First().Length;

            for (var i = 0; i < binLength; i++)
            {
                var ones = leftBinaries.Where(b => b[i] == '1').ToList();
                var zeros = leftBinaries.Where(b => b[i] == '0').ToList();

                if (ones.Count == zeros.Count)
                    leftBinaries = leftBinaries.Where(b => b[i] == defaultIfEqualCount).ToList();
                else if (ones.Count > zeros.Count)
                    leftBinaries = mostCommonMode ? ones : zeros;
                else
                    leftBinaries = mostCommonMode ? zeros : ones;

                if (leftBinaries.Count == 0)
                {
                    Console.WriteLine("No binary left, scraping went wrong!");
                    return null;
                }

                if (leftBinaries.Count == 1)
                    return leftBinaries.First();
            }
            
            if (leftBinaries.Count != 1)
            {
                Console.WriteLine("Scraping ended wrong!");
                return null;
            }

            return leftBinaries.First();
        }
    }
}