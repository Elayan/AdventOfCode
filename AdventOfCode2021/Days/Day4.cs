using System;
using System.Linq;
using AdventOfCode2021.Helpers;

namespace AdventOfCode2021.Days
{
    /// <summary>
    /// https://adventofcode.com/2021/day/4
    /// </summary>
    public static class Day4
    {
        public static void PlayFirstBingo()
        {
            var bingo = FileReader.ReadBingoFromFile("day4");
            if (bingo == null)
                return;

            bingo.Play(true, out var lastNumber, out var firstWinnerScore);
            if (lastNumber == -1)
            {
                Console.WriteLine("Bingo finished with no winner.");
                return;
            }

            Console.WriteLine($"[#04a] First Bingo : last * score = {lastNumber} x {firstWinnerScore} = {lastNumber * firstWinnerScore}");
        }

        public static void PlayLastBingo()
        {
            var bingo = FileReader.ReadBingoFromFile("day4");
            if (bingo == null)
                return;

            bingo.Play(false, out var lastNumber, out var lastWinnerScore);
            if (lastNumber == -1)
            {
                Console.WriteLine("Bingo finished with no winner.");
                return;
            }

            Console.WriteLine($"[#04b] Squid Bingo : last * score = {lastNumber} x {lastWinnerScore} = {lastNumber * lastWinnerScore}");
        }
    }
}