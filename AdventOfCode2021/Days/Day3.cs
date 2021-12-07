using System;
using System.Linq;
using AdventOfCode2021.Helpers;

namespace AdventOfCode2021.Days
{
    /// <summary>
    /// https://adventofcode.com/2021/day/3
    /// </summary>
    public static class Day3
    {
        public static void DecodeBinaryConsumption()
        {
            var binaries = FileReader.ReadBinariesFromFile("day3");
            if (binaries.Length == 0)
                return;

            var gamma = ComputeGamma(binaries);
            // Epsilon could be computed, but it's also simply gamma's reverse
            var epsilon = ReverseBinary(gamma);

            var gammaDec = Convert.ToInt32(gamma, 2);
            var epsilonDec = Convert.ToInt32(epsilon, 2);
            Console.WriteLine($"[03a] Decode binary : gamma * epsilon = {gamma} x {epsilon} = {gammaDec} x {epsilonDec} = {gammaDec * epsilonDec}");
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
    }
}