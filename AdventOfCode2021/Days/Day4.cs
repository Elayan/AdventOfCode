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
        public static void PlayBingo()
        {
            var bingo = FileReader.ReadBingoFromFile("day4");
            if (bingo == null)
                return;

            bingo.Play(out var lastNumber, out var winners);
            if (lastNumber == -1)
            {
                Console.WriteLine("Bingo finished with no winner.");
                return;
            }

            if (winners.Count != 1)
            {
                Console.WriteLine($"Found {winners.Count} winner(s), ONE expected!");
                return;
            }

            var winner = winners.First();
            var score = winner.ComputeScore();
            Console.WriteLine($"[#04a] Squid Bingo : last * score = {lastNumber} x {score} = {lastNumber * score}");
        }
    }
}