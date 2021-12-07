using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021.Core.Bingo
{
    public class Bingo
    {
        public List<int> Sequence { get; } = new List<int>();
        public List<Grid> Grids { get; } = new List<Grid>();

        public void Play(out int lastNumber, out List<Grid> winningGrids)
        {
            Reset();

            foreach (var number in Sequence)
            {
                lastNumber = number;
                
                Grids.ForEach(g => g.Call(number));
                winningGrids = Grids.Where(g => g.IsWinning).ToList();
                if (winningGrids.Any())
                    return;
            }

            lastNumber = -1;
            winningGrids = null;
        }

        private void Reset()
        {
            Grids.ForEach(g => g.Reset());
        }
    }
}