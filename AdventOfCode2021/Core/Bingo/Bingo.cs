using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021.Core.Bingo
{
    public class Bingo
    {
        public List<int> Sequence { get; } = new List<int>();
        public List<Grid> Grids { get; } = new List<Grid>();

        public void Play(bool stopAtFirstWin, out int lastWinningNumber, out int lastWinningScore)
        {
            Reset();
            lastWinningNumber = -1;
            lastWinningScore = -1;

            var previouslyWinningGrids = new List<Grid>();
            foreach (var number in Sequence)
            {
                Grids.ForEach(g => g.Call(number));
                var winningGrids = Grids.Except(previouslyWinningGrids)
                                                  .Where(g => g.IsWinning)
                                                  .ToList();
                if (!winningGrids.Any())
                    continue;

                lastWinningNumber = number;
                lastWinningScore = winningGrids.First().ComputeScore();
                if (stopAtFirstWin)
                    return;

                previouslyWinningGrids.AddRange(winningGrids);
            }
        }

        private void Reset()
        {
            Grids.ForEach(g => g.Reset());
        }
    }
}