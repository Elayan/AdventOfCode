using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021.Core.Bingo
{
    public class Grid
    {
        private readonly Cell[][] _values;

        private int Height => _values?.Length ?? 0;
        private int Width => _values?[0]?.Length ?? 0;

        public bool IsWinning => IsAnyRowWinning() || IsAnyColumnWinning();

        public Grid(int width, int height, int defaultValue)
        {
            _values = new Cell[height][];
            for (var i = 0; i < height; i++)
            {
                _values[i] = new Cell[width];
                for (var j = 0; j < width; j++)
                    _values[i][j] = new Cell { Value = defaultValue };
            }
        }

        public void SetValue(int row, int col, int value)
        {
            _values[row][col].Value = value;
        }

        public void Reset()
        {
            for (var i = 0; i < Height; i++)
                for (var j = 0; j < Width; j++)
                    _values[i][j].Marked = false;
        }

        public void Call(int value)
        {
            for (var i = 0; i < Height; i++)
            {
                for (var j = 0; j < Width; j++)
                {
                    if (_values[i][j].Value == value)
                        _values[i][j].Marked = true;
                }
            }
        }

        private bool IsAnyColumnWinning()
        {
            for (var c = 0; c < Width; c++)
                if (IsColumnWinning(c))
                    return true;
            return false;
        }

        private bool IsColumnWinning(int col)
        {
            for (var r = 0; r < Height; r++)
                if (!_values[r][col].Marked)
                    return false;
            return true;
        }

        private bool IsAnyRowWinning()
        {
            for (var r = 0; r < Height; r++)
                if (IsRowWinning(r))
                    return true;
            return false;
        }

        private bool IsRowWinning(int row)
        {
            for (var c = 0; c < Width; c++)
                if (!_values[row][c].Marked)
                    return false;
            return true;
        }

        public int ComputeScore()
        {
            var unmarkedCells = new List<Cell>();
            for (var r = 0; r < Height; r++)
            for (var c = 0; c < Width; c++)
                if (!_values[r][c].Marked)
                    unmarkedCells.Add(_values[r][c]);

            return unmarkedCells.Sum(c => c.Value);
        }
    }
}